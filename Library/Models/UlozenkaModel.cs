using ClassLibrary.Converters;
using Newtonsoft.Json;

namespace ClassLibrary.Models;

public class AdditionalParameters
{
    public string intime_external_code { get; set; }
}

public class AllowedConsignmentTypes
{
    public int standard_consignment { get; set; }
    public int backward_consignment { get; set; }
}

public class DataUlozenka
{
    public List<DestinationUlozenka> destination { get; set; }
}

public class DestinationUlozenka
{
    private string carrierBranchId;
    private string _house_number;
    public Links _links { get; set; }
    [JsonProperty("id")]
    public string CarrierBranchId
    {
        get { return carrierBranchId; }
        set
        {
            carrierBranchId = value;
            Url = $"https://www.ulozenka.cz/pobocky/{carrierBranchId}";
        }
    }
    [JsonProperty("shortcut")]
    public string shortcut { get; set; }
    [JsonProperty("name")]
    public string name { get; set; }
    [JsonProperty("street")]
    public string street { get; set; }
    [JsonProperty("house_number")]
    public string house_number
    {
        get { return _house_number; }
        set
        {
            _house_number = value;
            street = $"{street} {_house_number}";
        }
    }
    [JsonProperty("town")]
    public string town { get; set; }
    [JsonProperty("zip")]
    public string zip { get; set; }
    public District district { get; set; }
    [JsonProperty("country")]
    public string country { get; set; }
    public int partner { get; set; }
    public string group { get; set; }
    public List<object> departure_time { get; set; }
    [JsonConverter(typeof(AdditionUlozenkaParametersConverter))]
    public AdditionalParameters? additional_parameters { get; set; }
    public string external_id { get; set; }
    public object external_route { get; set; }
    public int active { get; set; }
    public int preparing { get; set; }
    public AllowedConsignmentTypes allowed_consignment_types { get; set; }
    public string phone { get; set; }
    public string email { get; set; }
    public OpeningHoursUlozenka opening_hours { get; set; }
    public GpsUozenka gps { get; set; }
    public Navigation navigation { get; set; }
    public object other_info { get; set; }
    public int card_payment { get; set; }
    public List<object> announcements { get; set; }
    public string Url { get; set; }
}

public class District
{
    public int id { get; set; }
    public string nuts_number { get; set; }
    public string name { get; set; }
}



public class GpsUozenka
{
    public double latitude { get; set; }
    public double longitude { get; set; }
}

public class HourUlozenka
{
    [JsonProperty("open")]
    public string open { get; set; }
    [JsonProperty("close")]
    public string close { get; set; }

    [JsonIgnore]
    public int Day { get; set; }
}

public class Links
{
    public Self self { get; set; }
    public Website website { get; set; }
    public Picture picture { get; set; }
}


public class Navigation
{
    public string general { get; set; }
    public object car { get; set; }
    public object public_transport { get; set; }
}

public class OpeningHoursUlozenka
{
    public RegularUlozenka regular { get; set; }
    public List<object> exceptions { get; set; }
}

public class Picture
{
    public string href { get; set; }
}

public class RegularUlozenka
{
    public WeekDay monday { get; set; }
    public WeekDay tuesday { get; set; }
    public WeekDay wednesday { get; set; }
    public WeekDay thursday { get; set; }
    public WeekDay friday { get; set; }
    public WeekDay saturday { get; set; }
    public WeekDay sunday { get; set; }
}

public class Ulozenka
{
    public int code { get; set; }
    public Links _links { get; set; }
    public DataUlozenka data { get; set; }
    public List<object> errors { get; set; }
}


public class Self
{
    public string href { get; set; }
}

public class WeekDay
{
    [JsonProperty("hours")]
    public List<HourUlozenka> hours { get; set; }
}

public class Website
{
    public string href { get; set; }
}
