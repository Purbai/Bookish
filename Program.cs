using System.Runtime.CompilerServices;
using Bookish;
using Bookish.Models;
using Microsoft.EntityFrameworkCore;
// using Newtonsoft.Json;
// using NLog;
// using NLog.Config;
// using NLog.Targets;
// using System.Xml;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


using (var context = new BookishContext())
{
    //creates db if not exists 
    context.Database.EnsureCreated();

    /*    using (var reader = new StreamReader(".\\data-Author.csv"))

       reader.ReadLine();
       while (!reader.EndOfStream)
       {
           var authorLine = reader.ReadLine();
           var authorValues = authorLine.Split(',');

           var author = new Author()
           {
               Id = Int32.Parse(values[0]),
               Name = values[1]
           };
           context.Author.Add(author);

           context.SaveChanges();
       } */

    //create entity objects
    //authors setup

    CreateAuthorData(context);

    // Librarian data setup
    CreateLibrarianData(context);

    // Penalty data setup
    CreatePenaltyData(context);

    // User data setup
    CreateUserData(context);

    // Item Type data setup
    CreateItemTypeData(context);

    // Genre Data setup
    CreateGenreData(context);

    //Catalogue Data setup
    CreateCatalogueData(context);
    
    CreateCatalogueInstanceData(context);
 

    // create catalogue view ....
    CreateCatalogueListView(context);

    //Console.WriteLine($"Creating CatalogueList view : {fs},: {createVwSql}");

    Console.WriteLine("output from CatalogueList view .... ");
    // retrieve all the students from the database
    foreach (var a in context.CatalogueList)
    {
        Console.WriteLine($"Id: {a.Id}, Authr Name: {a.Name}, Title: {a.Title}, Publication Date: {a.PublishDate}, Genre: {a.Description}, No of Copies: {a.Copies}, Item Type: {a.ItemTypeName}");
    }

    // //retrieve all the students from the database
    // foreach (var s in context.User) {
    //     Console.WriteLine($"Id: {s.Id}, Name: {s.Name}, Outstanding Fee: {s.OutStandingFees}");
    // }

    // Add data to all our tables except borrowed and return tables
    //Show data from database in frontend
    // add menu bar to allow user to add data or query data from front-end
    // validation to ensure that foreign is valid if used to add data which uses foreign key
    // do not allow data to be deleted if primary key is used as foriegn key in another table
    // allow user to sort data in the catalogue table
    // Allow user to borrow a item instance from catalogue
    // Allow user to return a item instance & work out if any penalty is payable
    //Allow librarian to add/remove item instances
    //Allow librarian to retrieve and organize catalogue

}


app.Run();

static void CreateGenreData(BookishContext context)
{
    var sqlString= "delete from \"Genre\"";
    var fSqlString = FormattableStringFactory.Create(sqlString);
    var delDataSql = context.Database.ExecuteSql(fSqlString);
    Console.WriteLine($"Deleting : {fSqlString},no of row deleted: {delDataSql}");
    var genre1 = new Genre() { Id = 1, Description = "Fiction" };
    var genre2 = new Genre() { Id = 2, Description = "Non-Fiction" };
    var genre3 = new Genre() { Id = 3, Description = "Religion" };
    var genre4 = new Genre() { Id = 4, Description = "Science" };
    var genre5 = new Genre() { Id = 5, Description = "Cooking" };
    var genre6 = new Genre() { Id = 6, Description = "Sports" };
    var genre7 = new Genre() { Id = 7, Description = "Walking" };
    var genre8 = new Genre() { Id = 8, Description = "Music" };
    context.Genre.Add(genre1);
    context.Genre.Add(genre2);
    context.Genre.Add(genre3);
    context.Genre.Add(genre4);
    context.Genre.Add(genre5);
    context.Genre.Add(genre6);
    context.Genre.Add(genre7);
    context.Genre.Add(genre8);
    context.SaveChanges();
    Console.WriteLine("setup data for Genre ....");
}

static void CreateItemTypeData(BookishContext context)
{
  
    var sqlString = "delete from \"ItemType\"";
    var fSqlString = FormattableStringFactory.Create(sqlString);
    var delDataSql = context.Database.ExecuteSql(fSqlString);
    Console.WriteLine($"Deleting : {fSqlString},no of row deleted: {delDataSql}");
    var itemType1 = new ItemType() { Id = 1, ItemTypeName = "Book", MaxBorrowingPeriod = 21 };
    var itemType2 = new ItemType() { Id = 3, ItemTypeName = "Newspaper/Magazine", MaxBorrowingPeriod = 5 };
    var itemType3 = new ItemType() { Id = 2, ItemTypeName = "CD", MaxBorrowingPeriod = 14 };
    context.ItemType.Add(itemType1);
    context.ItemType.Add(itemType2);
    context.ItemType.Add(itemType3);
    context.SaveChanges();
    Console.WriteLine("setup data for ItemType ....");
}

