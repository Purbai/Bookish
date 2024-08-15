using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bookish.Models;

[Table("ItemTypeInfo")]
public class ItemType
{
    [Key]
    public int Id { get; set; }
    public string ItemTypeName { get; set; }
    public int MaxBorrowingPeriod { get; set; }

}