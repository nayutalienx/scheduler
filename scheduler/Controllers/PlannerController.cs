using scheduler.Models;
using scheduler.Models.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace scheduler.Controllers
{
    public class PlannerController : Controller
    {
        TaskDataContext db = new TaskDataContext();
        public ActionResult Index()
        {
            ViewBag.ShelfTasks = from task in db.Tasks where task.Status.Contains("На полке") select task;
            ViewBag.CurrentTasksCount = (from task in db.Tasks where task.Status.Contains("Текущее") select task).Count();
            ViewBag.CurrentTasks = from task in db.Tasks where task.Status.Contains("Текущее") select task;
            ViewBag.ExpiredTasksCount = (from task in db.Tasks where task.Status.Contains("Просроченное") select task).Count();
            ViewBag.ExpiredTasks = from task in db.Tasks where task.Status.Contains("Просроченное") select task;
            return View();
        }

        public ActionResult PartialAddForm() {
            return PartialView();
        }

        public ActionResult PartialCurrentTasks() {
            return PartialView();
        }

        public ActionResult PartialShelfTasks() {
            return PartialView();
        }

        public ActionResult PartialExpiredTasks() {
            return PartialView();
        }

        [HttpPost]
        public RedirectResult Add(string taskName, string taskDescription, DateTime? taskDeadline, string[] taskTags, string taskStatus) {
            PlannerTask pt = new PlannerTask()
            {
                Header = taskName,
                Description = taskDescription,
                Deadline = (DateTime)taskDeadline,
                Status = taskStatus

            };
            
            pt.FormTags(taskTags);
            db.Tasks.Add(pt);
            db.SaveChanges();
            return Redirect("/");

        }

        public RedirectResult Delete(int id) {
            var task = new PlannerTask { Id = id };
            db.Tasks.Attach(task);
            db.Tasks.Remove(task);
            db.SaveChanges();
            return Redirect("/");
        }

        [HttpPost]
        public RedirectResult Edit(int id, string taskName, string taskDescription, DateTime? taskDeadline, string[] taskTags, string taskStatus) {
            PlannerTask pt = db.Tasks.SingleOrDefault(task => task.Id == id);
            if (pt != null)
            {
                pt.Header = taskName;
                pt.Description = taskDescription;
                pt.Deadline = (DateTime)taskDeadline;
                pt.Status = taskStatus;
                pt.FormTags(taskTags);
                db.SaveChanges();
            }
            return Redirect("/");
        }

        public RedirectResult Move(int id, string where) {
            PlannerTask pt = db.Tasks.SingleOrDefault(task => task.Id == id);
            if (pt != null)
            {
                pt.Status = where.Equals("current") ? "Текущее задание" : "Просроченное задание";
                db.SaveChanges();
            }
            return Redirect("/");
        }

        public ActionResult ModalEditTask(int id) {
            PlannerTask pt = db.Tasks.FirstOrDefault(task => task.Id == id);
            if (pt != null)
                return PartialView(pt);
            return HttpNotFound();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

    }
}