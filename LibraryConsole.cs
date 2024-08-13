using Bookish;
using Bookish.Models;
using LibraryConsole;

using (var context = new BookishContext())
{
    //creates db if not exists 
    context.Database.EnsureCreated();

    //create entity objects
    var librarian1 = new Librarian() { Id = 1, Name= "Joan" };
    var user1 = new User() { Id= 1, Name = "Yash", OutStandingFees = 0};

    //add entitiy to the context
    context.Librarian.Add(librarian1);
    context.User.Add(user1);


    //save data to the database tables
    context.SaveChanges();

    //retrieve all the students from the database
    foreach (var s in context.Librarian) {
        Console.WriteLine($"Id: {s.Id}, Librarian Name: {s.Name}");
    }

    
    //retrieve all the students from the database
    foreach (var s in context.User) {
        Console.WriteLine($"Id: {s.Id}, Name: {s.Name}, Outstanding Fee: {s.OutStandingFees}");
    }
}