namespace FribergRentalsRazor.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        public int CustomerId { get; set; }
        public int CarId { get; set; }
        public string RentalStartDate { get; set; }
        public string RentalReturnDate { get; set; }
    }
}
