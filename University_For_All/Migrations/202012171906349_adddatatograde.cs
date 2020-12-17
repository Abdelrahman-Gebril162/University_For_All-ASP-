namespace University_For_All.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adddatatograde : DbMigration
    {
        public override void Up()
        {
            Sql("insert into Grades(points) values(1)");
            Sql("insert into Grades(points) values(2)");
            Sql("insert into Grades(points) values(3)");
            Sql("insert into Grades(points) values(4)");

        }
        
        public override void Down()
        {
        }
    }
}
