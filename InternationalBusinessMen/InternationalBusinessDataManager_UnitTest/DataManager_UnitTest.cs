using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using InternationalBusinessBaseTracing.Interfaces;
using InternationalBusinessDataManager;
using InternationalBusinessDTOs;
using InternationalBusinessFileManager.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace InternationalBusinessDataManager_UnitTest
{
    [TestClass]
    public class DataManager_UnitTest
    {
        private IPersistentManager fileProvider;
        private IDataProvider jsonProvider;
        private ITracing myTracing;

        private Mock<IPersistentManager> moqFileProvider;
        private Mock<IDataProvider> moqJsonProvider;
        private Mock<ITracing> moqTracing;

        private DataManager dataManager = null;
        private bool isRates;
        private bool jsonIsNull;

        public DataManager_UnitTest()
        {
            fileProvider = ConfigureMoqFileProvider();
            jsonProvider = ConfigureJsonProvider();
            myTracing = ConfigureTracingProvider();

            dataManager = new DataManager(fileProvider, jsonProvider, myTracing);
        }

        private ITracing ConfigureTracingProvider()
        {
            moqTracing = new Mock<ITracing>();
            return moqTracing.Object;
        }

        private IDataProvider ConfigureJsonProvider()
        {
            moqJsonProvider = new Mock<IDataProvider>();
            moqJsonProvider
                .Setup(m => m.GetDataFromUri(It.IsAny<string>()))
                .Returns(() =>
                {
                    if (jsonIsNull)
                    {
                        return string.Empty;
                    }
                    string messsage = isRates ? File.ReadAllText(@"./Resources/rates.json") : File.ReadAllText(@"./Resources/transactions.json");
                    return messsage;
                });
            return moqJsonProvider.Object;
        }

        private IPersistentManager ConfigureMoqFileProvider()
        {
            moqFileProvider = new Mock<IPersistentManager>();
            return moqFileProvider.Object;
        }

        [TestInitialize]
        public void TestInitialize()
        {
            moqFileProvider.Invocations.Clear();
            moqJsonProvider.Invocations.Clear();
            moqTracing.Invocations.Clear();
            isRates = false;
            jsonIsNull = false;
        }

        [TestMethod]
        public void GetRates_Ok()
        {
            isRates = true;
            IEnumerable<Rates> result = dataManager.GetRates();
            Assert.IsNotNull(result);
            moqJsonProvider.Verify(m => m.GetDataFromUri(It.IsAny<string>()), Times.Once);
            moqFileProvider.Verify(m => m.Write(It.IsAny<IEnumerable<Rates>>()), Times.Once);
        }

        [TestMethod]
        public void GetRates_Returns_Empty_List_When_Json_Is_Empty()
        {
            isRates = true;
            jsonIsNull = true;
            IEnumerable<Rates> result = dataManager.GetRates();
            Assert.IsNull(result);
            moqJsonProvider.Verify(m => m.GetDataFromUri(It.IsAny<string>()), Times.Once);
            moqFileProvider.Verify(m => m.Write(It.IsAny<IEnumerable<Rates>>()), Times.Once);
        }

        [TestMethod]
        public void GetRates_Returns_Empty_List_When_Set_Wrong_Object()
        {
            jsonIsNull = true;
            IEnumerable<Rates> result = dataManager.GetRates();
            Assert.IsNull(result);
            moqJsonProvider.Verify(m => m.GetDataFromUri(It.IsAny<string>()), Times.Once);
            moqFileProvider.Verify(m => m.Write(It.IsAny<IEnumerable<Rates>>()), Times.Once);
        }

        [TestMethod]
        public void GetTransactions_Ok()
        {
            IEnumerable<Transaction> result = dataManager.GetTransactions();
            Assert.IsNotNull(result);
            moqJsonProvider.Verify(m => m.GetDataFromUri(It.IsAny<string>()), Times.Once);
            moqFileProvider.Verify(m => m.Write(It.IsAny<IEnumerable<Transaction>>()), Times.Once);
        }

        [TestMethod]
        public void GetTransactions_Returns_Empty_List_Failed_When_Json_Is_Empty()
        {
            jsonIsNull = true;
            IEnumerable<Transaction> result = dataManager.GetTransactions();
            Assert.IsNull(result);
            moqJsonProvider.Verify(m => m.GetDataFromUri(It.IsAny<string>()), Times.Once);
            moqFileProvider.Verify(m => m.Write(It.IsAny<IEnumerable<Transaction>>()), Times.Once);
        }

        [TestMethod]
        public void GetTransactions_Returns_Empty_List_When_Set_Wrong_Object()
        {
            jsonIsNull = true;
            IEnumerable<Transaction> result = dataManager.GetTransactions();
            Assert.IsNull(result);
            moqJsonProvider.Verify(m => m.GetDataFromUri(It.IsAny<string>()), Times.Once);
            moqFileProvider.Verify(m => m.Write(It.IsAny<IEnumerable<Transaction>>()), Times.Once);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void GetRates_When_EndPoint_Is_Null()
        {
            try
            {
                ConfigurationManager.AppSettings.Set("RatesUrl", "");
                dataManager.GetRates();
            }
            catch (Exception ex)
            {
                ConfigurationManager.AppSettings.Set("RatesUrl", "http://quiet-stone-2094.herokuapp.com/rates.json");
                throw ex;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void GetTransactions_When_EndPoint_Is_Null()
        {
            try
            {
                ConfigurationManager.AppSettings.Set("TransactionsUrl", "");
                dataManager.GetTransactions();
            }
            catch (Exception ex)
            {
                ConfigurationManager.AppSettings.Set("TransactionsUrl", "http://quiet-stone-2094.herokuapp.com/transactions.json");
                throw ex;
            }
        }
    }
}
