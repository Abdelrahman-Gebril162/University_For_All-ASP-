namespace University_For_All.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adddatatocourses : DbMigration
    {
        public override void Up()
        {
            Sql("insert into Courses(cr_title,cr_credit_hours,cr_term,cr_level,Facultyid,Instructorid) values('software engineering',3,1,3,1,1)");
            Sql("insert into Courses(cr_title,cr_credit_hours,cr_term,cr_level,Facultyid,Instructorid) values('General Physics',2,2,2,3,1)");
            Sql("insert into Courses(cr_title,cr_credit_hours,cr_term,cr_level,Facultyid,Instructorid) values('Electromagnetic fields',3,1,3,2,1)");
            Sql("insert into Courses(cr_title,cr_credit_hours,cr_term,cr_level,Facultyid,Instructorid) values('Radiology',3,1,4,4,2)");
        }
        
        public override void Down()
        {
        }
    }
}
