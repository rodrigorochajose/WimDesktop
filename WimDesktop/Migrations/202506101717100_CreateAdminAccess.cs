namespace WimDesktop.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class CreateAdminAccess : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO CLINIC (NAME, EMAIL, PASSWORD, ISADMIN, AUTOMATIC_LOGIN) VALUES ('Admin', 'admin', '$2a$11$B370Yz5Fg3CfTm6o4fw/qeB6cS2hSJjgEkPhQ2ZWfUbQu..jVtGjK', 1, 0);");
        }
        
        public override void Down()
        {
        }
    }
}
