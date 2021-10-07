using Autofac;
using Fc.Data.Definitions;
using Fc.Entities.Dto;
using Fc.Infraestructure.Definitions;
using Fc.Infraestructure.Implementations;
using Microsoft.EntityFrameworkCore;


namespace Fc.Data.IoC
{
    public static class Container
    {
        public static void LoadData(this ContainerBuilder builder, Settings settings)
        {
            builder.Register(x => new DbSettingsProvider(settings.DbName)
            ).As<IDbSettingsProvider>();

            builder.RegisterType<Context>().As<DbContext>().InstancePerLifetimeScope();
        }
    }
}