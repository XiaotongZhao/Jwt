using System;
using Consul;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Jwt.Middleware
{
    public static class ConsulExtensions
    {
        public static IServiceCollection AddConsulConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IConsulClient, ConsulClient>(p => new ConsulClient(consulConfig =>
            {
                var address = configuration.GetValue<string>("Consul:Host");
                consulConfig.Address = new Uri(address);
            }));
            return services;
        }

        public static IApplicationBuilder UseConsul(this IApplicationBuilder app, string host = null,
            string port = null)
        {
            //获取consul客户端实例
            var consulClient = app.ApplicationServices.GetRequiredService<IConsulClient>();
            var logger = app.ApplicationServices.GetRequiredService<ILoggerFactory>().CreateLogger("AppExtensions");
            var lifetime = app.ApplicationServices.GetRequiredService<IApplicationLifetime>();

            if (!(app.Properties["server.Features"] is FeatureCollection features)) return app;

            //var addresses = features.Get<IServerAddressesFeature>();
            //var address = addresses.Addresses.FirstOrDefault();
            //if (address == null)
            //{
            //    return app;
            //}

            var address = host + ":" + port;
            if (string.IsNullOrWhiteSpace(host) || string.IsNullOrWhiteSpace(port))
            {
                Console.WriteLine($"host或者port为空！");
                return app;
            }

            Console.WriteLine($"address={address}");
            var uri = new Uri(address);
            Console.WriteLine($"host={uri.Host},port={uri.Port}");

            var registration = new AgentServiceRegistration()
            {
                ID = $"MyService-{uri.Port}",
                Name = "Jwt",
                Address = $"{uri.Host}",
                Port = uri.Port,
                Check = new AgentServiceCheck()
                {
                    DeregisterCriticalServiceAfter = TimeSpan.FromSeconds(5), //服务启动多久后注册
                    Interval = TimeSpan.FromSeconds(10), //健康检查时间间隔
                    HTTP = $"{address}/HealthCheck", //健康检查地址
                    Timeout = TimeSpan.FromSeconds(5) //超时时间
                }
            };
            logger.LogInformation("Registering with Consul");
            logger.LogInformation($"Consul RegistrationID:{registration.ID}");
            //注销
            consulClient.Agent.ServiceDeregister(registration.ID).ConfigureAwait(true);
            //注册
            consulClient.Agent.ServiceRegister(registration).ConfigureAwait(true);
            //应用程序关闭时候
            lifetime.ApplicationStopping.Register(() =>
            {
                //正在注销
                logger.LogInformation("Unregistering from Consul");
                consulClient.Agent.ServiceDeregister(registration.ID).ConfigureAwait(true);
            });
            //每个服务都需要提供一个用于健康检查的接口，该接口不具备业务功能。服务注册时把这个接口的地址也告诉注册中心，注册中心会定时调用这个接口来检测服务是否正常，如果不正常，则将它移除，这样就保证了服务的可用性。
            app.Map("/HealthCheck", s => { s.Run(async context => { await context.Response.WriteAsync("ok"); }); });
            return app;
        }
    }
}