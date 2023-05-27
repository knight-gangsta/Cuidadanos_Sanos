using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ciudadanos_Sanos.Data;
using Ciudadanos_Sanos.Models;

namespace Ciudadanos_Sanos.Pages.Pacientes
{
	public class DeleteModel : PageModel
	{
		private readonly SanoContext _context;

		public DeleteModel(SanoContext context)
		{
			_context = context;
		}

		[BindProperty]
		public Paciente Paciente { get; set; }

		public async Task<IActionResult> OnGetAsync(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			Paciente = await _context.Paciente.FirstOrDefaultAsync(m => m.Id == id);

			if (Paciente == null)
			{
				return NotFound();
			}

			return Page();
		}

		public async Task<IActionResult> OnPostAsync()
		{
			var paciente = await _context.Paciente.FindAsync(Paciente.Id);

			if (paciente == null)
			{
				return NotFound();
			}

			_context.Paciente.Remove(paciente);
			await _context.SaveChangesAsync();

			return RedirectToPage("./Index");
		}
	}
}
