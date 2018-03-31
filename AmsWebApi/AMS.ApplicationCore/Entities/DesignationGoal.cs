using System.ComponentModel.DataAnnotations;

namespace Web.ApplicationCore.Entities
{
    public class DesignationGoal : Goals
    {
        [Required(ErrorMessage = "Designation Required")]
        public Designation Designation { get; set; } // Designation Entity
    }
}
