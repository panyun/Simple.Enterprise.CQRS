using Simple.Enterprise.CQRS.Domain.Imp;
using Simple.Enterprise.CQRS.Storage;
using Simple.Enterprise.CQRS.Storage.Imp;
using Simple.Enterprise.Sample.Diary.Domain.Mementos;
using Simple.Enterprise.Sample.Diary.Event;

namespace Simple.Enterprise.Sample.Diary.Domain
{
    public class DiaryItem : AggregateRoot,
          IOriginator
    {
        public string Title { get; set; }

        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public string Description { get; set; }

        public DiaryItem()
        {

        }

        public DiaryItem(Guid id, string title, string description, DateTime from, DateTime to)
        {
            ApplyChange(new ItemCreatedEvent(id, title, description, from, to));
        }

        public void ChangeTitle(string title)
        {
            ApplyChange(new ItemRenamedEvent(Id, title));
        }

        public void ChangeDescription(string description)
        {
            ApplyChange(new ItemDescriptionChangedEvent(Id, description));
        }

        public void ChangeFrom(DateTime from)
        {
            ApplyChange(new ItemFromChangedEvent(Id, from));
        }

        public void ChangeTo(DateTime to)
        {
            ApplyChange(new ItemToChangedEvent(Id, to));
        }

        public void Delete()
        {
            ApplyChange(new ItemDeletedEvent(Id));
        }

        public void Handle(ItemDeletedEvent e)
        {

        }

        public void Handle(ItemCreatedEvent e)
        {
            Title = e.Title;
            From = e.From;
            To = e.To;
            Id = e.AggregateId;
            Description = e.Description;
            Version = e.Version;
        }

        public void Handle(ItemRenamedEvent e)
        {
            Title = e.Title;
        }

        public void Handle(ItemFromChangedEvent e)
        {
            From = e.From;
        }

        public void Handle(ItemToChangedEvent e)
        {
            To = e.To;
        }

        public void Handle(ItemDescriptionChangedEvent e)
        {
            Description = e.Description;
        }

        public BaseMemento GetMemento()
        {
            return new DiaryItemMemento(Id, Title, Description, From, To, Version);
        }

        public void SetMemento(BaseMemento memento)
        {
            Title = ((DiaryItemMemento)memento).Title;
            To = ((DiaryItemMemento)memento).To;
            Version = memento.Version;
            From = ((DiaryItemMemento)memento).From;
            Description = ((DiaryItemMemento)memento).Description;
            Id = memento.Id;
        }


    }
}
