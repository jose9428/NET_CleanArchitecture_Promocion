namespace UseCases.Commont.Ports
{
    public interface IOutputPort<InteractorRequestType>
    {
        void Handle(InteractorRequestType response);
    }
}
