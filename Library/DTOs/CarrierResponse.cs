using ClassLibrary.Models;

namespace ClassLibrary.DTOs;

public class CarrierResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Ico { get; set; }
    public bool IsDeleted { get; set; } = false;
    public SelectabilityStatusModelEnum? SelectabilityStatusId { get; set; }
}
