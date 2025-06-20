using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnicomPro.Models
{
    public class LabHallAllocation
    {
        public int AllocationID { get; set; }
        public int CourseID { get; set; }
        public string LocationType { get; set; }   // "Lab" or "Hall"
        public string LocationName { get; set; }   // e.g., "Lab 1", "Hall A"
        public string Day { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
    }
}
