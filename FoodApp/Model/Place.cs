using System;
using Newtonsoft.Json;

namespace FoodApp.Model
{
    public class Place
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public bool OpenNow { get; set; }

        public double Rating { get; set; }

        public string Address { get; set; }

        public string PhotoReference { get; set; }

        public string GroupID { get; set; }

        [JsonIgnore]
        public string API_KEY { get; set; }

        public Place()
        {

            API_KEY = "AIzaSyAeWb6Bi96MdM3EWU5Fl0OxwRv6WiwvB_4";
        }

        public string GetPhotoURL()
        {
            string URL = "https://maps.googleapis.com/maps/api/place/photo?maxwidth=1000&photoreference=" 
            + PhotoReference 
                + "&key=" 
            + API_KEY;

            return URL;
        }
    }
}
