namespace ClassLibrary.Filter;

public class GetCustomerPickUpBranchFilter : BaseFilter
{
    public int? CategoryBranchId { get; set; }
    public string? InternalId { get; set; }
    public int? TransportServiceId { get; set; }
    public int? CarrierId { get; set; }
    public string? ProviderId { get; set; }
    public bool? IsEnabled { get; set; }
}
