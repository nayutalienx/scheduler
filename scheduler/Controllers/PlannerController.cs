using scheduler.Models;
using scheduler.Models.DataBase;
using scheduler.Models.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace scheduler.Controllers
{
    public class PlannerController : Controller
    {
        public ActionResult Index()
        {
            BookContext db = new BookContext();
            return View(db.Books);
        }

    }
}