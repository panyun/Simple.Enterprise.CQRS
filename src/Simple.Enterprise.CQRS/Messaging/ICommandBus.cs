using Simple.Enterprise.CQRS.Commands.Imp;

namespace Simple.Enterprise.CQRS.Messaging
{
    public interface ICommandBus
    {
        void Send<T>(T command) where T : Command;
    }
}
