using System.Text.Json.Serialization;

namespace ClassLibrary.DTOs;

public class CreateCarrierBranchCategoryRequest
{
    public string ProviderId { get; set; }
    public string CarrierBranchName { get; set; } = string.Empty;
    public int CarrierId { get; set; }
    public string? Parameters { get; set; }
    [JsonIgnore]
    public bool IsDeleted { get; set; } = false;
}
