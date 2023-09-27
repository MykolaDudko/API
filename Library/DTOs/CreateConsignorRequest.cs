using System.Text.Json.Serialization;

namespace ClassLibrary.DTOs;

public class CreateConsignorRequest
{
    public string ConsignorName { get; set; } = string.Empty;
    [JsonIgnore]
    public bool IsDeleted { get; set; } = false;
}
