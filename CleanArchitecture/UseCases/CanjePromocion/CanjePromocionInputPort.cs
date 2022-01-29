using UseCases.Commont.Ports;
using UseCases.DTO.CanjePromocion;

namespace UseCases.CanjePromocion
{
    public class CanjePromocionInputPort : IInputPort<CanjePromocionParametros, int>
    {
        public CanjePromocionParametros RequestData { get; }
        public IOutputPort<int> OutputPort { get; }
        public CanjePromocionInputPort(CanjePromocionParametros requestData, IOutputPort<int> outputPort)
            => (RequestData, OutputPort) = (requestData, outputPort);
    }
}
