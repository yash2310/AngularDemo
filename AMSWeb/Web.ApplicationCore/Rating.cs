using System;
using System.ComponentModel.DataAnnotations;
using Web.ApplicationCore.Security;

namespace Web.ApplicationCore
{
    public class Rating : BaseEntity
    {
        private float _rate;

        [Required(ErrorMessage = "Rater Id Required")]
        public Employee Rater { get; set; } // Employee Entity for Rater

        [Required(ErrorMessage = "Ratee Id Required")]
        public Employee Ratee { get; set; } // Employee Entity for Ratee

        [Required(ErrorMessage = "Goal Id Required")]
        public int GoalId { get; set; } // Id of Goals of any type

        [Required(ErrorMessage = "Goal Id Required")]
        public GoalType GoalType { get; set; } // Id of Goals of any type

        [Required(ErrorMessage = "Rate Required")]
        [Range(0, 5, ErrorMessage = "Rate 0 to 5")]
        public float Rate
        {
            get => _rate;
            set
            {
                if (value < 0 || value > 5)
                {
                    throw new Exception("Invalid rate");
                }
                _rate = value;
            }
        }

        [Required(ErrorMessage = "Comment Required")]
        public string Comment { get; set; }
    }

    public enum GoalType
    {
        Organization,
        Designation,
        Managerial,
        Employee
    }

}
