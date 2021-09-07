namespace Simple.Enterprise.Sample.Diary.Event
{
    public class ItemRenamedEvent : CQRS.Events.Imp.Event
    {
        public string Title { get; internal set; }
        public ItemRenamedEvent(Guid aggregateId, string title)
        {
            AggregateId = aggregateId;
            Title = title;
        }
    }
}
