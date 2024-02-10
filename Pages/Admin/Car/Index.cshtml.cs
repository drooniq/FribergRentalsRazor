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
    public class IndexModel : PageModel
    {
        private readonly ICar carRepository;

        public IndexModel(ICar carRepository)
        {
            this.carRepository = carRepository;
        }

        public IList<Models.Car> Car { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Car = (IList<Models.Car>) await carRepository.GetAllAsync();
        }
    }
}
