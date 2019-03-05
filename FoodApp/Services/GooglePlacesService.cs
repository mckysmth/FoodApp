using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FoodApp.Services
{
    public class GooglePlacesService
    {

        public string URL { get; set; }

        private string API_KEY { get; set; }

        public double Longitude { get; set; }

        public double Latitude { get; set; }

        private int radius;
        public int Radius
        {
            get
            {
                return radius;
            }
            set
            {
                radius = (int)(value * 1609.35);
            }
        }

        public GooglePlacesService(double latitude, double longitude)
        {
            Radius = 5;
            Latitude = latitude;
            Longitude = longitude;
            API_KEY = "AIzaSyAeWb6Bi96MdM3EWU5Fl0OxwRv6WiwvB_4";
            URL = "https://maps.googleapis.com/maps/api/place/nearbysearch/json?location=" + Latitude + "," + Longitude + "&radius=" + Radius + "&type=restaurant&key=" + API_KEY;
            GetJSON();
        }

        private async void GetJSON()
        {
            HttpClient client = new HttpClient();
            string response = await client.GetStringAsync(URL);

            dynamic data = JObject.Parse(response);
            //Console.Write(data["results"]);
        }
    }
}
