using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projectef;
using Task = projectef.Models.Task;
var builder = WebApplication.CreateBuilder(args);
// builder.Services.AddDbContext<TasksContext>(p => p.UseInMemoryDatabase("TasksDB"));
builder.Services.AddSqlServer<TasksContext>(builder.Configuration.GetConnectionString("cnTasks"));
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/dbconection", async ([FromServices] TasksContext dbContext) =>
{
  dbContext.Database.EnsureCreated();
  return Results.Ok("Base de datos en memoria " + dbContext.Database.IsInMemory());
});

app.MapGet("/api/tasks", async ([FromServices] TasksContext dbContext) =>
{
  // return Results.Ok(dbContext.Tasks.Include(p => p.Category).Where(p => p.TaskPriority == projectef.Models.Priority.Baja));
  return Results.Ok(dbContext.Tasks.Include(p => p.Category));
});

app.MapPost("/api/tasks", async ([FromServices] TasksContext dbContext, [FromBody] Task task) =>
{
  task.TaskId = Guid.NewGuid();
  task.CreationDate = DateTime.Now;
  await dbContext.Tasks.AddAsync(task);
  await dbContext.SaveChangesAsync();
  return Results.Ok();
});

app.MapPut("/api/tasks/{id}", async ([FromServices] TasksContext dbContext, [FromBody] Task task, [FromRoute] Guid id) =>
{
  var actualTask = dbContext.Tasks.Find(id);

  if (actualTask != null)
  {
    actualTask.CategoryId = task.CategoryId;
    actualTask.Title = task.Title;
    actualTask.TaskPriority = task.TaskPriority;
    actualTask.Description = task.Description;
    await dbContext.SaveChangesAsync();
    return Results.Ok();
  }

  return Results.NotFound();

});

app.MapDelete("/api/tasks/{id}", async ([FromServices] TasksContext dbContext, [FromRoute] Guid id) =>
{
  var task = dbContext.Tasks.Find(id);

  if (task == null)
    return Results.NotFound("Task not found.");

  dbContext.Remove(task);
  await dbContext.SaveChangesAsync();

  return Results.Ok("Removed!");
});

app.Run();