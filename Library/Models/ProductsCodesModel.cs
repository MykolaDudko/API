using System.Text.Json.Serialization;

namespace ClassLibrary.Models;
public class ProductsCodesModel
{
    [JsonPropertyName("changed_codes")]
    public string[] ChangedCodes { get; set; }
}
