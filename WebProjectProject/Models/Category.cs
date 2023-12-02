using System.ComponentModel;
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
        [MaxLength(30)]
        [DisplayName("Category Name")]
        public string Name { get; set; }

        [DisplayName("Display Order")]
        [Range(1,100, ErrorMessage = "Display Order Must be between 1 and 100.")]
        public int DisplayOrder { get; set; }

        // Default value is time now
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
