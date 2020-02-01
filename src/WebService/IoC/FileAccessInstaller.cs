using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using FileAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebService.FileAccess;

namespace WebService.IoC
{
    public class FileAccessInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IFileRepository>().ImplementedBy<FileRepository>().LifestyleTransient());
            container.Register(Component.For<IPathProvider>().ImplementedBy<FilePathProvider>().LifestyleTransient());
        }
    }
}
