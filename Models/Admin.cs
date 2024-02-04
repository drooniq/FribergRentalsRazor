using System.ComponentModel.DataAnnotations;

namespace FribergRentalsRazor.Models
{
    public class Booking
    {
        public int AdminId { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
