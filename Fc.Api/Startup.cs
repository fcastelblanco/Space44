using System;
using Autofac;
using Fc.Data.IoC;
using Fc.DomainServices.IoC;
using Fc.Entities.Dto;
using Fc.Infraestructure.IoC;
using Fc.Repository.IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Fc.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public IContainer ApplicationContainer => null;

        private Settings _settings;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var appSettingsSection = Configuration.GetSection("AppSettings");
            _settings = appSettingsSection.Get<Settings>();

            services.AddControllers();

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder
                            .WithOrigins("http://localhost:4200")
                            .AllowCredentials()
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });

            services.Configure<FormOptions>(o =>
            {
                o.ValueLengthLimit = int.MaxValue;
                o.MultipartBodyLengthLimit = int.MaxValue;
                o.MemoryBufferThreshold = int.MaxValue;
            });

            AddSwagger(services);
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.Register(x => new Settings
            {
                ApiEndpoint = _settings.ApiEndpoint,
                ApiName = _settings.ApiName,
                DbName = _settings.ApiName
            });

            builder.LoadData(_settings);
            builder.LoadInfraestructure();
            builder.LoadRepository(_settings);
            builder.LoadDomainServices();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseCors();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Fc API V1");
            });
        }

        private void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                var groupName = "v1";

                options.SwaggerDoc(groupName, new OpenApiInfo
                {
                    Title = $"Fc {groupName}",
                    Version = groupName,
                    Description = "Fc API",
                    Contact = new OpenApiContact
                    {
                        Name = "Fc",
                        Email = string.Empty,
                        Url = new Uri("https://github.com/fcastelblanco"),
                    }
                });
            });
        }
    }
}