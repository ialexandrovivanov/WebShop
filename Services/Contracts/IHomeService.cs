using System.Threading.Tasks;

namespace WebShop.Services.Contracts
{
    public interface IHomeService
    {
        Task<bool> ConfirmEmail(string userId, string code);
    }
}
