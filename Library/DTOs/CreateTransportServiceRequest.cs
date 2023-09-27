using ClassLibrary.Models;
using System.Text.Json.Serialization;

namespace ClassLibrary.DTOs;

public class CreateTransportServiceRequest
{
    public int CarrierId { get; set; }
    public int ConsignorId { get; set; }
    public int? HandoverPointSourceId { get; set; }
    public int? HandoverPointDestinationId { get; set; }
    public int CarrierBranchCategoryId { get; set; }
    public string CustomerFacingName { get; set; } = string.Empty;
    public SelectabilityStatusModelEnum? SelectabilityStatusId { get; set; }
    public int? PreviousTransportServiceId { get; set; }
    public string? Icon { get; set; }
    [JsonIgnore]
    public bool IsDeleted { get; set; } = false;
}
