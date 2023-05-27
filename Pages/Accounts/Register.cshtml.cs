using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Ciudadanos_Sano.Models;
using Ciudadanos_Sanos.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.Text;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

namespace Ciudadanos_Sano.Pages.Accounts
{

	
	public class RegisterModel : PageModel
    {
        private readonly SanoContext _context;

        public RegisterModel(SanoContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Usuario Usuario { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                // Comprueba si el correo ya está registrado
                var existingUser = await _context.Usuario.FirstOrDefaultAsync(u => u.Correo == Usuario.Correo);

                if (existingUser != null)
                {
                    ModelState.AddModelError(string.Empty, "El correo ya está registrado");
                    return Page();
                }

                // Guarda el nuevo usuario en la base de datos
                _context.Usuario.Add(Usuario);
                await _context.SaveChangesAsync();

                return RedirectToPage("/Index");
            }

            return Page();
        }
		public static string ConvertirSha256(string texto)
		{
			using (SHA256 hash = SHA256Managed.Create())
			{
				byte[] result = hash.ComputeHash(Encoding.UTF8.GetBytes(texto));
				StringBuilder sb = new StringBuilder();

				for (int i = 0; i < result.Length; i++)
				{
					sb.Append(result[i].ToString("x2"));
				}

				return sb.ToString();
			}
		}
	}
}
