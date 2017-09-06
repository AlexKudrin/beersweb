using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using beersweb.Helpers;
using beersweb.Models;
using System.Collections.Generic;

namespace beerswebTests
{
    [TestClass]
    public class ApiClientTest
    {
        [TestMethod]
        public void TestingGetBeers()
        {
            RestApiClient api = new RestApiClient();
            Beer data = api.getBeerPage(api.key);
            Assert.IsNotNull(data);
        }

        [TestMethod]
        public void TestingGetBeersByPage()
        {
            RestApiClient api = new RestApiClient();
            Beer data = api.getBeerPage(api.key+"&p=2");
            Assert.IsNotNull(data);
        }

        [TestMethod]
        public void TestingGetBeersByName()
        {
            RestApiClient api = new RestApiClient();
            Beer data = api.getBeerPage(api.key+"&name=Beer");
            Assert.AreEqual(data.data[0].name, "Beer");
        }

        [TestMethod]
        public void TestingGetBeersSortOrder()
        {
            RestApiClient api = new RestApiClient();
            Beer data = api.getBeerPage(api.key+"&order=name&sort=DESC");
            Assert.IsNotNull(data);
        }

        [TestMethod]
        public void TestingGetBeersFilter()
        {
            RestApiClient api = new RestApiClient();
            Beer data = api.getBeerPage(api.key+"&isOrganic=Y");
            List<BeersItem.BeerItem> anyNotOrganic = new List<BeersItem.BeerItem>();
            anyNotOrganic = data.data.FindAll(row => row.isOrganic == "N");
            Assert.AreEqual(0, anyNotOrganic.Count);
        }

        [TestMethod]
        public void TestingGetBeersById()
        {
            RestApiClient api = new RestApiClient();
            //id = DR14xU, name = Maibock
            BeersItem.BeerItem data = api.getBeerById("DR14xU");
            Assert.AreEqual("Maibock", data.name);
        }


    }
}
