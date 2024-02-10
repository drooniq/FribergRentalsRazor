using FribergRentalsRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FribergRentalsRazor.Pages.Customer.Booking
{
    public class ConfirmationModel : PageModel
    {
        private readonly IBooking booking;

        [BindProperty]
        public Models.Booking? Booking { get; set; }

        public ConfirmationModel(IBooking booking)
        {
            this.booking = booking;
        }

        public async Task OnGetBookingAsync(int id)
        {
            Booking = await booking.GetByIdAsync(id);
        }
    }
}
