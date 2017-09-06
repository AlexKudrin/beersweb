using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace beersweb.Models
{
    public class Beer
    {
        public List<BeersItem.BeerItem> data { get; set; }
        public int currentPage { get; set; }
        public int numberOfPages { get; set; }
        public int totalResults { get; set; }
    }

}