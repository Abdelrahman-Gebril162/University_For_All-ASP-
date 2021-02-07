namespace University_For_All.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ValidateTakemodel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Takes", "Gradeid", "dbo.Grades");
            DropIndex("dbo.Takes", new[] { "Gradeid" });
            AlterColumn("dbo.Takes", "Gradeid", c => c.Int());
            CreateIndex("dbo.Takes", "Gradeid");
            AddForeignKey("dbo.Takes", "Gradeid", "dbo.Grades", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Takes", "Gradeid", "dbo.Grades");
            DropIndex("dbo.Takes", new[] { "Gradeid" });
            AlterColumn("dbo.Takes", "Gradeid", c => c.Int(nullable: false));
            CreateIndex("dbo.Takes", "Gradeid");
            AddForeignKey("dbo.Takes", "Gradeid", "dbo.Grades", "id", cascadeDelete: true);
        }
    }
}
