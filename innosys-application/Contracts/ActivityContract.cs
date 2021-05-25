using innosys_application.IContracts;
using innosys_application.Models.Request;
using innosys_application.Models.Response;
using innosys_application.Services;
using innosys_domain;
using innosys_infastructure;
using innosys_infastructure.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace innosys_application.Contracts
{
    public class ActivityContract : IActivityContract
    {
        private readonly IRepository<Activity> _activityRepository;
        private readonly IDbContext _context;
        private readonly IDateService _dateService;
        public readonly string BIN_FOLDER_LOCATION = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        public ActivityContract(IRepository<Activity> activityRepository,
                                IDbContext context,
                                IDateService dateService)
        {
            _activityRepository = activityRepository;
            _context = context;
            _dateService = dateService;
        }

        public List<ActivityResponseModel> AddActivites(List<ActivityRequestModel> requestModel)
        {
            List<Activity> activies = new List<Activity>();

            foreach (var request in requestModel)
            {
                DateTime startDate = _dateService.StringToDateTime(request.StartDate);

                DateTime dueDate = _dateService.CaluclateBusinessDueDate(startDate, Int32.Parse(request.Duration));

                Activity activity = new Activity(Int32.Parse(request.Id),
                                                 request.Description.Trim('\''),
                                                 request.Client.Trim('\''),
                                                 startDate,
                                                 dueDate,
                                                 Int32.Parse(request.Duration));

                List<Task> tasks = new List<Task>();

                if (request.Task1.Trim('\'') != "")
                {
                    tasks.Add(new Task(activity, request.Task1.Trim('\'')));
                }

                if (request.Task2.Trim('\'') != "")
                {
                    tasks.Add(new Task(activity, request.Task2.Trim('\'')));
                }

                if (request.Task3.Trim('\'') != "")
                {
                    tasks.Add(new Task(activity, request.Task3.Trim('\'')));
                }

                if (request.Task4.Trim('\'') != "")
                {
                    tasks.Add(new Task(activity, request.Task4.Trim('\'')));
                }

                if (request.Task5.Trim('\'') != "")
                {
                    tasks.Add(new Task(activity, request.Task5.Trim('\'')));
                }

                activity.AddTasks(tasks);

                activies.Add(activity);

                _activityRepository.Add(activity);

            }

           _context.SaveChanges();

            return activies.Select(x => new ActivityResponseModel(x)).ToList();
        }

        public string ExportSQLScript()
        {
            string sqlString = File.ReadAllText(Path.Combine(BIN_FOLDER_LOCATION, @"Template\sql-script.sql"));

            string[] includeParamsInFilterResult = new string[1] { "Tasks" };

            List<Activity> activities = _activityRepository.GetAll(includeParamsInFilterResult).ToList();

            string insertActivity = "";

            string insertTask = "";

            foreach (var activity in activities)
            {
                if (insertActivity == "")
                {
                    insertActivity =  $"INSERT [dbo].[Activity] ([Id], [ActivityId], [Description], [Client], [StartDate], [DueDate], [Duration], [CreatedDate], [ModifiedDate]) VALUES (N'{activity.Id}', {activity.ActivityId}, N'{activity.Description}', N'{activity.Client}', CAST(N'{activity.StartDate}' AS DateTime2), CAST(N'{activity.DueDate}' AS DateTime2), {activity.Duration}, CAST(N'{activity.CreatedDate}' AS DateTime2), CAST(N'{activity.ModifiedDate}' AS DateTime2))\n";
                }
                else
                {
                    insertActivity = $"{insertActivity}INSERT [dbo].[Activity] ([Id], [ActivityId], [Description], [Client], [StartDate], [DueDate], [Duration], [CreatedDate], [ModifiedDate]) VALUES (N'{activity.Id}', {activity.ActivityId}, N'{activity.Description}', N'{activity.Client}', CAST(N'{activity.StartDate}' AS DateTime2), CAST(N'{activity.DueDate}' AS DateTime2), {activity.Duration}, CAST(N'{activity.CreatedDate}' AS DateTime2), CAST(N'{activity.ModifiedDate}' AS DateTime2))\n";
                }

                foreach (var task in activity.Tasks)
                {
                    string completedDate = task.CompletedDate == null ? "NULL" : $"CAST(N'{task.CompletedDate}' AS DateTime2)";

                    if (insertTask == "")
                    {
                        insertTask = $"INSERT [dbo].[Task] ([Id], [ActivityId], [Description], [Status], [CompletedDate], [CreatedDate], [ModifiedDate]) VALUES (N'{task.Id}', N'{activity.Id}', N'{task.Description}', {task.Status}, {completedDate}, CAST(N'{task.CreatedDate}' AS DateTime2), CAST(N'{task.ModifiedDate}' AS DateTime2))\n";
                    }
                    else
                    {
                        insertTask = $"{insertTask}INSERT [dbo].[Task] ([Id], [ActivityId], [Description], [Status], [CompletedDate], [CreatedDate], [ModifiedDate]) VALUES (N'{task.Id}', N'{activity.Id}', N'{task.Description}', {task.Status}, {completedDate}, CAST(N'{task.CreatedDate}' AS DateTime2), CAST(N'{task.ModifiedDate}' AS DateTime2))\n";
                    }
                }
            }

            sqlString = sqlString.Replace("##ACTIVITY##", insertActivity, ignoreCase: false, culture: null);

            sqlString = sqlString.Replace("##TASK##", insertTask, ignoreCase: false, culture: null);

            return sqlString;
        }

        public ActivityResponseModel GetActivityById(Guid activityId)
        {
            string[] includeParamsInFilterResult = new string[1] { "Tasks" };

            Activity activity = _activityRepository.GetById(activityId, includeParamsInFilterResult);

            if (activity == null)
            {
                return null;
            }

            return new ActivityResponseModel(activity);
        }

        public List<ActivityResponseModel> GetAllActivities()
        {
            string[] includeParamsInFilterResult = new string[1] { "Tasks" };

            List<Activity> activities = _activityRepository.GetAll(includeParamsInFilterResult).ToList();

            return activities.Select(x =>  new ActivityResponseModel(x)).ToList();
        }
    }
}
