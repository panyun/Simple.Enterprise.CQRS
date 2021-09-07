namespace Simple.Enterprise.Sample.Diary.Event
{
    public class ItemDescriptionChangedEvent : CQRS.Events.Imp.Event
    {
        public string Description { get; internal set; }
        public ItemDescriptionChangedEvent(Guid aggregateId, string description)
        {
            AggregateId = aggregateId;
            Description = description;
        }
    }
}
