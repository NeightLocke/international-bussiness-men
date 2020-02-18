using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternationalBusinessServiceLibrary.Unity
{
    public static class ConfigureUnity
    {
        public static void Configure(IUnityContainer container)
        {
            container.RegisterType<
                InternationalBusinessBaseTracing.Interfaces.ITracing,
                InternationalBusinessBaseTracing.Log4NetTracing>(new ContainerControlledLifetimeManager());

            container.RegisterType<
                InternationalBusinessServiceLibrary.Interfaces.IInternationalBusinessService,
                InternationalBusinessServiceLibrary.InternationalBusinessService>();

            container.RegisterType<
                InternationalBusinessFileManager.Interfaces.IPersistentManager,
                InternationalBusinessFileManager.PersistentManager>(new ContainerControlledLifetimeManager());

            container.RegisterType<
                InternationalBusinessDataManager.Interfaces.IDataManager,
                InternationalBusinessDataManager.DataManager>(new ContainerControlledLifetimeManager());

            container.RegisterType<
                InternationalBusinessFileManager.Interfaces.IDataProvider,
                InternationalBusinessFileManager.JsonProvider>(new ContainerControlledLifetimeManager());
        }
    }
}