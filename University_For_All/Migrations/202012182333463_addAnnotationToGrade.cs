namespace University_For_All.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addAnnotationToGrade : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Grades SET Latter = 'A' WHERE id = 4");
            Sql("UPDATE Grades SET Latter = 'B' WHERE id = 3");
            Sql("UPDATE Grades SET Latter = 'C' WHERE id = 2");
            Sql("UPDATE Grades SET Latter = 'D' WHERE id = 1");
            Sql("UPDATE Grades SET Latter = 'F' WHERE id = 5");
            AlterColumn("dbo.Grades", "Latter", c => c.String(nullable: false, maxLength: 1));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Grades", "Latter", c => c.String());
        }
    }
}
