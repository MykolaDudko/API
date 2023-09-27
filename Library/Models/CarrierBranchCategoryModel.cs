using Library.Models;

namespace ClassLibrary.Models;

public class CarrierBranchCategoryModel : Entity
{
    public string ProviderId { get; set; } = string.Empty;
    public string CarrierBranchName { get; set; } = string.Empty;
    public CarrierModel Carrier { get; set; }
    public int CarrierId { get; set; }
    public List<CustomerPickUpBranchModel> CustomerPickUpBranch { get; set; }
    public List<TransportServiceModel> TransportServices { get; set; }
    public string? Parameters { get; set; }
}
