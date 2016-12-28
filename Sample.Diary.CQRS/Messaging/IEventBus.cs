using Sample.Diary.CQRS.Events;

namespace Sample.Diary.CQRS.Messaging
{
    public interface IEventBus
    {
        void Publish<T>(T @event) where T : Event;
    }
}