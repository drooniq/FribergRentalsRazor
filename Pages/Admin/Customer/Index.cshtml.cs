using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FribergRentalsRazor.Data;
using FribergRentalsRazor.Models;

namespace FribergRentalsRazor.Pages.Admin.Customer
{
    public class IndexModel : PageModel
    {
        private readonly ICustomer customerRepository;

        public IndexModel(ICustomer customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public IList<Models.Customer> Customer { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Customer = customerRepository.GetAll().ToList();
        }
    }
}
