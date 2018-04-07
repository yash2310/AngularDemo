using AMS.ApplicationCore.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using Web.ApplicationCore.Entities.Security;

namespace AMS.Infrastructure.Repository
{
    public class AccountRepository
    {
        private AmsContext _dbcontext;

        public Employee Login(string email, string password)
        {
            using (_dbcontext = new AmsContext())
            {
                using (DbContextTransaction transaction = _dbcontext.Database.BeginTransaction())
                {
                    try
                    {
                        Employee employee =
                            _dbcontext.Employees.Include(r => r.ReportingManager)
                                .Include(dept => dept.Department)
                                .Include(desg => desg.Designation).Include(org => org.Organization)
                                .Include(r => r.Roles).FirstOrDefault(
                                    emp => emp.Email.Equals(email) && emp.Password.Equals(password));

                        return employee;
                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();
                        Console.Write(string.Format(ConfigurationManager.AppSettings["ErrorMessage"],
                            this.GetType().Name,
                            "Login", e.Message));
                        return null;
                    }
                }
            }
        }

        public bool ResetPassword(int id, string newPassword)
        {
            using (_dbcontext = new AmsContext())
            {
                using (DbContextTransaction transaction = _dbcontext.Database.BeginTransaction())
                {
                    try
                    {
                        Employee employee = _dbcontext.Employees.FirstOrDefault(emp => emp.Id.Equals(id));
                        if (employee != null)
                        {
                            employee.Password = newPassword;
                            _dbcontext.Employees.AddOrUpdate(employee);
                            _dbcontext.SaveChanges();
                            transaction.Commit();
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();
                        Console.Write(string.Format(ConfigurationManager.AppSettings["ErrorMessage"],
                            this.GetType().Name,
                            "ResetPassword", e.Message));
                        return false;
                    }
                }
            }
        }

        public bool Register(Employee employee)
        {
            using (_dbcontext = new AmsContext())
            {
                using (DbContextTransaction transaction = _dbcontext.Database.BeginTransaction())
                {
                    try
                    {
                        ValidationContext context = new ValidationContext(employee);
                        bool isValid = Validator.TryValidateObject(employee, context, null, true);

                        if (isValid == true)
                        {
                            _dbcontext.Employees.Add(employee);
                            _dbcontext.SaveChanges();
                            transaction.Commit();
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();
                        Console.Write(string.Format(ConfigurationManager.AppSettings["ErrorMessage"],
                            this.GetType().Name,
                            "ResetPassword", e.Message));
                        return false;
                    }
                }
            }
        }
    }
}