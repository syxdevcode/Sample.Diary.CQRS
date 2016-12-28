using Sample.Diary.CQRS.Events;

namespace Sample.Diary.CQRS.EventHandlers
{
    public interface IEventHandler<TEvent> where TEvent : Event
    {
        void Handle(TEvent e);
    }
}