using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ciudadanos_Sanos.Data;
using Ciudadanos_Sanos.Models;
using Microsoft.AspNetCore.Authorization;

namespace Ciudadanos_Sanos.Pages.RegistroCitas
{
	[Authorize]
	public class IndexModel : PageModel
	{
		private readonly SanoContext _context;

		public IndexModel(SanoContext context)
		{
			_context = context;
		}

		public IList<RegistroCita> RegistroCitas { get; set; }

		public async Task<IActionResult> OnGetAsync()
		{
			RegistroCitas = await _context.RegistroCita
				.Include(rc => rc.Paciente)
				.Include(rc => rc.Medico)
				.ToListAsync();

			return Page();
		}
	}
}

