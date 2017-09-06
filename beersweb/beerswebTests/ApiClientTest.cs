using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using beersweb.Helpers;
using beersweb.Models;

namespace beerswebTests
{
    [TestClass]
    public class ApiClientTest
    {
        [TestMethod]
        public void TestingGetBeers()
        {
            RestApiClient api = new RestApiClient();
            Beer data = api.getBeerData(null);
            Assert.IsNotNull(data);
        }

        [TestMethod]
        public void TestingGetBeersByPage()
        {
            RestApiClient api = new RestApiClient();
            Beer data = api.getBeerData("&p=2");
            Assert.IsNotNull(data);
        }

        [TestMethod]
        public void TestingGetBeersByName()
        {
            RestApiClient api = new RestApiClient();
            Beer data = api.getBeerData("&name=beer");
            Assert.AreEqual(data.data[0].name, "beer");
        }

        [TestMethod]
        public void TestingGetBeersSortOrder()
        {
            RestApiClient api = new RestApiClient();
            Beer data = api.getBeerData("&order=name&sort=DESC");
            Assert.IsNotNull(data);
        }

        [TestMethod]
        public void TestingGetBeersFilter()
        {
            RestApiClient api = new RestApiClient();
            Beer data = api.getBeerData("&organic=on");
            var anyNotOrganic = data.data.FindAll(row => row.isOrganic == "N");
            Assert.IsNull(anyNotOrganic);
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
