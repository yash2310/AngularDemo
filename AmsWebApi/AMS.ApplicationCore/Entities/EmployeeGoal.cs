using System.ComponentModel.DataAnnotations;
using Web.ApplicationCore.Entities.Security;

namespace Web.ApplicationCore.Entities
{
    public class EmployeeGoal : Goals
    {
        [Required(ErrorMessage = "Employee Required")]
        public Employee Employee { get; set; } // Employee Entity

        [Required(ErrorMessage = "Reviewer Required")]
        public Employee Reviewer { get; set; } // Employee Entity for Reviewer
    }

}
