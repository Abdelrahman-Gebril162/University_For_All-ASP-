namespace University_For_All.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adddatatograde1 : DbMigration
    {
        public override void Up()
        {
            Sql("insert into Grades(points) values(0)");
        }
        
        public override void Down()
        {
        }
    }
}
