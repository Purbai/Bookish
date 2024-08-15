using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bookish.Models;
[Table("PenaltyInfo")]
public class Penalty
{

[Key]
    public int Id { get; set; }
    public string ItemType { get; set; }
    public decimal PenaltyPerDay { get; set; }

}