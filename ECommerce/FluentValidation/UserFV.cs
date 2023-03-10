using ECommerce.Core.Domain.RequestModel;
using FluentValidation;

namespace ECommerce.FluentValidation
{
    public class UserFV:AbstractValidator<UserRequestModel>
    {
        public UserFV() 
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Email).EmailAddress();
        }
    }
}
