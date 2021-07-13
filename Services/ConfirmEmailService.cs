using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;
using System.Threading.Tasks;
using WebShop.Data.DbModels;
using WebShop.Services.Contracts;

namespace WebShop.Services
{
    public class ConfirmEmailService : IConfirmEmailService
    {
        private UserManager<User> _userManager { get; init; }

        public ConfirmEmailService(UserManager<User> userManager) => 
            _userManager = userManager;
       
        public async Task<string> Verify(string userId, string code)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
                return $"Unable to load user with ID '{userId}'";

            code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));

            var result = await _userManager.ConfirmEmailAsync(user, code);

            return result.Succeeded ? "Thank you for confirming your email." : "Error confirming your email.";
        }
    }
}
