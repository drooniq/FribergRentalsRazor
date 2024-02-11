using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FribergRentalsRazor.Models
{
    public class Car
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public required string Brand { get; set; }
        
        [Required]
        public required string Model { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public required int Year { get; set; }

        [Required]
        [Display(Name = "Cost Per Day")]
        public required float CostPerDay { get; set; }
        
        public string? Comment { get; set; }
        
        public List<string> ImageUrls { get; set; } = new List<string>();
    }
}
