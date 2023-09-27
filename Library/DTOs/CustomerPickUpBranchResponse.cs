using ClassLibrary.Models;

namespace ClassLibrary.DTOs;

public class CustomerPickUpBranchResponse
{
    public int Id { get; set; }
    public string? CarrierBranchId { get; set; }
    public CarrierResponse? Carrier;
    public int? CarrierId { get; set; }
    public CarrierBranchCategoryResponse? CarrierBranchCategory;
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
    public double Lat { get; set; }
    public double Lng { get; set; }
    public bool? CardPayment { get; set; }
    public string? Url { get; set; }
    public bool IsDeleted { get; set; } = false;
    public bool IsEnabled { get; set; } = true;
    public bool IsExists { get; set; } = true;
    public string? Description { get; set; }
}

