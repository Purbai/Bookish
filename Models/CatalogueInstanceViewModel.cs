namespace Bookish.Models;

public class CatalogueInstanceViewModel
{
    public int Id { get; set; }
    public int CatalogueId { get; set; }
    public DateTime DateAdded { get; set; }
    public int LibrarianId { get; set; }
    public string Availability { get; set; }

}