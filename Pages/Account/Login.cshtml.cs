using GestionRecursosHumanos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GestionRecursosHumanos.Pages.Account
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public User User { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> Onpost()
        {
            if (!ModelState.IsValid) return Page();

            if (User.Email == "preuebaCorreogmail.com" && User.Password == "12345")
            {
                return RedirectToPage("/index");
            }
            return Page();
        }
    }
}
