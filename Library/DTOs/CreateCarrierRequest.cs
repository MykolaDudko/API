using ClassLibrary.Models;
using System.Text.Json.Serialization;

namespace ClassLibrary.DTOs;

public class CreateCarrierRequest
{
    public string Name { get; set; } = string.Empty;
    public string? Ico { get; set; }
    [JsonIgnore]
    public bool IsDeleted { get; set; } = false;
    public SelectabilityStatusModelEnum? SelectabilityStatusId { get; set; }
}
