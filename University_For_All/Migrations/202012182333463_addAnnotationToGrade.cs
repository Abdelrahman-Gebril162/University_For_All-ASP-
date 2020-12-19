namespace University_For_All.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addAnnotationToGrade : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Grades", "Latter", c => c.String(nullable: false, maxLength: 1));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Grades", "Latter", c => c.String());
        }
    }
}
