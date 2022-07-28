using WhereBy.Auth.Models;
using WhereBy.Domain;

namespace WhereBy.Auth
{
    public interface IJWTService
    {
        Task<Tokens> GetTokensAsync(User user, CancellationToken cancellationToken);
    }
}
