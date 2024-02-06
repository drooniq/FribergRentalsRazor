using FribergRentalsRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FribergRentalsRazor.Pages.Customer.Booking
{
    public class ConfirmationModel : PageModel
    {
        private readonly IBooking booking;

        [BindProperty]
        public Models.Booking Booking { get; set; }

        public ConfirmationModel(IBooking booking)
        {
            this.booking = booking;
        }

        public void OnGetBooking(int id)
        {
            Booking = booking.GetById(id);
        }
    }
}
