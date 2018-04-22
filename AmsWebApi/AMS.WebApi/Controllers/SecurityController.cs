using AMS.Infrastructure.Repository;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using Web.ApplicationCore.Entities.Security;

namespace AMS.WebApi.Controllers
{
    [RoutePrefix("api/security")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class SecurityController : ApiController
    {
        [HttpPost]
        [Route("login")]
        public EmployeeData Login([FromBody] LoginData loginData)
        {
            EmployeeData employeeData = null;
            AccountRepository accountRepository = new AccountRepository();
            try
            {
                Employee employee = accountRepository.Login(loginData.Username, loginData.Password);
                if (employee != null)
                {
                    employeeData = new EmployeeData();
                    employeeData.Id = employee.Id;
                    employeeData.Name = employee.Name;
                    employeeData.Email = employee.Email;
                    employeeData.ImageUrl = employee.ImageUrl;
                    employeeData.EmployeeNo = employee.EmployeeNo;
                    employeeData.ContactNo = employee.ContactNo;
                    employeeData.JoiningDate = employee.JoiningDate;
                    employeeData.NewUser = employee.NewUser;

                    employeeData.ReportingManager = employee.ReportingManager
                        .IfNotNull(d => new Data() {Id = d.Id, Name = d.Name});
                    employeeData.Department = employee.Department
                        .IfNotNull(d => new Data() {Id = d.Id, Name = d.Name});
                    employeeData.Designation = employee.Designation
                        .IfNotNull(d => new Data() {Id = d.Id, Name = d.Name});
                    employeeData.Organization = employee.Organization
                        .IfNotNull(d => new Data() {Id = d.Id, Name = d.Name});
                    employeeData.Roles = employee.Roles.Select(d => new Data() {Id = d.Id, Name = d.Name}).ToList();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                employeeData = null;
            }
            return employeeData;
        }

        [HttpPost]
        [Route("reset")]
        public string ResetPassword([FromBody] ResetData resetData)
        {
            AccountRepository accountRepository = new AccountRepository();
            string result;
            try
            {
                result = accountRepository.ResetPassword(resetData.Id, resetData.Password).Equals(true)
                    ? "success"
                    : "failed";
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                result = "failed";
            }
            return result;
        }

        [HttpPost]
        [Route("register")]
        public bool Register([FromBody] RegisterData regData)
        {
            string str = null;
            Employee employee = new Employee();
            AccountRepository accountRepository = new AccountRepository();
            try
            {
                employee.Name = regData.Name;
                employee.Email = regData.Email;
                employee.EmployeeNo = regData.EmployeeNo;
                employee.JoiningDate = regData.JoiningDate;
                employee.Password = regData.Password;
                employee.ImageUrl = "url";
                employee.NewUser = true;
                employee.CreatedOn = DateTime.Now;
                employee.CreatedBy = 1;

                return accountRepository.Register(employee);
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }

    public class LoginData
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class ResetData
    {
        public int Id { get; set; }
        public string Password { get; set; }
    }

    public class Data
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Reporting
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }

    public class EmployeeData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string EmployeeNo { get; set; }
        public long ContactNo { get; set; }
        public DateTime JoiningDate { get; set; }
        public string ImageUrl { get; set; }
        public bool NewUser { get; set; }
        public Data ReportingManager { get; set; }

        public Data Designation { get; set; } // Designation Entity
        public Data Department { get; set; } // Department Entity
        public Data Organization { get; set; } // Organization Entity
        public List<Data> Roles { get; set; } // List Role Entity
    }

    public class RegisterData
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string EmployeeNo { get; set; }
        public DateTime JoiningDate { get; set; }
        public string Password { get; set; }
    }
}