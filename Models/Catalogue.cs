using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bookish.Models;

[Table("CatalogueInfo")]
public class Catalogue
{

    [Key]
    public int Id { get; set; }
    public string Title { get; set; }
    public int AuthorId { get; set; }
    public int GenreId { get; set; }
    public int Copies { get; set; }
    public int ItemTypeId { get; set; }
    public DateTime PublishDate { get; set; }
    [ForeignKey("AuthorId")]
    public virtual Author Author { get; set; }
    [ForeignKey("GenreId")]
    public virtual Genre Genre { get; set; }
    [ForeignKey("ItemTypeId")]
    public virtual ItemType ItemType { get; set; }
}