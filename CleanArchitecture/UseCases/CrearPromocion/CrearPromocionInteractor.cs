using Entities.Exceptions;
using Entities.Interfaces;
using Entities.POCO;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace UseCases.CrearPromocion
{
    public class CrearPromocionInteractor : AsyncRequestHandler<CrearPromocionInputPort>
    {
        readonly IPromocionRepository PromocionRepository;
        readonly IUnitOfWork UnitOfWork;

        public CrearPromocionInteractor(IPromocionRepository promocionRepository, IUnitOfWork unitOfWork)
            => (PromocionRepository, UnitOfWork) = (promocionRepository, unitOfWork);

        protected async override Task Handle(CrearPromocionInputPort request, CancellationToken cancellationToken)
        {
            Promocion promocion = new Promocion
            {
                Nombre = request.RequestData.Nombre,
                Email = request.RequestData.Email,
                Estado = "generado",
                Codigo = "CODPRO" + DateTime.Now.ToString("hhmmss"),
                FechaCreacion = DateTime.Now,
                FechaCanje = null
            };
            //Solo se puede generar un código por email.
            Promocion promocionEmail = PromocionRepository.GetAll().Where(p => p.Email == request.RequestData.Email).FirstOrDefault();
            if (promocionEmail==null) {
                
                PromocionRepository.Create(promocion);
                try
                {
                    await UnitOfWork.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw new GeneralException("Error al generar un codigo de promocion", ex.Message);
                }
            }

            request.OutputPort.Handle(promocion.Id);
        }
    }
}
