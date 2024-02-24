using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06_LastName.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int? CategoryId { get; set; }

        [ForeignKey("CategoryId")] // This establishes the relationship
        public Category? Category { get; set; } // Navigation property

        [Required]
        public string Title { get; set; }

        [Required]
        [Range(1888, 2100)]
        public int Year { get; set; }

        public string? Director { get; set; }

        public string? Rating { get; set; }
        
        [Required]
        [Range(0, 1)]
        public int Edited { get; set; } 

        [Required]
        [Range(0, 1)]
        public int CopiedToPlex { get; set; }

        public string? LentTo { get; set; }

        [MaxLength(25)]
        public string? Notes { get; set; }
    }

}