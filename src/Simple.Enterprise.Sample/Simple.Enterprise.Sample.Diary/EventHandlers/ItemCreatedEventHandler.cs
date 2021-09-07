using Simple.Enterprise.CQRS.EventHandlers;
using Simple.Enterprise.CQRS.Reporting;
using Simple.Enterprise.Sample.Diary.Event;
using Simple.Enterprise.Sample.Diary.Reporting;

namespace Simple.Enterprise.Sample.Diary.EventHandlers
{
    public class ItemCreatedEventHandler : IEventHandler<ItemCreatedEvent>
    {
        private readonly IReportDatabase<DiaryItemDto> _reportDatabase;
        public ItemCreatedEventHandler(IReportDatabase<DiaryItemDto> reportDatabase)
        {
            _reportDatabase = reportDatabase;
        }
        public void Handle(ItemCreatedEvent handle)
        {
            DiaryItemDto item = new DiaryItemDto()
            {
                Id = handle.AggregateId,
                Description = handle.Description,
                From = handle.From,
                Title = handle.Title,
                To = handle.To,
                Version = handle.Version
            };

            _reportDatabase.Add(item);
        }
    }
}
