using System;
using System.Collections.Generic;
using System.Net.Http;
using Autofac;
using Fc.Entities.Dto;
using Fc.Repository.Definitions;
using Fc.Repository.Implementations;

namespace Fc.Repository.IoC
{
    public static class Container
    {
        public static void LoadRepository(this ContainerBuilder builder, Settings settings)
        {
            var clientHandler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
            };

            builder.Register(x => new Dictionary<string, HttpClient>
                {
                    {
                        settings.ApiName,
                        new HttpClient(clientHandler)
                        {
                            BaseAddress = new Uri(settings.ApiEndpoint)
                        }
                    }
                }
            );

            builder.RegisterType<SourceRepository>().As<ISourceRepository>().InstancePerLifetimeScope();
            builder.RegisterType<ImageRepository>().As<IImageRepository>().InstancePerLifetimeScope();
        }
    }
}
