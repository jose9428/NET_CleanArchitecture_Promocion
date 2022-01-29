using UseCases.Commont.Ports;
using UseCases.DTO.CrearPromocion;

namespace UseCases.CrearPromocion
{
    public class CrearPromocionInputPort : IInputPort<CrearPromocionParametros, int>//evaluar response
    {
        public CrearPromocionParametros RequestData { get; }
        public IOutputPort<int> OutputPort { get; }
        public CrearPromocionInputPort(CrearPromocionParametros requestData, IOutputPort<int> outputPort)
            => (RequestData, OutputPort) = (requestData, outputPort);
    }
}
