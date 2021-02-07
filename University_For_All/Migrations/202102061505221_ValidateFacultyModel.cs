namespace University_For_All.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ValidateFacultyModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Faculties", "fc_name", c => c.String(nullable: false));
            AlterColumn("dbo.Faculties", "fc_description", c => c.String(nullable: false));
            AlterColumn("dbo.Faculties", "fc_logo", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Faculties", "fc_logo", c => c.String());
            AlterColumn("dbo.Faculties", "fc_description", c => c.String());
            AlterColumn("dbo.Faculties", "fc_name", c => c.String());
        }
    }
}
