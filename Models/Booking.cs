using Humanizer;
using System.ComponentModel.DataAnnotations;

namespace FribergRentalsRazor.Models
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }
        public Customer Customer { get; set; }
        public Car Car { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Rent Date")]
        public DateTime RentalStartDate { get; set; }
      
        [DataType(DataType.Date)]
        [Display(Name = "Return Date")]
        public DateTime RentalReturnDate { get; set; }
    }
}
