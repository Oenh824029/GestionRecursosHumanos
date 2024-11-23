using GestionRecursosHumanos.Data;
using GestionRecursosHumanos.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GestionRecursosHumanos.Pages.Nomina
{
    [Authorize]
    public class CreateModel : PageModel
    {
            private readonly GestionRecursosContext _context;

            public CreateModel(GestionRecursosContext context)
            {
                this._context = context;
            }

            public IActionResult OnGet()
            {
                return Page();
            }


            [BindProperty]
            public Nominas Nomina { get; set; }

            public async Task<IActionResult> OnPostAsync()
            {
                if (!ModelState.IsValid || _context.Nomina == null || Nomina == null)
                {
                    return Page();
                }

                _context.Nomina.Add(Nomina);
                await _context.SaveChangesAsync();

                return RedirectToPage("./Index");
            }
        }
    }
