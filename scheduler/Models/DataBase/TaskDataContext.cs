using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace scheduler.Models.DataBase
{
    public class TaskDataContext : DbContext
    {
        public DbSet<PlannerTask> Tasks { get; set; }
    }
}