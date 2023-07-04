namespace projectef.Models;

public class Category
{
  public Guid CategoryId { get; set; }
  public string name { get; set; }

  public string description { get; set; }
  public virtual ICollection<Task> Tasks { get; set; }

}