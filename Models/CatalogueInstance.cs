using System.ComponentModel.DataAnnotations.Schema;

namespace Bookish.Models;

public class CatalogueInstance
{
    public int Id { get; set; }
    public int CatalogueId { get; set; }
    public DateTime DateAdded { get; set; }
    public int LibrarianId { get; set; }
    public string Availability { get; set; }
    [ForeignKey("CatalogueId")]
    public virtual Catalogue Catalogue { get; set; }
}