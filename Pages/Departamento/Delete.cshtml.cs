using GestionRecursosHumanos.Data;
using GestionRecursosHumanos.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GestionRecursosHumanos.Pages.Departamento
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        
        private readonly GestionRecursosContext _context;

        public DeleteModel(GestionRecursosContext context)
        {
            this._context = context;
        }

        [BindProperty]
        public Departamentos Departamento { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Departamento == null)
            {
                return NotFound();
            }

            var departamento = await _context.Departamento.FirstOrDefaultAsync(m => m.IdDepartamento == id);

            if (departamento == null)
            {
                return NotFound();
            }
            else
            {
                Departamento =departamento;
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Departamento == null)
            {
                return NotFound();
            }
            var departamento = await _context.Departamento.FindAsync(id);

            if (departamento != null)
            {
                Departamento = departamento;
                _context.Departamento.Remove(Departamento);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }

    }
}
