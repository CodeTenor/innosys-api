using innosys_application.IContracts;
using innosys_application.Models.Response;
using innosys_domain;
using innosys_infastructure;
using innosys_infastructure.Repository;
using System;

namespace innosys_application.Contracts
{
    public class TaskContract : ITaskContract
    {
        private readonly IRepository<Task> _taskRepository;
        private readonly IDbContext _context;

        public TaskContract(IRepository<Task> taskRepository, IDbContext context)
        {
            _taskRepository = taskRepository;
            _context = context;
        }

        public TaskResponseModel CompleteTask(Guid taskId)
        {
            Task task = _taskRepository.GetById(taskId);

            if (task == null)
            {
                throw new Exception($"task with id :{taskId} does not exist");
            }

            task.CompleteTask();

            _context.SaveChanges();

            return new TaskResponseModel(task);
        }
    }
}
