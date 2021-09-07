using Autofac;
using Simple.Enterprise.CQRS.Commands;
using Simple.Enterprise.CQRS.Commands.Imp;

namespace Simple.Enterprise.CQRS.Utils
{
    public class AutofacIns
    {
        public static AutofacIns Ins = new AutofacIns();
        private AutofacIns()
        {

        }
        public IContainer Container { get; private set; }


    }
    public class StructureMapCommandHandlerFactory : ICommandHandlerFactory
    {



        public ICommandHandler<T> GetHandler<T>() where T : Command
        {
            var handlers = GetHandlerTypes<T>().ToList();
            var cmdHandler = handlers.Select(handler =>
                (ICommandHandler<T>)AutofacIns.Ins.Container.Resolve(handler)).FirstOrDefault();

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
