using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace scheduler.Models
{
    public class PlannerTask
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }

        public string ImportantTag { get; set; }

        public string RushTag { get; set; }

        public void FormTags(string tagList) {
            ImportantTag = (tagList.Contains("Важное")) ? "Важное" : "";
            RushTag = (tagList.Contains("Срочное")) ? "Срочное" : "";
        }


    }
}