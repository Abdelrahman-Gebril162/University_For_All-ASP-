namespace University_For_All.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class compositeUniqueStudentandCourse : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Takes", new[] { "Studentid" });
            DropIndex("dbo.Takes", new[] { "Courseid" });
            CreateIndex("dbo.Takes", new[] { "Studentid", "Courseid" }, unique: true, name: "studentAndCourse");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Takes", "studentAndCourse");
            CreateIndex("dbo.Takes", "Courseid");
            CreateIndex("dbo.Takes", "Studentid");
        }
    }
}
