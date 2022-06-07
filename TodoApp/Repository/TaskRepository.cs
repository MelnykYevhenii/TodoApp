using Microsoft.EntityFrameworkCore;
using TodoApp.db;
using TodoApp.Models;
using TodoApp.Interfaces;
using Microsoft.Data.SqlClient;

namespace TodoApp.Repository
{
    public class TaskRepository : ITask
    {
        private readonly AppDBContext _context;
        public TaskRepository(AppDBContext appDbContext)
        {
            this._context = appDbContext;
        }
        public IEnumerable<Exercise> GetAllTasks => _context.TodoTask.Where(t => t.Id != 0);
        public void CreateTask(Exercise exercise)
        {
            var task = new Exercise()
            {
                TaskDescription = exercise.TaskDescription,
                TaskStatus = "In progress",
            };

            _context.TodoTask.Add(task);
            _context.SaveChanges();
        }
        public void DeleteTask(int exerciseID)
        {
            //_context.TodoTask.Remove(_context.TodoTask.Where(t => t.Id == exerciseID).FirstOrDefault());
            string connection = "Server=(localdb)\\mssqllocaldb;Database=ToDoAppDb;Trusted_Connection=True;";
            using (SqlConnection con = new SqlConnection(connection))
            {
                string cmd = "Delete from dbo.TodoTask where id = @id";
                SqlCommand command = new SqlCommand(cmd, con);
                command.Parameters.Add("id", System.Data.SqlDbType.Int).Value = exerciseID;
                con.Open();
                command.ExecuteNonQuery();
                _context.SaveChanges();
            }
        }
    }
}
