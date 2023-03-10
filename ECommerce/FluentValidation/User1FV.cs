using ECommerce.Infra.Domain.Entities;
using FluentValidation;

namespace ECommerce.FluentValidation
{
    public class User1FV:AbstractValidator<User1>
    {
        public User1FV()
        {
            RuleFor(x => x.Email).EmailAddress();
        }
    }
}
