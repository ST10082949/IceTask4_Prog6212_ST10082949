using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TaskManagementApp_ST10082949.Models;

namespace TaskManagementApp_ST10082949.Controllers
{
    public class TaskController : Controller
    {
        private static List<TaskModel> tasks = new List<TaskModel>();
        private static int currentId = 1;

        public IActionResult Index()
        {
            return View(tasks);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TaskModel model)
        {
            if (ModelState.IsValid)
            {
                model.Id = currentId++;
                tasks.Add(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task == null) return NotFound();
            return View(task);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TaskModel model)
        {
            if (ModelState.IsValid)
            {
                var task = tasks.FirstOrDefault(t => t.Id == model.Id);
                if (task == null) return NotFound();

                task.Title = model.Title;
                task.Description = model.Description;
                task.Deadline = model.Deadline;

                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task == null) return NotFound();  // Returns 404 if the task is not found
            return View(task);  // Returns the delete confirmation view with the task details
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task == null) return NotFound();  // Returns 404 if the task is not found

            tasks.Remove(task);  // Remove the task from the list
            return RedirectToAction(nameof(Index));  // Redirect to the task list after deletion
        }
    }
}
