namespace University_For_All.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addLatterToGradeModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Grades", "Latter", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Grades", "Latter");
        }
    }
}
