namespace University_For_All.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class imgNullInFaculty : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Faculties", "fc_logo", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Faculties", "fc_logo", c => c.String(nullable: false));
        }
    }
}
