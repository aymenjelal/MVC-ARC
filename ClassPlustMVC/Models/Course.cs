using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClassPlustMVC.Models
{
    public class Course
    {

        public int CourseId { get; set; }

        [Display(Name="Teacher")]
        public string TeacherId { get; set; }

        [Display(Name ="Course Name")]
        public string CourseName { get; set; }

        [Display(Name ="Couse Description")]
        public string CourseDescription { get; set; }

        [Display(Name ="SchoolName")]
        public string SchoolName { get; set; }

        public int Active { get; set; }

        public ICollection<Enrollment> Enrolments { get; set; }
    }
}
