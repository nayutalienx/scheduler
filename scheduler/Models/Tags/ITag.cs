using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scheduler.Models.Tags
{
    public interface ITag
    {
        string Name { get; set; }
        int Id { get; set; }
    }
}
