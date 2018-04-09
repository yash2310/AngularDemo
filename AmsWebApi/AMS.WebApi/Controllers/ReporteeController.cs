using AMS.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Web.ApplicationCore.Entities;
using Web.ApplicationCore.Entities.Security;
using WebGrease.Css.Extensions;

namespace AMS.WebApi.Controllers
{
    [RoutePrefix("api/reportee")]
    public class ReporteeController : ApiController
    {
        EmployeeRepository repository = new EmployeeRepository();

        [HttpGet]
        [Route("reportees/{id}")]
        public List<ReporteeData> GetAllReportee(int id)
        {
            ReporteeData reportee;
            List<ReporteeData> reporteeDatas = new List<ReporteeData>();
            List<Employee> employees;
            try
            {
                employees = repository.GetAllById(id).ToList();

                foreach (Employee employee in employees)
                {
                    reportee = new ReporteeData();
                    reportee.Id = employee.Id;
                    reportee.Name = employee.Name;
                    reportee.Email = employee.Email;
                    reportee.EmployeeNo = employee.EmployeeNo;
                    reportee.JoiningDate = employee.JoiningDate;
                    reportee.ReportingManager =
                        new Reporting()
                        {
                            Id = employee.ReportingManager.Id,
                            Name = employee.ReportingManager.Name,
                            Email = employee.ReportingManager.Email
                        };
                    reportee.Designation = new Data()
                    {
                        Id = employee.Designation.Id,
                        Name = employee.Designation.Name
                    };
                    reportee.Department = new Data()
                    {
                        Id = employee.Department.Id,
                        Name = employee.Department.Name
                    };
                    reportee.Organization = new Data()
                    {
                        Id = employee.Organization.Id,
                        Name = employee.Organization.Name
                    };
                    reportee.Roles = employee.Roles.Select(r => new Data
                    {
                        Id = r.Id,
                        Name = r.Name
                    }).ToList();

                    reporteeDatas.Add(reportee);
                }
            }
            catch (Exception e)
            {
                reporteeDatas = null;
            }
            return reporteeDatas;
        }
    }

    public class ReporteeData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string EmployeeNo { get; set; }
        public DateTime JoiningDate { get; set; }
        public Reporting ReportingManager { get; set; }
        public Data Designation { get; set; } // Designation Entity
        public Data Department { get; set; } // Department Entity
        public Data Organization { get; set; } // Organization Entity
        public IList<Data> Roles { get; set; } // List Role Entity
    }
}
