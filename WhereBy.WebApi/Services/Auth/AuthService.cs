using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using WhereBy.Application.Common.Exceptions;
using WhereBy.Application.Interfaces;
using WhereBy.Domain;
using WhereBy.WebApi.Helpers;
using WhereBy.WebApi.Models.Auth;
using WhereBy.WebApi.Services.JWT;

namespace WhereBy.WebApi.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IJWTService jWTService;
        private readonly IDatabaseContext databaseContext;
        private readonly IMailService mail;

        public AuthService(IJWTService jWTService, IDatabaseContext databaseContext, IMailService mail)
        {
            this.jWTService = jWTService;
            this.databaseContext = databaseContext;
            this.mail = mail;
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

            await mail.SendCodeAsync(user.Email, (new Random()).Next(1000, 9999));

            return await jWTService.GetTokensAsync(user, cancellationToken);
        }

        public async Task<Tokens> ValidateVereficationCode(string code, CancellationToken cancellationToken)
        {
            return null;
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
                Points = 0
            };

            await databaseContext.Users.AddAsync(user, cancellationToken);
            await databaseContext.SaveChangesAsync(cancellationToken);

            return user;
        }
    }
}
