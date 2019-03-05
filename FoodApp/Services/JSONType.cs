using System;

namespace FoodApp.Services
{

    public partial class FoodAppServices
    {
        public object[] HtmlAttributions { get; set; }
        public string NextPageToken { get; set; }
        public Result[] Results { get; set; }
        public string Status { get; set; }
    }

    public partial class Result
    {
        public Geometry Geometry { get; set; }
        public Uri Icon { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public OpeningHours OpeningHours { get; set; }
        public Photo[] Photos { get; set; }
        public string PlaceId { get; set; }
        public PlusCode PlusCode { get; set; }
        public double Rating { get; set; }
        public string Reference { get; set; }
        public Scope Scope { get; set; }
        public TypeElement[] Types { get; set; }
        public long UserRatingsTotal { get; set; }
        public string Vicinity { get; set; }
        public long? PriceLevel { get; set; }
    }

    public partial class Geometry
    {
        public Location Location { get; set; }
        public Viewport Viewport { get; set; }
    }

    public partial class Location
    {
        public double Lat { get; set; }
        public double Lng { get; set; }
    }

    public partial class Viewport
    {
        public Location Northeast { get; set; }
        public Location Southwest { get; set; }
    }

    public partial class OpeningHours
    {
        public bool OpenNow { get; set; }
    }

    public partial class Photo
    {
        public long Height { get; set; }
        public string[] HtmlAttributions { get; set; }
        public string PhotoReference { get; set; }
        public long Width { get; set; }
    }

    public partial class PlusCode
    {
        public string CompoundCode { get; set; }
        public string GlobalCode { get; set; }
    }

    public enum Scope { Google };

    public enum TypeElement { Bar, Cafe, Establishment, Food, Lodging, MealTakeaway, PointOfInterest, Restaurant, Store };
}