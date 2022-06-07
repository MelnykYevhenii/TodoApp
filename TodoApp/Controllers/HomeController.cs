using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TodoApp.db;
using TodoApp.Interfaces;
using TodoApp.Models;
using Microsoft.EntityFrameworkCore;
using TodoApp.ViewModels;

namespace TodoApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITask _task;
        public HomeController(ITask t)
        {
            _task = t;
        }
        public ViewResult Index()
        {
            var obj = new TaskViewModel
            {
                AllTasks = _task.GetAllTasks
            };
            return View(obj);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Exercise task)
        {
            _task.CreateTask(task);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> DeleteTask(int taskId)
        {
            _task.DeleteTask(taskId);
            return RedirectToAction("Index");
        }
    }
}