using Autofac;
using Fc.DomainServices.Definitions;
using Fc.DomainServices.Implementations;

namespace Fc.DomainServices.IoC
{
    public static class Container
    {
        public static void LoadDomainServices(this ContainerBuilder builder)
        {
            builder.RegisterType<SourceService>().As<ISourceService>().InstancePerLifetimeScope();
            builder.RegisterType<ImageService>().As<IImageService>().InstancePerLifetimeScope();
            builder.RegisterInstance(MapperConfig.Initialize()).SingleInstance();
        }
    }
}
