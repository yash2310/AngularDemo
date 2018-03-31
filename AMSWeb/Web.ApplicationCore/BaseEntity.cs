using System;
using System.ComponentModel.DataAnnotations;

namespace Web.ApplicationCore
{
    public class BaseEntity
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Date Required")]
        public DateTime CreatedOn { get; set; }

        [Required(ErrorMessage = "Employee Id Required")]
        public int CreatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public int? UpdatedBy { get; set; }

    }
}
