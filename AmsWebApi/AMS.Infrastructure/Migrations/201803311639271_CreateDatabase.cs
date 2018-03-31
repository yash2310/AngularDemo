namespace AMS.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedOn = c.DateTime(),
                        UpdatedBy = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        EmployeeNo = c.String(nullable: false),
                        ContactNo = c.Long(nullable: false),
                        Password = c.String(nullable: false),
                        JoiningDate = c.DateTime(nullable: false),
                        ImageUrl = c.String(nullable: false),
                        NewUser = c.Boolean(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedOn = c.DateTime(),
                        UpdatedBy = c.Int(),
                        Department_Id = c.Int(),
                        Organization_Id = c.Int(),
                        Designation_Id = c.Int(),
                        ReportingManager_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.Department_Id)
                .ForeignKey("dbo.Organizations", t => t.Organization_Id)
                .ForeignKey("dbo.Designations", t => t.Designation_Id)
                .ForeignKey("dbo.Employees", t => t.ReportingManager_Id)
                .Index(t => t.Department_Id)
                .Index(t => t.Organization_Id)
                .Index(t => t.Designation_Id)
                .Index(t => t.ReportingManager_Id);
            
            CreateTable(
                "dbo.Designations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedOn = c.DateTime(),
                        UpdatedBy = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DesignationGoals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Goal = c.String(nullable: false),
                        Weightage = c.Int(nullable: false),
                        Description = c.String(nullable: false, maxLength: 500),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedOn = c.DateTime(),
                        UpdatedBy = c.Int(),
                        Cycle_Id = c.Int(nullable: false),
                        Designation_Id = c.Int(nullable: false),
                        Status_Id = c.Int(nullable: false),
                        Employee_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ReviewCycles", t => t.Cycle_Id, cascadeDelete: true)
                .ForeignKey("dbo.Designations", t => t.Designation_Id, cascadeDelete: true)
                .ForeignKey("dbo.GoalStatus", t => t.Status_Id, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.Employee_Id)
                .Index(t => t.Cycle_Id)
                .Index(t => t.Designation_Id)
                .Index(t => t.Status_Id)
                .Index(t => t.Employee_Id);
            
            CreateTable(
                "dbo.ReviewCycles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        StartMonth = c.Int(nullable: false),
                        EndMonth = c.Int(nullable: false),
                        Status = c.Boolean(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedOn = c.DateTime(),
                        UpdatedBy = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EmployeeGoals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Goal = c.String(nullable: false),
                        Weightage = c.Int(nullable: false),
                        Description = c.String(nullable: false, maxLength: 500),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedOn = c.DateTime(),
                        UpdatedBy = c.Int(),
                        Cycle_Id = c.Int(nullable: false),
                        Employee_Id = c.Int(nullable: false),
                        Reviewer_Id = c.Int(nullable: false),
                        Status_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ReviewCycles", t => t.Cycle_Id, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.Employee_Id)
                .ForeignKey("dbo.Employees", t => t.Reviewer_Id, cascadeDelete: true)
                .ForeignKey("dbo.GoalStatus", t => t.Status_Id, cascadeDelete: true)
                .Index(t => t.Cycle_Id)
                .Index(t => t.Employee_Id)
                .Index(t => t.Reviewer_Id)
                .Index(t => t.Status_Id);
            
            CreateTable(
                "dbo.GoalStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedOn = c.DateTime(),
                        UpdatedBy = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ManagerialEmployeeGoals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Goal = c.String(nullable: false),
                        Weightage = c.Int(nullable: false),
                        Description = c.String(nullable: false, maxLength: 500),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedOn = c.DateTime(),
                        UpdatedBy = c.Int(),
                        Cycle_Id = c.Int(nullable: false),
                        Employee_Id = c.Int(nullable: false),
                        Reviewer_Id = c.Int(),
                        Status_Id = c.Int(nullable: false),
                        Employee_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ReviewCycles", t => t.Cycle_Id, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.Employee_Id, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.Reviewer_Id)
                .ForeignKey("dbo.GoalStatus", t => t.Status_Id, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.Employee_Id1)
                .Index(t => t.Cycle_Id)
                .Index(t => t.Employee_Id)
                .Index(t => t.Reviewer_Id)
                .Index(t => t.Status_Id)
                .Index(t => t.Employee_Id1);
            
            CreateTable(
                "dbo.OrganizationGoals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Goal = c.String(nullable: false),
                        Weightage = c.Int(nullable: false),
                        Description = c.String(nullable: false, maxLength: 500),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedOn = c.DateTime(),
                        UpdatedBy = c.Int(),
                        Cycle_Id = c.Int(nullable: false),
                        Organization_Id = c.Int(nullable: false),
                        Status_Id = c.Int(nullable: false),
                        Employee_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ReviewCycles", t => t.Cycle_Id, cascadeDelete: true)
                .ForeignKey("dbo.Organizations", t => t.Organization_Id, cascadeDelete: true)
                .ForeignKey("dbo.GoalStatus", t => t.Status_Id, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.Employee_Id)
                .Index(t => t.Cycle_Id)
                .Index(t => t.Organization_Id)
                .Index(t => t.Status_Id)
                .Index(t => t.Employee_Id);
            
            CreateTable(
                "dbo.Organizations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedOn = c.DateTime(),
                        UpdatedBy = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GoalId = c.Int(nullable: false),
                        GoalType = c.Int(nullable: false),
                        Rate = c.Single(nullable: false),
                        Comment = c.String(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedOn = c.DateTime(),
                        UpdatedBy = c.Int(),
                        Ratee_Id = c.Int(nullable: false),
                        Rater_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.Ratee_Id, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.Rater_Id)
                .Index(t => t.Ratee_Id)
                .Index(t => t.Rater_Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedOn = c.DateTime(),
                        UpdatedBy = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.NotificationLogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                        Subject = c.String(nullable: false),
                        Message = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RatingLogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rating = c.Single(nullable: false),
                        Feedback = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedOn = c.DateTime(),
                        UpdatedBy = c.Int(),
                        Designation_Id = c.Int(),
                        Employee_Id = c.Int(),
                        ReportingManager_Id = c.Int(),
                        ReviewCycle_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Designations", t => t.Designation_Id)
                .ForeignKey("dbo.Employees", t => t.Employee_Id)
                .ForeignKey("dbo.Employees", t => t.ReportingManager_Id)
                .ForeignKey("dbo.ReviewCycles", t => t.ReviewCycle_Id)
                .Index(t => t.Designation_Id)
                .Index(t => t.Employee_Id)
                .Index(t => t.ReportingManager_Id)
                .Index(t => t.ReviewCycle_Id);
            
            CreateTable(
                "dbo.RatingStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedOn = c.DateTime(),
                        UpdatedBy = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Settings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Days = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedOn = c.DateTime(),
                        UpdatedBy = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RoleEmployees",
                c => new
                    {
                        Role_Id = c.Int(nullable: false),
                        Employee_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Role_Id, t.Employee_Id })
                .ForeignKey("dbo.Roles", t => t.Role_Id, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.Employee_Id, cascadeDelete: true)
                .Index(t => t.Role_Id)
                .Index(t => t.Employee_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RatingLogs", "ReviewCycle_Id", "dbo.ReviewCycles");
            DropForeignKey("dbo.RatingLogs", "ReportingManager_Id", "dbo.Employees");
            DropForeignKey("dbo.RatingLogs", "Employee_Id", "dbo.Employees");
            DropForeignKey("dbo.RatingLogs", "Designation_Id", "dbo.Designations");
            DropForeignKey("dbo.RoleEmployees", "Employee_Id", "dbo.Employees");
            DropForeignKey("dbo.RoleEmployees", "Role_Id", "dbo.Roles");
            DropForeignKey("dbo.Employees", "ReportingManager_Id", "dbo.Employees");
            DropForeignKey("dbo.Ratings", "Rater_Id", "dbo.Employees");
            DropForeignKey("dbo.Ratings", "Ratee_Id", "dbo.Employees");
            DropForeignKey("dbo.OrganizationGoals", "Employee_Id", "dbo.Employees");
            DropForeignKey("dbo.ManagerialEmployeeGoals", "Employee_Id1", "dbo.Employees");
            DropForeignKey("dbo.DesignationGoals", "Employee_Id", "dbo.Employees");
            DropForeignKey("dbo.Employees", "Designation_Id", "dbo.Designations");
            DropForeignKey("dbo.DesignationGoals", "Status_Id", "dbo.GoalStatus");
            DropForeignKey("dbo.DesignationGoals", "Designation_Id", "dbo.Designations");
            DropForeignKey("dbo.DesignationGoals", "Cycle_Id", "dbo.ReviewCycles");
            DropForeignKey("dbo.OrganizationGoals", "Status_Id", "dbo.GoalStatus");
            DropForeignKey("dbo.OrganizationGoals", "Organization_Id", "dbo.Organizations");
            DropForeignKey("dbo.Employees", "Organization_Id", "dbo.Organizations");
            DropForeignKey("dbo.OrganizationGoals", "Cycle_Id", "dbo.ReviewCycles");
            DropForeignKey("dbo.ManagerialEmployeeGoals", "Status_Id", "dbo.GoalStatus");
            DropForeignKey("dbo.ManagerialEmployeeGoals", "Reviewer_Id", "dbo.Employees");
            DropForeignKey("dbo.ManagerialEmployeeGoals", "Employee_Id", "dbo.Employees");
            DropForeignKey("dbo.ManagerialEmployeeGoals", "Cycle_Id", "dbo.ReviewCycles");
            DropForeignKey("dbo.EmployeeGoals", "Status_Id", "dbo.GoalStatus");
            DropForeignKey("dbo.EmployeeGoals", "Reviewer_Id", "dbo.Employees");
            DropForeignKey("dbo.EmployeeGoals", "Employee_Id", "dbo.Employees");
            DropForeignKey("dbo.EmployeeGoals", "Cycle_Id", "dbo.ReviewCycles");
            DropForeignKey("dbo.Employees", "Department_Id", "dbo.Departments");
            DropIndex("dbo.RoleEmployees", new[] { "Employee_Id" });
            DropIndex("dbo.RoleEmployees", new[] { "Role_Id" });
            DropIndex("dbo.RatingLogs", new[] { "ReviewCycle_Id" });
            DropIndex("dbo.RatingLogs", new[] { "ReportingManager_Id" });
            DropIndex("dbo.RatingLogs", new[] { "Employee_Id" });
            DropIndex("dbo.RatingLogs", new[] { "Designation_Id" });
            DropIndex("dbo.Ratings", new[] { "Rater_Id" });
            DropIndex("dbo.Ratings", new[] { "Ratee_Id" });
            DropIndex("dbo.OrganizationGoals", new[] { "Employee_Id" });
            DropIndex("dbo.OrganizationGoals", new[] { "Status_Id" });
            DropIndex("dbo.OrganizationGoals", new[] { "Organization_Id" });
            DropIndex("dbo.OrganizationGoals", new[] { "Cycle_Id" });
            DropIndex("dbo.ManagerialEmployeeGoals", new[] { "Employee_Id1" });
            DropIndex("dbo.ManagerialEmployeeGoals", new[] { "Status_Id" });
            DropIndex("dbo.ManagerialEmployeeGoals", new[] { "Reviewer_Id" });
            DropIndex("dbo.ManagerialEmployeeGoals", new[] { "Employee_Id" });
            DropIndex("dbo.ManagerialEmployeeGoals", new[] { "Cycle_Id" });
            DropIndex("dbo.EmployeeGoals", new[] { "Status_Id" });
            DropIndex("dbo.EmployeeGoals", new[] { "Reviewer_Id" });
            DropIndex("dbo.EmployeeGoals", new[] { "Employee_Id" });
            DropIndex("dbo.EmployeeGoals", new[] { "Cycle_Id" });
            DropIndex("dbo.DesignationGoals", new[] { "Employee_Id" });
            DropIndex("dbo.DesignationGoals", new[] { "Status_Id" });
            DropIndex("dbo.DesignationGoals", new[] { "Designation_Id" });
            DropIndex("dbo.DesignationGoals", new[] { "Cycle_Id" });
            DropIndex("dbo.Employees", new[] { "ReportingManager_Id" });
            DropIndex("dbo.Employees", new[] { "Designation_Id" });
            DropIndex("dbo.Employees", new[] { "Organization_Id" });
            DropIndex("dbo.Employees", new[] { "Department_Id" });
            DropTable("dbo.RoleEmployees");
            DropTable("dbo.Settings");
            DropTable("dbo.RatingStatus");
            DropTable("dbo.RatingLogs");
            DropTable("dbo.NotificationLogs");
            DropTable("dbo.Roles");
            DropTable("dbo.Ratings");
            DropTable("dbo.Organizations");
            DropTable("dbo.OrganizationGoals");
            DropTable("dbo.ManagerialEmployeeGoals");
            DropTable("dbo.GoalStatus");
            DropTable("dbo.EmployeeGoals");
            DropTable("dbo.ReviewCycles");
            DropTable("dbo.DesignationGoals");
            DropTable("dbo.Designations");
            DropTable("dbo.Employees");
            DropTable("dbo.Departments");
        }
    }
}
