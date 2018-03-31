using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Web.ApplicationCore.Entities.Security
{
    public class Role : BaseEntity
    {
        [Required(ErrorMessage = "Name Required")]
        public string Name { get; set; }

        public IList<Employee> Employees { get; set; }
    }

}
