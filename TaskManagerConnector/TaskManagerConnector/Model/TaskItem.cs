using System.ComponentModel.DataAnnotations;

namespace TaskManagerConnector.Model
{
    public class TaskItem
    {
        [Key] // Explicitly mark as primary key
        public string Id { get; set; } = String.Empty;
        public string Title { get; set; } = String.Empty;
        public string? Description { get; set; }

        public bool? Completed { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime CompletedAt { get; set; } = DateTime.MinValue;
    }
}
