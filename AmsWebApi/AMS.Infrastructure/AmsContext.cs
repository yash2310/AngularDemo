using System.Data.Entity;
using Web.ApplicationCore.Entities;
using Web.ApplicationCore.Entities.Security;

namespace AMS.Infrastructure
{
    public class AmsContext : DbContext
    {
        public AmsContext() : base("AmsConnection")
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Role> Roles { get; set; }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<GoalStatus> GoalStatuses { get; set; }
        public DbSet<NotificationLog> NotificationLogs { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<RatingLog> RatingLogs { get; set; }
        public DbSet<RatingStatus> RatingStatuses { get; set; }
        public DbSet<ReviewCycle> ReviewCycles { get; set; }
        public DbSet<Setting> Settings { get; set; }

        public DbSet<EmployeeGoal> EmployeeGoals { get; set; }
        public DbSet<ManagerialEmployeeGoal> ManagerialEmployeeGoals { get; set; }
        public DbSet<DesignationGoal> DesignationGoals { get; set; }
        public DbSet<OrganizationGoal> OrganizationGoals { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeGoal>().HasRequired(emp => emp.Employee).WithMany(goal => goal.EmployeeGoals)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Rating>().HasRequired(emp => emp.Rater).WithMany(rate => rate.Ratings)
                .WillCascadeOnDelete(false);
            base.OnModelCreating(modelBuilder);
        }
    }
}