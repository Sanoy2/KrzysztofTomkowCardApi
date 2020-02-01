using Castle.Windsor;
using Castle.Windsor.MsDependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace WebService.IoC
{
    public class ServiceResolver : IServiceProvider
    {
        private static WindsorContainer container;
        private static IServiceProvider serviceProvider;

        public ServiceResolver(IServiceCollection services)
        {
            container = new WindsorContainer();
            container.Install(new FileAccessInstaller());
            serviceProvider = WindsorRegistrationHelper.CreateServiceProvider(container, services);
        }

        public object GetService(Type serviceType)
        {
            return container.Resolve(serviceType);
        }

        public IServiceProvider GetServiceProvider()
        {
            return serviceProvider;
        }
    }
}
