﻿using System;
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
    public class DetailsModel : PageModel
    {
        private readonly ICar carRepository;

        public DetailsModel(ICar carRepository)
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
                return Page();
            }
            else
            {
                Car = car;
            }
            return Page();
        }
    }
}
