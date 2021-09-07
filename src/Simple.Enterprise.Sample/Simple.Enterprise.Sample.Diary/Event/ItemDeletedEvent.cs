namespace Simple.Enterprise.Sample.Diary.Event
{
    public class ItemDeletedEvent : CQRS.Events.Imp.Event
    {
        public ItemDeletedEvent(Guid aggregateId)
        {
            AggregateId = aggregateId;
        }
    }
}
