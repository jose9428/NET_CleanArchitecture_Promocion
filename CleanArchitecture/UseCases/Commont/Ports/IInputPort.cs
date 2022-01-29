using MediatR;

namespace UseCases.Commont.Ports
{
    public interface IInputPort<InteractorRequestType, InteractorResponseType> : IRequest
    {
        public InteractorRequestType RequestData { get; }
        public IOutputPort<InteractorResponseType> OutputPort { get; }
    }
}
