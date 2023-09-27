using Library.Models;
namespace ClassLibrary.Models;

public class HandoverPointModel : Entity
{
    public string HandoverPointName { get; set; } = string.Empty;
    public List<TransportServiceModel> TransportServicesWithDeliverySource { get; set; }
    public List<TransportServiceModel> TransportServicesWithDeliveryDestination { get; set; }

}
