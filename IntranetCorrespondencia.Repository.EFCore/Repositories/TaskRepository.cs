using IntranetCorrespondencia.Entities.Interfaces;
using IntranetCorrespondencia.Entities.POCOs;
using IntranetCorrespondencia.Repository.EFCore.DBContext;

namespace IntranetCorrespondencia.Repository.EFCore.Repositories
{
    public class TaskRepository : ITaskRepository
    {

        readonly IntranetCorrespondenciaContext Context;

        public TaskRepository(IntranetCorrespondenciaContext context)
        {
            Context = context;
        }

        public Entities.POCOs.Task CreateTask(Entities.POCOs.Task task)
        {
            Context.Tasks.Add(task);
            Context.SaveChanges();
            return task;
        }

        public IEnumerable<Entities.POCOs.Task> GetTasks()
        {
            return Context.Tasks;
        }
    }
}
