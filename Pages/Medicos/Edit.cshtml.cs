using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ciudadanos_Sanos.Data;
using Ciudadanos_Sanos.Models;

namespace Ciudadanos_Sanos.Pages.Medicos
{
	public class EditModel : PageModel
	{
		private readonly SanoContext _context;

		public EditModel(SanoContext context)
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

			Medico = await _context.Medico.FindAsync(id);

			if (Medico == null)
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

			_context.Attach(Medico).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!MedicoExists(Medico.Id))
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

		private bool MedicoExists(int id)
		{
			return _context.Medico.Any(e => e.Id == id);
		}
	}
}
