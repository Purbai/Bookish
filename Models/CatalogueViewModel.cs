namespace Bookish.Models;

public class CatalogueViewModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int AuthorId { get; set; }
    public int GenreId { get; set; }
    public int Copies { get; set; }
    public int ItemTypeId { get; set; }
    public DateTime PublishDate { get; set; }

}