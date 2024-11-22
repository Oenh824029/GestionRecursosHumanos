using GestionRecursosHumanos.Data;
using GestionRecursosHumanos.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace GestionRecursosHumanos.Pages.Empleado
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
        public Empleados Empleado { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleado.FirstOrDefaultAsync(m =>
                m.IdEmpleados == id);
            if (empleado == null)
            {
                return NotFound();
            }
            Empleado = empleado;
            return Page();
        }
        
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _context.Attach(Empleado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpleadoExists(Empleado.IdEmpleados))
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

        public bool EmpleadoExists(int id)
        {
            return (_context.Empleado?.Any(e => e.IdEmpleados == id)).GetValueOrDefault();
        }

    ///----///
    }
}
