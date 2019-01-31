using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClassPlustMVC.Models
{
    public class Response
    {
        public int ResponseId { get; set; }
        public string StudentId { get; set; }
        public int AssignmentId { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime PostDate { get; set; }

        public byte[] Submission { get; set; }

        public string postType { get; set; }

        public ApplicationUser Student { get; set; }

        public Assignment Assignment { get; set; }
        
    }
}
