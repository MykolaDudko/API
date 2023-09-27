using System.Xml.Serialization;

namespace ClassLibrary.Models;


[XmlRoot(ElementName = "contact")]
public class Contact
{

    [XmlElement(ElementName = "country")]
    public string Country { get; set; }

    [XmlElement(ElementName = "phone")]
    public string Phone { get; set; }

    [XmlElement(ElementName = "email")]
    public string Email { get; set; }

    [XmlElement(ElementName = "businessHours")]
    public string BusinessHours { get; set; }
}

[XmlRoot(ElementName = "contacts")]
public class ContactsZasilkovnaXml
{

    [XmlElement(ElementName = "contact")]
    public List<Contact> Contact { get; set; }
}

[XmlRoot(ElementName = "status")]
public class StatusZasilkovnaXml
{

    [XmlElement(ElementName = "statusId")]
    public int StatusId { get; set; }

    [XmlElement(ElementName = "description")]
    public string Description { get; set; }
}

[XmlRoot(ElementName = "photo")]
public class PhotoZasilkovnaXml
{

    [XmlElement(ElementName = "thumbnail")]
    public string Thumbnail { get; set; }

    [XmlElement(ElementName = "normal")]
    public string Normal { get; set; }
}

[XmlRoot(ElementName = "photos")]
public class Photos
{

    [XmlElement(ElementName = "photo")]
    public List<PhotoZasilkovnaXml> Photo { get; set; }
}

[XmlRoot(ElementName = "regular")]
public class RegularZasilkovnaXml
{
    public List<WorkHoursModel> workHours = new();
    private string monday;
    private string tuesday;
    private string wednesday;
    private string thursday;
    private string friday;
    private string saturday;
    private string sunday;
    [XmlElement(ElementName = "monday")]
    public string Monday
    {
        get
        { return monday; }
        set
        {
            if (value.Length > 0)
            {
                monday = value;
                workHours.Add(new WorkHoursModel { Day = 1, TimeFrom = value.Split('–')[0], TimeTo = value.Split('–').Last() });
            }

        }
    }

    [XmlElement(ElementName = "tuesday")]
    public string Tuesday
    {
        get
        { return tuesday; }
        set
        {
            if (value.Length > 0)
            {
                tuesday = value;
                workHours.Add(new WorkHoursModel { Day = 2, TimeFrom = value.Split('–')[0], TimeTo = value.Split('–').Last() });
            }

        }
    }

    [XmlElement(ElementName = "wednesday")]
    public string Wednesday
    {
        get
        { return wednesday; }
        set
        {
            if (value.Length > 0)
            {
                wednesday = value;
                workHours.Add(new WorkHoursModel { Day = 3, TimeFrom = value.Split('–')[0], TimeTo = value.Split('–').Last() });
            }

        }
    }

    [XmlElement(ElementName = "thursday")]
    public string Thursday
    {
        get
        { return thursday; }
        set
        {
            if (value.Length > 0)
            {
                thursday = value;
                workHours.Add(new WorkHoursModel { Day = 4, TimeFrom = value.Split('–')[0], TimeTo = value.Split('–').Last() });
            }

        }
    }

    [XmlElement(ElementName = "friday")]
    public string Friday
    {
        get
        { return friday; }
        set
        {
            if (value.Length > 0)
            {
                friday = value;
                workHours.Add(new WorkHoursModel { Day = 5, TimeFrom = value.Split('–')[0], TimeTo = value.Split('–').Last() });
            }

        }
    }

    [XmlElement(ElementName = "saturday")]
    public string Saturday
    {
        get
        { return saturday; }
        set
        {
            if (value.Length > 0)
            {
                saturday = value;
                workHours.Add(new WorkHoursModel { Day = 6, TimeFrom = value.Split('–')[0], TimeTo = value.Split('–').Last() });
            }

        }
    }

    [XmlElement(ElementName = "sunday")]
    public string Sunday
    {
        get
        { return sunday; }
        set
        {
            if (value.Length > 0)
            {
                sunday = value;
                workHours.Add(new WorkHoursModel { Day = 7, TimeFrom = value.Split('–')[0], TimeTo = value.Split('–').Last() });
            }

        }
    }
}

[XmlRoot(ElementName = "exception")]
public class ExceptionZasilkovnaXml
{

    [XmlElement(ElementName = "date")]
    public DateTime Date { get; set; }

    [XmlElement(ElementName = "hours")]
    public object Hours { get; set; }
}

[XmlRoot(ElementName = "exceptions")]
public class ExceptionsZasilkovnaXml
{

    [XmlElement(ElementName = "exception")]
    public List<ExceptionZasilkovnaXml> Exception { get; set; }
}

[XmlRoot(ElementName = "openingHours")]
public class OpeningHoursZasilkovnaXml
{

    //[XmlElement(ElementName = "compactShort")]
    //public string CompactShort { get; set; }

    //[XmlElement(ElementName = "compactLong")]
    //public string CompactLong { get; set; }

    //[XmlElement(ElementName = "tableLong")]
    //public string TableLong { get; set; }

