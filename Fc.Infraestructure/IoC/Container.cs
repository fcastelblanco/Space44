using Autofac;
using Fc.Infraestructure.Definitions;
using Fc.Infraestructure.Implementations;

namespace Fc.Infraestructure.IoC
{
    public static class Container 
    {
        public static void LoadInfraestructure(this ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
        }
    }
}