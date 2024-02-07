using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FribergRentalsRazor.Data;
using FribergRentalsRazor.Models;

namespace FribergRentalsRazor.Pages.Customer.Car
{
    [BindProperties]
    public class IndexModel : PageModel
    {
        private readonly ICar carRepository;
        private readonly IBooking bookingRepository;

        public IndexModel(ICar carRepository, IBooking bookingRepository)
        {
            this.carRepository = carRepository;
            this.bookingRepository = bookingRepository;
        }

        public List<Models.Car> Cars { get;set; } = new List<Models.Car>();
        private IEnumerable<Models.Booking> currentBookings { get; set; } = default!;

        public IActionResult OnGet()
        {
            currentBookings = bookingRepository
                .GetAll()
                .Where(d => d.RentalReturnDate >= DateTime.Now)
                .Where(d => d.RentalStartDate <= DateTime.Now)
                .AsQueryable()
                .Include(c => c.Car)
                .Include(c => c.Customer);

            var allCars = carRepository.GetAll();

            foreach (var car in allCars)
            {
                if (!currentBookings.Any(d => d.Car.Id == car.Id))
                {
                    Cars.Add(car);
                }
            }

            return Page();
        }
    }
}
