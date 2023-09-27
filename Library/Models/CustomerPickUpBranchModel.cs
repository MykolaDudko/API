using Library.Models;

namespace ClassLibrary.Models;

public class CustomerPickUpBranchModel : Entity
{
    public string? CarrierBranchId { get; set; }
    public CarrierModel? Carrier { get; set; }
    public int? CarrierId { get; set; }
    public CarrierBranchCategoryModel CarrierBranchCategory { get; set; }
    public int CarrierBranchCategoryId { get; set; }
    public string CustomerPickUpBranchName { get; set; } = string.Empty;
    public string CustomerPickUpBranchName2 { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Street { get; set; } = string.Empty;
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? Photo { get; set; }
    public List<WorkHoursModel>? WorkHours { get; set; }
    public string ZipCode { get; set; } = string.Empty;
    public string CountryCode { get; set; } = string.Empty;
    public string Position { get; set; } = string.Empty;
    public NetTopologySuite.Geometries.Point Location { get; set; }
    public bool? CardPayment { get; set; }
    public string? Url { get; set; }
    public bool IsEnabled { get; set; } = true;
    public bool IsExists { get; set; } = true;
    public string? Description { get; set; }
}
