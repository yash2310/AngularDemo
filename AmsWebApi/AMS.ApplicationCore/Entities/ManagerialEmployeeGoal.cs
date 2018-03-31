using System.ComponentModel.DataAnnotations;
using Web.ApplicationCore.Entities.Security;

namespace Web.ApplicationCore.Entities
{
    public class ManagerialEmployeeGoal : Goals
    {
        [Required(ErrorMessage = "Employee Required")]
        public Employee Employee { get; set; } // Employee Entity

        //[Required(ErrorMessage = "Reviewer Required")]
        public Employee Reviewer { get; set; } // List Employee Entity for Reviewer
    }
}
