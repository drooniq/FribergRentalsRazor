using Humanizer;
using System.ComponentModel.DataAnnotations;

namespace FribergRentalsRazor.Models
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }

        [Required]
        public required Customer Customer { get; set; }

        [Required]
        public required Car Car { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Rent Date")]
        public DateTime RentalStartDate { get; set; }
      
        [DataType(DataType.Date)]
        [Display(Name = "Return Date")]
        public DateTime RentalReturnDate { get; set; }
    }
}