static void CreateUserData(BookishContext context)
{
    var sqlString = "delete from \"User\"";
    var fSqlString = FormattableStringFactory.Create(sqlString);
    var delDataSql = context.Database.ExecuteSql(fSqlString);
    Console.WriteLine($"Deleting : {fSqlString},no of row deleted: {delDataSql}");
    var user1 = new User() { Id = 1, Name = "Yash", OutStandingFees = 0.0M };
    var user2 = new User() { Id = 2, Name = "Kiran", OutStandingFees = 0.0M };
    var user3 = new User() { Id = 3, Name = "Sasha", OutStandingFees = 0.20M };
    context.User.Add(user1);
    context.User.Add(user2);
    context.User.Add(user3);
    context.SaveChanges();
    Console.WriteLine("setup data for User ....");
}

static void CreatePenaltyData(BookishContext context)
{
    var sqlString = "delete from \"Penalty\"";
    var fSqlString = FormattableStringFactory.Create(sqlString);
    var delDataSql = context.Database.ExecuteSql(fSqlString);
    Console.WriteLine($"Deleting : {fSqlString},no of row deleted: {delDataSql}");
    // needed to 'M' for the decimal values
    var penalty1 = new Penalty() { Id = 1, ItemType = "Book", PenaltyPerDay = 0.25M };
    var penalty2 = new Penalty() { Id = 2, ItemType = "CD", PenaltyPerDay = 0.50M };
    var penalty3 = new Penalty() { Id = 3, ItemType = "Newspaper/Magazine", PenaltyPerDay = 0.10M };
    context.Penalty.Add(penalty1);
    context.Penalty.Add(penalty2);
    context.Penalty.Add(penalty3);
    context.SaveChanges();
    Console.WriteLine("setup data for Penalty ....");
    }

static void CreateLibrarianData(BookishContext context)
{
    var sqlString = "delete from \"Librarian\"";
    var fSqlString = FormattableStringFactory.Create(sqlString);
    var delDataSql = context.Database.ExecuteSql(fSqlString);
    Console.WriteLine($"Deleting : {fSqlString},no of row deleted: {delDataSql}");

    var librarian1 = new Librarian() { Id = 1, Name = "Joan" };
    var librarian2 = new Librarian() { Id = 2, Name = "Jack" };
    var librarian3 = new Librarian() { Id = 4, Name = "Test" };
    var librarian4 = new Librarian() { Id = 5, Name = "Claudia" };
    var librarian5 = new Librarian() { Id = 3, Name = "test user" };
    context.Librarian.Add(librarian1);
    context.Librarian.Add(librarian2);
    context.Librarian.Add(librarian3);
    context.Librarian.Add(librarian4);
    context.Librarian.Add(librarian5);
    context.SaveChanges();
    Console.WriteLine("setup data for Librarian ....");

}

static void CreateAuthorData(BookishContext context)
{
        // delete any rows that we had previous added
    var sqlString = "delete from \"Author\"";
    var fSqlString = FormattableStringFactory.Create(sqlString);
    var delDataSql = context.Database.ExecuteSql(fSqlString);
    Console.WriteLine($"Deleting : {fSqlString},no of row deleted: {delDataSql}");

    // now set the data for new rows to be added
    var author1 = new Author() { Id = 1, Name = "Joan Smith" };
    var author2 = new Author() { Id = 2, Name = "Jack Smith" };
    var author3 = new Author() { Id = 3, Name = "James Black" };
    var author4 = new Author() { Id = 4, Name = "R Royle" };
    var author5 = new Author() { Id = 5, Name = "Terry James" };
    var author6 = new Author() { Id = 6, Name = "Wendy Jackson" };
    var author7 = new Author() { Id = 7, Name = "Taylor Swift" };
    var author8 = new Author() { Id = 8, Name = "Jesus" };
    var author9 = new Author() { Id = 9, Name = "FT owners" };

    // add entitiy to the context Author
    context.Author.Add(author1);
    context.Author.Add(author2);
    context.Author.Add(author3);
    context.Author.Add(author4);
    context.Author.Add(author5);
    context.Author.Add(author6);
    context.Author.Add(author7);
    context.Author.Add(author8);
    context.SaveChanges();
    Console.WriteLine("setup data for Author ....");

}

