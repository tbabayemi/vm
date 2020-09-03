
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using vm.domain.service;
using vm.domain.service.Modules;
using vm.persistence.Contracts;
using vm.persistence.Data;
using vm.persistence.Implementation;

namespace vm.services
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; private set; }
        public ILifetimeScope AutofacContainer { get; private set; }
        private IMapper _mapper;

        public Startup(IHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);
            this.Configuration = builder.Build();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();
            services.AddDbContext<VmContext>();
            
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            _mapper = mapperConfig.CreateMapper();
            
            services.AddSingleton(_mapper);
            services.AddMvc(option => option.EnableEndpointRouting = false).AddControllersAsServices();
            
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            //builder.RegisterType<ConfigurationRoot>().As<IConfigurationRoot>();
            builder.RegisterType<UserPersistence>().As<IUserPersistence>();
            // Register your own things directly with Autofac, like:
            builder.RegisterModule(new DomainModule());
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            AutofacContainer = app.ApplicationServices.GetAutofacRoot();
            app.UseRouting();

            app.UseMvc();
        }
    }
}
