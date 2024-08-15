using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bookish.Models;

[Table("Genre")]
public class Genre
{

    [Key]
    public int Id { get; set; }

    [Column("Description")]
    public string Description { get; set; }

}