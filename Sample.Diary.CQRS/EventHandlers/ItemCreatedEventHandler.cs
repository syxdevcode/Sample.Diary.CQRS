using Sample.Diary.CQRS.Events;
using Sample.Diary.CQRS.Reporting;

namespace Sample.Diary.CQRS.EventHandlers
{
    public class ItemCreatedEventHandler : IEventHandler<ItemCreatedEvent>
    {
        private readonly IReportDatabase _reportDatabase;

        public ItemCreatedEventHandler(IReportDatabase reportDatabase)
        {
            _reportDatabase = reportDatabase;
        }

        public void Handle(ItemCreatedEvent e)
        {
            DiaryItemDto item = new DiaryItemDto()
            {
                Id = e.AggregateId,
                Description = e.Description,
                From = e.From,
                Title = e.Title,
                To = e.To,
                Version = e.Version
            };
            _reportDatabase.Add(item);
        }
    }
}