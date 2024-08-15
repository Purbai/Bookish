using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bookish.Models;

[Table("LibrarianInfor")]
public class Librarian
{
    [Key]
    public int Id { get; set; }

    [Column("Name", TypeName="ntext")]
    public string Name { get; set; }

}