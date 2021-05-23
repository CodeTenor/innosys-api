using innosys_application.IContracts;
using innosys_application.Models.Request;
using innosys_application.Models.Response;
using innosys_application.Services;
using innosys_domain;
using innosys_infastructure;
using innosys_infastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace innosys_application.Contracts
{
    public class ActivityContract : IActivityContract
    {
        private readonly IRepository<Activity> _activityRepository;
        private readonly IDbContext _context;
        private readonly IDateService _dateService;

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

        public ActivityResponseModel GetActivityById(Guid activityId)
        {
            string[] includeParamsInFilterResult = new string[1] { "Task" };

            Activity activity = _activityRepository.GetById(activityId, includeParamsInFilterResult);

            if (activity == null)
            {
                return null;
            }

            return new ActivityResponseModel(activity);
        }

        public List<ActivityResponseModel> GetAllActivities()
        {
            string[] includeParamsInFilterResult = new string[1] { "Task" };

            List<Activity> activities = _activityRepository.GetAll(includeParamsInFilterResult).ToList();

            return activities.Select(x =>  new ActivityResponseModel(x)).ToList();
        }
    }
}
