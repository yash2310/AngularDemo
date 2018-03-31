using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Web.ApplicationCore.Entities
{
    public class ReviewCycle : BaseEntity
    {
        [Required(ErrorMessage = "Cycle Name Required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Valid From Required")]
        public int StartMonth { get; set; }

        [Required(ErrorMessage = "Valid To Required")]
        public int EndMonth { get; set; }

        [Required(ErrorMessage = "Status Required")]
        public bool Status { get; set; }

        public IList<OrganizationGoal> OrganizationGoals { get; set; }
        public IList<DesignationGoal> DesignationGoals { get; set; }
        public IList<ManagerialEmployeeGoal> ManagerialEmployeeGoals { get; set; }
        public IList<EmployeeGoal> EmployeeGoals { get; set; }
    }

}
