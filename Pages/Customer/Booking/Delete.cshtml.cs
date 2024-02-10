using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FribergRentalsRazor.Data;
using FribergRentalsRazor.Models;

namespace FribergRentalsRazor.Pages.Customer.Booking
{
    public class DeleteModel : PageModel
    {
        private readonly IBooking bookingRepository;

        public DeleteModel(IBooking bookingRepository)
        {
            this.bookingRepository = bookingRepository;
        }

        [BindProperty]
        public Models.Booking Booking { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return Page();
            }

            var booking = await bookingRepository.GetByIdAsync(id);

            if (booking == null)
            {
                return NotFound();
            }
            else
            {
                Booking = booking;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return Page();
            }

            var booking = await bookingRepository.GetByIdAsync(id);

            if (booking != null)
            {
                Booking = booking;
                await bookingRepository.RemoveAsync(Booking);
            }

            return RedirectToPage("./Index");
        }
    }
}
