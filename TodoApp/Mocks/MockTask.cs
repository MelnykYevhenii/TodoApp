using TodoApp.db;
using TodoApp.Interfaces;
using TodoApp.Models;

namespace TodoApp.Mocks
{
    public class MockTask : ITask
    {
        public IEnumerable<Exercise> GetAllTasks
        {
            get
            {
                return new List<Exercise>
                {
                    new Exercise { TaskDescription = "TaskDescription", TaskStatus = "TaskStatus" }
                };
            }
        }

        public void CreateTask(Exercise exercise)
        {
            throw new NotImplementedException();
        }

        public void DeleteTask(int taskId)
        {
            throw new NotImplementedException();
        }
    }
}
