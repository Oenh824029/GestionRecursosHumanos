using GestionRecursosHumanos.Data;
using GestionRecursosHumanos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GestionRecursosHumanos.Pages.Cargo
{
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
        public Cargos Cargo { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Cargo == null || Cargo == null)
            {
                return Page();
            }

            _context.Cargo.Add(Cargo);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
