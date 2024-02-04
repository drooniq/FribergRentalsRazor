using FribergRentalsRazor.Data;
using FribergRentalsRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Cryptography;

namespace FribergRentalsRazor.Pages
{
    public class LogoutModel : PageModel
    {
        public LogoutModel(ApplicationDbContext context)
        {
        }

        public void OnGet()
        {
            HttpContext.Session.Clear();
        }
    }
}
