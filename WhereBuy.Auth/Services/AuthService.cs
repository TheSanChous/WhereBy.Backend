using Microsoft.EntityFrameworkCore;
using WhereBuy.Auth.Common.Exceptions;
using WhereBuy.Auth.Common.Helpers;
using WhereBuy.Auth.Models;
using WhereBuy.Common.Abstractions;
using WhereBuy.Common.Errors;
using WhereBuy.Domain;

namespace WhereBuy.Auth.Services
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
                throw AppErrors.UserNotFound;
            }

            if (user.PasswordHash != await PasswordManager.GetPasswordHashAsync(loginModel.Password))
            {
                throw AppErrors.WrongPassword;
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
