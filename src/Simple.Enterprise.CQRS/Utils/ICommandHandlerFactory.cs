using Simple.Enterprise.CQRS.Commands;
using Simple.Enterprise.CQRS.Commands.Imp;

namespace Simple.Enterprise.CQRS.Utils
{
    public interface ICommandHandlerFactory
    {
        ICommandHandler<T> GetHandler<T>() where T : Command;
    }
}
