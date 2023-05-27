using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Ciudadanos_Sanos.Models
{
	public class Paciente
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public string Cedula { get; set; }
		[Display(Name = "Nombre Paciente")]
		public string Nombre_Completo { get; set; }
		public string Correo { get; set; }
		public string Descripcion { get; set; }
		public ICollection<RegistroCita>? RegistroCitas { get; set; } = default!;
	}

}
