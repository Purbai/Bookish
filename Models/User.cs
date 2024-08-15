using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bookish.Models;

[Table("UserInfo")]
public class User
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal OutStandingFees{ get; set; }
}