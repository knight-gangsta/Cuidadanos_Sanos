using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ciudadanos_Sanos.Data;
using Ciudadanos_Sanos.Models;

namespace Ciudadanos_Sanos.Pages
{
	public class ConsultaModel : PageModel
	{
		private readonly SanoContext _context;

		public ConsultaModel(SanoContext context)
		{
			_context = context;
		}

		public List<CitaViewModel> Citas { get; set; }

		public async Task<IActionResult> OnGetAsync()
		{
			Citas = await _context.RegistroCita
				.Include(rc => rc.Paciente)
				.Include(rc => rc.Medico)
				.Select(rc => new CitaViewModel
				{
					Fecha = rc.Fecha,
					NombrePaciente = rc.Paciente.Nombre_Completo,
					NombreMedico = rc.Medico.Nombre_Completo
				})
				.ToListAsync();

			return Page();
		}
	}

	
}
