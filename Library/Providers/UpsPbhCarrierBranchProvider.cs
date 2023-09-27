using AutoMapper;
using ClassLibrary.DTOs;
using ClassLibrary.Models;
using System.Xml.Serialization;

namespace ClassLibrary.Providers;

public class UpsPbhCarrierBranchProvider : BaseCarrierBranchProvider
{
    public override string Id => "postabezhranic";
    public override string Name => "UPS";
    public override string Url => "http://www.postabezhranic.cz/api/get-parcelshops?courier={country}";
    public override string ParameterHint => "<sk_ups|ro_fan_parcelshop>";

    List<CustomerPickUpBranchModel> AllCustomerPickUpBranches = new List<CustomerPickUpBranchModel>();
    private readonly IMapper _mapper;
    private readonly IHttpClientFactory _factory;

    public UpsPbhCarrierBranchProvider(IMapper mapper, IHttpClientFactory factory)
    {
        _factory = factory;
        _mapper = mapper;
    }
    public override async Task<List<CustomerPickUpBranchModel>> GetBranchesAsync(string parameterString, CancellationToken ct)
    {
        var parameters = ParseParameters(parameterString, new List<string>() { "id" });
        var connectionString = Url;

        foreach (var item in parameters)
        {
            switch (item.Key)
            {
                case "id":
                    connectionString = item.Value == "ro_fan_parcelshop" ? $"{connectionString.Replace("{country}", item.Value)}&type=fanbox" : connectionString.Replace("{country}", "sk_ups");

                    break;
            }
        }
        var handler = new HttpClientHandler()
        {
            AllowAutoRedirect = false
        };
        CheckForUrlValidity(connectionString);
        var client = _factory.CreateClient("ups");


        var redirectedResponse = await client.GetAsync(connectionString, cancellationToken: ct);
        var finalResponse = await client.GetAsync(redirectedResponse.RequestMessage.RequestUri, cancellationToken: ct);

        var allBranches = await finalResponse.Content.ReadAsStreamAsync(cancellationToken: ct);
        var serializer = new XmlSerializer(typeof(UpsPickUpPointsModel));
        var listOfBranchesUps = (UpsPickUpPointsModel)serializer.Deserialize(allBranches);
        AllCustomerPickUpBranches = _mapper.Map<List<Place>, List<CustomerPickUpBranchModel>>(listOfBranchesUps.Place);
        return AllCustomerPickUpBranches;

    }
}
