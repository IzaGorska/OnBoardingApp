namespace WebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Assignment",
                c => new
                    {
                        AssignmentID = c.Int(nullable: false, identity: true),
                        EmployeeID = c.Int(nullable: false),
                        ProjectID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AssignmentID)
                .ForeignKey("dbo.Employee", t => t.EmployeeID, cascadeDelete: true)
                .ForeignKey("dbo.Project", t => t.ProjectID, cascadeDelete: true)
                .Index(t => t.EmployeeID)
                .Index(t => t.ProjectID);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 20),
                        LastName = c.String(nullable: false, maxLength: 20),
                        Location = c.Int(nullable: false),
                        Contract = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Project",
                c => new
                    {
                        ProjectID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ProjectID);
            
            CreateTable(
                "dbo.Step",
                c => new
                    {
                        StepID = c.Int(nullable: false, identity: true),
                        ProjectID = c.Int(nullable: false),
                        Name = c.String(),
                        Info = c.String(),
                    })
                .PrimaryKey(t => t.StepID)
                .ForeignKey("dbo.Project", t => t.ProjectID, cascadeDelete: true)
                .Index(t => t.ProjectID);
            
            CreateTable(
                "dbo.ProjectEmployee",
                c => new
                    {
                        Project_ProjectID = c.Int(nullable: false),
                        Employee_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Project_ProjectID, t.Employee_ID })
                .ForeignKey("dbo.Project", t => t.Project_ProjectID, cascadeDelete: true)
                .ForeignKey("dbo.Employee", t => t.Employee_ID, cascadeDelete: true)
                .Index(t => t.Project_ProjectID)
                .Index(t => t.Employee_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Step", "ProjectID", "dbo.Project");
            DropForeignKey("dbo.ProjectEmployee", "Employee_ID", "dbo.Employee");
            DropForeignKey("dbo.ProjectEmployee", "Project_ProjectID", "dbo.Project");
            DropForeignKey("dbo.Assignment", "ProjectID", "dbo.Project");
            DropForeignKey("dbo.Assignment", "EmployeeID", "dbo.Employee");
            DropIndex("dbo.ProjectEmployee", new[] { "Employee_ID" });
            DropIndex("dbo.ProjectEmployee", new[] { "Project_ProjectID" });
            DropIndex("dbo.Step", new[] { "ProjectID" });
            DropIndex("dbo.Assignment", new[] { "ProjectID" });
            DropIndex("dbo.Assignment", new[] { "EmployeeID" });
            DropTable("dbo.ProjectEmployee");
            DropTable("dbo.Step");
            DropTable("dbo.Project");
            DropTable("dbo.Employee");
            DropTable("dbo.Assignment");
        }
    }
}
