using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using Ciudadanos_Sano.Models;
using System.Security.Cryptography;
using System.Text;
using Ciudadanos_Sanos.Data;
using System.Data;
using Microsoft.EntityFrameworkCore;


namespace Ciudadanos_Sano.Pages.Accounts
{
    public class LoginModel : PageModel
    {
        private readonly SanoContext _context;

        public LoginModel(SanoContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
        }

        [BindProperty]
        public Usuario Usuario { get; set; }

        public IActionResult OnPost()
        {
            Usuario.Clave = ConvertirSha256(Usuario.Clave);

            try
            {
				var usuarioDb = _context.Usuario.FirstOrDefault(u => u.Correo == Usuario.Correo);


				if (usuarioDb != null)
                {
                    // Autenticar al usuario y configurar la identidad
                    var identity = new ClaimsIdentity("MyCookieAuth");
                    identity.AddClaim(new Claim(ClaimTypes.Name, usuarioDb.Correo));

                    var principal = new ClaimsPrincipal(identity);

                    // Iniciar sesión
                    HttpContext.SignInAsync("MyCookieAuth", principal).Wait();

                    return RedirectToPage("/Index");
                }
                else
                {
                    ViewData["Mensaje"] = "Usuario no encontrado";
                    return Page();
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción o mostrar un mensaje de error específico
                ViewData["Mensaje"] = "Error durante el inicio de sesión: " + ex.Message;
                return Page();
            }
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
