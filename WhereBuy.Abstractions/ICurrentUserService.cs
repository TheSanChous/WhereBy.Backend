using WhereBy.Domain;

namespace WhereBy.Abstractions
{
    public interface ICurrentUserService
    {
        bool IsAuthenticated { get; }
        User? User { get; } 
        int? UserId { get; }
        string? Email { get; }
        int? Points { get;  }
    }
}
