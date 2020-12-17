namespace University_For_All.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adddatatostudent : DbMigration
    {
        public override void Up()
        {
            Sql("insert into Students(st_fname,st_lname,st_address,st_city,st_phone,st_email,st_password,st_confirmPassword,st_picture,st_level,FacultyId,st_DateOfBirth, Undergrad,enroll_date) values('ahmed','mohamed','25 gamal abdelnasr st','alex',0126985478,'ahmed2@gmail.com','aasdf45','aasdf45','~/images/4.jpg',2,1,'1997-10-5','false','2019-2-10')");
            Sql("insert into Students(st_fname,st_lname,st_address,st_city,st_phone,st_email,st_password,st_confirmPassword,st_picture,st_level,FacultyId,st_DateOfBirth, Undergrad,enroll_date) values('ali','moustafa','13 elhoria st','cairo',0123698745,'ali_9@gmail.com','859cxvb87','859cxvb87','~/images/5.jpg',1,2,'2002-11-10','false','2020-4-11')");
            Sql("insert into Students(st_fname,st_lname,st_address,st_city,st_phone,st_email,st_password,st_confirmPassword,st_picture,st_level,FacultyId,st_DateOfBirth, Undergrad,enroll_date) values('aya','mahmoud','25 smouha st','alex',0101236598,'aya_mahmoud11@gamil.com','416sfghjk39','416sfghjk39','~/images/6.jpg',4,3,'1998-8-2','false','2018-6-4')");
            Sql("insert into Students(st_fname,st_lname,st_address,st_city,st_phone,st_email,st_password,st_confirmPassword,st_picture,st_level,FacultyId,st_DateOfBirth, Undergrad,enroll_date) values('mona','magdy','agamy distinct',null,0150236987,'mona78@gmail.com','asfgnn74136','asfgnn74136','~/images/7.jpg',3,4,'2000-12-10','false','2018-8-10')");

        }

        public override void Down()
        {
        }
    }
}
