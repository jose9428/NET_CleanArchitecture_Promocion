using Entities.Exceptions;
using Entities.Interfaces;
using Entities.POCO;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace UseCases.CanjePromocion
{
    public class CanjePromocionInteractor : AsyncRequestHandler<CanjePromocionInputPort>
    {
        readonly IPromocionRepository PromocionRepository;
        readonly IUnitOfWork UnitOfWork;
        public CanjePromocionInteractor(IPromocionRepository promocionRepository, IUnitOfWork unitOfWork)
            => (PromocionRepository, UnitOfWork) = (promocionRepository, unitOfWork);
        protected async override Task Handle(CanjePromocionInputPort request, CancellationToken cancellationToken) {
            int returnId = 0;
            Promocion promocion = PromocionRepository.GetAll().Where(p => p.Codigo == request.RequestData.Codigo).FirstOrDefault();
            if (promocion != null)
            {
                //Solo se puede canjear un código a la vez.
                if (promocion.Estado == "generado") {
                    promocion.Estado = "canjeado";
                    promocion.FechaCanje = DateTime.Now;
                    PromocionRepository.Update(promocion);
                    try
                    {
                        await UnitOfWork.SaveChangesAsync();
                        returnId = promocion.Id;
                    }
                    catch (Exception ex)
                    {
                        throw new GeneralException("Error al canjear un codigo de promocion", ex.Message);
                    }
                }
            }
            request.OutputPort.Handle(returnId);
        }
    }
}
