using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace beersweb.Models
{
    public class BeersItem
    {
        public class BeerItem
        {
            public string id { get; set; }
            public string name { get; set; }
            public string nameDisplay { get; set; }
            public string description { get; set; }
            public string abv { get; set; }
            public string ibu { get; set; }
            public string srmId { get; set; }
            public string styleId { get; set; }
            public string isOrganic { get; set; }
            public string status { get; set; }
            public string year { get; set; }
            public string statusDisplay { get; set; }
            public string createDate { get; set; }
            public string updateDate { get; set; }

            public Labels labels { get; set; }
        }

        public class Labels
        {
            public string icon { get; set; }
            public string medium { get; set; }
            public string large { get; set; }
        }
    }
}