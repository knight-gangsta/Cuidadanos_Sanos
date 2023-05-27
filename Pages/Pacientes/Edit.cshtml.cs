using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ciudadanos_Sanos.Data;
using Ciudadanos_Sanos.Models;

namespace Ciudadanos_Sanos.Pages.Pacientes
{
	public class EditModel : PageModel
	{
		private readonly SanoContext _context;

		public EditModel(SanoContext context)
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

			Paciente = await _context.Paciente.FindAsync(id);

			if (Paciente == null)
			{
				return NotFound();
			}

			return Page();
		}

		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}

			_context.Attach(Paciente).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!PacienteExists(Paciente.Id))
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

		private bool PacienteExists(int id)
		{
			return _context.Paciente.Any(e => e.Id == id);
		}
	}
}
