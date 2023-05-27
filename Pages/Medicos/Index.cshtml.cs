using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Ciudadanos_Sanos.Data;
using Ciudadanos_Sanos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace Ciudadanos_Sanos.Pages.Medicos
{
	[Authorize]
	public class IndexModel : PageModel
    {
		private readonly SanoContext _context;
		public IndexModel(SanoContext context)
		{
			_context = context;
		}
		public IList<Medico> Medicos { get; set; } = default!;
		public async Task OnGetAsync()
        {
			if (_context.Medico != null)
			{
				Medicos = await _context.Medico.ToListAsync();
			}
		}
    }
}
