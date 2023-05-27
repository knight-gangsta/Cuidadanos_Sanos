using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ciudadanos_Sanos.Data;
using Ciudadanos_Sanos.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ciudadanos_Sanos.Pages.RegistroCitas
{
	public class EditModel : PageModel
	{
		private readonly SanoContext _context;

		public EditModel(SanoContext context)
		{
			_context = context;
		}

		[BindProperty]
		public RegistroCita RegistroCita { get; set; }

		public List<SelectListItem> PacientesList { get; set; }
		public List<SelectListItem> MedicosList { get; set; }

		public async Task<IActionResult> OnGetAsync(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			RegistroCita = await _context.RegistroCita.FindAsync(id);

			if (RegistroCita == null)
			{
				return NotFound();
			}

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

			_context.Attach(RegistroCita).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!RegistroCitaExists(RegistroCita.Id))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}

			return RedirectToPage("./Index");
		}

		private bool RegistroCitaExists(int id)
		{
			return _context.RegistroCita.Any(e => e.Id == id);
		}
	}
}
