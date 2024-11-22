using GestionRecursosHumanos.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

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

            if (User.Email == "preuebaCorreo@gmail.com" && User.Password == "12345")
            {
                //se crea los claim, datos a almacenar en la cookie
                var claims = new List<Claim>
                {
                    new Claim (ClaimTypes.Name, " "),
                    new Claim(ClaimTypes.Email,User.Email),
                };

                //se asocia a los claims creados a un nombre de una cokkie 
                var identity = new ClaimsIdentity(claims, "MyCookieAuth");
                //Se agrega la  identidad creada al claimsprincipal de la aplicacion 
                ClaimsPrincipal claimsprincipal = new ClaimsPrincipal(identity);

                //se registra exitosamente la autenticacion y se crea la cookie en el navegador
                await HttpContext.SignInAsync("MyCookieAuth", claimsprincipal);


                return RedirectToPage("/Index");

            }

                return Page();
        }
    }
}
        
