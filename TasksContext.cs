using Microsoft.EntityFrameworkCore;
using projectef.Models;
using Task = projectef.Models.Task;

namespace projectef;

public class TasksContext : DbContext
{
  public DbSet<Category> Categories { get; set; }
  public DbSet<Task> Tasks { get; set; }
  public TasksContext(DbContextOptions<TasksContext> options) : base(options) { }
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    List<Category> categoriesInit = new List<Category>();
    categoriesInit.Add(new Category()
    {
      CategoryId = Guid.Parse("f7d31d43-485b-4499-9502-97c3cf0c806d"),
      Name = "Actividades Pendientes",
      Weight = 20
    });
    categoriesInit.Add(new Category()
    {
      CategoryId = Guid.Parse("f7d31d43-485b-4499-9502-97c3cf0c8061"),
      Name = "Actividades Personales",
      Weight = 50
    });
    modelBuilder.Entity<Category>(category =>
    {
      category.ToTable("Category");
      category.HasKey(p => p.CategoryId);
      category.Property(p => p.Name).IsRequired().HasMaxLength(150);
      category.Property(p => p.Description).IsRequired(false);
      category.Property(p => p.Weight);
      category.HasData(categoriesInit);
    });
    List<Task> tasksInit = new List<Task>();
    tasksInit.Add(new Task()
    {
      TaskId = Guid.Parse("f7d31d43-485b-4499-9502-97c3cf0c8789"),
      CategoryId = Guid.Parse("f7d31d43-485b-4499-9502-97c3cf0c806d"),
      TaskPriority = Priority.Media,
      Title = "Pago servicios publicos",
      CreationDate = DateTime.Now
    });
    tasksInit.Add(new Task()
    {
      TaskId = Guid.Parse("f7d31d43-485b-4499-9502-97c3cf0c8780"),
      CategoryId = Guid.Parse("f7d31d43-485b-4499-9502-97c3cf0c806d"),
      TaskPriority = Priority.Alta,
      Title = "Hacer la tarea de la U",
      CreationDate = DateTime.Now
    });
    tasksInit.Add(new Task()
    {
      TaskId = Guid.Parse("f7d31d43-485b-4499-9502-97c3cf0c8100"),
      CategoryId = Guid.Parse("f7d31d43-485b-4499-9502-97c3cf0c8061"),
      TaskPriority = Priority.Media,
      Title = "Sacar a zeus",
      CreationDate = DateTime.Now
    });
    tasksInit.Add(new Task()
    {
      TaskId = Guid.Parse("f7d31d43-485b-4499-9502-97c3cf0c81a1"),
      CategoryId = Guid.Parse("f7d31d43-485b-4499-9502-97c3cf0c8061"),
      TaskPriority = Priority.Baja,
      Title = "Nose",
      CreationDate = DateTime.Now
    });
    modelBuilder.Entity<Task>(task =>
    {
      task.ToTable("Task");
      task.HasKey(p => p.TaskId);
      task.HasOne(p => p.Category).WithMany(p => p.Tasks).HasForeignKey(p => p.CategoryId);
      task.Property(p => p.Title).IsRequired().HasMaxLength(200);
      task.Property(p => p.Description).IsRequired(false);
      task.Property(p => p.TaskPriority);
      task.Property(p => p.CreationDate);
      task.Ignore(p => p.Summary);
      task.HasData(tasksInit);
    });
  }
}