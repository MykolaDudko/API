namespace ClassLibrary.DTOs;

public class CarrierBranchCategoryResponse
{
    public int Id { get; set; }

    public string ProviderId { get; set; }
    public string CarrierBranchName { get; set; } = string.Empty;
    public int CarrierId { get; set; }
    public string? Parameters { get; set; }
    public bool IsDeleted { get; set; } = false;
}
