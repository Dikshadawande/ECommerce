using ECommerce.Core.Domain.RequestModel;
using FluentValidation;

namespace ECommerce.FluentValidation
{
    public class ProductFV: AbstractValidator<ProductRequestModel>
    {
        public ProductFV()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();

        }
    }
}
