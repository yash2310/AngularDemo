using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Web.ApplicationCore.Entities.Security;

namespace Web.ApplicationCore.Entities
{
    public class Department : BaseEntity
    {
        [Required(ErrorMessage = "Department Name Required")]
        public string Name { get; set; }

        public IList<Employee> Employees { get; set; }
    }
}