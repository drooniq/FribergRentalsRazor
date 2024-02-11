using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FribergRentalsRazor.Data;
using FribergRentalsRazor.Models;

namespace FribergRentalsRazor.Pages.Admin.Customer
{
    public class EditModel : PageModel
    {
        private readonly ICustomer customerRepository;

        public EditModel(ICustomer customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        [BindProperty]
        public Models.Customer Customer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer =  await customerRepository.GetByIdAsync(id);

            if (customer == null)
            {
                return NotFound();
            }
            Customer = customer;
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
                await customerRepository.UpdateAsync(Customer);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(Customer.CustomerId))
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

        private bool CustomerExists(int id)
        {
            return (customerRepository.GetByIdAsync(id) != null);
        }
    }
}
