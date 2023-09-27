using System.Xml.Serialization;

namespace ClassLibrary.Models;

[XmlRoot(ElementName = "place")]
public class Place
{
    [XmlIgnore]
    private string _city;
    [XmlIgnore]
    private string _type;
    public string zipCodeRO;
    [XmlElement(ElementName = "type")]
    public string type
    {
        get { return _type; }
        set
        {
            _type = value;
            if (_type == "PS")
            {
                CountryCode = "sk";

            }
            else
            {
                CountryCode = "ro";
            }
        }
    }

    [XmlElement(ElementName = "id")]
    public string CarrierBranchId { get; set; }

    [XmlElement(ElementName = "description")]
    public string description { get; set; }

    [XmlElement(ElementName = "address")]
    public string address { get; set; }

    [XmlElement(ElementName = "city")]
    public string city
    {
        get { return _city; }
        set
        {
            _city = value;
            if (_type == "PS")
            {
                CustomerPickUpBranchName = $"{description}, {address}, {city}";
            }
            else
            {
                CustomerPickUpBranchName = $"{address}, {city}";
            }
        }
    }
    [XmlElement(ElementName = "virtualzip")]
    public string virtualzip { get; set; }

    [XmlElement(ElementName = "zip")]
    public string zip
    {
        get { return zipCodeRO; }
        set
        {
            zipCodeRO = value;
            virtualzip = value;
        }
    }

    [XmlElement(ElementName = "status")]
    public int Status { get; set; }

    [XmlElement(ElementName = "gpsLat")]
    public double gpsLat { get; set; }

    [XmlElement(ElementName = "gpsLong")]
    public double gpsLong { get; set; }

    [XmlElement(ElementName = "center")]
    public int Center { get; set; }

    [XmlElement(ElementName = "workDays")]
    public WorkDays? WorkDays { get; set; }

    [XmlIgnore]
    public string CustomerPickUpBranchName { get; set; }

    [XmlIgnore]
    public string CountryCode { get; set; }
}

[XmlRoot(ElementName = "workday")]
public class Workday
{
    private string workHours;

    private string dayString;

    [XmlIgnore]
    public int Day { get; set; }

    [XmlElement(ElementName = "day")]
    public string DayStringRO
    {
        get { return dayString; }
        set
        {
            dayString = value.ToLower();

            switch (dayString)
            {
                case "pondělí":
                    Day = 1; break;
                case "úterý":
                    Day = 2; break;
                case "středa":
                    Day = 3; break;
                case "čtvrtek":
                    Day = 4; break;
                case "pátek":
                    Day = 5; break;
                case "sobota":
                    Day = 6; break;
                case "neděle":
                    Day = 7; break;
            }

        }
    }

    [XmlElement(ElementName = "date")]
    public string DayStringSK
    {
        get { return dayString; }
        set
        {
            DateOnly date = DateOnly.Parse(value);

            switch (date.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    Day = 1; break;
                case DayOfWeek.Tuesday:
                    Day = 2; break;
                case DayOfWeek.Wednesday:
                    Day = 3; break;
                case DayOfWeek.Thursday:
                    Day = 4; break;
                case DayOfWeek.Friday:
                    Day = 5; break;
                case DayOfWeek.Saturday:
                    Day = 6; break;
                case DayOfWeek.Sunday:
                    Day = 7; break;
            }

        }
    }

    [XmlElement(ElementName = "workHours")]
    public string WorkHours
    {
        get
        {
            return workHours;
        }
        set
        {
            workHours = value;
            TimeFrom = value.Split(' ').FirstOrDefault();
            TimeTo = value.Split(' ').LastOrDefault();

        }
    }
    [XmlIgnore]
    public string? TimeFrom { get; set; }
    [XmlIgnore]
    public string? TimeTo { get; set; }
}

[XmlRoot(ElementName = "workDays")]
public class WorkDays
{
    [XmlIgnore]
    private List<Workday> workday;
    [XmlElement(ElementName = "workday")]
    public List<Workday> Workday
    {
        get
        {
            if (workday != null)
            {
                workday = workday.DistinctBy(i => i.Day).OrderBy(x => x.Day).ToList();
            }
            return workday;
        }
        set
        {
            workday = value;
        }
    }
}

[XmlRoot(ElementName = "places")]
public class UpsPickUpPointsModel
{

    [XmlElement(ElementName = "place")]
    public List<Place> Place { get; set; }
}
