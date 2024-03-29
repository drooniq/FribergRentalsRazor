﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FribergRentalsRazor.Data;
using FribergRentalsRazor.Models;

namespace FribergRentalsRazor.Pages.Admin.Car
{
    public class EditModel : PageModel
    {
        private readonly ICar carRepository;

        public EditModel(ICar carRepository)
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

            var car =  await carRepository.GetByIdAsync(id);

            if (car == null)
            {
                return NotFound();
            }
            Car = car;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                var updatedCar = await carRepository.UpdateAsync(Car);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await CarExistsAsync(Car.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private async Task<bool> CarExistsAsync(int id)
        {
            return (await carRepository.GetByIdAsync(id) != null);
        }
    }
}
