using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ciudadanos_Sanos.Data;
using Ciudadanos_Sanos.Models;
using System.Threading.Tasks;

namespace Ciudadanos_Sanos.Pages.Medicos
{
	public class DeleteModel : PageModel
	{
		private readonly SanoContext _context;

		public DeleteModel(SanoContext context)
		{
			_context = context;
		}

		[BindProperty]
		public Medico Medico { get; set; }

		public async Task<IActionResult> OnGetAsync(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			Medico = await _context.Medico.FirstOrDefaultAsync(m => m.Id == id);

			if (Medico == null)
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

			Medico = await _context.Medico.FindAsync(id);

			if (Medico != null)
			{
				_context.Medico.Remove(Medico);
				await _context.SaveChangesAsync();
			}

			return RedirectToPage("./Index");
		}
	}
}
