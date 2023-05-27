using Ciudadanos_Sanos.Data;
using Ciudadanos_Sano.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Ciudadanos_Sano.Pages.Accounts
{
	[Authorize]
	public class IndexModel : PageModel
    {
        private readonly SanoContext _context;
		private IEnumerable<object> bytes;

		public IndexModel(SanoContext context)
        {
            _context = context;
        }

        public IList<Usuario> Usuarios { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Usuarios = await _context.Usuario.ToListAsync();

			// Codificar las claves de los usuarios
			foreach (var usuario in Usuarios)
			{
				usuario.Clave = HashClave(usuario.Clave);
			}


			return Page();
        }
		//40
		// Método para codificar la clave utilizando SHA256
		private string HashClave(string clave)
		{
			using (var sha256 = SHA256.Create())
			{
				var bytes = Encoding.UTF8.GetBytes(clave);
				var hashedBytes = sha256.ComputeHash(bytes);
				return ConvertBytesToHexString(hashedBytes);
			}
		}

		
		// Método auxiliar para convertir un array de bytes en una cadena hexadecimal
		private string ConvertBytesToHexString(byte[] hashedBytes)
		{
			var builder = new StringBuilder();
			foreach (var b in hashedBytes)
			{
				builder.Append(b.ToString("x2"));
			}
			return builder.ToString();
		}

	}
}
