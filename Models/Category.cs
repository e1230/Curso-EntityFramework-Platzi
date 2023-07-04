using System.ComponentModel.DataAnnotations;

namespace projectef.Models;

public class Category
{
  [Key]
  public Guid CategoryId { get; set; }
  [Required]
  [MaxLength(150)]
  public string name { get; set; }

  public string description { get; set; }
  public virtual ICollection<Task> Tasks { get; set; }

}