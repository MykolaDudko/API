using Newtonsoft.Json;

namespace ClassLibrary.Models;

public class InTimeModel
{
    public Intime intime { get; set; }
}
public class Address
{
    [JsonIgnore]
    private string _number;
    [JsonIgnore]
    public string zipCode;
    [JsonProperty("town")]
    public string town { get; set; }
    [JsonProperty("street")]
    public string street { get; set; }
    [JsonProperty("postal_code")]
    public string postal_code
    {
        get { return zipCode; }
        set
        {
            value = value.Replace(" ", string.Empty);
            zipCode = value;
        }
    }
    [JsonProperty("number")]
    public string number
    {
        get { return _number; }
        set
        {
            _number = value;
            street = $"{street} {_number}";
        }
    }

}

public class Intime
{
    public List<Machine> machines { get; set; }
}

public class Machine
{
    public Machine()
    {
        WorkHours = new List<WorkHoursModel>
        {
            new WorkHoursModel { Day = 1, TimeFrom = "00:00", TimeTo="23:59" } ,
            new WorkHoursModel { Day = 2, TimeFrom = "00:00", TimeTo="23:59" } ,
            new WorkHoursModel { Day = 3, TimeFrom = "00:00", TimeTo="23:59" } ,
            new WorkHoursModel { Day = 4, TimeFrom = "00:00", TimeTo="23:59" } ,
            new WorkHoursModel { Day = 5, TimeFrom = "00:00", TimeTo="23:59" } ,
            new WorkHoursModel { Day = 6, TimeFrom = "00:00", TimeTo="23:59" } ,
            new WorkHoursModel { Day = 7, TimeFrom = "00:00", TimeTo="23:59" }
        };
    }

    [JsonIgnore]
    private Address _address;
    [JsonProperty("photo_small")]
    public string photo_small { get; set; }
    [JsonProperty("name")]
    public string name { get; set; }
    [JsonProperty("photo")]
    public List<string> photo { get; set; }
    [JsonProperty("location_description")]
    public string location_description { get; set; }
    [JsonProperty("address")]
    public Address address
    {
        get { return _address; }
        set
        {
            _address = value;
            CustomerPickUpBranchName = $"{_address.town}, {_address.street}";
        }
    }
    [JsonProperty("position")]
    public Position position { get; set; }
    [JsonProperty("id")]
    public int id { get; set; }
    [JsonIgnore]
    public string CustomerPickUpBranchName { get; set; }
    [JsonIgnore]
    public string CustomerPickUpBranchName2 = "InTime Poštomat 24/7";
    [JsonIgnore]
    public string CountryCode = "CZE";
    [JsonIgnore]
    public string Url = "https://postomaty.cz/cz/kde-je-tvuj-postomat";
    public List<WorkHoursModel> WorkHours { get; set; }
}

public class Position
{
    [JsonProperty("lat")]
    public double lat { get; set; }
    [JsonProperty("lng")]
    public double lng { get; set; }
}
