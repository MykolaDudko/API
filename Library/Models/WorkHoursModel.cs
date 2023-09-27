using Library.Models;

namespace ClassLibrary.Models;

public class WorkHoursModel : Entity
{
    public int Day { get; set; }
    public string? TimeFrom { get; set; }
    public string? TimeTo { get; set; }
}
