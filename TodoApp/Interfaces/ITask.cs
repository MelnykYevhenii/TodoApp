using TodoApp.Models;

namespace TodoApp.Interfaces
{
    public interface ITask
    {
        IEnumerable<Exercise> GetAllTasks { get; }
        void CreateTask(Exercise exercise);
        void DeleteTask(int taskId);
    }
}
