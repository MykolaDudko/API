using System.Text.Json.Serialization;

namespace ClassLibrary.DTOs;
public class UpdateConsignorRequest
{
    public string ConsignorName { get; set; } = string.Empty;
    [JsonIgnore]
    public bool IsDeleted { get; set; } = false;
}
