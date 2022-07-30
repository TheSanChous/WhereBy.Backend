using FluentValidation;
using System.Text.RegularExpressions;

namespace WhereBuy.Application.Shops.Commands.Create
{
    public class CreateShopCommandValidator : AbstractValidator<CreateShopCommand>
    {
        public CreateShopCommandValidator()
        {
            RuleFor(c => c.Name)
                .MinimumLength(2)
                .MaximumLength(64)
                .NotEmpty()
                .NotNull();

            RuleFor(c => c.Address)
                .MinimumLength(5)
                .MaximumLength(64)
                .NotEmpty()
                .NotNull();

            RuleFor(c => c.Location)
                .Matches(new Regex(@"^(-?\d+(\.\d+)?),\s*(-?\d+(\.\d+)?)$"))
                .MaximumLength(64)
                .NotEmpty()
                .NotNull();
        }
    }
}
