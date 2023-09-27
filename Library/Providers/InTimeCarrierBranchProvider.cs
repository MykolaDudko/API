using AutoMapper;
using ClassLibrary.DTOs;
using ClassLibrary.Models;
using System.Text.Json;

namespace ClassLibrary.Providers;

public class InTimeCarrierBranchProvider : BaseCarrierBranchProvider
{
    public override string Id => "inTime";
    public override string Name => "InTime";
    public override string Url => "https://bridge.intime.cz/public/paczkomaty/machines.json";
    public override string ParameterHint => "<>";
    List<CustomerPickUpBranchModel> AllCustomerPickUpBranches = new List<CustomerPickUpBranchModel>();
    private readonly IMapper _mapper;
    private readonly IHttpClientFactory _factory;

    public InTimeCarrierBranchProvider(IMapper mapper, IHttpClientFactory factory)
    {
        _factory = factory;
        _mapper = mapper;
    }
    public override async Task<List<CustomerPickUpBranchModel>> GetBranchesAsync(string parameterString, CancellationToken ct)
    {
        var connectionString = Url;
        var client = _factory.CreateClient();
        var response = await client
            .GetAsync(connectionString, cancellationToken: ct);
        var allBranches = await response.Content.ReadAsStreamAsync(cancellationToken: ct);
        var listOfBranchesInTime = JsonSerializer.Deserialize<InTimeModel>(allBranches);
        AllCustomerPickUpBranches = _mapper.Map<List<Machine>, List<CustomerPickUpBranchModel>>(listOfBranchesInTime.intime.machines);
        return AllCustomerPickUpBranches;
    }
}
