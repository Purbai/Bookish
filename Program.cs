using Bookish;
using Bookish.Models;
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
    //authors
    var author1 = new Author() { Id = 1, Name= "Joan Smith" };
    var author2 = new Author() { Id = 2, Name= "Jack Smith" };
    var author3 = new Author() { Id = 3, Name= "James Black" };
    var author4 = new Author() { Id = 4, Name= "R Royle" };
    var author5 = new Author() { Id = 5, Name= "Terry James" };
    var author6 = new Author() { Id = 6, Name= "Wendy Jackson" };
    var author7 = new Author() { Id = 7, Name= "JJ Terence" };

    // var user1 = new User() { Id= 2, Name = "Kiran", OutStandingFees = 0};

    //add entitiy to the context
    context.Author.Add(author1);
    context.Author.Add(author2);
    context.Author.Add(author3);
    context.Author.Add(author4);
    context.Author.Add(author5);
    context.Author.Add(author6);
    context.Author.Add(author7);

    // context.User.Add(user1);

    //save data to the database tables
    context.SaveChanges();

    // retrieve all the students from the database
    foreach (var a in context.Author)
    {
        Console.WriteLine($"Id: {a.Id}, Authr Name: {a.Name}");
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
