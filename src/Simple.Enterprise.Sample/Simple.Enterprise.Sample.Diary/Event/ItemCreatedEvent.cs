namespace Simple.Enterprise.Sample.Diary.Event
{
    public class ItemCreatedEvent : CQRS.Events.Imp.Event
    {
        public string Title { get; internal set; }
        public DateTime From { get; internal set; }
        public DateTime To { get; internal set; }
        public string Description { get; internal set; }

        public ItemCreatedEvent(Guid aggregateId, string title,
            string description, DateTime from, DateTime to)
        {
           
            AggregateId = aggregateId;
            Title = title;
            From = from;
            To = to;
            Description = description;
        }
    }
}
