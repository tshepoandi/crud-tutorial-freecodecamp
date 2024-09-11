using System.ComponentModel.DataAnnotations;

namespace TodoAPI.Models
{
    public class ToDo
    {
        [Key]
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public bool IsComplete { get; set; }

        public DateTime DueDate { get; set; }

        public int Priority { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public ToDo()
        {
            IsComplete = false;
        }
    }
}
