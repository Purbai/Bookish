using Bookish.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookish
{
    public class BookishContext : DbContext
    {
/* 
         string connString = "Server=localhost;Port=5432;Database=bookish;User Id=Bookish;Password=Bookish;";

        public BookishContext() : base("name=connString")
        {
            Database.SetInitializer<BookishContext>(new DropCreateDatabaseIfModelChanges<BookishContext>());
        } */
 
        // Put all the tables you want in your database here
        public DbSet<Author> Author { get; set; }
        public DbSet<Catalogue> Catalogue { get; set; }
        public DbSet<CatalogueInstance> CatalogueInstance { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<ItemType> ItemType { get; set; }
        public DbSet<Librarian> Librarian { get; set; }
        public DbSet<Penalty> Penalty { get; set; }
        public DbSet<User> User { get; set; }
        // public DbSet<CatalogueList> CatalogueList { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // This is the configuration used for connecting to the database
            optionsBuilder.UseNpgsql(@"Server=localhost;Port=5432;Database=bookish;User Id=Bookish;Password=Bookish;");
        }
    }

}