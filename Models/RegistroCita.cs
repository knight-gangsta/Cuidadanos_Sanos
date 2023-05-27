using System.ComponentModel.DataAnnotations;

namespace Ciudadanos_Sanos.Models
{
	public class RegistroCita
	{
		public int Id { get; set; }
		public DateTime Fecha { get; set; }
		[Display(Name = "Nombre Paciente")]
		public int PacienteId { get; set; }
		[Display(Name = "Nombre Medico")]
		public int MedicoId { get; set; }
		public string Descripcion { get; set; }
		public Paciente Paciente { get; set; }
		public Medico Medico { get; set; }
	}
}
