using System.ComponentModel.DataAnnotations;

namespace FribergRentalsRazor.Models
{
    public class Car
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Brand { get; set; }
        
        [Required]
        public string Model { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public float CostPerDay { get; set; }
        
        public string Comment { get; set; }
        
        public List<string> ImageUrls { get; set; } = new List<string>();
    }
}
