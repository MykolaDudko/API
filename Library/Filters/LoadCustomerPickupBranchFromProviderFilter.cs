namespace ClassLibrary.Filter;

public class LoadCustomerPickupBranchFromProviderFilter
{
    public string? Parameters { get; set; }
    public int Limit { get; set; } = 50;
    public int Offset { get; set; } = 0;
}
