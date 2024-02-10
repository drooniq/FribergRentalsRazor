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

        public async Task OnGetAsync()
        {
            Bookings = (await booking.GetAllAsync()).OrderBy( b => b.BookingId).ToList();
        }
    }
}
