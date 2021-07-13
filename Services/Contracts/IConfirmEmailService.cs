using System.Threading.Tasks;

namespace WebShop.Services.Contracts
{
    public interface IConfirmEmailService
    {
        Task<string> Verify(string userId, string code);
    }
}
