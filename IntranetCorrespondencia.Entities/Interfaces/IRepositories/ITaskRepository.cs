using IntranetCorrespondencia.Entities.POCOs;

namespace IntranetCorrespondencia.Entities.Interfaces
{
    public interface ITaskRepository
    {
        POCOs.Task CreateTask(POCOs.Task task);
        IEnumerable<POCOs.Task> GetTasks();
    }
}
