using System.ComponentModel.DataAnnotations;

namespace ClassLibrary.Models;

public enum SelectabilityStatusModelEnum : int
{
    HIDE = 0,
    DISABLED = 1,
    ENABLED = 2
}
public class SelectabilityStatusModel
{
    [Key]
    public SelectabilityStatusModelEnum Id { get; set; }
    public string SelectabilityStatus { get; set; }
}

