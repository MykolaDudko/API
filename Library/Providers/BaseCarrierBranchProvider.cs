using ClassLibrary.DTOs;
using ClassLibrary.Exceptions;
using ClassLibrary.Models;

namespace ClassLibrary.Providers;

public abstract class BaseCarrierBranchProvider : ICarrierBranchProvider
{
    public abstract string Id { get; }
    public abstract string Name { get; }
    public abstract string Url { get; }
    public abstract string ParameterHint { get; }

    public enum BoxesEnum
    {
        onlyCarrierBox,
        onlyPoint,
        onlyAlzaBox,
        carrierBoxAndAlzaBox,
        carrierBoxAndPoint,
        all
    }

    public abstract Task<List<CustomerPickUpBranchModel>> GetBranchesAsync(string parameterString, CancellationToken ct);

    protected Dictionary<string, string> ParseParameters(string parameterString, List<string> listKey)
    {
        var parameters = new Dictionary<string, string>();
        if (String.IsNullOrEmpty((parameterString ?? "").Trim()))
            return parameters;

        var parts = parameterString.Split(';').Select(x => x.Trim()).ToList();

        for (int i = 0; i < listKey.Count; i++)
        {
            if (parts.Count > i)
            {
                parameters.Add(listKey[i], parts[i]);
            }
        }
        return parameters;
    }

    protected List<string> ParseParameterWithSeveralDefinitions(string parameterString)
    {
        if (String.IsNullOrEmpty((parameterString ?? "").Trim()))
            return new List<string>();

        var parts = parameterString.Split('|').Select(x => x.Trim()).ToList();
        return parts;
    }

    protected void CheckForUrlValidity(string url)
    {
        if (!Uri.IsWellFormedUriString(url, UriKind.Absolute))
        {
            throw new ProviderException($"Url {url} is wrong");
        }
    }
}
