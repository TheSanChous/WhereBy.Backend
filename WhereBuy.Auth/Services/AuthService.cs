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

            if (user.IsEmailConfirmed is false)
            {
                throw AppErrors.EmailIsNotConfirmed;
            }

            return await jWTService.GetTokensAsync(user, cancellationToken);
        }

        public async Task<Tokens> ValidateVerificationCode(EmailVereficationCodeModel codeModel, CancellationToken cancellationToken)
        {
            var user = await databaseContext.Users
                .FirstOrDefaultAsync(user => user.Email == codeModel.Email, cancellationToken);
            
            if (user == null)
            {
                throw AppErrors.NotFound.Create(nameof(codeModel.Email), codeModel.Email);
            }

            if(user.VerificationCode != codeModel.Code)
            {
                throw AppErrors.WrongVerificationCode;
            }

            user.IsEmailConfirmed = true;

            await databaseContext.SaveChangesAsync(cancellationToken);

            return await jWTService.GetTokensAsync(user, cancellationToken);
        }

        public async Task RegisterUserAsync(UserRegisterModel registerModel, CancellationToken cancellationToken)
        {
            var user = await databaseContext.Users
                .FirstOrDefaultAsync(user => user.Email == registerModel.Email, cancellationToken);

            if (user != null)
            {
                throw AppErrors.EntityExists.Create(registerModel.Email);
            }

            user = await CreateNewUserAsync(registerModel, cancellationToken);

            user.VerificationCode = (new Random()).Next(1000, 9999);

            await mail.SendCodeAsync(user.Email, user.VerificationCode);

            await databaseContext.SaveChangesAsync(cancellationToken);
        }

        private async Task<User> CreateNewUserAsync(UserRegisterModel registerModel, CancellationToken cancellationToken)
        {
            var passwordHash = await PasswordManager.GetPasswordHashAsync(registerModel.Password);

            var user = new User
            {
                Email = registerModel.Email,
                PasswordHash = passwordHash,
                Name = registerModel.Email.Split('@').First(),
                Points = 0,
                IsEmailConfirmed = false
            };

            await databaseContext.Users.AddAsync(user, cancellationToken);
            await databaseContext.SaveChangesAsync(cancellationToken);

            return user;
        }
    }
}
