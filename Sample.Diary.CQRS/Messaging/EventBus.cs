using Sample.Diary.CQRS.Events;
using Sample.Diary.CQRS.Utils;

namespace Sample.Diary.CQRS.Messaging
{
    public class EventBus : IEventBus
    {
        private IEventHandlerFactory _eventHanlderFactory;

        public EventBus(IEventHandlerFactory eventHandlerFactory)
        {
            _eventHanlderFactory = eventHandlerFactory;
        }

        public void Publish<T>(T @event) where T : Event
        {
            var handlers = _eventHanlderFactory.GetHandlers<T>();
            foreach (var eventHandler in handlers)
            {
                eventHandler.Handle(@event);
            }
        }
    }
}