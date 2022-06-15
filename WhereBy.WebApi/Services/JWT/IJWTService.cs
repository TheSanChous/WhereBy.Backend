using System.Threading;
using System.Threading.Tasks;
using WhereBuy.Domain;

namespace WhereBuy.WebApi.Services.JWT
{
    public interface IJWTService
    {
        Task<Tokens> GetTokensAsync(User user, CancellationToken cancellationToken);
    }
}
