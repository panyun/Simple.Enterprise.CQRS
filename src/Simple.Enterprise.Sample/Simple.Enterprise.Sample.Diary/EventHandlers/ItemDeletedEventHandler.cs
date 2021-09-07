using Simple.Enterprise.CQRS.EventHandlers;
using Simple.Enterprise.CQRS.Reporting;
using Simple.Enterprise.Sample.Diary.Event;
using Simple.Enterprise.Sample.Diary.Reporting;

namespace Simple.Enterprise.Sample.Diary.EventHandlers
{
    public class ItemDeletedEventHandler : IEventHandler<ItemDeletedEvent>
    {
        private readonly IReportDatabase<DiaryItemDto> _reportDatabase;
        public ItemDeletedEventHandler(IReportDatabase<DiaryItemDto> reportDatabase)
        {
            _reportDatabase = reportDatabase;
        }
        public void Handle(ItemDeletedEvent handle)
        {
            _reportDatabase.Delete(handle.AggregateId);
        }
    }
}
