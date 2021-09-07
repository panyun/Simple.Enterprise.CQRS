using Simple.Enterprise.CQRS.Commands;
using Simple.Enterprise.CQRS.Storage;
using Simple.Enterprise.Sample.Diary.Commands;
using Simple.Enterprise.Sample.Diary.Domain;

namespace Simple.Enterprise.Sample.Diary.CommandHandlers
{
    public class DeleteItemCommandHandler : ICommandHandler<DeleteItemCommand>
    {
        private readonly IRepository<DiaryItem> _repository;

        public DeleteItemCommandHandler(IRepository<DiaryItem> repository)
        {
            _repository = repository;
        }

        public void Execute(DeleteItemCommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException("command");
            }
            if (_repository == null)
            {
                throw new InvalidOperationException("Repository is not initialized.");
            }

            var aggregate = _repository.GetById(command.Id);
            aggregate.Delete();
            _repository.Save(aggregate, aggregate.Version);

        }
    }
}
