namespace WimDesktop.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class ChangeAdminPWD_ResizeColumns : DbMigration
    {
        public override void Up()
        {
            Sql(@"UPDATE CLINIC SET PASSWORD = '$2a$11$Y0jOVc6dtfMTJxvF/RLkZeoUBKz6HY1azhRgFWt9QnhQ94WkharjK' WHERE ISADMIN = 1");


            Sql(@"ALTER TABLE EXAM ALTER COLUMN SESSION_NAME TYPE VARCHAR(255);");

            Sql(@"ALTER TABLE EXAM_IMAGE ALTER COLUMN NOTES TYPE VARCHAR(2048);");

            Sql(@"ALTER TABLE PATIENT ALTER COLUMN NAME TYPE VARCHAR(255);");
            Sql(@"ALTER TABLE PATIENT ALTER COLUMN RECOMMENDATION TYPE VARCHAR(255);");
            Sql(@"ALTER TABLE PATIENT ALTER COLUMN OBSERVATION TYPE VARCHAR(2048);");
        }
        
        public override void Down()
        {
        }
    }
}
