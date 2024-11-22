using GestionRecursosHumanos.Data;
using GestionRecursosHumanos.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GestionRecursosHumanos.Pages.Nomina
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly GestionRecursosContext _context;

        public EditModel(GestionRecursosContext context)
        {
            this._context = context;
        }
        [BindProperty]
        public Nominas Nomina { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nomina = await _context.Nomina.FirstOrDefaultAsync(m =>
                m.IdNomina == id);
            if (nomina == null)
            {
                return NotFound();
            }
            Nomina = nomina;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _context.Attach(Nomina).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NominaExists(Nomina.IdNomina))
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

        public bool NominaExists(int id)
        {
            return (_context.Nomina?.Any(e => e.IdNomina == id)).GetValueOrDefault();
        }

        ///----///
    }
}
