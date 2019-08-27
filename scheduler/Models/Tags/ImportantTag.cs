using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace scheduler.Models.Tags
{
    public class ImportantTag : ITag
    {
        public string Name { get; set; }
        public int Id { get; set; }

        public ImportantTag(string name, int id) {
            Name = name;
            Id = id;
        }
    }
}