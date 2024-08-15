using System.ComponentModel.DataAnnotations.Schema;

namespace Bookish.Models;

public class CatalogueList
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Title { get; set; }
    public DateTime PublishDate { get; set; } 
    public string Description { get; set; }
    public int Copies { get; set; }
    public string ItemTypeName { get; set; }
}