using FribergRentalsRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FribergRentalsRazor.Pages.Admin.Booking
{
    public class IndexModel : PageModel
    {
        private readonly IBooking booking;

        [BindProperty]
        public IList<Models.Booking> Bookings { get; set; } = default!;

        public IndexModel(IBooking booking)
        {
            this.booking = booking;
        }

        public void OnGet()
        {
            Bookings = booking.GetAll().OrderBy( b => b.BookingId).ToList();
        }
    }
}
