using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Web.ApplicationCore.Security
{
    public class Employee : BaseEntity
    {
        [Required(ErrorMessage = "Employee Name Required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email Required")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Invalid Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Employee Number Required")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Invalid Employee Number")]
        public string EmployeeNo { get; set; }

        [Required(ErrorMessage = "Contact Number Required")]
        public long ContactNo { get; set; }

        [Required(ErrorMessage = "Password Required")]
        [DataType(DataType.Password, ErrorMessage = "Invalid Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Joining Date Required")]
        public DateTime JoiningDate { get; set; }

        [Required(ErrorMessage = "Image URL Required")]
        public string ImageUrl { get; set; }

        public bool NewUser { get; set; }

        [Required(ErrorMessage = "Reporting Manager Required")]
        public Employee ReportingManager { get; set; }

        public Designation Designation { get; set; } // Designation Entity
        public Department Department { get; set; } // Department Entity
        public Organization Organization { get; set; } // Organization Entity
        public IList<Role> Roles { get; set; } // List Role Entity
        public ICollection<OrganizationGoal> OrganizationGoals { get; set; }
        public ICollection<DesignationGoal> DesignationGoals { get; set; }
        public ICollection<ManagerialEmployeeGoal> ManagerialEmployeeGoals { get; set; }
        public ICollection<EmployeeGoal> EmployeeGoals { get; set; }
    }
}