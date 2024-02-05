using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FribergRentalsRazor.Data;
using FribergRentalsRazor.Models;

namespace FribergRentalsRazor.Pages
{
    public class CreateModel : PageModel
    {
        private readonly ICustomer customerRepository;

        public CreateModel(ICustomer customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Models.Customer Customer { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPost(Models.Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            customerRepository.Add(Customer);
            customerRepository.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}
