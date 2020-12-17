namespace University_For_All.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adddatatotakes : DbMigration
    {
        public override void Up()
        {
            Sql("insert into Takes(Studentid,Courseid,Gradeid) values(1,2,1)");
            Sql("insert into Takes(Studentid,Courseid,Gradeid) values(2,3,2)");
            Sql("insert into Takes(Studentid,Courseid,Gradeid) values(4,1,3)");
        }
        
        public override void Down()
        {
        }
    }
}
