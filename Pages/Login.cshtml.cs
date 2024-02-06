using FribergRentalsRazor.Data;
using FribergRentalsRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Cryptography;

namespace FribergRentalsRazor.Pages
{
    public class LoginModel : PageModel
    {
        AdminRepository adminRepository;
        CustomerRepository customerRepository;

        [BindProperty]
        public Models.Admin Admin { get; set; }
        public List<Models.Admin> Admins { get; set; }

        public LoginModel(ApplicationDbContext context)
        {
            adminRepository = new AdminRepository(context);
            customerRepository = new CustomerRepository(context);
        }

        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("LoggedInAdmin") != null || HttpContext.Session.GetString("LoggedInCustomer") != null)
            {
                ModelState.AddModelError("LoggedIn", "You are already logged in. Logout first");
                return Page();
                //return RedirectToPage("/Logout");
            }

            Admins = adminRepository.GetAll().ToList() ?? new List<Models.Admin>();
            return Page();
        }

        public IActionResult OnPost(Models.Admin admin)
        {

            var Admin = adminRepository.Find(a => a.Email == admin.Email && a.Password == admin.Password);
            if (Admin.Count() > 0)
            {
                HttpContext.Session.SetString("LoggedInAdmin", Admin.ToList()[0].Email);
                HttpContext.Session.SetInt32("AdminId", Admin.ToList()[0].AdminId);
                HttpContext.Session.Remove("LoggedInCustomer");
                HttpContext.Session.Remove("CustomerId");
                return RedirectToPage("/Admin/Index");
            }
            else
            {
                var Customer = customerRepository.Find(c => c.Email == admin.Email && c.Password == admin.Password);
                if (Customer.Count() > 0)
                {
                    HttpContext.Session.SetString("LoggedInCustomer", Customer.ToList()[0].Email);
                    HttpContext.Session.SetInt32("CustomerId", Customer.ToList()[0].CustomerId);
                    HttpContext.Session.Remove("LoggedInAdmin");
                    HttpContext.Session.Remove("AdminId");
                    return RedirectToPage("/Customer/Index");
                }
                else
                {
                    ModelState.AddModelError("Email", "Invalid Email or Password");
                    return Page();
                }
            }
        }
    }
}
