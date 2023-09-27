using AutoMapper;
using ClassLibrary.DTOs;
using ClassLibrary.Models;
using System.Text.Json;

namespace ClassLibrary.Providers;

public class WedoBoxCarrierBranchProvider : BaseCarrierBranchProvider
{
    public override string Id => "wedo";
    public override string Name => "WeDo";
    public override string Url => "https://api.wedo.cz/v2/distribution-point?type={boxy}";
    public override string ParameterHint => "<boxcz|boxsk|oxbox|alza|wedo>";

    List<CustomerPickUpBranchModel> AllCustomerPickUpBranches = new List<CustomerPickUpBranchModel>();
    private readonly IMapper _mapper;
    private readonly IHttpClientFactory _factory;

    public WedoBoxCarrierBranchProvider(IMapper mapper, IHttpClientFactory factory)
    {
        _factory = factory;
        _mapper = mapper;
    }
    public override async Task<List<CustomerPickUpBranchModel>> GetBranchesAsync(string parameterString, CancellationToken ct)
    {
        var parameters = ParseParameters(parameterString, new List<string>() { "boxy" });
        var types = ParseParameterWithSeveralDefinitions(parameters.FirstOrDefault(i => i.Key == "boxy").Value);
        if (types == null || types.Count == 0)
            return new List<CustomerPickUpBranchModel>();

        foreach (var type in types)
        {
            var connectionString = Url.Replace("{boxy}", type);
            CheckForUrlValidity(connectionString);
            var client = _factory.CreateClient();
            var response = await client.GetAsync(connectionString, cancellationToken: ct);
            var allBranches = await response.Content.ReadAsStreamAsync(cancellationToken: ct);
            WedoModel listOfBranchesUlozenka = JsonSerializer.Deserialize<WedoModel>(allBranches);
            var boxOrPickupPoint = listOfBranchesUlozenka.wedo.branches.Count > 0
                ? listOfBranchesUlozenka.wedo.branches
                : listOfBranchesUlozenka.wedo.boxes;

            AllCustomerPickUpBranches.AddRange(_mapper.Map<List<WedoBranche>, List<CustomerPickUpBranchModel>>(boxOrPickupPoint));
            foreach (var item in boxOrPickupPoint)
            {
                var workHours = GetHours(item.opening_hours);
                var branch = AllCustomerPickUpBranches.FirstOrDefault(i => i.CarrierBranchId == item.code);

                if (branch != null && workHours.Count > 0)
                {
                    branch.WorkHours = workHours;
                }

            }
        }
        return AllCustomerPickUpBranches;
    }
    private List<WorkHoursModel> GetHours(OpeningHoursWedo openingHours)
    {
        var workHours = new List<WorkHoursModel>();
        var weekShedule = new List<WeekDayWedo> { openingHours.mon, openingHours.tue, openingHours.wed,
            openingHours.thu, openingHours.fri, openingHours.sat, openingHours.sun};

        for (int i = 0; i < weekShedule.Count(); i++)
        {
            if (weekShedule[i] != null)
            {
                weekShedule[i].Day = i + 1;
                workHours.Add(_mapper.Map<WeekDayWedo, WorkHoursModel>(weekShedule[i]));
            }
        }
        return workHours;
    }
}
