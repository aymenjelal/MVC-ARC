using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassPlustMVC.Models
{
    public class Enrollment
    {
        public int EnrollmentId { get; set; }

        public int CourseId { get; set; }

        public string StudentId { get; set; }

        public int Active { get; set; }

        public Course Course { get; set; }

        public ApplicationUser Student { get; set; }

        public Enrollment(int courseId, string studentId, int active)
        {
            CourseId = courseId;
            StudentId = studentId;
            Active = active;

        }
    }
}
