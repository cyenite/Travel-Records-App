using System;
using System.Collections.Generic;
using System.Text;
using TravelRecordsApp.Helpers;

namespace TravelRecordsApp.Model
{
    public class Venue
    {
        public static void UrlGenerator(double latitude, double longitude)
        {
            string url = string.Format(Constants.SEARCH_URL, latitude,longitude,Constants.CLIENT_ID,Constants.CLIENT_SECRET,DateTime.Now.ToString("yyyyMMdd"));

        }
    }
}
