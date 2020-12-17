namespace University_For_All.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adddatatodepartment : DbMigration
    {
        public override void Up()
        {

            Sql("insert into Departments(name,description,FacultyId) values('software engineering depatrment','about software systems',1)");
            Sql("insert into Departments(name,description,FacultyId) values('electical engineering depatrment','electical system design',2)");
            Sql("insert into Departments(name,description,FacultyId) values('physics depatrment','study of the natural phenomena',3)");
            Sql("insert into Departments(name,description,FacultyId) values('depatrment of neurology','study of human body surgery',4)");


        }

        public override void Down()
        {
        }
    }
}
