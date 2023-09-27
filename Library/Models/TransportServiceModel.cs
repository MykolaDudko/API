using Library.Models;

namespace ClassLibrary.Models;

public class TransportServiceModel : Entity
{
    public string Name { get; set; }
    public CarrierModel Carrier { get; set; }
    public int CarrierId { get; set; }
    public ConsignorModel Consignor { get; set; }
    public int ConsignorId { get; set; }
    public string CustomerFacingName { get; set; } = string.Empty;
    public HandoverPointModel? HandoverPointSource { get; set; }
    public int? HandoverPointSourceId { get; set; }
    public HandoverPointModel? HandoverPointDestination { get; set; }
    public int? HandoverPointDestinationId { get; set; }
    public string? Icon { get; set; }
    public SelectabilityStatusModelEnum? SelectabilityStatusId { get; set; }
    public SelectabilityStatusModel? SelectabilityStatus { get; set; }
    public CarrierBranchCategoryModel? CarrierBranchCategory { get; set; }
    public int? CarrierBranchCategoryId { get; set; }
    public TransportServiceModel? PreviousTransportsService { get; set; }
    public int? PreviousTransportServiceId { get; set; }
}
