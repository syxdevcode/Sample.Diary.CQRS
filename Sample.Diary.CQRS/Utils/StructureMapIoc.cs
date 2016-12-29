using Sample.Diary.CQRS.Messaging;
using Sample.Diary.CQRS.Reporting;
using Sample.Diary.CQRS.Storage;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Diary.CQRS.Utils
{
    public class StructureMapIOC
    {
        private static ICommandBus _commandBus;
        private static IReportDatabase _reportDatabase;
        private static bool _isInitialized;
        private static readonly object _lockThis = new object();

        static StructureMapIOC()
        {
            if (!_isInitialized)
            {
                lock (_lockThis)
                {
                    _commandBus = IocContainer.Default.GetInstance<ICommandBus>();
                    _reportDatabase = IocContainer.Default.GetInstance<IReportDatabase>();
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
    }

    public class IocContainer
    {
        public static Container Default = new Container();
    }

    public class Bootstrapper
    {
        public static void BootstrapStructureMap()
        {
            IocContainer.Default.Configure(x =>
            {
                x.For(typeof(IRepository<>)).Singleton().Use(typeof(Repository<>));
                x.For<IEventStorage>().Singleton().Use<InMemoryEventStorage>();
                x.For<ICommandHandlerFactory>().Use<StructureMapCommandHandlerFactory>();
                x.For<IEventHandlerFactory>().Use<StructureMapEventHandlerFactory>();
                x.For<ICommandBus>().Use<CommandBus>();
                x.For<IEventBus>().Use<EventBus>();
                x.For<IReportDatabase>().Use<ReportDatabase>();
            });
        }
    }
}
