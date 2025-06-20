using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnicomPro.Models
{
    public class Lecture
    {
        public int LectureID { get; set; }
        public string LectureName { get; set; }
        public int CourseId { get; set; }
    }
}
