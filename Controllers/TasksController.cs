using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagementAPI.Datas;
using TaskManagementAPI.Models;

namespace TaskManagementAPI.Controllers; 

[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    private readonly AppDbContext _context; 

    public TasksController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TodoTask>>> GetTasks()
    {
        return await _context.TodoTasks.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TodoTask>> GetTask(int id)
    {
        var task = await _context.TodoTasks.FindAsync(id);

        if(task == null)
        {
            return NotFound();
        }
        return task;
    }

    [HttpPost]
    public async Task<ActionResult<TodoTask>> CreateTask(TodoTask task)
    {
        task.CreatedAt = DateTime.UtcNow;
        _context.TodoTasks.Add(task);
        await _context.SaveChangesAsync();
        return CreatedAtAction(
            nameof(GetTask),
            new {id = task.Id },
            task
        );
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTask(int id, TodoTask updatedTask)
    {
        var task = await _context.TodoTasks.FindAsync(id);

        if (task == null)
        {
            return NotFound();
        }

        task.Title = updatedTask.Title; 
        task.Description = updatedTask.Description;
        task.IsCompleted = updatedTask.IsCompleted;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTask(int id)
    {
        var task = await _context.TodoTasks.FindAsync(id);

        if (task == null)
        {
            return NotFound();
        }

        _context.TodoTasks.Remove(task);

        await _context.SaveChangesAsync();

        return NoContent();
    }
}