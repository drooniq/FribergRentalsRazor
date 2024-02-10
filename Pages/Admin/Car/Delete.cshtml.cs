using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FribergRentalsRazor.Data;
using FribergRentalsRazor.Models;

namespace FribergRentalsRazor.Pages.Admin.Car
{
    public class DeleteModel : PageModel
    {
        private readonly ICar carRepository;

        public DeleteModel(ICar carRepository)
        {
            this.carRepository = carRepository;
        }

        [BindProperty]
        public Models.Car Car { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return Page();
            }

            var car = await carRepository.GetByIdAsync(id);

            if (car == null)
            {
                return NotFound();
            }
            else
            {
                Car = car;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await carRepository.GetByIdAsync(id);

            if (car != null)
            {
                Car = car;
                await carRepository.RemoveAsync(Car);
            }

            return RedirectToPage("./Index");
        }
    }
}
