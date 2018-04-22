using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMS.ApplicationCore.Interface;
using Web.ApplicationCore.Entities;
using Web.ApplicationCore.Entities.Security;

namespace AMS.Infrastructure.Repository
{
    public class GoalRepository : IRepository<Goals>
    {
        private AmsContext _dbcontext;
        public IEnumerable<Goals> GetAllById(object Id)
        {
            throw new NotImplementedException();
        }

        public Goals GetById(object Id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Goals obj)
        {
            try
            {
                object goal = null;
                using (_dbcontext = new AmsContext())
                {
                    Employee employee = _dbcontext.Employees.FirstOrDefault(emp => emp.Id.Equals(obj.Employee));
                    if (obj.GoalType.Equals(GoalType.Employee))
                    {
                        foreach (var data in obj.Reviewer)
                        {
                            goal = new EmployeeGoal
                            {
                                Goal = obj.Goal,
                                Weightage = obj.Weightage,
                                Description = obj.Description,
                                Cycle = _dbcontext.ReviewCycles.FirstOrDefault(rc => rc.Id.Equals(obj.Cycle)),
                                Status = _dbcontext.GoalStatuses.FirstOrDefault(gs => gs.Id.Equals(obj.Status)),
                                StartDate = obj.StartDate,
                                EndDate = obj.EndDate,
                                Employee = employee,
                                Reviewer = _dbcontext.Employees.FirstOrDefault(rev => rev.Id.Equals(data.Id)),
                                CreatedOn = DateTime.Now,
                                CreatedBy = obj.Employee
                            };

                            _dbcontext.EmployeeGoals.Add(goal as EmployeeGoal);
                            _dbcontext.SaveChanges();
                        }
                    }
                    else if (obj.GoalType.Equals(GoalType.Managerial))
                    {
                        goal = new ManagerialEmployeeGoal()
                        {
                            Goal = obj.Goal,
                            Weightage = obj.Weightage,
                            Description = obj.Description,
                            Cycle = _dbcontext.ReviewCycles.FirstOrDefault(rc => rc.Id.Equals(obj.Cycle)),
                            Status = _dbcontext.GoalStatuses.FirstOrDefault(gs => gs.Id.Equals(obj.Status)),
                            StartDate = obj.StartDate,
                            EndDate = obj.EndDate,
                            Employee = employee,
                            //Reviewer = _dbcontext.Employees.FirstOrDefault(rev => rev.Id.Equals(obj.Reviewer)),
                            CreatedOn = DateTime.Now,
                            CreatedBy = obj.Employee
                        };

                        _dbcontext.ManagerialEmployeeGoals.Add(goal as ManagerialEmployeeGoal);
                        _dbcontext.SaveChanges();
                    }
                    else if (obj.GoalType.Equals(GoalType.Designation))
                    {
                        goal = new DesignationGoal()
                        {
                            Goal = obj.Goal,
                            Weightage = obj.Weightage,
                            Description = obj.Description,
                            Cycle = _dbcontext.ReviewCycles.FirstOrDefault(rc => rc.Id.Equals(obj.Cycle)),
                            Status = _dbcontext.GoalStatuses.FirstOrDefault(gs => gs.Id.Equals(obj.Status)),
                            StartDate = obj.StartDate,
                            EndDate = obj.EndDate,
                            Designation = _dbcontext.Designations.FirstOrDefault(desg => desg.Id.Equals(obj.Designation)),
                            CreatedOn = DateTime.Now,
                            CreatedBy = obj.Employee
                        };

                        _dbcontext.DesignationGoals.Add(goal as DesignationGoal);
                        _dbcontext.SaveChanges();
                    }
                    else if (obj.GoalType.Equals(GoalType.Organization))
                    {
                        goal = new OrganizationGoal()
                        {
                            Goal = obj.Goal,
                            Weightage = obj.Weightage,
                            Description = obj.Description,
                            Cycle = _dbcontext.ReviewCycles.FirstOrDefault(rc => rc.Id.Equals(obj.Cycle)),
                            Status = _dbcontext.GoalStatuses.FirstOrDefault(gs => gs.Id.Equals(obj.Status)),
                            StartDate = obj.StartDate,
                            EndDate = obj.EndDate,
                            Organization = _dbcontext.Organizations.FirstOrDefault(org => org.Id.Equals(obj.Organization)),
                            CreatedOn = DateTime.Now,
                            CreatedBy = obj.Employee
                        };

                        _dbcontext.OrganizationGoals.Add(goal as OrganizationGoal);
                        _dbcontext.SaveChanges();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }

            return true;
        }

        public bool Update(Goals obj)
        {
            try
            {
                object goal = null;
                using (_dbcontext = new AmsContext())
                {
                    GoalStatus status = _dbcontext.GoalStatuses.FirstOrDefault(gs => gs.Id.Equals(obj.Status));
                    ReviewCycle cycle = _dbcontext.ReviewCycles.FirstOrDefault(gs => gs.Id.Equals(obj.Cycle));
                    Employee employee = _dbcontext.Employees.FirstOrDefault(emp => emp.Id.Equals(obj.Employee));

                    if (obj.GoalType.Equals(GoalType.Employee))
                    {
                        using (DbContextTransaction transaction = _dbcontext.Database.BeginTransaction())
                        {
                            EmployeeGoal delGoal = _dbcontext.EmployeeGoals
                                .FirstOrDefault(eg => eg.Goal.Equals(obj.Goal)
                                                      && eg.Status.Equals(status)
                                                      && eg.Cycle.Equals(cycle)
                                                      && eg.Employee.Equals(employee));
                            if (delGoal != null)
                            {
                                _dbcontext.EmployeeGoals.Remove(delGoal);
                            }

                            foreach (var data in obj.Reviewer)
                            {
                                Employee reviewer =
                                    _dbcontext.Employees.FirstOrDefault(rev => rev.Id.Equals(data.Id));

                                goal = new EmployeeGoal
                                {
                                    Goal = obj.Goal,
                                    Weightage = obj.Weightage,
                                    Description = obj.Description,
                                    Cycle = cycle,
                                    Status = status,
                                    StartDate = obj.StartDate,
                                    EndDate = obj.EndDate,
                                    Employee = employee,
                                    Reviewer = reviewer,
                                    CreatedOn = DateTime.Now,
                                    CreatedBy = obj.Employee
                                };

                                _dbcontext.EmployeeGoals.Add(goal as EmployeeGoal);
                                _dbcontext.SaveChanges();
                            }

                            transaction.Commit();
                        }
                    }
                    else if (obj.GoalType.Equals(GoalType.Managerial))
                    {
                        Employee reviewer = _dbcontext.Employees.FirstOrDefault(rev => rev.Id.Equals(obj.Reviewer));
                        goal = new ManagerialEmployeeGoal()
                        {
                            Goal = obj.Goal,
                            Weightage = obj.Weightage,
                            Description = obj.Description,
                            Cycle = cycle,
                            Status = status,
                            StartDate = obj.StartDate,
                            EndDate = obj.EndDate,
                            Employee = employee,
                            CreatedOn = DateTime.Now,
                            CreatedBy = obj.Employee
                        };

                        _dbcontext.ManagerialEmployeeGoals.Add(goal as ManagerialEmployeeGoal);
                        _dbcontext.SaveChanges();
                    }
                    else if (obj.GoalType.Equals(GoalType.Designation))
                    {
                        goal = new DesignationGoal()
                        {
                            Goal = obj.Goal,
                            Weightage = obj.Weightage,
                            Description = obj.Description,
                            Cycle = cycle,
                            Status = status,
                            StartDate = obj.StartDate,
                            EndDate = obj.EndDate,
                            Designation = _dbcontext.Designations
                                .FirstOrDefault(desg => desg.Id.Equals(obj.Designation)),
                            CreatedOn = DateTime.Now,
                            CreatedBy = obj.Employee
                        };

                        _dbcontext.DesignationGoals.Add(goal as DesignationGoal);
                        _dbcontext.SaveChanges();
                    }
                    else if (obj.GoalType.Equals(GoalType.Organization))
                    {
                        goal = new OrganizationGoal()
                        {
                            Goal = obj.Goal,
                            Weightage = obj.Weightage,
                            Description = obj.Description,
                            Cycle = cycle,
                            Status = status,
                            StartDate = obj.StartDate,
                            EndDate = obj.EndDate,
                            Organization = _dbcontext.Organizations.FirstOrDefault(org => org.Id.Equals(obj.Organization)),
                            CreatedOn = DateTime.Now,
                            CreatedBy = obj.Employee
                        };

                        _dbcontext.OrganizationGoals.Add(goal as OrganizationGoal);
                        _dbcontext.SaveChanges();
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }

            return true;
        }

        public bool Delete(object Id)
        {
            throw new NotImplementedException();
        }
    }

    public class Goals
    {
        public int Id { get; set; }
        public string Goal { get; set; }
        public int GoalType { get; set; }
        public string Description { get; set; }
        public int Cycle { get; set; }
        public int Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Employee { get; set; }
        public List<Data> Reviewer { get; set; }
        public int Weightage { get; set; }
        public int Designation { get; set; }
        public int Organization { get; set; }
    }

    public class Data
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public int Value { get; set; }
    }
}