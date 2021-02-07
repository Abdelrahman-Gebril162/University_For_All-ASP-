namespace University_For_All.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class validateDepartmentModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Departments", "name", c => c.String(nullable: false));
            AlterColumn("dbo.Departments", "description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Departments", "description", c => c.String());
            AlterColumn("dbo.Departments", "name", c => c.String());
        }
    }
}
