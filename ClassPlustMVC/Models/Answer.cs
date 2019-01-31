using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassPlustMVC.Models
{
    public class Answer
    {
        public int AnswerId { get; set; }
        public string StudentId { get; set; }
        public int QuestionId { get; set; }
        public DateTime PostDate { get; set; }
        public string AnswerContent { get; set; }

        public ApplicationUser Student { get; set; }
        public Question Question {get; set;}
        
    }
}
