using TodoApp.Models;

namespace TodoApp.ViewModels
{
    public class TaskViewModel
    {
        public IEnumerable<Exercise> AllTasks { get; set; }
        public string? TaskDescription { get; set; }
    }
}
