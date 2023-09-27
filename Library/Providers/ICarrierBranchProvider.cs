using ClassLibrary.DTOs;
using ClassLibrary.Models;
using System.Text.Json.Serialization;

namespace ClassLibrary.Providers;

public interface ICarrierBranchProvider
{
    string Id { get; }
    string Name { get; }
    [JsonIgnore]
    string Url { get; }
    string ParameterHint { get; }
    Task<List<CustomerPickUpBranchModel>> GetBranchesAsync(string parameter, CancellationToken ct = default);
}
