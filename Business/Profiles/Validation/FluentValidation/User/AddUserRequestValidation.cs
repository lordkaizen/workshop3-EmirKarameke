using Business.Requests.User;
using FluentValidation;

namespace Business.Profiles.Validation.FluentValidation.User
{
    public class AddUserRequestValidation : AbstractValidator<AddUserRequest>
    {
        public AddUserRequestValidation() 
        {
            RuleFor(x => x.FirstName.Length).NotEmpty().GreaterThan(0);
            RuleFor(x => x.LastName.Length).NotEmpty().GreaterThan(0);
            RuleFor(x => x.Email.Length).NotEmpty().GreaterThan(0);
            RuleFor(x => x.Password).NotEmpty().MinimumLength(2).MaximumLength(50);
        }
    }
}
