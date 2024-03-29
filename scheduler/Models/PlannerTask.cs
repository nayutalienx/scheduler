﻿using System;
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
        public string Status { get; set; }
        public void FormTags(string[] tagList) {
            string tags = "";
            if (tagList != null)
                tags += String.Join(" ", tagList);
            ImportantTag = (tags.Contains("important")) ? "Важное" : "";
            RushTag = (tags.Contains("rush")) ? "Срочное" : "";
        }
    }
}