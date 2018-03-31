using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Web.ApplicationCore.Security;

namespace Web.ApplicationCore
{
    public class Designation : BaseEntity
    {
        [Required(ErrorMessage = "Designation Name Required")]
        public string Name { get; set; }

        public IList<DesignationGoal> DesignationGoals { get; set; }

        public IList<Employee> Employees { get; set; }
    }

}
