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
            
            return View(db.Tasks);
        }

        [HttpPost]
        public RedirectResult Add(string taskName, string taskDescription, DateTime? taskDeadline, string taskTags) {
            PlannerTask pt = new PlannerTask() {
                Header = taskName,
                Description = taskDescription,
                Deadline = (DateTime)taskDeadline
            };
            pt.FormTags(taskTags);
            db.Tasks.Add(pt);
            db.SaveChanges();
            return Redirect("/");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

    }
}