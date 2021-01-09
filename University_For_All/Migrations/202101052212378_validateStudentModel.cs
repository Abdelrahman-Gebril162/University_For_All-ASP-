namespace University_For_All.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class validateStudentModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "st_picture", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "st_picture", c => c.String(nullable: false));
        }
    }
}
