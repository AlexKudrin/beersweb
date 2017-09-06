using beersweb.Helpers;
using beersweb.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace beersweb.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index(int? page, string name, string sortOrder, string organic, string labels)
        {
            RestApiClient api = new RestApiClient();

            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "date_asc" ? "date_desc" : "date_asc";
            ViewBag.DescriptionSortParm = sortOrder == "description_asc" ? "description_desc" : "description_asc";
            ViewBag.OrganicSortParm = sortOrder == "organic_asc" ? "organic_desc" : "organic_asc";
            ViewBag.ABVSortParm = sortOrder == "abv_asc" ? "abv_desc" : "abv_asc";
            ViewBag.IBUSortParm = sortOrder == "ibu_asc" ? "ibu_desc" : "ibu_asc";
            
            string urlParameters = prepareParameters(api.key, page, name, sortOrder, organic, labels);

            var beersModel = api.getBeerPage(urlParameters);

            if (beersModel.data != null)
            {
                beersModel.data.Where(row => row.labels == null).ToList().ForEach(row => row.labels = new BeersItem.Labels());
                beersModel.data.Where(row => row.labels.icon == null).ToList().ForEach(row => row.labels.icon = "https://www.cheapbats.com/uploads/commerce/images/att_img_sm/noimage.gif");
            }

            return View(beersModel);
        }

        [HttpGet]
        public JsonResult getModel(string id)
        {
            RestApiClient api = new RestApiClient();

            var beerModel = api.getBeerById(id);

            if (beerModel.labels == null)
            {
                beerModel.labels = new Models.BeersItem.Labels();
                beerModel.labels.medium = "https://www.cheapbats.com/uploads/commerce/images/att_img_sm/noimage.gif";
            }

            foreach (PropertyInfo propertyInfo in beerModel.GetType().GetProperties())
            {
                if (propertyInfo.PropertyType == typeof(string))
                {
                    string value = (string)propertyInfo.GetValue(beerModel);
                    if (string.IsNullOrEmpty(value))
                    {
                        propertyInfo.SetValue(beerModel, "");
                    }
                }
            }

            return Json(beerModel, JsonRequestBehavior.AllowGet); 
        }

        public string prepareParameters(string key, int? page, string name, string sortOrder, string organic, string labels)
        {
            string urlParameters= key;

            if (page != null)
                urlParameters = urlParameters + "&p=" + page;

            if (organic == "true")
                urlParameters = urlParameters + "&isOrganic=Y";

            if (labels == "true")
                urlParameters = urlParameters + "&hasLabels=Y";

            if (!String.IsNullOrEmpty(name) && name != "null")
                urlParameters = urlParameters + "&name=*" + name + "*";

            string order;

            switch (sortOrder)
            {
                case "name_desc":
                    order = "&order=name&sort=DESC";
                    break;

                case "date_desc":
                    order = "&order=createDate&sort=DESC";
                    break;

                case "date_asc":
                    order = "&order=createDate&sort=ASC";
                    break;

                case "description_asc":
                    order = "&order=description&sort=ASC";
                    break;

                case "description_desc":
                    order = "&order=description&sort=DESC";
                    break;

                case "organic_asc":
                    order = "&order=isOrganic&sort=ASC";
                    break;

                case "organic_desc":
                    order = "&order=isOrganic&sort=DESC";
                    break;

                case "abv_asc":
                    order = "&order=abv&sort=ASC";
                    break;

                case "abv_desc":
                    order = "&order=abv&sort=DESC";
                    break;

                case "ibu_asc":
                    order = "&order=ibu&sort=ASC";
                    break;

                case "ibu_desc":
                    order = "&order=ibu&sort=DESC";
                    break;

                default:
                    order = "&order=name&sort=ASC";
                    break;
            }

            urlParameters = urlParameters + order;
            return urlParameters;
        }

    }
}