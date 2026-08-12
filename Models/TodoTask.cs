using System.ComponentModel.DataAnnotations;

namespace TaskManagementAPI.Models;

public class TodoTask // this is our Task class 
{
    public int Id {get; set; }                               // this stores task's ID (int)

    [Required]
    [StringLength(100)]
    public string Title {get; set; } = string.Empty;         // this stores title (string)

    [StringLength(500)]
    public string Description {get; set; } = string.Empty;   

    public bool IsCompleted {get; set; }                     // this stores status (bool)

    public DateTime CreatedAt {get; set; }                  // this records when the task was created
}