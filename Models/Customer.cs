using System.ComponentModel.DataAnnotations;

namespace FribergRentalsRazor.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        [Required]
        public required string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public required string Password { get; set; }
        public string? FullName { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Zipcode { get; set; }
        public string? Country { get; set; }
        public string? Phone { get; set; }
    }
}
