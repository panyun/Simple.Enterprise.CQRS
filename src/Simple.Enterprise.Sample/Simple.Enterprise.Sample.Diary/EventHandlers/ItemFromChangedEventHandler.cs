using Simple.Enterprise.CQRS.EventHandlers;
using Simple.Enterprise.CQRS.Reporting;
using Simple.Enterprise.Sample.Diary.Event;
using Simple.Enterprise.Sample.Diary.Reporting;

namespace Simple.Enterprise.Sample.Diary.EventHandlers
{
    public class ItemFromChangedEventHandler : IEventHandler<ItemFromChangedEvent>
    {
        private readonly IReportDatabase<DiaryItemDto> _reportDatabase;
        public ItemFromChangedEventHandler(IReportDatabase<DiaryItemDto> reportDatabase)
        {
            _reportDatabase = reportDatabase;
        }
        public void Handle(ItemFromChangedEvent handle)
        {
            var item = _reportDatabase.GetById(handle.AggregateId);
            item.From = handle.From;
            item.Version = handle.Version;
        }
    }
}