static void CreateCatalogueData(BookishContext context)
{
var sqlString = "delete from \"Catalogue\"";
    var fSqlString = FormattableStringFactory.Create(sqlString);
    var delDataSql = context.Database.ExecuteSql(fSqlString);
    Console.WriteLine($"Deleting : {fSqlString},no of row deleted: {delDataSql}");

    DateTime datechk = Convert.ToDateTime("29/10/2001");
    DateTimeOffset dateTimeOffset = new DateTimeOffset(datechk, TimeSpan.Zero);  // Convert to DateTimeOffset
    DateTimeOffset utcDateTime = dateTimeOffset.ToUniversalTime();   // Convert to UTC
    //Console.WriteLine($"date checking : {datechk}, {utcDateTime}....");

    var catalogue1 = new Catalogue() { Id = 1, Title = "Star Trek", AuthorId = 1, GenreId = 4, Copies = 2, ItemTypeId = 1, PublishDate = utcDateTime.UtcDateTime };
    datechk = Convert.ToDateTime("01/01/1900");
    dateTimeOffset = new DateTimeOffset(datechk, TimeSpan.Zero); // Convert to DateTimeOffset
    utcDateTime = dateTimeOffset.ToUniversalTime();  // Convert to UTC
    var catalogue2 = new Catalogue() { Id = 2, Title = "Bible", AuthorId = 8, GenreId = 3, Copies = 1, ItemTypeId = 1, PublishDate = utcDateTime.UtcDateTime };
    datechk = Convert.ToDateTime("15/02/1980");
    dateTimeOffset = new DateTimeOffset(datechk, TimeSpan.Zero); // Convert to DateTimeOffset
    utcDateTime = dateTimeOffset.ToUniversalTime();  // Convert to UTC
    var catalogue3 = new Catalogue() { Id = 3, Title = "70's Top 40", AuthorId = 2, GenreId = 8, Copies = 1, ItemTypeId = 2, PublishDate = utcDateTime.UtcDateTime };
    datechk = Convert.ToDateTime("15/04/2020");
    dateTimeOffset = new DateTimeOffset(datechk, TimeSpan.Zero); // Convert to DateTimeOffset
    utcDateTime = dateTimeOffset.ToUniversalTime();  // Convert to UTC
    var catalogue4 = new Catalogue() { Id = 4, Title = "TaylorSwift Album", AuthorId = 7, GenreId = 8, Copies = 2, ItemTypeId = 2, PublishDate = utcDateTime.UtcDateTime };
    datechk = Convert.ToDateTime("14/08/2024");
    dateTimeOffset = new DateTimeOffset(datechk, TimeSpan.Zero); // Convert to DateTimeOffset
    utcDateTime = dateTimeOffset.ToUniversalTime();  // Convert to UTC
    var catalogue5 = new Catalogue() { Id = 5, Title = "FT", AuthorId = 9, GenreId = 2, Copies = 1, ItemTypeId = 3, PublishDate = utcDateTime.UtcDateTime };
    context.Catalogue.Add(catalogue1);
    context.Catalogue.Add(catalogue2);
    context.Catalogue.Add(catalogue3);
    context.Catalogue.Add(catalogue4);
    context.Catalogue.Add(catalogue5);
    context.SaveChanges();
    Console.WriteLine("setup data for Catalogue ....");
}

