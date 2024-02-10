using FribergRentalsRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FribergRentalsRazor.Pages.Customer.Booking
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
            Bookings = (await booking.GetAllAsync())
                .AsQueryable()
                .Include( c => c.Customer)
                .Include( c => c.Car)
                .Where( c => c.Customer.CustomerId == HttpContext.Session.GetInt32("CustomerId"))
//                .OrderByDescending( t => t.BookingId)
                .ToList();
        }
    }
}
