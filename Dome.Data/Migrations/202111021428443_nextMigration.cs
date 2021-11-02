namespace Dome.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nextMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Books", "GenreId", "dbo.Genres");
            DropIndex("dbo.Books", new[] { "GenreId" });
            CreateTable(
                "dbo.BookGenres",
                c => new
                    {
                        BookId = c.Int(nullable: false),
                        GenreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.BookId, t.GenreId })
                .ForeignKey("dbo.Books", t => t.BookId, cascadeDelete: true)
                .ForeignKey("dbo.Genres", t => t.GenreId, cascadeDelete: true)
                .Index(t => t.BookId)
                .Index(t => t.GenreId);
            
            DropColumn("dbo.Books", "GenreId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "GenreId", c => c.Int(nullable: false));
            DropForeignKey("dbo.BookGenres", "GenreId", "dbo.Genres");
            DropForeignKey("dbo.BookGenres", "BookId", "dbo.Books");
            DropIndex("dbo.BookGenres", new[] { "GenreId" });
            DropIndex("dbo.BookGenres", new[] { "BookId" });
            DropTable("dbo.BookGenres");
            CreateIndex("dbo.Books", "GenreId");
            AddForeignKey("dbo.Books", "GenreId", "dbo.Genres", "GenreId", cascadeDelete: true);
        }
    }
}
