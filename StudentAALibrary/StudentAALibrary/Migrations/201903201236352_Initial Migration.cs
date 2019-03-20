namespace StudentAALibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Assessments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AssessmentName = c.String(),
                        Summary = c.String(),
                        MaxGrade = c.Single(nullable: false),
                        ModuleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Modules", t => t.ModuleID, cascadeDelete: true)
                .Index(t => t.ModuleID);
            
            CreateTable(
                "dbo.Modules",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ModuleName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Attendances",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AttendanceDate = c.DateTime(nullable: false),
                        ModuleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Modules", t => t.ModuleID, cascadeDelete: true)
                .Index(t => t.ModuleID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StudentID = c.String(),
                        FName = c.String(),
                        LName = c.String(),
                        Attendance_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Attendances", t => t.Attendance_ID)
                .Index(t => t.Attendance_ID);
            
            CreateTable(
                "dbo.Lecturers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FName = c.String(),
                        LName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.StudentGrades",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Grade = c.Single(nullable: false),
                        AssessmentID = c.Int(nullable: false),
                        StudentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Assessments", t => t.AssessmentID, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentID, cascadeDelete: true)
                .Index(t => t.AssessmentID)
                .Index(t => t.StudentID);
            
            CreateTable(
                "dbo.StudentModules",
                c => new
                    {
                        Student_ID = c.Int(nullable: false),
                        Module_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Student_ID, t.Module_ID })
                .ForeignKey("dbo.Students", t => t.Student_ID, cascadeDelete: true)
                .ForeignKey("dbo.Modules", t => t.Module_ID, cascadeDelete: true)
                .Index(t => t.Student_ID)
                .Index(t => t.Module_ID);
            
            CreateTable(
                "dbo.LecturerModules",
                c => new
                    {
                        Lecturer_ID = c.Int(nullable: false),
                        Module_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Lecturer_ID, t.Module_ID })
                .ForeignKey("dbo.Lecturers", t => t.Lecturer_ID, cascadeDelete: true)
                .ForeignKey("dbo.Modules", t => t.Module_ID, cascadeDelete: true)
                .Index(t => t.Lecturer_ID)
                .Index(t => t.Module_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentGrades", "StudentID", "dbo.Students");
            DropForeignKey("dbo.StudentGrades", "AssessmentID", "dbo.Assessments");
            DropForeignKey("dbo.Assessments", "ModuleID", "dbo.Modules");
            DropForeignKey("dbo.LecturerModules", "Module_ID", "dbo.Modules");
            DropForeignKey("dbo.LecturerModules", "Lecturer_ID", "dbo.Lecturers");
            DropForeignKey("dbo.Students", "Attendance_ID", "dbo.Attendances");
            DropForeignKey("dbo.StudentModules", "Module_ID", "dbo.Modules");
            DropForeignKey("dbo.StudentModules", "Student_ID", "dbo.Students");
            DropForeignKey("dbo.Attendances", "ModuleID", "dbo.Modules");
            DropIndex("dbo.LecturerModules", new[] { "Module_ID" });
            DropIndex("dbo.LecturerModules", new[] { "Lecturer_ID" });
            DropIndex("dbo.StudentModules", new[] { "Module_ID" });
            DropIndex("dbo.StudentModules", new[] { "Student_ID" });
            DropIndex("dbo.StudentGrades", new[] { "StudentID" });
            DropIndex("dbo.StudentGrades", new[] { "AssessmentID" });
            DropIndex("dbo.Students", new[] { "Attendance_ID" });
            DropIndex("dbo.Attendances", new[] { "ModuleID" });
            DropIndex("dbo.Assessments", new[] { "ModuleID" });
            DropTable("dbo.LecturerModules");
            DropTable("dbo.StudentModules");
            DropTable("dbo.StudentGrades");
            DropTable("dbo.Lecturers");
            DropTable("dbo.Students");
            DropTable("dbo.Attendances");
            DropTable("dbo.Modules");
            DropTable("dbo.Assessments");
        }
    }
}
