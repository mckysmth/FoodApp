using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Http;
using System.Threading.Tasks;
using FoodApp.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FoodApp.Services
{
    public class GooglePlacesService
    {

        public string URL { get; set; }

        public string API_KEY { get; set; }

        public double Longitude { get; set; }

        public double Latitude { get; set; }

        public string NextPageToken { get; set; }

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
        }

        public async Task<List<Place>> GetPlaceList()
        {
            HttpClient client = new HttpClient();
            string response = await client.GetStringAsync(URL);

            JObject data = JObject.Parse(response);

            NextPageToken = data["next_page_token"].ToString();


            List<JObject> results = data["results"].ToObject<List<JObject>>();

            List<Place> places = new List<Place>();

            foreach (var item in results)
            {
                Place place = new Place
                {
                    Name = item["name"].ToString(),
                    Latitude = (double)item["geometry"]["location"]["lat"],
                    Longitude = (double)item["geometry"]["location"]["lng"],
                    OpenNow = (bool)item["opening_hours"]["open_now"],
                    Rating = (double)item["rating"],
                    Address = item["vicinity"].ToString(),
                    PhotoReference = item["photos"][0]["photo_reference"].ToString()
                };

                places.Add(place);
            }

            return places;

        }

        public async Task<List<Place>> NextPageAsync()
        {
            string nextPageURL = "https://maps.googleapis.com/maps/api/place/nearbysearch/json?pagetoken=" 
            + NextPageToken 
                + "&key=" 
            + API_KEY;

            HttpClient client = new HttpClient();
            string response = await client.GetStringAsync(nextPageURL);

            JObject data = JObject.Parse(response);

            try
            {
                NextPageToken = data["next_page_token"].ToString();

            }
            catch (Exception)
            {
                NextPageToken = string.Empty;
            }


            List<JObject> results = data["results"].ToObject<List<JObject>>();

            List<Place> places = new List<Place>();

            foreach (var item in results)
            {
                try
                {
                    places.Add(new Place()
                    {
                        Name = item["name"].ToString(),
                        Latitude = (double)item["geometry"]["location"]["lat"],
                        Longitude = (double)item["geometry"]["location"]["lng"],
                        OpenNow = (bool)item["opening_hours"]["open_now"],
                        Rating = (double)item["rating"],
                        Address = item["vicinity"].ToString(),
                        PhotoReference = item["photos"][0]["photo_reference"].ToString()
                    });

                  
                }
                catch (Exception ex)
                {

                }



            }

            return places;
        }

    }
}
