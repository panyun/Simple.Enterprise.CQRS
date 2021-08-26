using Autofac;
using Simple.Enterprise.CQRS.EventHandlers;
using Simple.Enterprise.CQRS.Events.Imp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.Enterprise.CQRS.Utils
{
    public class StructureMapEventHandlerFactory : IEventHandlerFactory
    {
        public IEnumerable<IEventHandler<T>> GetHandlers<T>() where T : Event
        {
            var handlers = GetHandlerType<T>();
            var lstHandlers = handlers.Select(handler => (IEventHandler<T>)AutofacIns.Ins.Container.Resolve(handler)).ToList();
            return lstHandlers;
        }

        private static IEnumerable<Type> GetHandlerType<T>() where T : Event
        {/*
            var handlers = typeof(IEventHandler<T>).Assembly.GetExportedTypes()
                .Where(x => x.GetInterfaces()
                    .Any(a => a.IsGenericType && a.GetGenericTypeDefinition() == typeof(IEventHandler<>)));
            return handlers;*/

            var handlers = typeof(IEventHandler<>).Assembly.GetExportedTypes()
                .Where(x => x.GetInterfaces()
                    .Any(a => a.IsGenericType && a.GetGenericTypeDefinition() == typeof(IEventHandler<>))).Where(h => h.GetInterfaces().Any(ii => ii.GetGenericArguments().Any(aa => aa == typeof(T)))).ToList();


            return handlers;
        }
    }
}
