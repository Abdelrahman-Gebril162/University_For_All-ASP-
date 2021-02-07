namespace University_For_All.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ValidateInstructor : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Instructors", "ints_fname", c => c.String(nullable: false));
            AlterColumn("dbo.Instructors", "inst_lname", c => c.String(nullable: false));
            AlterColumn("dbo.Instructors", "ints_email", c => c.String(nullable: false));
            AlterColumn("dbo.Instructors", "inst_password", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Instructors", "inst_confirmPassword", c => c.String(nullable: false));
            AlterColumn("dbo.Instructors", "inst_picture", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Instructors", "inst_picture", c => c.String());
            AlterColumn("dbo.Instructors", "inst_confirmPassword", c => c.String());
            AlterColumn("dbo.Instructors", "inst_password", c => c.String());
            AlterColumn("dbo.Instructors", "ints_email", c => c.String());
            AlterColumn("dbo.Instructors", "inst_lname", c => c.String());
            AlterColumn("dbo.Instructors", "ints_fname", c => c.String());
        }
    }
}
