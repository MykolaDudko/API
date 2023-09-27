using System.Xml.Serialization;

namespace ClassLibrary.Models;

[XmlRoot(ElementName = "zv", Namespace = "http://www.cpost.cz/schema/aict/zv_2")]
public class BalikovnaPickUpPointsModel
{

    [XmlElement(ElementName = "generated")]
    public DateTime Generated { get; set; }

    [XmlElement(ElementName = "row")]
    public List<RowBalikovna> Row { get; set; }

    [XmlAttribute(AttributeName = "xmlns")]
    public string Xmlns { get; set; }

    [XmlAttribute(AttributeName = "xsi")]
    public string Xsi { get; set; }

    [XmlAttribute(AttributeName = "schemaLocation")]
    public string SchemaLocation { get; set; }

    [XmlText]
    public string Text { get; set; }
}
[XmlRoot(ElementName = "od_do")]
public class OdDoBalikovna
{

    [XmlElement(ElementName = "od")]
    public string TimeFrom { get; set; }

    [XmlElement(ElementName = "do")]
    public string TimeTo { get; set; }
}

[XmlRoot(ElementName = "den")]
public class DenBalikovna
{
    [XmlIgnore]
    private string dayBalikovna;

    [XmlElement(ElementName = "od_do")]
    public List<OdDoBalikovna> OdDo { get; set; }

    [XmlAttribute(AttributeName = "name")]
    public string DayBalikovna
    {
        get { return dayBalikovna; }
        set
        {
            dayBalikovna = value;
            switch (dayBalikovna)
            {
                case "Pondělí":
                    Day = 1; break;
                case "Úterý":
                    Day = 2; break;
                case "Středa":
                    Day = 3; break;
                case "Čtvrtek":
                    Day = 4; break;
                case "Pátek":
                    Day = 5; break;
                case "Sobota":
                    Day = 6; break;
                case "Neděle":
                    Day = 7; break;
            }
        }
    }
    [XmlIgnore]
    public int Day { get; set; }

    [XmlText]
    public string Text { get; set; }
}

[XmlRoot(ElementName = "OTEV_DOBY")]
public class OTEVDOBYBalikovna
{

    [XmlElement(ElementName = "den")]
    public List<DenBalikovna> Den { get; set; }
}

[XmlRoot(ElementName = "row")]
public class RowBalikovna
{
    [XmlIgnore]
    private string streetBalikovna;

    [XmlIgnore]
    private int zipCode;

    [XmlElement(ElementName = "PSC")]
    public int PSC
    {
        get { return zipCode; }
        set
        {
            zipCode = value;
            Url = $"https://www.postaonline.cz/detail-pobocky/-/pobocky/detail/{zipCode}";
        }
    }

    [XmlElement(ElementName = "NAZEV")]
    public string NAZEV { get; set; }

    [XmlElement(ElementName = "ADRESA")]
    public string ADRESA
    {
        get { return streetBalikovna; }
        set
        {
            streetBalikovna = value;
            CustomerPickUpBranchName = streetBalikovna;
            CustomerPickUpBranchName2 = streetBalikovna;
            Street = streetBalikovna.Split(",").FirstOrDefault();
            City = streetBalikovna.Split(",").LastOrDefault().Trim();
        }
    }
    [XmlIgnore]
    public string Street { get; set; }
    [XmlElement(ElementName = "TYP")]
    public string TYP { get; set; }

    [XmlElement(ElementName = "OTEV_DOBY")]
    public OTEVDOBYBalikovna OTEVDOBY { get; set; }

    [XmlIgnore]
    public List<WorkHoursModel>? WorkHours { get; set; }

    //private double sOURX;

    //[XmlElement(ElementName = "SOUR_X")]
    //public double SOURX
    //{
    //    get { return sOURX; }
    //    set
    //    {
    //        try { sOURX = value; }
    //        catch { sOURX = 0; }
    //    }
    //}



    //private double sOURY;
    //[XmlElement(ElementName = "SOUR_Y")]
    //public double SOURY
    //{
    //    get { return sOURY; }
    //    set
    //    {
    //        try { sOURY = value; }
    //        catch { sOURY = 0; }
    //    }
    //}

    //[XmlElement(ElementName = "OBEC")]
    [XmlIgnore]
    public string City { get; set; }

    [XmlElement(ElementName = "C_OBCE")]
    public string C_OBCE { get; set; }




    private string latString;

    public double Lat { get; set; }

    [XmlElement(ElementName = "SOUR_X_WGS84")]
    public string SOUR_X_WGS84
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
            else
            {
                IsEnabled = false;
            }
        }
    }

    private string lngString;

    public double Lng { get; set; }

    [XmlElement(ElementName = "SOUR_Y_WGS84")]
    public string SOUR_Y_WGS84
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
            else
            {
                IsEnabled = false;
            }
        }
    }

    [XmlElement(ElementName = "STAV")]
    public object STAV { get; set; }

    [XmlElement(ElementName = "POPIS")]
    public string POPIS { get; set; }
    [XmlIgnore]
    public string CustomerPickUpBranchName { get; set; }
    [XmlIgnore]
    public string CustomerPickUpBranchName2 { get; set; }
    [XmlIgnore]
    public string CountryCode = "CZE";
    [XmlIgnore]
    public bool IsEnabled { get; set; } = true;
    [XmlIgnore]
    public string Url { get; set; }
}
