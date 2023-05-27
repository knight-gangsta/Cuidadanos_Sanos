using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ciudadanos_Sanos.Data;
using Ciudadanos_Sanos.Models;
using System.Threading.Tasks;

namespace Ciudadanos_Sanos.Pages.RegistroCitas
{
	public class DeleteModel : PageModel
	{
		private readonly SanoContext _context;

		public DeleteModel(SanoContext context)
		{
			_context = context;
		}

		[BindProperty]
		public RegistroCita RegistroCita { get; set; }

		public async Task<IActionResult> OnGetAsync(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			RegistroCita = await _context.RegistroCita
				.Include(r => r.Paciente)
				.Include(r => r.Medico)
				.FirstOrDefaultAsync(m => m.Id == id);

			if (RegistroCita == null)
			{
				return NotFound();
			}

			return Page();
		}

		public async Task<IActionResult> OnPostAsync(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			RegistroCita = await _context.RegistroCita.FindAsync(id);

			if (RegistroCita != null)
			{
				_context.RegistroCita.Remove(RegistroCita);
				await _context.SaveChangesAsync();
			}

			return RedirectToPage("./Index");
		}
	}
}

