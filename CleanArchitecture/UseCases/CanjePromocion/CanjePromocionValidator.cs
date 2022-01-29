using FluentValidation;

namespace UseCases.CanjePromocion
{
    public class CanjePromocionValidator : AbstractValidator<CanjePromocionInputPort>
    {
        public CanjePromocionValidator() {
            RuleFor(c => c.RequestData.Codigo).NotEmpty().MinimumLength(12).WithMessage("Debe de proporcionar código de promoción");
        }
    }
}
