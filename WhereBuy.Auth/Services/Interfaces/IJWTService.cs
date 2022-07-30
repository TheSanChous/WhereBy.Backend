using WhereBuy.Auth.Models;
using WhereBuy.Domain;

namespace WhereBuy.Auth
{
    public interface IJWTService
    {
        Task<Tokens> GetTokensAsync(User user, CancellationToken cancellationToken);
    }
}
