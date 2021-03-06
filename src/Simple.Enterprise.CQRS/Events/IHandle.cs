using Simple.Enterprise.CQRS.Events.Imp;

namespace Simple.Enterprise.CQRS.Events
{
    public interface IHandle<TEvent> where TEvent : Event
    {
        void Handle(TEvent e);
    }
}
