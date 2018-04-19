using AMS.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Web.ApplicationCore.Entities;
using Web.ApplicationCore.Entities.Security;
using WebGrease.Css.Extensions;

namespace AMS.WebApi.Controllers
{
    [RoutePrefix("api/reportee")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ReporteeController : ApiController
    {
        private EmployeeRepository repository = new EmployeeRepository();
        private ReporteeRepository reporteeRepository = new ReporteeRepository();

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

        [HttpGet]
        [Route("allgoals/{id}")]
        public ReporteeGoal GetReporteeGoal(int id)
        {
            ReporteeGoal reporteeGoal = new ReporteeGoal();
            try
            {
                return reporteeRepository.ReporteeGoals(id);
            }
            catch (Exception e)
            {
                HttpResponseMessage message = new HttpResponseMessage(HttpStatusCode.Conflict);
                message.ReasonPhrase = "Invalid Response";
                throw new HttpResponseException(message);
            }

            return reporteeGoal;
        }

        [HttpGet]
        [Route("managergoals/{id}")]
        public List<GoalData> GetManagerialGoal(int id)
        {
            try
            {
                return reporteeRepository.ManagerialGoals(id);
            }
            catch (Exception e)
            {
                HttpResponseMessage message = new HttpResponseMessage(HttpStatusCode.Conflict);
                message.ReasonPhrase = "Invalid Response";
                throw new HttpResponseException(message);
            }
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