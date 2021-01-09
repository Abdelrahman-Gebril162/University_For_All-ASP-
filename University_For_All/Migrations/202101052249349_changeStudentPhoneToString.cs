namespace University_For_All.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeStudentPhoneToString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "st_phone", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "st_phone", c => c.Int(nullable: false));
        }
    }
}
