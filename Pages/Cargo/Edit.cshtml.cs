using GestionRecursosHumanos.Data;
using GestionRecursosHumanos.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GestionRecursosHumanos.Pages.Cargo
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
        public Cargos Cargo { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cargo = await _context.Cargo.FirstOrDefaultAsync(m =>
                m.IdCargos == id);
            if (cargo == null)
            {
                return NotFound();
            }
            Cargo = cargo;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _context.Attach(Cargo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CargoExists(Cargo.IdCargos))
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

        public bool CargoExists(int id)
        {
            return (_context.Cargo?.Any(e => e.IdCargos == id)).GetValueOrDefault();
        }
    }
}
