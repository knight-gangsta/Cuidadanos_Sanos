using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Ciudadanos_Sanos.Data;
using Ciudadanos_Sanos.Models;
using System.Threading.Tasks;

namespace Ciudadanos_Sanos.Pages.Medicos
{
	public class CreateModel : PageModel
	{
		private readonly SanoContext _context;

		public CreateModel(SanoContext context)
		{
			_context = context;
		}

		[BindProperty]
		public Medico Medico { get; set; }

		public IActionResult OnGet()
		{
			return Page();
		}

		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid || _context.Medico == null || Medico == null)
			{
				return Page();
			}

			_context.Medico.Add(Medico);
			await _context.SaveChangesAsync();

			return RedirectToPage("./Index");
		}
	}
}
