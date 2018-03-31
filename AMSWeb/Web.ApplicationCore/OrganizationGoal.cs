using System.ComponentModel.DataAnnotations;

namespace Web.ApplicationCore
{
    public class OrganizationGoal : Goals
    {
        [Required(ErrorMessage = "Organization Required")]
        public Organization Organization { get; set; } // Organization Entity
    }

}
