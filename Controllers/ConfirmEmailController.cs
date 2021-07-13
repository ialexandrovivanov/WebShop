using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebShop.Services.Contracts;

namespace WebShop.Controllers
{
    public class ConfirmEmailController : Controller
    {
        private IConfirmEmailService _confirmEmailService;

        public ConfirmEmailController(IConfirmEmailService confirmEmailService) =>
            _confirmEmailService = confirmEmailService;

        [TempData]
        public string StatusMessage { get; set; }

        public async Task<IActionResult> Confirm(string userId, string code)
        {
            if (userId == null || code == null)
                return RedirectToPage("/Index");

            StatusMessage = await _confirmEmailService.Verify(userId, code);

            return View();
        }
    }
}
