namespace _1WelcomeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenreIdInMovie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "GenreId", c => c.Byte(nullable: false));
            DropColumn("dbo.Movies", "Publisher");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "Publisher", c => c.String());
            DropColumn("dbo.Movies", "GenreId");
        }
    }
}
