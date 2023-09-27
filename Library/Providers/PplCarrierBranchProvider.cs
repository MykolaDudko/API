using AutoMapper;
using ClassLibrary.DTOs;
using ClassLibrary.Models;
using System.Xml.Serialization;

namespace ClassLibrary.Providers;

public class PplCarrierBranchProvider : BaseCarrierBranchProvider
{
    public override string Id => "PPL";
    public override string Name => "PPL";
    public override string Url => "https://www.pplbalik.cz/ASM/Ktm.asmx/GetAccessPointList?countryCode=cz&accessPointType={pointType}&allowInactive=false";
    public override string ParameterHint => "<ParcelShop1|Pbox3>";
    List<CustomerPickUpBranchModel> AllCustomerPickUpBranches = new List<CustomerPickUpBranchModel>();
    string connectionString = string.Empty;
    private readonly IMapper _mapper;
    private readonly IHttpClientFactory _factory;

    public PplCarrierBranchProvider(IMapper mapper, IHttpClientFactory factory)
    {
        _factory = factory;
        _mapper = mapper;
    }
    public override async Task<List<CustomerPickUpBranchModel>> GetBranchesAsync(string parameterString, CancellationToken ct)
    {

        connectionString = Url;
        var parameters2 = ParseParameters(parameterString, new List<string>() { "boxy" });

        foreach (var item in parameters2)
        {
            switch (item.Key)
            {
                case "boxy":
                    connectionString = connectionString.Replace("{pointType}", item.Value);
                    break;
            }
        }
        CheckForUrlValidity(connectionString);
        var client = _factory.CreateClient();
        var response = await client
            .GetAsync(connectionString, cancellationToken: ct);
        var allBranches = await response.Content.ReadAsStreamAsync(cancellationToken: ct);
        var serializer = new XmlSerializer(typeof(PplPickUpPointsModel));
        var listOfBranchesPpl = (PplPickUpPointsModel)serializer.Deserialize(allBranches);
        AllCustomerPickUpBranches = _mapper.Map<List<AccessPointDetailModel>, List<CustomerPickUpBranchModel>>
           (listOfBranchesPpl.AccessPointDetailModel);
        return AllCustomerPickUpBranches;
    }
}
