using System.ComponentModel.DataAnnotations;

namespace Web.ApplicationCore.Entities
{
    public class OrganizationGoal : Goals
    {
        [Required(ErrorMessage = "Organization Required")]
        public Organization Organization { get; set; } // Organization Entity
    }

}
