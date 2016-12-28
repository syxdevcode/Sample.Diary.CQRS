using Sample.Diary.CQRS.Events;
using Sample.Diary.CQRS.Reporting;

namespace Sample.Diary.CQRS.EventHandlers
{
    public class ItemDescriptionChangedEventHandler : IEventHandler<ItemDescriptionChangedEvent>
    {
        private readonly IReportDatabase _reportDatabase;

        public ItemDescriptionChangedEventHandler(IReportDatabase reportDatabase)
        {
            _reportDatabase = reportDatabase;
        }

        public void Handle(ItemDescriptionChangedEvent e)
        {
            var item = _reportDatabase.GetById(e.AggregateId);
            item.Description = e.Description;
            item.Version = e.Version;
        }
    }
}