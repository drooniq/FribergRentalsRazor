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
        public DateTime RentalStartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime RentalReturnDate { get; set; }
    }
}
