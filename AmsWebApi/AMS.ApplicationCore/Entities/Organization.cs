using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Web.ApplicationCore.Entities.Security;

namespace Web.ApplicationCore.Entities
{
    public class Organization : BaseEntity
    {
        [Required(ErrorMessage = "Organization Name Required")]
        public string Name { get; set; }

        public IList<OrganizationGoal> OrganizationGoals { get; set; }

        public IList<Employee> Employees { get; set; }
    }

}
