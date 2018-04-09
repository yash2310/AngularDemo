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
    public class EmployeeRepository : IRepository<Employee>
    {
        private AmsContext _dbcontext;

        public IEnumerable<Employee> GetAllById(object id)
        {
            using (_dbcontext = new AmsContext())
            {
                using (DbContextTransaction transaction = _dbcontext.Database.BeginTransaction())
                {
                    try
                    {
                        int data = Convert.ToInt32(id);
                        List<Employee> employee =
                            _dbcontext.Employees
                                .Include(r => r.ReportingManager)
                                .Include(d => d.Designation)
                                .Include(d => d.Department)
                                .Include(d => d.Organization)
                                .Include(d => d.Roles)
                                .Where(emp => emp.ReportingManager.Id == data).ToList();

                        return employee;
                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();
                        Console.Write(string.Format(ConfigurationManager.AppSettings["ErrorMessage"],
                            this.GetType().Name,
                            "GetAllById", e.Message));
                        return null;
                    }
                }
            }
        }

        public Employee GetById(object id)
        {
            using (_dbcontext = new AmsContext())
            {
                try
                {
                    Employee employee = _dbcontext.Employees.FirstOrDefault(emp => emp.Id.Equals(id));
                    return employee;
                }
                catch (Exception e)
                {
                    Console.Write(string.Format(ConfigurationManager.AppSettings["ErrorMessage"], this.GetType().Name,
                        "GetById", e.Message));
                    return null;
                }
            }
        }

        public bool Delete(object id)
        {
            using (_dbcontext = new AmsContext())
            {
                using (DbContextTransaction transaction = _dbcontext.Database.BeginTransaction())
                {
                    try
                    {
                        _dbcontext.Employees.Remove(_dbcontext.Employees.First(emp => emp.Id.Equals(id)));
                        _dbcontext.SaveChanges();
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();
                        Console.Write(string.Format(ConfigurationManager.AppSettings["ErrorMessage"],
                            this.GetType().Name,
                            "Delete", e.Message));
                        return false;
                    }
                }
            }
        }

        public bool Update(Employee obj)
        {
            using (_dbcontext = new AmsContext())
            {
                using (DbContextTransaction transaction = _dbcontext.Database.BeginTransaction())
                {
                    try
                    {
                        ValidationContext validationContext = new ValidationContext(obj, null, null);
                        List<ValidationResult> results = new List<ValidationResult>();
                        bool valid = Validator.TryValidateObject(obj, validationContext, results, true);
                        if (!valid && results.Count > 0)
                        {
                            throw new Exception(results[0].ToString());
                        }

                        Employee employee = _dbcontext.Employees.FirstOrDefault(emp => emp.Id.Equals(obj.Id));
                        if (employee != null)
                        {
                            employee = obj;
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
                            "Update", e.Message));
                        return false;
                    }
                }
            }
        }

        public bool Insert(Employee obj)
        {
            using (_dbcontext = new AmsContext())
            {
                ValidationContext validationContext = new ValidationContext(obj, null, null);
                List<ValidationResult> results = new List<ValidationResult>();
                bool valid = Validator.TryValidateObject(obj, validationContext, results, true);
                if (!valid && results.Count > 0)
                {
                    throw new Exception(results[0].ToString());
                }

                using (DbContextTransaction transaction = _dbcontext.Database.BeginTransaction())
                {
                    try
                    {
                        _dbcontext.Employees.Add(obj);
                        _dbcontext.SaveChanges();
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();
                        Console.Write(string.Format(ConfigurationManager.AppSettings["ErrorMessage"],
                            this.GetType().Name,
                            "Insert", e.Message));
                        return false;
                    }
                }
            }
        }
    }
}