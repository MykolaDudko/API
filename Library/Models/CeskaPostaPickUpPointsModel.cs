using System.Xml.Serialization;

namespace ClassLibrary.Models;

[XmlRoot(ElementName = "od_do")]
public class OdDo
{

    [XmlElement(ElementName = "od")]
    public string od { get; set; }

    [XmlElement(ElementName = "do")]
    public string @do { get; set; }
}

[XmlRoot(ElementName = "den")]
public class Den
{
    [XmlIgnore]
    private string dayCP;

    [XmlElement(ElementName = "od_do")]
    public OdDo od_do { get; set; }

    [XmlAttribute(AttributeName = "name")]
    public string name
    {
        get { return dayCP; }
        set
        {
            dayCP = value;
            switch (dayCP)
            {
                case "Pondělí":
                    Day = "1"; break;
                case "Úterý":
                    Day = "2"; break;
                case "Středa":
                    Day = "3"; break;
                case "Čtvrtek":
                    Day = "4"; break;
                case "Pátek":
                    Day = "5"; break;
                case "Sobota":
                    Day = "6"; break;
                case "Neděle":
                    Day = "7"; break;
            }
        }
    }
    [XmlIgnore]
    public string Day { get; set; }

    [XmlText]
    public string Text { get; set; }
}

[XmlRoot(ElementName = "OTV_DOBA")]
public class OTVDOBA
{

    [XmlElement(ElementName = "den")]
    public List<Den> den { get; set; }
}

[XmlRoot(ElementName = "row")]
public class RowCP
{
    [XmlIgnore]
    private string streetCP;
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

    [XmlElement(ElementName = "NAZ_PROV")]
    public string NAZ_PROV { get; set; }

    [XmlElement(ElementName = "OKRES")]
    public string OKRES { get; set; }

    [XmlElement(ElementName = "ADRESA")]
    public string ADRESA
    {
        get { return streetCP; }
        set
        {
            streetCP = value;
            CustomerPickUpBranchName = streetCP;
            CustomerPickUpBranchName2 = streetCP;
            Street = streetCP.Split(",").FirstOrDefault();
            City = streetCP.Split(",").LastOrDefault().Trim();
        }
    }

    [XmlIgnore]
    public string Street { get; set; }

    [XmlElement(ElementName = "V_PROVOZU")]
    public string VPROVOZU { get; set; }

    [XmlElement(ElementName = "PRODL_DOBA")]
    public string PRODLDOBA { get; set; }

    [XmlElement(ElementName = "BANKOMAT")]
    public string BANKOMAT { get; set; }

    [XmlElement(ElementName = "PARKOVISTE")]
    public string PARKOVISTE { get; set; }

    [XmlElement(ElementName = "KOMPLET_SERVIS")]
    public string KOMPLETSERVIS { get; set; }

    [XmlElement(ElementName = "VIKEND")]
    public string VIKEND { get; set; }

    [XmlElement(ElementName = "LOKALITY_PRODL")]
    public string LOKALITYPRODL { get; set; }

    [XmlElement(ElementName = "VYDEJ_NP_OD")]
    public object VYDEJNPOD { get; set; }

    [XmlElement(ElementName = "UKL_NP_LIMIT")]
    public string UKLNPLIMIT { get; set; }

    [XmlElement(ElementName = "PSC_NP_NAHR")]
    public object PSCNPNAHR { get; set; }

    [XmlElement(ElementName = "NAZ_NP_NAHR")]
    public object NAZNPNAHR { get; set; }

    [XmlElement(ElementName = "ABC_BOX")]
    public string ABCBOX { get; set; }

    [XmlElement(ElementName = "OTV_DOBA")]
    public OTVDOBA OTVDOBA { get; set; }

    //[XmlElement(ElementName = "OBEC")]
    [XmlIgnore]
    public string City { get; set; }

    [XmlElement(ElementName = "C_OBCE")]
    public string C_OBCE { get; set; }

    [XmlIgnore]
    public string CustomerPickUpBranchName { get; set; }
    [XmlIgnore]
    public string CustomerPickUpBranchName2 { get; set; }

    [XmlIgnore]
    public string CountryCode = "CZE";




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
    [XmlIgnore]
    public bool IsEnabled { get; set; } = true;
    [XmlIgnore]
    public string Url { get; set; }

}

[XmlRoot(ElementName = "zv", Namespace = "http://www.cpost.cz/schema/aict/zv_1")]
public class CeskaPostaPickUpPointModel
{

    [XmlElement(ElementName = "generated")]
    public DateTime Generated { get; set; }

    [XmlElement(ElementName = "row")]
    public List<RowCP> Row { get; set; }

    [XmlAttribute(AttributeName = "xmlns")]
    public string Xmlns { get; set; }

    [XmlAttribute(AttributeName = "xsi")]
    public string Xsi { get; set; }

    [XmlAttribute(AttributeName = "schemaLocation")]
    public string SchemaLocation { get; set; }

    [XmlText]
    public string Text { get; set; }

}
