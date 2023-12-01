using System.ComponentModel.DataAnnotations;

namespace WebProjectProject.Models
{
    // Represents a table in the database
    public class Category
    {
        // ID - is a primary key
        [Key]
        public int Id { get; set; }

        // Name - is required
        [Required]
        public string Name { get; set; }

        public int DisplayOrder { get; set; }

        // Default value is time now
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
