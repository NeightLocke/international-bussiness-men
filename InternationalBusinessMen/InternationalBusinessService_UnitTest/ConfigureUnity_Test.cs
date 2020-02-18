using System;
using InternationalBusinessBaseTracing.Interfaces;
using InternationalBusinessDataManager.Interfaces;
using InternationalBusinessFileManager.Interfaces;
using InternationalBusinessServiceLibrary.Interfaces;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InternationalBusinessService_UnitTest
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
                InternationalBusinessServiceLibrary.Unity.ConfigureUnity.Configure(container);
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
                InternationalBusinessServiceLibrary.Unity.ConfigureUnity.Configure(container);
                myTracing = container.Resolve<ITracing>();
            }

            Assert.IsNotNull(myTracing);
        }

        [TestMethod]
        public void FileProvider()
        {
            IPersistentManager fileProvider = null;

            using (IUnityContainer container = new UnityContainer())
            {
                InternationalBusinessServiceLibrary.Unity.ConfigureUnity.Configure(container);
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
                InternationalBusinessServiceLibrary.Unity.ConfigureUnity.Configure(container);
                dataManager = container.Resolve<IDataManager>();
            }

            Assert.IsNotNull(dataManager);
        }
    }
}