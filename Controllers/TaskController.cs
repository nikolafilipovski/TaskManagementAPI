using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagementSystemData.Entities;
using TaskManagementSystemService.Interfaces;

namespace TaskManagementSystem.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITasksService _tasksService;

        public TaskController(ITasksService tasksService)
        {
            _tasksService = tasksService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Task>>> GetAllTasks()
        {
            var tasks = await _tasksService.GetAllTasks();

            return Ok(tasks);
        }

        [HttpPost]
        public async Task<ActionResult<Task>> CreateTask(TaskDto task)
        {
            var result = await _tasksService.CreateTask(task);

            return Ok(task);
        }

        [HttpPost]
        public async Task<ActionResult<Task>> UpdateTask(TaskDto task)
        {
            var updatedTask = await _tasksService.UpdateTask(task);

            if (updatedTask == null)
                return NotFound();

            return Ok(updatedTask);
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteTask(int taskId)
        {
            var success = await _tasksService.DeleteTask(taskId);

            if (!success)
                return NotFound();

            return Ok(true);
        }
    }
}
