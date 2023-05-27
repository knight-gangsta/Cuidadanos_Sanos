using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Ciudadanos_Sanos.Models
{
	public class Medico
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		[Display(Name = "Nombre Medico")]
		public string Nombre_Completo { get; set; }
		public string Cargo { get; set; }
		[Display(Name = "Correo Corporativo")]
		public string CorreoCo { get; set; }
		public ICollection<RegistroCita>? RegistroCitas { get; set; } = default!;
	}

}
