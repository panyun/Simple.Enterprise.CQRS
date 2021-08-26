using Simple.Enterprise.CQRS.Commands.Imp;

namespace Simple.Enterprise.CQRS.Commands
{
    public interface ICommand
    {
        Guid Id { get; }
    }
    public interface ICommandHandler<TCommand> where TCommand : Command
    {
        void Execute(TCommand command);
    }
}
