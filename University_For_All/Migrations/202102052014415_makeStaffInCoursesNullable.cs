namespace University_For_All.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class makeStaffInCoursesNullable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Courses", "Instructorid", "dbo.Instructors");
            DropIndex("dbo.Courses", new[] { "Instructorid" });
            AlterColumn("dbo.Courses", "Instructorid", c => c.Int());
            CreateIndex("dbo.Courses", "Instructorid");
            AddForeignKey("dbo.Courses", "Instructorid", "dbo.Instructors", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "Instructorid", "dbo.Instructors");
            DropIndex("dbo.Courses", new[] { "Instructorid" });
            AlterColumn("dbo.Courses", "Instructorid", c => c.Int(nullable: false));
            CreateIndex("dbo.Courses", "Instructorid");
            AddForeignKey("dbo.Courses", "Instructorid", "dbo.Instructors", "id", cascadeDelete: true);
        }
    }
}
