namespace University_For_All.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fillAllModels : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Students", "Faculty_id", "dbo.Faculties");
            DropIndex("dbo.Students", new[] { "Faculty_id" });
            DropColumn("dbo.Students", "FacultyId");
            RenameColumn(table: "dbo.Students", name: "Faculty_id", newName: "FacultyId");
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        cr_title = c.String(),
                        cr_credit_hours = c.Int(nullable: false),
                        cr_term = c.Int(nullable: false),
                        cr_level = c.Int(nullable: false),
                        Facultyid = c.Int(nullable: false),
                        Instructorid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Faculties", t => t.Facultyid, cascadeDelete: true)
                .ForeignKey("dbo.Instructors", t => t.Instructorid, cascadeDelete: true)
                .Index(t => t.Facultyid)
                .Index(t => t.Instructorid);
            
            CreateTable(
                "dbo.Instructors",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        ints_fname = c.String(),
                        inst_lname = c.String(),
                        ints_email = c.String(),
                        inst_password = c.String(),
                        inst_confirmPassword = c.String(),
                        inst_picture = c.String(),
                        
                        Rankid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                
                .ForeignKey("dbo.Ranks", t => t.Rankid, cascadeDelete: true)
                
                .Index(t => t.Rankid);
            
            CreateTable(
                "dbo.Ranks",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        description = c.String(),
                        Facultyid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Faculties", t => t.Facultyid, cascadeDelete: true)
                .Index(t => t.Facultyid);
            
            CreateTable(
                "dbo.Grades",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        points = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Takes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Studentid = c.Int(nullable: false),
                        Courseid = c.Int(nullable: false),
                        Gradeid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Courses", t => t.Courseid, cascadeDelete: false)
                .ForeignKey("dbo.Grades", t => t.Gradeid, cascadeDelete: false)
                .ForeignKey("dbo.Students", t => t.Studentid, cascadeDelete: false)
                .Index(t => t.Studentid)
                .Index(t => t.Courseid)
                .Index(t => t.Gradeid);
            
            AddColumn("dbo.Students", "st_DateOfBirth", c => c.DateTime(nullable: false));
            AddColumn("dbo.Students", "Undergrad", c => c.Boolean(nullable: false));
            AddColumn("dbo.Students", "enroll_date", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Faculties", "fc_levels_num", c => c.Int(nullable: false));
            AlterColumn("dbo.Faculties", "fc_spicial_year", c => c.Int(nullable: false));
            AlterColumn("dbo.Students", "st_level", c => c.Int(nullable: false));
            AlterColumn("dbo.Students", "FacultyId", c => c.Int(nullable: false));
            AlterColumn("dbo.Students", "FacultyId", c => c.Int(nullable: false));
            CreateIndex("dbo.Students", "FacultyId");
            AddForeignKey("dbo.Students", "FacultyId", "dbo.Faculties", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "FacultyId", "dbo.Faculties");
            DropForeignKey("dbo.Takes", "Studentid", "dbo.Students");
            DropForeignKey("dbo.Takes", "Gradeid", "dbo.Grades");
            DropForeignKey("dbo.Takes", "Courseid", "dbo.Courses");
            DropForeignKey("dbo.Departments", "Facultyid", "dbo.Faculties");
            DropForeignKey("dbo.Courses", "Instructorid", "dbo.Instructors");
            DropForeignKey("dbo.Instructors", "Rankid", "dbo.Ranks");
            DropForeignKey("dbo.Instructors", "Facultyid", "dbo.Faculties");
            DropForeignKey("dbo.Courses", "Facultyid", "dbo.Faculties");
            DropIndex("dbo.Takes", new[] { "Gradeid" });
            DropIndex("dbo.Takes", new[] { "Courseid" });
            DropIndex("dbo.Takes", new[] { "Studentid" });
            DropIndex("dbo.Students", new[] { "FacultyId" });
            DropIndex("dbo.Departments", new[] { "Facultyid" });
            DropIndex("dbo.Instructors", new[] { "Rankid" });
            DropIndex("dbo.Instructors", new[] { "Facultyid" });
            DropIndex("dbo.Courses", new[] { "Instructorid" });
            DropIndex("dbo.Courses", new[] { "Facultyid" });
            AlterColumn("dbo.Students", "FacultyId", c => c.Int());
            AlterColumn("dbo.Students", "FacultyId", c => c.Byte(nullable: false));
            AlterColumn("dbo.Students", "st_level", c => c.Byte(nullable: false));
            AlterColumn("dbo.Faculties", "fc_spicial_year", c => c.Byte(nullable: false));
            AlterColumn("dbo.Faculties", "fc_levels_num", c => c.Byte(nullable: false));
            DropColumn("dbo.Students", "enroll_date");
            DropColumn("dbo.Students", "Undergrad");
            DropColumn("dbo.Students", "st_DateOfBirth");
            DropTable("dbo.Takes");
            DropTable("dbo.Grades");
            DropTable("dbo.Departments");
            DropTable("dbo.Ranks");
            DropTable("dbo.Instructors");
            DropTable("dbo.Courses");
            RenameColumn(table: "dbo.Students", name: "FacultyId", newName: "Faculty_id");
            AddColumn("dbo.Students", "FacultyId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Students", "Faculty_id");
            AddForeignKey("dbo.Students", "Faculty_id", "dbo.Faculties", "id");
        }
    }
}
