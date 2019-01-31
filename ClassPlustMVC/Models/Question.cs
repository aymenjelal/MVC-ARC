using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassPlustMVC.Models
{
    public class Question
    {
        public int QuestionId { get; set; }
        public string StudentId { get; set; }
        public int CourseId { get; set; }
        public DateTime PostDate { get; set; }
        public string QuestionContent { get; set; }


        public ApplicationUser Student { get; set; }
        public Course Course { get; set; }
        
        public ICollection<Answer> Answers { get; set; }
    }
}
