using GestionRecursosHumanos.Data;
using GestionRecursosHumanos.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GestionRecursosHumanos.Pages.Cargo
{
    [Authorize]
    public class IndexModel : PageModel
    {

        private readonly GestionRecursosContext _context;

        public IndexModel(GestionRecursosContext context)
        {
            _context = context;
        }

        public IList<Cargos> cargo{ get; set; }

        public async Task OnGetAsync()
        {
            if (_context.Cargo != null)
            {
                cargo= await _context.Cargo.ToListAsync();
            }
        }
    }
}
