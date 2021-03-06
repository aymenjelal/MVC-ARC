﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassPlustMVC.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser() : base()
        {

        }


        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<Enrollment> Enrolments { get; set; }

        public ICollection<Question> Questions { get; set; }

        public ICollection<Answer> Answers { get; set; }

    }
}
