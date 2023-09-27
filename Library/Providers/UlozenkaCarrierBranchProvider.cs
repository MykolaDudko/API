using AutoMapper;
using ClassLibrary.DTOs;
using ClassLibrary.Models;
using System.Text.Json;

namespace ClassLibrary.Providers;

public class UlozenkaCarrierBranchProvider : BaseCarrierBranchProvider
{
    public override string Id => "ulozenka";
    public override string Name => "Ulozenka";
    public override string Url => "https://api.ulozenka.cz/v3/transportservices/{id}/branches?includeInactive=0&destinationOnly=1&registerOnly=1&registerOnly=0&destinationCountry={countryCode}";
    public override string ParameterHint => "<transportservice: 18(mallbox by ulozenka)|5(dpd sk)|22(depo sk)|11(cz uloženka)|1(sk uloženka)>;<CZE|SVK>";

    List<CustomerPickUpBranchModel> AllCustomerPickUpBranches = new List<CustomerPickUpBranchModel>();
    private readonly IMapper _mapper;
    private readonly IHttpClientFactory _factory;

    public UlozenkaCarrierBranchProvider(IMapper mapper, IHttpClientFactory factory)
    {
        _factory = factory;
        _mapper = mapper;
    }
    public override async Task<List<CustomerPickUpBranchModel>> GetBranchesAsync(string parameterString, CancellationToken ct)
    {
        var connectionString = Url;
        var parameters = ParseParameters(parameterString, new List<string>() { "id", "countryCode" });
        foreach (var item in parameters)
        {
            switch (item.Key)
            {
                case "countryCode":
                    connectionString = connectionString.Replace("{countryCode}", item.Value);
                    break;

            }
        }
        var types = ParseParameterWithSeveralDefinitions(parameters.Where(i => i.Key == "id").FirstOrDefault().Value);
        AllCustomerPickUpBranches = new List<CustomerPickUpBranchModel>();
        foreach (var type in types)
        {
            var connectionStringToDownload = connectionString.Replace("{id}", type);
            CheckForUrlValidity(connectionStringToDownload);
            var client = _factory.CreateClient();
            var response = await client
                .GetAsync(connectionStringToDownload, cancellationToken: ct);
            var allBranches = await response.Content.ReadAsStreamAsync(cancellationToken: ct);

            var listOfBranchesUlozenkaSk = JsonSerializer.Deserialize<Ulozenka>(allBranches);
            AllCustomerPickUpBranches.AddRange(_mapper.Map<List<DestinationUlozenka>, List<CustomerPickUpBranchModel>>(listOfBranchesUlozenkaSk.data.destination));
            AddBranchWorkHours(listOfBranchesUlozenkaSk.data.destination);
        }
        return AllCustomerPickUpBranches;

    }

    private void AddBranchWorkHours(List<DestinationUlozenka> destinationList)
    {
        foreach (var item in destinationList)
        {
            var workHours = GetHours(item.opening_hours);
            var exisitingBranch = AllCustomerPickUpBranches.FirstOrDefault(i => i.CarrierBranchId == item.CarrierBranchId);
            if (exisitingBranch != null && workHours.Count > 0)
            {
                exisitingBranch.WorkHours = workHours;
            }
        }
    }

    private List<WorkHoursModel> GetHours(OpeningHoursUlozenka openingHours)
    {
        var branches = new List<WorkHoursModel>();
        var weekShedule = new List<WeekDay> { openingHours.regular.monday, openingHours.regular.tuesday, openingHours.regular.wednesday,
            openingHours.regular.thursday, openingHours.regular.friday, openingHours.regular.saturday, openingHours.regular.sunday };

        for (int i = 0; i < weekShedule.Count(); i++)
        {
            if (weekShedule[i].hours != null)
            {
                foreach (var hour in openingHours.regular.monday.hours)
                {
                    hour.Day = i + 1;
                    branches.Add(_mapper.Map<HourUlozenka, WorkHoursModel>(hour));
                }
            }
        }
        return branches;
    }
}
