namespace University_For_All.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adddatatorank : DbMigration
    {
        public override void Up()
        {
            Sql("insert into Ranks(name) values('Professor')");
            Sql("insert into Ranks(name) values('Assistant')");
        }
        
        public override void Down()
        {
        }
    }
}
