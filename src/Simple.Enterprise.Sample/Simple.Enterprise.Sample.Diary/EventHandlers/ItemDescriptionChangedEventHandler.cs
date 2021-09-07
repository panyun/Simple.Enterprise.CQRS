using Simple.Enterprise.CQRS.EventHandlers;
using Simple.Enterprise.CQRS.Reporting;
using Simple.Enterprise.Sample.Diary.Event;
using Simple.Enterprise.Sample.Diary.Reporting;

namespace Simple.Enterprise.Sample.Diary.EventHandlers
{
    public class ItemDescriptionChangedEventHandler : IEventHandler<ItemDescriptionChangedEvent>
    {
        private readonly IReportDatabase<DiaryItemDto> _reportDatabase;
        public ItemDescriptionChangedEventHandler(IReportDatabase<DiaryItemDto> reportDatabase)
        {
            _reportDatabase = reportDatabase;
        }
        public void Handle(ItemDescriptionChangedEvent handle)
        {
            var item = _reportDatabase.GetById(handle.AggregateId);
            item.Description = handle.Description;
            item.Version = handle.Version;
        }
    }
}
