using GestionRecursosHumanos.Data;
using GestionRecursosHumanos.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GestionRecursosHumanos.Pages.Empleado
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly GestionRecursosContext _context;

        public IndexModel(GestionRecursosContext context)
        {
            _context = context;
        }

        public IList<Empleados> Empleados { get; set; }

        public async Task OnGetAsync()
        {
            if(_context.Empleado != null)
            {
                Empleados = await _context.Empleado.ToListAsync();
            }
        }
        
    }
}
