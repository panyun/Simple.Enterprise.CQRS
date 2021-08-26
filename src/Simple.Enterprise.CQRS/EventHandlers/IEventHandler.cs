using Simple.Enterprise.CQRS.Events.Imp;

namespace Simple.Enterprise.CQRS.EventHandlers
{
    public interface IEventHandler<TEvent> where TEvent : Event
    {
        void Handle(TEvent handle);
    }
}
