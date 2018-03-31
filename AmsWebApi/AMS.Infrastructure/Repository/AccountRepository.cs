using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMS.ApplicationCore.Interface;
using Web.ApplicationCore.Entities.Security;

namespace AMS.Infrastructure.Repository
{
    public class AccountRepository : IRepository<Employee>
    {
        private AmsContext dbcontext;

        public IEnumerable<Employee> GetAll()
        {
            throw new NotImplementedException();
        }

        public Employee GetById(object Id)
        {
            throw new NotImplementedException();
        }

        public string Insert(Employee obj)
        {
            using (dbcontext = new AmsContext())
            {
                ValidationContext validationContext = new ValidationContext(obj, null, null);
                List<ValidationResult> results = new List<ValidationResult>();
                bool valid = Validator.TryValidateObject(obj, validationContext, results, true);
                if (!valid && results.Count > 0)
                {
                    throw new Exception(results[0].ToString());
                }

                using (DbContextTransaction transaction = dbcontext.Database.BeginTransaction())
                {
                    try
                    {
                        dbcontext.Employees.Add(obj);
                        dbcontext.SaveChanges();
                        transaction.Commit();
                        return "success";
                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();
                        Console.WriteLine(e.Message);
                        return "failed";
                    }
                }
            }
        }

        public string Delete(object Id)
        {
            using (dbcontext = new AmsContext())
            {
                using (DbContextTransaction transaction = dbcontext.Database.BeginTransaction())
                {
                    try
                    {
                        dbcontext.Employees.Remove(dbcontext.Employees.First(emp => emp.Id.Equals(Id)));
                        dbcontext.SaveChanges();
                        transaction.Commit();
                        return "success";
                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();
                        Console.WriteLine(e.Message);
                        return "failed";
                    }
                }
            }
        }

        public string Update(Employee obj)
        {
            throw new NotImplementedException();
        }

        public string Save()
        {
            throw new NotImplementedException();
        }
    }
}