﻿using Sample.Diary.CQRS.CommandHandlers;
using Sample.Diary.CQRS.Commands;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sample.Diary.CQRS.Utils
{
    public class StructureMapCommandHandlerFactory : ICommandHandlerFactory
    {
        public ICommandHandler<T> GetHandler<T>() where T : Command
        {
            var handlers = GetHandlerTypes<T>().ToList();

            var cmdHandler = handlers.Select(handler =>
                (ICommandHandler<T>)IocContainer.Default.GetInstance(handler)).FirstOrDefault();

            return cmdHandler;
        }

        private IEnumerable<Type> GetHandlerTypes<T>() where T : Command
        {
            var handlers = typeof(ICommandHandler<>).Assembly.GetExportedTypes()
                .Where(x => x.GetInterfaces()
                    .Any(a => a.IsGenericType && a.GetGenericTypeDefinition() == typeof(ICommandHandler<>)))
                .Where(h => h.GetInterfaces()
                    .Any(ii => ii.GetGenericArguments()
                        .Any(aa => aa == typeof(T)))).ToList();
            return handlers;
        }
    }
}