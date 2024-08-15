using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bookish.Models;

[Table("AuthorInfo")]
public class Author
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
}