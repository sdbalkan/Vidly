namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipName : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET Name='Membership 1' WHERE Id=1");
            Sql("UPDATE MembershipTypes SET Name='Membership 2' WHERE Id=2");
            Sql("UPDATE MembershipTypes SET Name='Membership 3' WHERE Id=3");
            Sql("UPDATE MembershipTypes SET Name='Membership 4' WHERE Id=4");
        }

        public override void Down()
        {
        }
    }
}
