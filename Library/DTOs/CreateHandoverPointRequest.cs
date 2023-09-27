using System.Text.Json.Serialization;

namespace ClassLibrary.DTOs;

public class CreateHandoverPointRequest
{
    public string HandoverPointName { get; set; } = string.Empty;
    [JsonIgnore]
    public bool IsDeleted { get; set; } = false;
}
