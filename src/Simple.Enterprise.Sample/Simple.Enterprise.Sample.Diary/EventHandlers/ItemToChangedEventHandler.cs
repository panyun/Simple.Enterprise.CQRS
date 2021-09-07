using Simple.Enterprise.CQRS.EventHandlers;
using Simple.Enterprise.CQRS.Reporting;
using Simple.Enterprise.Sample.Diary.Event;
using Simple.Enterprise.Sample.Diary.Reporting;

namespace Simple.Enterprise.Sample.Diary.EventHandlers
{
    public class ItemToChangedEventHandler : IEventHandler<ItemToChangedEvent>
    {
        private readonly IReportDatabase<DiaryItemDto> _reportDatabase;
        public ItemToChangedEventHandler(IReportDatabase<DiaryItemDto> reportDatabase)
        {
            _reportDatabase = reportDatabase;
        }
        public void Handle(ItemToChangedEvent handle)
        {
            var item = _reportDatabase.GetById(handle.AggregateId);
            item.To = handle.To;
            item.Version = handle.Version;
        }
    }
}
