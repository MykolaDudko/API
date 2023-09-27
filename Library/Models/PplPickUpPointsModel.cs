using Newtonsoft.Json;
using System.Xml.Serialization;

namespace ClassLibrary.Models;

[XmlRoot(ElementName = "Gps")]
public class Gps
{
    [XmlElement(ElementName = "Latitude")]
    public double Latitude { get; set; }


    [XmlElement(ElementName = "Longitude")]
    public double Longitude { get; set; }


}
[XmlRoot(ElementName = "OpenHours")]
public class OpenHours
{
    [XmlIgnore]
    public List<WorkHoursModel> WorkHours = new();
    private string[] _string;
    [XmlElement(ElementName = "string")]

    public string[] String
    {

        get
        {
            return _string;
        }
        set
        {
            if (value.Length > 0)
            {
                _string = value;

                foreach (var item in value)
                {
                    string[] splited = item.Split(';');
                    int day = 0;
                    switch (splited[0])
                    {
                        case "Mon":
                            day = 1; break;
                        case "Tue":
                            day = 2; break;
                        case "Wed":
                            day = 3; break;
                        case "Thu":
                            day = 4; break;
                        case "Fri":
                            day = 5; break;
                        case "Sat":
                            day = 6; break;
                        case "Sun":
                            day = 7; break;
                    }
                    WorkHours.Add(new WorkHoursModel { Day = day, TimeFrom = splited[1], TimeTo = splited[2] });

                    if (splited[3].Length > 0)
                    {
                        WorkHours.Add(new WorkHoursModel { Day = day, TimeFrom = splited[3], TimeTo = splited[4] });
                    }
                }
            }


        }
    }


    [XmlIgnore]
    public string Day { get; set; } = string.Empty;
    [XmlIgnore]
    public string? TimeFrom { get; set; }
    [XmlIgnore]
    public string? TimeTo { get; set; }
}

[XmlRoot(ElementName = "ExternalNumberModel")]
public class ExternalNumberModel
{

    [XmlElement(ElementName = "Type")]
    public string Type { get; set; }

    [XmlElement(ElementName = "Value")]
    public string Value { get; set; }
}

[XmlRoot(ElementName = "ExternalNumbers")]
public class ExternalNumbers
{

    [XmlElement(ElementName = "ExternalNumberModel")]
    public List<ExternalNumberModel> ExternalNumberModel { get; set; }
}

[XmlRoot(ElementName = "AccessPointDetailModel")]
public class AccessPointDetailModel
{
    [JsonIgnore]
    public string city;

    [XmlElement(ElementName = "Id")]
    public string Id { get; set; }

    [XmlElement(ElementName = "Code")]
    public string Code { get; set; }

    [XmlElement(ElementName = "Depot")]
    public int Depot { get; set; }

    [XmlElement(ElementName = "Name")]
    public string Name { get; set; }

    [XmlElement(ElementName = "Street")]
    public string Street { get; set; }

    [XmlElement(ElementName = "City")]
    public string City
    {
        get { return city; }
        set
        {
            city = value;
            CustomerPickUpBranchName = $"{Name}, {Street}, {city}";
            CustomerPickUpBranchName2 = Name;
        }
    }

    [XmlElement(ElementName = "Country")]
    public string Country { get; set; }

    [XmlElement(ElementName = "ZipCode")]
    public int ZipCode { get; set; }

    [XmlElement(ElementName = "ParcelshopName")]
    public string ParcelshopName { get; set; }

    [XmlElement(ElementName = "Phone")]
    public string Phone { get; set; }

    [XmlElement(ElementName = "Www")]
    public object Www { get; set; }

    [XmlElement(ElementName = "KtmNote")]
    public string KtmNote { get; set; }

    [XmlElement(ElementName = "Gps")]
    public Gps Gps { get; set; }

    [XmlElement(ElementName = "OpenHours")]
    public OpenHours OpenHours { get; set; }

    [XmlElement(ElementName = "ExternalNumbers")]
    public ExternalNumbers ExternalNumbers { get; set; }

    [XmlElement(ElementName = "VisiblePs")]
    public bool VisiblePs { get; set; }

    [XmlElement(ElementName = "TribalServicePoint")]
    public bool TribalServicePoint { get; set; }

    [XmlElement(ElementName = "AccessPointType")]
    public string AccessPointType { get; set; }
    [JsonIgnore]
    public string CustomerPickUpBranchName { get; set; }
    [JsonIgnore]
    public string CustomerPickUpBranchName2 { get; set; }
    [JsonIgnore]
    public string Url = "https://www.pplbalik.cz/Main3.aspx?cls=KTMMap";
}

[XmlRoot(ElementName = "ArrayOfAccessPointDetailModel", Namespace = "http://StorageClub/AccessPoint/ASMX/Ktm.asmx")]
public class PplPickUpPointsModel
{
    [XmlElement(ElementName = "AccessPointDetailModel")]
    public List<AccessPointDetailModel> AccessPointDetailModel { get; set; }

    [XmlAttribute(AttributeName = "xsd")]
    public string Xsd { get; set; }

    [XmlAttribute(AttributeName = "xsi")]
    public string Xsi { get; set; }

    [XmlAttribute(AttributeName = "xmlns")]
    public string Xmlns { get; set; }

    [XmlText]
    public string Text { get; set; }
}
