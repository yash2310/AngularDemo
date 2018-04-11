using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMS.ApplicationCore.Interface;
using Web.ApplicationCore.Entities;
using Web.ApplicationCore.Entities.Security;

namespace AMS.Infrastructure.Repository
{
    public class ReporteeRepository
    {
        private AmsContext _dbcontext;

        public ReporteeGoal ReporteeGoals(int id)
        {
            ReporteeGoal reporteeGoal = new ReporteeGoal();

            using (_dbcontext = new AmsContext())
            {
                try
                {
                    Employee employee =
                        _dbcontext.Employees
                            .Include(r => r.ReportingManager)
                            .Include(emp => emp.EmployeeGoals)
                            .Include(desg => desg.DesignationGoals)
                            .Include(org => org.OrganizationGoals)
                            .FirstOrDefault(
                                emp => emp.Id.Equals(id));

                    if (employee != null)
                    {
                        reporteeGoal.EmployeeGoal = employee.EmployeeGoals
                            .Where(eg => eg.Cycle.Id.Equals(1))
                            .Select(eg => new GoalData
                            {
                                Id = eg.Id,
                                Goal = eg.Goal,
                                Description = eg.Description,
                                GoalType = GoalType.Employee,
                                Status = eg.Status.Id,
                                Weightage = eg.Weightage
                            }).ToList();

                        reporteeGoal.DesignationGoal = employee.DesignationGoals
                            .Where(eg => eg.Cycle.Id.Equals(1))
                            .Select(eg => new GoalData
                            {
                                Id = eg.Id,
                                Goal = eg.Goal,
                                Description = eg.Description,
                                GoalType = GoalType.Designation,
                                Status = eg.Status.Id,
                                Weightage = eg.Weightage
                            }).ToList();

                        reporteeGoal.OrganizationGoal = employee.OrganizationGoals
                            .Where(eg => eg.Cycle.Id.Equals(1))
                            .Select(eg => new GoalData
                            {
                                Id = eg.Id,
                                Goal = eg.Goal,
                                Description = eg.Description,
                                GoalType = GoalType.Organization,
                                Status = eg.Status.Id,
                                Weightage = eg.Weightage
                            }).ToList();
                    }

                }
                catch (Exception e)
                {
                    Console.Write(string.Format(ConfigurationManager.AppSettings["ErrorMessage"],
                        this.GetType().Name,
                        "Reportee", e.Message));
                    return null;
                }
            }

            return reporteeGoal;
        }

        public List<GoalData> ManagerialGoals(int id)
        {
            List<GoalData> managerialGoal = new List<GoalData>();

            using (_dbcontext = new AmsContext())
            {
                try
                {
                    Employee employee =
                        _dbcontext.Employees
                            .Include(mgr => mgr.ManagerialEmployeeGoals)
                            .FirstOrDefault(
                                emp => emp.Id.Equals(id));

                    if (employee != null)
                    {
                        managerialGoal = employee.ManagerialEmployeeGoals
                            .Where(eg => eg.Cycle.Id.Equals(1))
                            .Select(eg => new GoalData
                            {
                                Id = eg.Id,
                                Goal = eg.Goal,
                                Description = eg.Description,
                                GoalType = GoalType.Employee,
                                Status = eg.Status.Id,
                                Weightage = eg.Weightage
                            }).ToList();
                    }

                }
                catch (Exception e)
                {
                    Console.Write(string.Format(ConfigurationManager.AppSettings["ErrorMessage"],
                        this.GetType().Name,
                        "Reportee", e.Message));
                    return null;
                }
            }

            return managerialGoal;
        }
    }

    public class GoalData
    {
        public int Id { get; set; }
        public string Goal { get; set; }
        public string Description { get; set; }
        public GoalType GoalType { get; set; }
        public int Status { get; set; }
        public int Weightage { get; set; }
    }

    public class ReporteeGoal
    {
        public List<GoalData> EmployeeGoal { get; set; }
        public List<GoalData> DesignationGoal { get; set; }
        public List<GoalData> OrganizationGoal { get; set; }
    }
}
