using FluentValidation;

namespace UseCases.CrearPromocion
{
    public class CrearPromocionValidator : AbstractValidator<CrearPromocionInputPort>
    {
        public CrearPromocionValidator()
        {
            RuleFor(c => c.RequestData.Nombre).NotEmpty().WithMessage("Debe de proporcionar nombre completo");
            RuleFor(c => c.RequestData.Email).NotEmpty().WithMessage("Debe de proporcionar email");
        }
    }
}
