using System.ComponentModel.DataAnnotations;

namespace Mission06_LastName.Models
{
    public class Category
    {
        [Key]
        public string CategoryId { get; set; }

        [Required]
        public string Category { get; set; }
    }
}