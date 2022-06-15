using System;
using WhereBuy.Domain;

namespace WhereBuy.Application.Interfaces
{
    public interface ICurrentUserService
    {
        int UserId { get; }
    }
}
