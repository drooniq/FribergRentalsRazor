using FribergRentalsRazor.Data;
using FribergRentalsRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;

namespace FribergRentalsRazor.Pages.Customer.Booking
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        public Models.Car? Car { get; set; }
        public Models.Customer? Customer { get; set; }
        public Models.Booking? Booking { get; set; }

        private readonly ICar carRepository;
        private readonly ICustomer customerRepository;
        private readonly IBooking bookingRepository;

        public CreateModel(ICar carRepository, ICustomer customerRepository, IBooking bookingRepository)
        {
            this.carRepository = carRepository;
            this.customerRepository = customerRepository;
            this.bookingRepository = bookingRepository;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Car = await carRepository.GetByIdAsync(id);

            if (Car == null)
            {
                ModelState.AddModelError("CarIdNotFound", "Could not book car by that ID: " + id);
                return Page();
            }

            if (HttpContext.Session == null || HttpContext.Session.Keys.Count() == 0)
            {
                ModelState.AddModelError("CustomerNotLoggedIn", "You must be logged in to book a car");
                return RedirectToPage("/Login");
            }

#pragma warning disable CS8602 // Dereference of a possibly null reference.
            string customerEmail = HttpContext.Session.GetString("LoggedInCustomer").ToString();
#pragma warning restore CS8602 // Dereference of a possibly null reference.

            if (customerEmail == null)
            {
                ModelState.AddModelError("CustomerNotLoggedIn", "You must be logged in to book a car");
                return RedirectToPage("/Login");
            }

            Customer = (await customerRepository.FindAsync(c => c.Email == customerEmail)).FirstOrDefault();

            if (Customer == null)
            {
                ModelState.AddModelError("CustomerNotFound", "Could not find customer with email " + customerEmail);
                return Page();
            }

            Booking = new Models.Booking
            {
                Customer = Customer,
                Car = Car,
                RentalStartDate = DateTime.Now,
                RentalReturnDate = DateTime.Now.AddDays(1)
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            ModelState.Clear();

            if (Booking == null)
            {
                ModelState.AddModelError("BookingNotCreated", "Booking object is null");
                return Page();
            }

            if (!TryValidateModel(Booking, nameof(Booking)))
            {
                return Page();
            }

            IEnumerable<Models.Booking>? allBookingsForThisCar = (await bookingRepository.GetAllAsync()).Where(b => b.Car.Id == Car.Id);

            foreach (var booking in allBookingsForThisCar)
            {
                if (Booking.RentalStartDate >= booking.RentalStartDate && Booking.RentalStartDate <= booking.RentalReturnDate)
                {
                    ModelState.AddModelError("CarAlreadyBooked", "Car is already booked for the selected dates");
                    return Page();
                }
                if (Booking.RentalReturnDate >= booking.RentalStartDate && Booking.RentalReturnDate <= booking.RentalReturnDate)
                {
                    ModelState.AddModelError("CarAlreadyBooked", "Car is already booked for the selected dates");
                    return Page();
                }
            }

            Models.Booking bookingObject = await bookingRepository.AddAsync(Booking);

            return RedirectToPage("/Customer/Booking/Confirmation", "Booking", new { id = bookingObject.BookingId });
        }
    }
}
