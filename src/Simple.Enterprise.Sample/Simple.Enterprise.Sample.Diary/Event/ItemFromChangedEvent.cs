namespace Simple.Enterprise.Sample.Diary.Event
{
    public class ItemFromChangedEvent : CQRS.Events.Imp.Event
    {
        public DateTime From { get; internal set; }
        public ItemFromChangedEvent(Guid aggregateId, DateTime from)
        {
            AggregateId = aggregateId;
            From = from;
        }
    }
}
