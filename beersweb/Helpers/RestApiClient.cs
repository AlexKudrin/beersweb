using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using beersweb.Models;
using System.Diagnostics;
using PagedList;
using static beersweb.Models.BeersItem;

namespace beersweb.Helpers
{
    public class RestApiClient
    {

        public string key = "?key=4c48bd4a8f21fd967abdd363dab3676d";
        public string URL = "http://api.brewerydb.com/v2/";
        
        public Beer getBeerPage(string urlParameters)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL);
            Beer dataObjects = new Beer();

            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            URL = URL + "beers/" + urlParameters;

            // List data response.
            HttpResponseMessage response = client.GetAsync(URL).Result;  
            if (response.IsSuccessStatusCode)
            {
                dataObjects = response.Content.ReadAsAsync<Beer>().Result;
            }

            return dataObjects;
        }

        public BeerItem getBeerById(string id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL);
            BeerSingle dataObjects = new BeerSingle();

            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            URL = URL + "beer/"+ id+"/" + key;

            // List data response.
            HttpResponseMessage response = client.GetAsync(URL).Result;
            if (response.IsSuccessStatusCode)
            {
                dataObjects = response.Content.ReadAsAsync<BeerSingle>().Result;
            }

            return dataObjects.data;
        }

    }
}