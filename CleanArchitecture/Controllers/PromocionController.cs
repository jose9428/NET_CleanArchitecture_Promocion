using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Presenters;
using System.Threading.Tasks;
using UseCases.CanjePromocion;
using UseCases.CrearPromocion;
using UseCases.DTO.CanjePromocion;
using UseCases.DTO.CrearPromocion;

namespace Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class PromocionController
    {
        readonly IMediator Mediator;
        public PromocionController(IMediator mediator) =>
            Mediator = mediator;
        
        [HttpPost("create-promocion")]
        public async Task<string> CrearPromocion(CrearPromocionParametros crearPromocionParametros) 
        {
            CreateOrderPresenter presenter = new CreateOrderPresenter();
            await Mediator.Send(new CrearPromocionInputPort(crearPromocionParametros, presenter));
            return presenter.Content;
        }

        [HttpPost("canje-promocion")]
        public async Task<string> CanjePromocion(CanjePromocionParametros canjePromocionParametros)
        {
            CreateOrderPresenter presenter = new CreateOrderPresenter();
            await Mediator.Send(new CanjePromocionInputPort(canjePromocionParametros, presenter));
            return presenter.Content;
        }
    }
}
