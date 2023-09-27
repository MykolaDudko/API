namespace ClassLibrary.Filter;

public class GetCarrierBranchCategoryFilter : BaseFilter
{
    public int? CarrierId { get; set; }
    public bool? IsDeleted { get; set; }
    public string? ProviderId { get; set; }
}
