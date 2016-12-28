using Sample.Diary.CQRS.Events;
using Sample.Diary.CQRS.Reporting;

namespace Sample.Diary.CQRS.EventHandlers
{
    public class ItemDeletedEventHandler : IEventHandler<ItemDeletedEvent>
    {
        private readonly IReportDatabase _reportDatebase;

        public ItemDeletedEventHandler(IReportDatabase reportDatabase)
        {
            _reportDatebase = reportDatabase;
        }

        public void Handle(ItemDeletedEvent e)
        {
            _reportDatebase.Delete(e.AggregateId);
        }
    }
}