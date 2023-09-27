using AutoMapper;
using ClassLibrary.DTOs;
using ClassLibrary.Models;
using System.Text.Json;

namespace ClassLibrary.Providers;

public class DpdCarrierBranchProvider : BaseCarrierBranchProvider
{
    public override string Id => "DPD";
    public override string Name => "Dpd";
    public override string Url => "https://pickup.dpd.cz/api/get-all";
    public override string ParameterHint => "<onlyCarrierBox|onlyPoint|onlyAlzaBox|carrierBoxAndAlzaBox|carrierBoxAndPoint|all>";
    private readonly IMapper _mapper;
    private readonly IHttpClientFactory _factory;

    public DpdCarrierBranchProvider(IMapper mapper, IHttpClientFactory factory)
    {
        _factory = factory;
        _mapper = mapper;
    }


    List<CustomerPickUpBranchModel> AllCustomerPickUpBranches = new List<CustomerPickUpBranchModel>();
    public override async Task<List<CustomerPickUpBranchModel>> GetBranchesAsync(string parameterString, CancellationToken ct)
    {

        var connectionString = Url;
        var client = _factory.CreateClient();
        var response = await client.GetAsync(connectionString, cancellationToken: ct);
        var allBranches = await response.Content.ReadAsStreamAsync(cancellationToken: ct);
        var listOfBranchesDpd = JsonSerializer.Deserialize<DpdPickUpPointsModel>(allBranches);

        var parameters = ParseParameters(parameterString, new List<string>() { "boxy" });
        if (parameters.TryGetValue("boxy", out string boxyParam))
        {
            var types = ParseParameterWithSeveralDefinitions(boxyParam);

            foreach (var type in types)
            {
                switch (type)
                {
                    case nameof(BoxesEnum.carrierBoxAndAlzaBox):
                        listOfBranchesDpd.data.items = listOfBranchesDpd.data.items
                            .Where(i => i.pickup_network_type == "dpd_box" || i.company.Contains("AlzaBox")).ToList();
                        break;

                    case nameof(BoxesEnum.carrierBoxAndPoint):
                        listOfBranchesDpd.data.items = listOfBranchesDpd.data.items
                            .Where(i => i.pickup_network_type == "dpd_box" || i.pickup_network_type == "pickup_point").ToList();
                        break;

                    case nameof(BoxesEnum.onlyCarrierBox):
                        listOfBranchesDpd.data.items = listOfBranchesDpd.data.items
                            .Where(i => i.pickup_network_type == "dpd_box").ToList();
                        break;

                    case nameof(BoxesEnum.onlyAlzaBox):
                        listOfBranchesDpd.data.items = listOfBranchesDpd.data.items
                            .Where(i => i.pickup_network_type == "dpd_box" && i.company.Contains("AlzaBox")).ToList();
                        break;

                    case nameof(BoxesEnum.onlyPoint):
                        listOfBranchesDpd.data.items = listOfBranchesDpd.data.items
                            .Where(i => i.pickup_network_type == "pickup_point").ToList();
                        break;
                }
            }

        }
        AllCustomerPickUpBranches = _mapper.Map<List<Item>, List<CustomerPickUpBranchModel>>(listOfBranchesDpd.data.items);

        return AllCustomerPickUpBranches;
    }
}
