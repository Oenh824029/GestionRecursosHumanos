using GestionRecursosHumanos.Data;
using GestionRecursosHumanos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GestionRecursosHumanos.Pages.Nomina
{
    public class DeleteModel : PageModel
    {
        private readonly GestionRecursosContext _context;

        public DeleteModel(GestionRecursosContext context)
        {
            this._context = context;
        }

        [BindProperty]
        public Nominas Nomina { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Nomina == null)
            {
                return NotFound();
            }

            var nomina = await _context.Nomina.FirstOrDefaultAsync(m => m.IdNomina == id);

            if (nomina == null)
            {
                return NotFound();
            }
            else
            {
                Nomina = nomina;
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Nomina == null)
            {
                return NotFound();
            }
            var nomina = await _context.Nomina.FindAsync(id);

            if (nomina != null)
            {
                Nomina = nomina;
                _context.Nomina.Remove(Nomina);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }

        ///
    }
}
