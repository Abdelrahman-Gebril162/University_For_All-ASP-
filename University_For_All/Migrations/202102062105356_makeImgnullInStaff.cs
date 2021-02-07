namespace University_For_All.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class makeImgnullInStaff : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Instructors", "inst_picture", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Instructors", "inst_picture", c => c.String(nullable: false));
        }
    }
}
