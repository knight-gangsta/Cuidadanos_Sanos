using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace Ciudadanos_Sano.Models
{
	public class Usuario
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdUsuario { get; set; }
		public string Correo { get; set; }
		[Required]
		[DataType(DataType.Password)]
		[Display(Name = "Contraseña Encriptada")]
		public string Clave { get; set; }


	}
}

