using GestionRecursosHumanos.Data;
using GestionRecursosHumanos.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GestionRecursosHumanos.Pages.Departamento
{
    [Authorize]
    public class IndexModel : PageModel
    {
            private readonly GestionRecursosContext _context;

            public IndexModel(GestionRecursosContext context)
            {
                _context = context;
            }

            public IList<Departamentos> Departamento { get; set; }

            public async Task OnGetAsync()
            {
                if (_context.Departamento != null)
                {
                    Departamento = await _context.Departamento.ToListAsync();
                }
            }

        
    }
}

