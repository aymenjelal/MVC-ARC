using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClassPlustMVC.Models
{
    public class Assignment
    {

        public int AssignmentId { get; set; }
        public int CourseId { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime PostDate { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Deadline { get; set; }


        public string Topic { get; set; }

        public byte[] Question { get; set; }

        public string postType { get; set; }

        public Course Course { get; set; }
    }
}
