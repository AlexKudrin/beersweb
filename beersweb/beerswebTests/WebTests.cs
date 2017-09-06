using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using beersweb.Controllers;
using System.Web.Mvc;
using System.Xml.Linq;
using beersweb.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Web.Script.Serialization;

namespace beerswebTests
{
    [TestClass]
    public class WebTests
    {
        [TestMethod]
        public void TestingIndexViewData()
        {
            HomeController controller = new HomeController();
            ViewResult result = controller.Index(null, null, null, null, null) as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestingGetModel()
        {
            //id = DR14xU, name = Maibock
            HomeController controller = new HomeController();
            JsonResult result = controller.getModel("DR14xU");
            string json = new JavaScriptSerializer().Serialize(result.Data);
            BeersItem.BeerItem beer = JsonConvert.DeserializeObject<BeersItem.BeerItem>(json);
            Assert.AreEqual("Maibock", beer.name);
        }

    }
}