    [XmlElement(ElementName = "regular")]
    public RegularZasilkovnaXml Regular { get; set; }

    [XmlElement(ElementName = "exceptions")]
    public ExceptionsZasilkovnaXml Exceptions { get; set; }
}

[XmlRoot(ElementName = "branch")]
public class Branch
{
    private string country;
    private string city;
    private string latString;
    private string lngString;
    [XmlElement(ElementName = "id")]
    public int CarrierBranchId { get; set; }

    [XmlElement(ElementName = "name")]
    public string Name { get; set; }

    [XmlElement(ElementName = "special")]
    public string Special { get; set; }

    [XmlElement(ElementName = "place")]
    public string Place { get; set; }

    [XmlElement(ElementName = "street")]
    public string Street { get; set; }

    [XmlElement(ElementName = "city")]
    public string City
    {
        get { return city; }
        set
        {
            city = value;
            CustomerPickUpBranchName = $"{Place}, {city}, {Street}";
        }
    }

    private string zip;

    [XmlElement(ElementName = "zip")]
    public string Zip
    {
        get { return zip; }
        set
        {
            zip = value.Replace(" ", "");
        }
    }

    [XmlElement(ElementName = "country")]
    public string Country
    {
        get { return country; }
        set
        {
            country = value;
            if (country == "cz")
            {
                Url = $"https://www.zasilkovna.cz/pobocky/{CarrierBranchId}";
            }
            else if (country == "hu")
            {
                Url = $"https://www.csomagkuldo.hu/atvevohelyek/{CarrierBranchId}";
            }
            else if (country == "ro")
            {
                Url = $"https://www.coletaria.ro/puncte-pick-up/{CarrierBranchId}";
            }
        }
    }

    [XmlElement(ElementName = "currency")]
    public string Currency { get; set; }

    [XmlElement(ElementName = "status")]
    public StatusZasilkovnaXml Status { get; set; }

    [XmlElement(ElementName = "displayFrontend")]
    public int DisplayFrontend { get; set; }

    //[XmlElement(ElementName = "directions")]
    //public string Directions { get; set; }

    [XmlElement(ElementName = "directionsCar")]
    public string DirectionsCar { get; set; }

    [XmlElement(ElementName = "directionsPublic")]
    public string DirectionsPublic { get; set; }

    [XmlElement(ElementName = "wheelchairAccessible")]
    public string WheelchairAccessible { get; set; }

    [XmlElement(ElementName = "creditCardPayment")]
    public string CreditCardPayment { get; set; }

    [XmlElement(ElementName = "dressingRoom")]
    public int DressingRoom { get; set; }

    [XmlElement(ElementName = "claimAssistant")]
    public int ClaimAssistant { get; set; }

    [XmlElement(ElementName = "packetConsignment")]
    public int PacketConsignment { get; set; }

    public double Lat { get; set; }

    [XmlElement(ElementName = "latitude")]
    public string Latitude
    {
        get { return latString; }
        set
        {
            latString = value;
            if (latString.Length > 0)
            {
                latString = latString.Replace(".", ",");
                Lat = Convert.ToDouble(latString);
            }

        }
    }
    public double Lng { get; set; }
    [XmlElement(ElementName = "longitude")]
    public string Longitude
    {
        get { return lngString; }
        set
        {
            lngString = value;
            if (lngString.Length > 0)
            {
                lngString = lngString.Replace(".", ",");
                Lng = Convert.ToDouble(lngString);
            }
        }
    }

    [XmlElement(ElementName = "url")]
    public string Url { get; set; }

    [XmlElement(ElementName = "maxWeight")]
    public int MaxWeight { get; set; }

    [XmlElement(ElementName = "labelRouting")]
    public string LabelRouting { get; set; }

    [XmlElement(ElementName = "labelName")]
    public string LabelName { get; set; }

    [XmlElement(ElementName = "photos")]
    public Photos Photos { get; set; }

    [XmlElement(ElementName = "openingHours")]
    public OpeningHoursZasilkovnaXml OpeningHours { get; set; }

    public string CustomerPickUpBranchName { get; set; }

    public string CustomerPickUpBranchName2 { get; set; }
}

[XmlRoot(ElementName = "branches")]
public class Branches
{

    [XmlElement(ElementName = "branch")]
    public List<Branch> Branch { get; set; }
}

[XmlRoot(ElementName = "export", Namespace = "http://www.zasilkovna.cz/api/v4/branch")]
public class ZasilkovnaXmlModel
{

    [XmlElement(ElementName = "contacts")]
    public ContactsZasilkovnaXml Contacts { get; set; }

    [XmlElement(ElementName = "branches")]
    public Branches Branches { get; set; }

    [XmlAttribute(AttributeName = "xmlns")]
    public string Xmlns { get; set; }

    [XmlAttribute(AttributeName = "ns")]
    public string Ns { get; set; }

    [XmlAttribute(AttributeName = "xsi")]
    public string Xsi { get; set; }

    [XmlAttribute(AttributeName = "schemaLocation")]
    public string SchemaLocation { get; set; }

    [XmlText]
    public string Text { get; set; }
}
