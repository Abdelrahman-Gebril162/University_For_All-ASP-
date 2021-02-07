namespace University_For_All.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ValidateCourseModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Courses", "cr_title", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Courses", "cr_title", c => c.String());
        }
    }
}
