using Newtonsoft.Json;

namespace ClassLibrary.Models;

public class CarrierBartolini
{
    public int id { get; set; }
    public string name { get; set; }
    public List<Point> points { get; set; }
}

public class Coordinates
{
    private string latString;

    public double Lat { get; set; }
    [JsonProperty("latitude")]
    public string latitude

    {
        get { return latString; }
        set
        {
            latString = value;
            latString = latString.Replace(".", ",");
            Lat = Convert.ToDouble(latString);
        }
    }


    private string lngString;

    public double Lng { get; set; }
    [JsonProperty("longitude")]
    public string longitude
    {
        get { return lngString; }
        set
        {
            lngString = value;
            lngString = lngString.Replace(".", ",");
            Lng = Convert.ToDouble(lngString);
        }
    }
}

public class Point
{
    [JsonIgnore]
    private string _city;
    [JsonProperty("code")]
    public string code { get; set; }
    public Coordinates coordinates { get; set; }
    [JsonProperty("street")]
    public string street { get; set; }
    public string streetNumber { get; set; }
    [JsonProperty("city")]
    public string city
    {
        get { return _city; }
        set
        {
            _city = value;
            street = $"{street} {streetNumber}";
            CustomerPickUpBranchName = $"{_city}, {street}";
        }
    }
    [JsonProperty("zip")]
    public string zip { get; set; }
    [JsonProperty("country")]
    public string country { get; set; }
    [JsonProperty("payment")]
    public string payment { get; set; }
    public int displayFrontend { get; set; }
    [JsonIgnore]
    public string CustomerPickUpBranchName { get; set; }
    [JsonIgnore]
    public string CustomerPickUpBranchName2 { get; set; } = "IT Bartolini PP";
}

public class ZasilkovnaBartoliniPickUpPointsModel
{
    public List<CarrierBartolini> carriers { get; set; }
}
