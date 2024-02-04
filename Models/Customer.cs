using System.ComponentModel.DataAnnotations;

namespace FribergRentalsRazor.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string? FullName { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Zipcode { get; set; }
        public string? Country { get; set; }
        public string? Phone { get; set; }
    }
}
