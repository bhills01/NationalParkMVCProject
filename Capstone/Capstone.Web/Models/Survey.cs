﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class Survey
    {
        public int SurveyId { get; set; }
        [Required]
        [EmailAddress]
        [Display(Prompt = "Enter Email")]
        public string Email { get; set; }
        public string StateOfResidence { get; set; }
        [Required]
        public string ActivityLevel { get; set; }
        [Required]        
        public string ParkCode { get; set; }

        public Survey()
        {

        }

        public Survey(int surveyID, string email, string stateOfResidence, string activityLevel, string parkCode)
        {
            SurveyId = surveyID;
            Email = email;
            StateOfResidence = stateOfResidence;
            ActivityLevel = activityLevel;
            ParkCode = parkCode;
        }
    }
}
