namespace University_For_All.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adddatatoinstructor : DbMigration
    {
        public override void Up()
        {

            Sql("insert into Instructors(ints_fname,inst_lname,ints_email,inst_password,inst_confirmPassword,inst_picture,Rankid) values('osama','abdelrahman','osama232gmail.com','fghj67','fghj67','~/images/8.jpg',1)");
            Sql("insert into Instructors(ints_fname,inst_lname,ints_email,inst_password,inst_confirmPassword,inst_picture,Rankid) values('eslam','abdelaziz','eslam_2@gamil.com','jkshud79','jkshud79','~/images/9.jpg',2)");
            Sql("insert into Instructors(ints_fname,inst_lname,ints_email,inst_password,inst_confirmPassword,inst_picture,Rankid) values('ebrahim','gamal','ebrahim34@gamil.com','shvuyc6799','shvuyc6799','~/images/10.jpg',1)");
            Sql("insert into Instructors(ints_fname,inst_lname,ints_email,inst_password,inst_confirmPassword,inst_picture,Rankid) values('yousf','ramadan','yousf-7@gamil.com','bhxfcst66g','bhxfcst66g','~/images/11.jpg',2)");
        }
        
        public override void Down()
        {
        }
    }
}
