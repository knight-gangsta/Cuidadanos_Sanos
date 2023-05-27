using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ciudadanos_Sano.Pages.Accounts
{
    public class LogoutModel : PageModel
    {
		public async Task<IActionResult> OnPostAsync()
		{
			await HttpContext.SignOutAsync("MyCookieAuth");
			return RedirectToPage("/Index");
		}
	}
}
