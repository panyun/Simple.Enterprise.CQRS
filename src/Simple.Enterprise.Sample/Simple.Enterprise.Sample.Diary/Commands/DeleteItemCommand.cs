using Simple.Enterprise.CQRS.Commands.Imp;

namespace Simple.Enterprise.Sample.Diary.Commands
{
    public class DeleteItemCommand : Command
    {
        public DeleteItemCommand(Guid id, int version) : base(id, version)
        {
        }
    }
}
