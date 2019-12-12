using Autofac;
using Autofac.Extensions.DependencyInjection;
using Infrastructure.Common.Token;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;

namespace Infrastructure.IoC.IoC
{
    public class IoCConfig
    {
        public static AutofacServiceProvider ImplementDI(IServiceCollection services, IConfiguration Configuration)
        {
            services.Configure<TokenManagement>(Configuration.GetSection("TokenManagement"));
            //services.AddDbContext<EFContext>(options => options.UseMySql(Configuration.GetConnectionString("DBConnection")));
            ContainerBuilder builder = new ContainerBuilder();
            //builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();

            //Assembly servicesRepository = Assembly.Load("Infrastructure.Repository");
            //Type[] servicesRepositorytypes = servicesRepository.GetTypes();
            //builder.RegisterTypes(servicesRepositorytypes).AsImplementedInterfaces().InstancePerLifetimeScope();

            Assembly servicesDomain = Assembly.Load("Domain");
            Type[] servicesDomainRepositorytypes = servicesDomain.GetTypes();
            builder.RegisterTypes(servicesDomainRepositorytypes).AsImplementedInterfaces().InstancePerLifetimeScope();

            Assembly servicesApplication = Assembly.Load("AppService");
            Type[] servicesApplicationtypes = servicesApplication.GetTypes();
            builder.RegisterTypes(servicesApplicationtypes).AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.Populate(services);
            IContainer container = builder.Build();
            return new AutofacServiceProvider(container);
        }
    }
}
