using System;
using WhereBy.Domain;

namespace WhereBy.Application.Interfaces
{
    public interface ICurrentUserService
    {
        int UserId { get; }
    }
}