static void CreateCatalogueInstanceData(BookishContext context)
{

   // Catalogue Instance Data setup
    var sqlString = "delete from \"CatalogueInstance\"";
    var fSqlString = FormattableStringFactory.Create(sqlString);
    var delDataSql = context.Database.ExecuteSql(fSqlString);
    Console.WriteLine($"Deleting : {fSqlString},no of row deleted: {delDataSql}");
    DateTime datechk = Convert.ToDateTime("31/01/2002");
    DateTimeOffset dateTimeOffset = new DateTimeOffset(datechk, TimeSpan.Zero); // Convert to DateTimeOffset
    DateTimeOffset utcDateTime = dateTimeOffset.ToUniversalTime();  // Convert to UTC
    var catalogueinstance1 = new CatalogueInstance() { Id = 1, CatalogueId = 1, DateAdded = utcDateTime.UtcDateTime, LibrarianId = 1, Availability = "Yes" };
    datechk = Convert.ToDateTime("01/01/2003");
    dateTimeOffset = new DateTimeOffset(datechk, TimeSpan.Zero); // Convert to DateTimeOffset
    utcDateTime = dateTimeOffset.ToUniversalTime();  // Convert to UTC
    var catalogueinstance2 = new CatalogueInstance() { Id = 2, CatalogueId = 1, DateAdded = utcDateTime.UtcDateTime, LibrarianId = 1, Availability = "Yes" };
    datechk = Convert.ToDateTime("03/01/2012");
    dateTimeOffset = new DateTimeOffset(datechk, TimeSpan.Zero); // Convert to DateTimeOffset
    utcDateTime = dateTimeOffset.ToUniversalTime();  // Convert to UTC
    var catalogueinstance3 = new CatalogueInstance() { Id = 3, CatalogueId = 2, DateAdded = utcDateTime.UtcDateTime, LibrarianId = 2, Availability = "Yes" };
    datechk = Convert.ToDateTime("25/02/1980");
    dateTimeOffset = new DateTimeOffset(datechk, TimeSpan.Zero); // Convert to DateTimeOffset
    utcDateTime = dateTimeOffset.ToUniversalTime();  // Convert to UTC
    var catalogueinstance4 = new CatalogueInstance() { Id = 4, CatalogueId = 3, DateAdded = utcDateTime.UtcDateTime, LibrarianId = 3, Availability = "Yes" };
    datechk = Convert.ToDateTime("24/04/2020");
    dateTimeOffset = new DateTimeOffset(datechk, TimeSpan.Zero); // Convert to DateTimeOffset
    utcDateTime = dateTimeOffset.ToUniversalTime();  // Convert to UTC
    var catalogueinstance5 = new CatalogueInstance() { Id = 5, CatalogueId = 4, DateAdded = utcDateTime.UtcDateTime, LibrarianId = 3, Availability = "Yes" };
    datechk = Convert.ToDateTime("24/04/2021");
    dateTimeOffset = new DateTimeOffset(datechk, TimeSpan.Zero); // Convert to DateTimeOffset
    utcDateTime = dateTimeOffset.ToUniversalTime();  // Convert to UTC
    var catalogueinstance6 = new CatalogueInstance() { Id = 6, CatalogueId = 4, DateAdded = utcDateTime.UtcDateTime, LibrarianId = 3, Availability = "Yes" };
    datechk = Convert.ToDateTime("14/04/2024");
    dateTimeOffset = new DateTimeOffset(datechk, TimeSpan.Zero); // Convert to DateTimeOffset
    utcDateTime = dateTimeOffset.ToUniversalTime();  // Convert to UTC
    var catalogueinstance7 = new CatalogueInstance() { Id = 7, CatalogueId = 5, DateAdded = utcDateTime.UtcDateTime, LibrarianId = 2, Availability = "Yes" };
    context.CatalogueInstance.Add(catalogueinstance1);
    context.CatalogueInstance.Add(catalogueinstance2);
    context.CatalogueInstance.Add(catalogueinstance3);
    context.CatalogueInstance.Add(catalogueinstance4);
    context.CatalogueInstance.Add(catalogueinstance5);
    context.CatalogueInstance.Add(catalogueinstance6);
    context.CatalogueInstance.Add(catalogueinstance7);

    //save data to the database tables
    context.SaveChanges();
    Console.WriteLine("setup data for CatalogueInstance ...");
}

static void CreateCatalogueListView(BookishContext context)
{
    var s = "DROP VIEW \"CatalogueList\"";
    var fs = FormattableStringFactory.Create(s);
    var dropVwSql = context.Database.ExecuteSql(fs);
    Console.WriteLine($"dropped CatalogueList view : {fs},: {dropVwSql}");

    Console.WriteLine("Creating CatatlogueList view ....");
    s = "CREATE VIEW \"CatalogueList\" AS select c.\"Id\",a.\"Name\", c.\"Title\", c.\"PublishDate\", g.\"Description\", c.\"Copies\", i.\"ItemTypeName\" from \"Catalogue\" c join \"Author\" a on c.\"AuthorId\" = a.\"Id\" join \"Genre\" g on c.\"GenreId\" = g.\"Id\" join \"ItemType\" i on c.\"ItemTypeId\" = i.\"Id\"";
    fs = FormattableStringFactory.Create(s);
    var createVwSql = context.Database.ExecuteSql(fs);
}