using Newtonsoft.Json;

namespace ClassLibrary.Models;

public class AddressWedo
{
    public string number { get; set; }
    public string street { get; set; }
    public string town { get; set; }
    public string postal_code { get; set; }
    public string country { get; set; }
}

//public class BoxWedo
//{
//    [JsonProperty("id")]
//    public string CarrierBranchId { get; set; }
//    public string type { get; set; }
//    public string code { get; set; }
//    [JsonProperty("name")]
//    public string CustomerPickUpBranchName { get; set; }
//    public AddressWedo address { get; set; }
//    [JsonProperty("location_description")]
//    public string Description { get; set; }
//    public PositionWedo position { get; set; }
//    public OpeningHoursWedo opening_hours { get; set; }
//    public Contacts contacts { get; set; }
//    public string photo { get; set; }
//    [JsonProperty("credit_card_payment")]
//    public bool CardPayment { get; set; }
//    public bool time_note { get; set; }
//    public bool pickup { get; set; }
//}

public class WedoBranche
{
    [JsonIgnore]
    private AddressWedo address;
    [JsonProperty("id")]
    public double id { get; set; }
    public string type { get; set; }
    [JsonProperty("code")]
    public string code { get; set; }
    [JsonProperty("name")]
    public string name { get; set; }
    [JsonProperty("address")]
    public AddressWedo Address
    {
        get { return address; }
        set
        {
            address = value;
            address.street = $"{address.street} {address.number}";
            name = name.Trim();
            name = $"{name}, {address.street}, {address.town}";
        }
    }
    [JsonProperty("location_description")]
    public string location_description { get; set; }
    [JsonProperty("position")]
    public PositionWedo position { get; set; }
    public OpeningHoursWedo opening_hours { get; set; }
    public Contacts contacts { get; set; }
    public string photo { get; set; }
    [JsonProperty("credit_card_payment")]
    public bool credit_card_payment { get; set; }
    public object time_note { get; set; }
    public bool pickup { get; set; }
}

public class Contacts
{
    public object phone { get; set; }
    public object email { get; set; }
}



public class OpeningHoursWedo
{
    public WeekDayWedo mon { get; set; }
    public WeekDayWedo tue { get; set; }
    public WeekDayWedo wed { get; set; }
    public WeekDayWedo thu { get; set; }
    public WeekDayWedo fri { get; set; }
    public WeekDayWedo sat { get; set; }
    public WeekDayWedo sun { get; set; }
}

public class PositionWedo
{
    public double lat { get; set; }
    public double lng { get; set; }
}

public class WedoModel
{
    public WedoBranches wedo { get; set; }
}

public class WeekDayWedo
{
    [JsonProperty("from")]
    public string from { get; set; }
    [JsonProperty("to")]
    public string to { get; set; }
    public string note { get; set; }
    [JsonIgnore]
    public int Day { get; set; }
}

public class WedoBranches
{
    public List<WedoBranche> branches { get; set; }
    public List<WedoBranche> boxes { get; set; }
}
