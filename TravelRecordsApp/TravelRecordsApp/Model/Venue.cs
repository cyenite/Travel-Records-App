using System;
using System.Collections.Generic;
using System.Text;
using TravelRecordsApp.Helpers;

namespace TravelRecordsApp.Model
{
    public class VenueRoot
    {

        public Response response { get; set; }

        public static string UrlGenerator(double latitude, double longitude)
        {
            string url = string.Format(Constants.SEARCH_URL, latitude,longitude,Constants.CLIENT_ID,Constants.CLIENT_SECRET,DateTime.Now.ToString("yyyyMMdd"));

            return url;
        }
    }

   
    public class Location
    {
        public double lat { get; set; }
        public double lng { get; set; }
        public int distance { get; set; }
        public string cc { get; set; }
        public string country { get; set; }
        public IList<string> formattedAddress { get; set; }
        public string address { get; set; }
        public string crossStreet { get; set; }
        public string postalCode { get; set; }
        public string city { get; set; }
        public string state { get; set; }
    }


    public class Category
    {
        public string id { get; set; }
        public string name { get; set; }
        public string pluralName { get; set; }
        public string shortName { get; set; }
        public bool primary { get; set; }
    }

    public class Venue
    {
        public string id { get; set; }
        public string name { get; set; }
        public Location location { get; set; }
        public IList<Category> categories { get; set; }
        public string referralId { get; set; }
        public bool hasPerk { get; set; }
    }

    public class Response
    {
        public IList<Venue> venues { get; set; }
        public bool confident { get; set; }
    }

   

}
