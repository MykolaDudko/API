using ClassLibrary.Models;

namespace ClassLibrary.Filter;

public class TransportServiceFilter : BaseFilter
{
    public int? CarrierId { get; set; }
    public int? ConsignorId { get; set; }
    public string? Name { get; set; }
    public SelectabilityStatusModelEnum? SelectabilityStatus { get; set; }
}
