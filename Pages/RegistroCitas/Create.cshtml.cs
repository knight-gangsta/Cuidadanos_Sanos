using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ciudadanos_Sanos.Data;
using Ciudadanos_Sanos.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ciudadanos_Sanos.Pages.RegistroCitas
{
	public class CreateModel : PageModel
	{
		private readonly SanoContext _context;

		public CreateModel(SanoContext context)
		{
			_context = context;
		}

		[BindProperty]
		public RegistroCita RegistroCita { get; set; }

		public List<SelectListItem> PacientesList { get; set; }
		public List<SelectListItem> MedicosList { get; set; }

		public async Task<IActionResult> OnGetAsync()
		{
			PacientesList = await _context.Paciente
				.Select(p => new SelectListItem
				{
					Value = p.Id.ToString(),
					Text = p.Nombre_Completo
				})
				.ToListAsync();

			MedicosList = await _context.Medico
				.Select(m => new SelectListItem
				{
					Value = m.Id.ToString(),
					Text = m.Nombre_Completo
				})
				.ToListAsync();

			return Page();
		}

		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				//return Page();
			}

			_context.RegistroCita.Add(RegistroCita);
			await _context.SaveChangesAsync();

			return RedirectToPage("./Index");
		}
	}
}
