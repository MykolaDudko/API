using Newtonsoft.Json;

namespace ClassLibrary.Models;


public class Data
{
    public List<Item> items { get; set; }
}

public class Hour
{
    [JsonProperty("day")]
    public int day { get; set; }
    [JsonProperty("openMorning")]
    public string openMorning { get; set; }
    public string closeMorning { get; set; }
    public string openAfternoon { get; set; }
    [JsonProperty("closeAfternoon")]
    public string closeAfternoon { get; set; }
}

public class Item
{
    [JsonIgnore]
    public List<Hour> workHours { get; set; }
    [JsonIgnore]
    private string _house_number { get; set; }
    [JsonProperty("id")]
    public string id { get; set; }
    public string company { get; set; }
    [JsonProperty("street")]
    public string street { get; set; }
    [JsonProperty("city")]
    public string city { get; set; }
    [JsonIgnore]
    public string CountryCode { get; set; } = "CZE";
    [JsonProperty("house_number")]
    public string house_number
    {
        get { return _house_number; }
        set
        {
            _house_number = value;
            street = $"{street} {_house_number}";
            CustomerPickUpBranchName = $"{company}, {street}, {city}";
        }
    }
    [JsonProperty("postcode")]
    public string postcode { get; set; }
    [JsonProperty("phone")]
    public string phone { get; set; }
    public string fax { get; set; }
    [JsonProperty("email")]
    public string email { get; set; }
    [JsonProperty("homepage")]
    public string homepage { get; set; }
    public string pickup_network_type { get; set; }
    public int pickup_allowed { get; set; }
    public int return_allowed { get; set; }
    public int dropoff_allowed { get; set; }
    public int express_allowed { get; set; }
    public int cardpayment_allowed { get; set; }
    public int cod_allowed { get; set; }
    public int service { get; set; }
    public int open_weekend { get; set; }
    [JsonProperty("latitude")]
    public double latitude { get; set; }

    [JsonIgnore]
    public string CustomerPickUpBranchName { get; set; }

    [JsonProperty("longitude")]
    public double longitude { get; set; }

    [JsonProperty("hours")]
    public List<Hour> hours
    {
        get { return workHours; }
        set
        {
            workHours = new();
            foreach (var item in value)
            {
                if (item.closeMorning.Length > 0)
                {
                    workHours.Add(new Hour { openMorning = item.openMorning, closeAfternoon = item.closeMorning, day = item.day });
                }
                if (item.openAfternoon.Length > 0)
                {
                    workHours.Add(new Hour { openMorning = item.openAfternoon, closeAfternoon = item.closeAfternoon, day = item.day });
                }
                if (item.closeMorning.Length == 0 && item.openAfternoon.Length == 0)
                {
                    workHours.Add(item);
                }
            }
        }
    }
    [JsonProperty("photo")]
    public string photo { get; set; }
}

public class DpdPickUpPointsModel
{
    public string status { get; set; }
    public int code { get; set; }
    public int count { get; set; }
    public string hash { get; set; }
    public Data data { get; set; }
}
