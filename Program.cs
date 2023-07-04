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

app.Run();