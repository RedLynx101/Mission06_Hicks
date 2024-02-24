using System.ComponentModel.DataAnnotations;

namespace Mission06_LastName.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? CategoryId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [Range(1888, 2100)]
        public int Year { get; set; }

        [Required]
        public string? Director { get; set; }

        [Required]
        public string Rating { get; set; }
        
        [Required]
        public bool Edited { get; set; } // Empty returns false, so it will return some value regardless of user intent
        
        [Required]
        public bool CopiedToPlex { get; set; }

        public string? LentTo { get; set; }

        [MaxLength(25)]
        public string? Notes { get; set; }
    }

}