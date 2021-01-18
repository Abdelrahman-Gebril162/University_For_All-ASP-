namespace University_For_All.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addFacultyToInstructor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Instructors", "Facultyid", c => c.Int(nullable: true));
            CreateIndex("dbo.Instructors", "Facultyid");
            AddForeignKey("dbo.Instructors", "Facultyid", "dbo.Faculties", "id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Instructors", "Facultyid", "dbo.Faculties");
            DropIndex("dbo.Instructors", new[] { "Facultyid" });
            DropColumn("dbo.Instructors", "Facultyid");
        }
    }
}
