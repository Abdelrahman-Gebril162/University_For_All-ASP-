namespace University_For_All.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adddatatofaculties : DbMigration
    {
        public override void Up()
        {
            Sql("insert into Faculties (fc_name,fc_description,fc_created_at,fc_levels_num,fc_spicial_year,fc_logo) values ('fci','teaches computer', '2020-6-1',4,3,'~/images/abdo.jpg')");
            Sql("insert into Faculties (fc_name,fc_description,fc_created_at,fc_levels_num,fc_spicial_year,fc_logo) values ('faculty  of engineering','teaching engineering','2009-1-12',5,2,'~/images/3.jpg')");
            Sql("insert into Faculties (fc_name,fc_description,fc_created_at,fc_levels_num,fc_spicial_year,fc_logo) values ('faculty of science','teaching science','2015-11-9',4,2,'~/images/1.jpg')");
            Sql("insert into Faculties (fc_name,fc_description,fc_created_at,fc_levels_num,fc_spicial_year,fc_logo) values ('faculty of medicine','teaching medicine','2016-7-4',7,5,'~/images/2.jpg')");

        }
        
        public override void Down()
        {
        }
    }
}
