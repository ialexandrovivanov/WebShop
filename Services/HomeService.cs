using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;
using System.Threading.Tasks;
using WebShop.Data.DbModels;
using WebShop.Services.Contracts;

namespace WebShop.Services
{

    public class HomeService : IHomeService
    {
        private readonly UserManager<User> userManager;

        public HomeService(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }
        public async Task<bool> ConfirmEmail(string userId, string code)
        {
            var user = await userManager.FindByIdAsync(userId);

            if (user == null)
                return false;

            code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));

            var result = await userManager.ConfirmEmailAsync(user, code);

            return result.Succeeded;
        }
    }
}
