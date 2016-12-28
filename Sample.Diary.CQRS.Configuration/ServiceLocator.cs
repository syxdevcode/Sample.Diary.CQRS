using Sample.Diary.CQRS.Messaging;
using Sample.Diary.CQRS.Reporting;
using Sample.Diary.CQRS.Storage;
using Sample.Diary.CQRS.Utils;
using StructureMap;

namespace Sample.Diary.CQRS.Configuration
{
    /*
     * 适配StructureMap版本2.6.4.1
    */
    public class ServiceLocator
    {
        /*
        private static ICommandBus _commandBus;
        private static IReportDatabase _reportDatabase;
        private static bool _isInitialized;
        private static readonly object _lockThis = new object();

        static ServiceLocator()
        {
            if (!_isInitialized)
            {
                lock (_lockThis)
                {
                    ContainerBootstrapper.BootstrapStructureMap();
                    _commandBus = ContainerBootstrapper.BootstrapStructureMap().GetInstance<ICommandBus>();
                    _reportDatabase = ContainerBootstrapper.BootstrapStructureMap().GetInstance<IReportDatabase>();
                    _isInitialized = true;
                }
            }
        }

        public static ICommandBus CommandBus
        {
            get { return _commandBus; }
        }

        public static IReportDatabase ReportDatabase
        {
            get { return _reportDatabase; }
        }
        */
    }

    public class ContainerBootstrapper
    {
        public static void BootstrapStructureMap()
        {
            //ObjectFactory.Initialize(x =>
            //{
            //    x.For(typeof(IRepository<>)).Singleton().Use(typeof(Repository<>));
            //    x.For<IEventStorage>().Singleton().Use<InMemoryEventStorage>();
            //    x.For<ICommandHandlerFactory>().Use<StructureMapCommandHandlerFactory>();
            //    x.For<IEventHandlerFactory>().Use<StructureMapEventHandlerFactory>();
            //    x.For<ICommandBus>().Use<CommandBus>();
            //    x.For<IEventBus>().Use<EventBus>();
            //    x.For<IReportDatabase>().Use<ReportDatabase>();
            //});
        }
    }
}