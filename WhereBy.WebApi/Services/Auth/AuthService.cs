using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WhereBuy.Application.Common.Exceptions;
using WhereBuy.Application.Interfaces;
using WhereBuy.Domain;
using WhereBuy.WebApi.Helpers;
using WhereBuy.WebApi.Models.Auth;
using WhereBuy.WebApi.Services.JWT;

namespace WhereBuy.WebApi.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IJWTService jWTService;
        private readonly IDatabaseContext databaseContext;

        public AuthService(IJWTService jWTService, IDatabaseContext databaseContext)
        {
            this.jWTService = jWTService;
            this.databaseContext = databaseContext;
        }
        public async Task<Tokens> LoginUserAsync(UserLoginModel loginModel, CancellationToken cancellationToken)
        {
            var user = await databaseContext.Users
                .FirstOrDefaultAsync(user => user.Email == loginModel.Email, cancellationToken);

            if (user == null)
            {
                throw new UnauthorizedException("USER_NOT_FOUND");
            }

            if (user.PasswordHash != await PasswordManager.GetPasswordHashAsync(loginModel.Password))
            {
                throw new UnauthorizedException("WRONG_PASSWORD");
            }

            return await jWTService.GetTokensAsync(user, cancellationToken);
        }

        public async Task<Tokens> RegisterUserAsync(UserRegisterModel registerModel, CancellationToken cancellationToken)
        {
            var user = await databaseContext.Users
                .FirstOrDefaultAsync(user => user.Email == registerModel.Email, cancellationToken);

            if (user != null)
            {
                throw new UnauthorizedException("EMAIL_ALREADY_EXIST");
            }

            user = await CreateNewUserAsync(registerModel, cancellationToken);

            return await jWTService.GetTokensAsync(user, cancellationToken);
        }

        private async Task<User> CreateNewUserAsync(UserRegisterModel registerModel, CancellationToken cancellationToken)
        {
            var passwordHash = await PasswordManager.GetPasswordHashAsync(registerModel.Password);

            var user = new User
            {
                Email = registerModel.Email,
                PasswordHash = passwordHash,
                Name = registerModel.Email.Split("@").First(),
                Points = 0
            };

            await databaseContext.Users.AddAsync(user, cancellationToken);
            await databaseContext.SaveChangesAsync(cancellationToken);

            return user;
        }
    }
}
