using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Web.ApplicationCore.Entities.Security;

namespace Web.ApplicationCore.Entities
{
    public class Designation : BaseEntity
    {
        [Required(ErrorMessage = "Designation Name Required")]
        public string Name { get; set; }

        public IList<DesignationGoal> DesignationGoals { get; set; }

        public IList<Employee> Employees { get; set; }
    }

}
