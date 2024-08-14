using Bookish;
using Bookish.Models;

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

    //create entity objects
    // var librarian1 = new Librarian() { Id = 2, Name= "Jack" };
    // var user1 = new User() { Id= 2, Name = "Kiran", OutStandingFees = 0};

    // //add entitiy to the context
    // Console.WriteLine("Just above where we use the Add to add our data");
    // context.Librarian.Add(librarian1);
    // context.User.Add(user1);

    // //save data to the database tables
    // context.SaveChanges();

    //retrieve all the students from the database
    // foreach (var s in context.Librarian) {
    //     Console.WriteLine($"Id: {s.Id}, Librarian Name: {s.Name}");
    // }

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
