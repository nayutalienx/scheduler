using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using scheduler.Models.Tags;

namespace scheduler.Models
{
    public class PlannerTask
    {
        public uint Id { get; set; }
        public string Header { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }

        public PlannerTask(uint id, string header, string description, DateTime deadline) {
            Id = id;
            Header = header;
            Description = description;
            Deadline = deadline;
            
        }

        


    }
}