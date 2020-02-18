using System;
using InternationalBusinessBaseTracing.Interfaces;
using InternationalBusinessDataManager.Interfaces;
using InternationalBusinessFileManager.Interfaces;
using InternationalBusinessServiceLibrary.Interfaces;
using InternationalBusinessWebApi.App_Start;
using InternationalBusinessWebApiLibrary.Interfaces;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InternationalBusinessWebApi_UnitTest
{
    [TestClass]
    public class ConfigureUnity_Test
    {
        [TestMethod]
        public void Service()
        {
            IInternationalBusinessService service = null;

            using (IUnityContainer container = new UnityContainer())
            {
                UnityConfig.RegisterTypes(container);
                service = container.Resolve<IInternationalBusinessService>();
            }

            Assert.IsNotNull(service);
        }

        [TestMethod]
        public void Tracing()
        {
            ITracing myTracing = null;

            using (IUnityContainer container = new UnityContainer())
            {
                UnityConfig.RegisterTypes(container);
                myTracing = container.Resolve<ITracing>();
            }

            Assert.IsNotNull(myTracing);
        }

        [TestMethod]
        public void Adapter()
        {
            IInternationalBusinessAdapter adapter = null;

            using (IUnityContainer container = new UnityContainer())
            {
                UnityConfig.RegisterTypes(container);
                adapter = container.Resolve<IInternationalBusinessAdapter>();
            }

            Assert.IsNotNull(adapter);
        }

        [TestMethod]
        public void FileProvider()
        {
            IPersistentManager fileProvider = null;

            using (IUnityContainer container = new UnityContainer())
            {
                UnityConfig.RegisterTypes(container);
                fileProvider = container.Resolve<IPersistentManager>();
            }

            Assert.IsNotNull(fileProvider);
        }

        [TestMethod]
        public void DataManager()
        {
            IDataManager dataManager = null;

            using (IUnityContainer container = new UnityContainer())
            {
                UnityConfig.RegisterTypes(container);
                dataManager = container.Resolve<IDataManager>();
            }

            Assert.IsNotNull(dataManager);
        }
    }
}