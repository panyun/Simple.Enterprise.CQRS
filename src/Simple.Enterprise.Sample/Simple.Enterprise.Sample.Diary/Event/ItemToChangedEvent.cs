namespace Simple.Enterprise.Sample.Diary.Event
{
    public class ItemToChangedEvent : CQRS.Events.Imp.Event
    {
        public DateTime To { get; internal set; }
        public ItemToChangedEvent(Guid aggregateId, DateTime to)
        {
            AggregateId = aggregateId;
            To = to;
        }
    }
}
