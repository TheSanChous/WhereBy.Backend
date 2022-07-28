using WhereBy.Domain;

namespace WhereBuy.Common.Abstractions
{
    public interface ICurrentUserService
    {
        bool IsAuthenticated { get; }
        User? User { get; }
        int? UserId { get; }
        string? Email { get; }
        int? Points { get; }
    }
}
