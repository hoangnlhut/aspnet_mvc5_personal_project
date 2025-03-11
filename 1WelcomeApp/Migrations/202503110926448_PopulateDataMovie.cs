namespace _1WelcomeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateDataMovie : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movies (Name, ReleaseDate, DateAdded, NumberInStock, Genre_Id) VALUES ('Die Hard', '1988-07-20', '2025-03-11', 5, 1)");
            Sql("INSERT INTO Movies (Name, ReleaseDate, DateAdded, NumberInStock, Genre_Id) VALUES ('The Dark Knight', '2008-07-18', '2025-03-11', 5, 1)");
            Sql("INSERT INTO Movies (Name, ReleaseDate, DateAdded, NumberInStock, Genre_Id) VALUES ('The Lion King', '1994-06-24', '2025-03-11', 5, 3)");
            Sql("INSERT INTO Movies (Name, ReleaseDate, DateAdded, NumberInStock, Genre_Id) VALUES ('Titanic', '1997-12-19', '2025-03-11', 5, 4)");
            Sql("INSERT INTO Movies (Name, ReleaseDate, DateAdded, NumberInStock, Genre_Id) VALUES ('The Hangover', '2009-06-05', '2025-03-11', 5, 5)");
        }

        public override void Down()
        {
        }
    }
}
