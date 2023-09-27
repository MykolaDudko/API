using AutoMapper;
using ClassLibrary.DTOs;
using ClassLibrary.Models;
using Microsoft.Extensions.DependencyInjection;
using System.Xml.Serialization;

namespace ClassLibrary.Providers;

public class ZasilkovnaCarrierBranchProvider : BaseCarrierBranchProvider
{
    public override string Id => "zasilkovna";
    public override string Name => "Zasilkovňa";
    public override string Url => "https://www.zasilkovna.cz/api/v4/{key}/branch.xml";
    public override string ParameterHint => "<country cz|sk|it|hu|at|ro>;<zasilkovnaAccountKey>;<ids>;<onlyCarrierBox|onlyPoint|onlyAlzaBox|carrierBoxAndAlzaBox|carrierBoxAndPoint|all>";
    List<CustomerPickUpBranchModel> AllCustomerPickUpBranches = new List<CustomerPickUpBranchModel>();
    private readonly IMapper _mapper;
    private readonly IHttpClientFactory _factory;

    [ActivatorUtilitiesConstructor]
    public ZasilkovnaCarrierBranchProvider(IMapper mapper, IHttpClientFactory factory)
    {
        _factory = factory;
        _mapper = mapper;
    }
    public override async Task<List<CustomerPickUpBranchModel>> GetBranchesAsync(string parameterString, CancellationToken ct)
    {
        var parameters = ParseParameters(parameterString, new List<string>() { "countryCode", "accountkey", "ids", "boxy" });
        var connectionString = Url;
        foreach (var item in parameters)
        {
            switch (item.Key)
            {
                case "accountkey":
                    connectionString = connectionString.Replace("{key}", item.Value);
                    break;
                case "ids":
                    if (!string.IsNullOrEmpty(item.Value))
                    {
                        connectionString = $"{connectionString.Replace("branch.xml", "point.json").Replace("/v4", "")}?ids={item.Value}";
                    }
                    break;

            }
        }
        CheckForUrlValidity(connectionString);
        var client = _factory.CreateClient();
        var response = await client.GetAsync(connectionString, cancellationToken: ct);

        var allBranches = await response.Content.ReadAsStreamAsync(cancellationToken: ct);

        if (connectionString.Contains("point.json"))
        {
            return GetPointBranches(allBranches);
        }
        else
        {

            var listOfBranchesZasilkovna = new ZasilkovnaXmlModel();
            allBranches.Position = 0;
            var serializer = new XmlSerializer(typeof(ZasilkovnaXmlModel));
            listOfBranchesZasilkovna = (ZasilkovnaXmlModel)serializer.Deserialize(allBranches);
            var types = ParseParameterWithSeveralDefinitions(parameters.FirstOrDefault(i => i.Key == "boxy").Value);
            foreach (var item in parameters)
            {
                switch (item.Key)
                {
                    case "countryCode":
                        listOfBranchesZasilkovna.Branches.Branch = listOfBranchesZasilkovna.Branches.Branch.Where(i => i.Country.ToLower() == item.Value.ToLower())
                              .ToList();
                        break;

                    case "boxy":
                        listOfBranchesZasilkovna.Branches.Branch = FilterBranchesByType(listOfBranchesZasilkovna.Branches.Branch, types);
                        break;
                }
            }
            AllCustomerPickUpBranches =
                _mapper.Map<List<Branch>, List<CustomerPickUpBranchModel>>(listOfBranchesZasilkovna.Branches.Branch);
        }
        return AllCustomerPickUpBranches;

    }

    private List<CustomerPickUpBranchModel> GetPointBranches(Stream allBranches)
    {
        var listOfBranchesBartolini = System.Text.Json.JsonSerializer.Deserialize<ZasilkovnaBartoliniPickUpPointsModel>(allBranches);
        var allCustomerPickUpBranches = new List<CustomerPickUpBranchModel>();
        foreach (var item in listOfBranchesBartolini.carriers)
        {
            allCustomerPickUpBranches.AddRange(_mapper.Map<List<Point>, List<CustomerPickUpBranchModel>>(item.points));
        }
        return allCustomerPickUpBranches;
    }

    private List<Branch> FilterBranchesByType(List<Branch> branches, List<string> types)
    {
        var filteredBranches = new List<Branch>();
        foreach (var item in types)
        {
            switch (item)
            {
                case nameof(BoxesEnum.all):
                    filteredBranches = branches;
                    break;
                case nameof(BoxesEnum.carrierBoxAndAlzaBox):
                    filteredBranches = branches.Where(i => i.Place == "Z-BOX" || i.Place == "Alzabox").ToList();
                    break;
                case nameof(BoxesEnum.carrierBoxAndPoint):
                    filteredBranches = branches.Where(i => i.Place == "Z-BOX" || i.Place != "Alzabox").ToList();
                    break;
                case nameof(BoxesEnum.onlyAlzaBox):
                    filteredBranches = branches.Where(i => i.Place == "Alzabox").ToList();
                    break;
                case nameof(BoxesEnum.onlyCarrierBox):
                    filteredBranches = branches.Where(i => i.Place == "Z-BOX").ToList();
                    break;
                case nameof(BoxesEnum.onlyPoint):
                    filteredBranches = branches.Where(i => i.Place != "Z-BOX" && i.Place != "Alzabox").ToList();
                    break;
                default:
                    break;
            }
        }
        return filteredBranches;
    }
}
