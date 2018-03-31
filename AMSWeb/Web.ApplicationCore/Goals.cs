using System;
using System.ComponentModel.DataAnnotations;

namespace Web.ApplicationCore
{
    public class Goals : BaseEntity
    {
        private int _weightage;

        [Required(ErrorMessage = "Goal Required")]
        public string Goal { get; set; }

        [Required(ErrorMessage = "Weightage Required")]
        [Range(0, 100, ErrorMessage = "Weightage 0 to 100")]
        public int Weightage
        {
            get => _weightage;
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new Exception("Invalid weightage");
                }
                _weightage = value;
            }
        }

        [Required(ErrorMessage = "Description Required")]
        [StringLength(500, ErrorMessage = "Description not more than 500 character")]
        public string Description { get; set; } // Description for Goals

        [Required(ErrorMessage = "Review Cycle Required")]
        public ReviewCycle Cycle { get; set; } // Review cycle

        [Required(ErrorMessage = "Goal Status Required")]
        public GoalStatus Status { get; set; } // Goal Status

        [Required(ErrorMessage = "Start Date Required")]
        public DateTime StartDate { get; set; } // Goal start date

        [Required(ErrorMessage = "End Date Required")]
        public DateTime EndDate { get; set; } // Goal end date
    }

}
