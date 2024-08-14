using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Bookish.Models;

namespace Bookish.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        Console.WriteLine("inside HomeController");
        _logger = logger;
    }

    public IActionResult Index()
    {
                Console.WriteLine("inside IActionResult Index");
        return View();
    }

    public IActionResult Privacy()
    {
        Console.WriteLine("inside IActionResult Privacy");
        return View();
    }

    public IActionResult Librarian()
    {
        Console.WriteLine("inside IActionResult Librarian");
        return View(new Librarian());
    }

    public IActionResult CatalogueMView()
    {
        Console.WriteLine("inside IActionResult CatalogueMView");
        return View(new CatalogueMView());
    }

    
    public IActionResult CatalogueList()
    {
        Console.WriteLine("inside IActionResult CatalogueList");
        return View(new CatalogueList());
    }


    public IActionResult CatalogueInstance()
    {
        Console.WriteLine("inside IActionResult CatalogueInstance");
        return View(new CatalogueInstance());
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
