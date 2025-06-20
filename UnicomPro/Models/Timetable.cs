using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnicomPro.Models
{
    public class Timetable
    {
        public int TimetableID { get; set; }    // Primary Key
        public int CourseID { get; set; }       // Foreign Key to Courses table
        public string Subject { get; set; }     // Subject name
        public string Day { get; set; }         // Day of the week (e.g., "Monday")
        public string StartTime { get; set; }   // Start time as string (e.g., "09:00")
        public string EndTime { get; set; }
    }
}
