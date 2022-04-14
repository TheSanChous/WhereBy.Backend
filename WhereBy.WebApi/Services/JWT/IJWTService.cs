using System.Threading;
using System.Threading.Tasks;
using WhereBy.Domain;

namespace WhereBy.WebApi.Services.JWT
{
    public interface IJWTService
    {
        Task<Tokens> GetTokensAsync(User user, CancellationToken cancellationToken);
    }
}
