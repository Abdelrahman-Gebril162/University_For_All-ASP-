namespace University_For_All.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addFaculty : DbMigration
    {
        public override void Up()
        {
            Sql("insert into Faculties (fc_name,fc_description,fc_created_at,fc_levels_num,fc_spicial_year,fc_logo) values ('fci','teaches computer', '2020-6-1',4,3,'~/photo/abdo.jpg')");
        }
        
        public override void Down()
        {
        }
    }
}
