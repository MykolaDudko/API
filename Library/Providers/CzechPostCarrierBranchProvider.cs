using AutoMapper;
using ClassLibrary.DTOs;
using ClassLibrary.Models;
using System.Xml.Serialization;

namespace ClassLibrary.Providers;

public class CzechPostCarrierBranchProvider : BaseCarrierBranchProvider
{
    public override string Id => "ceskaposta";
    public override string Name => "Česká pošta - Balíkovna";
    public override string Url => "http://napostu.ceskaposta.cz/vystupy/";
    public override string ParameterHint => "<onlyCarrierBox|onlyPoint|onlyAlzaBox|carrierBoxAndAlzaBox|carrierBoxAndPoint|all>;<ceskaposta|balikovna>";
    List<CustomerPickUpBranchModel> AllCustomerPickUpBranches = new List<CustomerPickUpBranchModel>();
    private readonly IMapper _mapper;
    private readonly IHttpClientFactory _factory;

    public CzechPostCarrierBranchProvider(IMapper mapper, IHttpClientFactory factory)
    {
        _factory = factory;
        _mapper = mapper;
    }

    public override async Task<List<CustomerPickUpBranchModel>> GetBranchesAsync(string parameterString, CancellationToken ct)
    {
        var parameters = ParseParameters(parameterString, new List<string>() { "boxy", "type" });
        string connectionString = Url;
        if (parameters.TryGetValue("type", out string type) && type == "ceskaposta")
        {
            connectionString = $"{connectionString}napostu_1.xml";
        }
        else
        {
            connectionString = $"{connectionString}balikovny.xml";
        }

        CheckForUrlValidity(connectionString);
        var client = _factory.CreateClient();
        var response = await client
            .GetAsync(connectionString, cancellationToken: ct);
        var allBranches = await response.Content.ReadAsStreamAsync(cancellationToken: ct);
        if (type == "ceskaposta")
        {
            var serializer = new XmlSerializer(typeof(CeskaPostaPickUpPointModel));
            var listOfBranchesCP = (CeskaPostaPickUpPointModel)serializer.Deserialize(allBranches);
            FilterCeskaPostaBranches(listOfBranchesCP, parameters);

            AllCustomerPickUpBranches = _mapper.Map<List<RowCP>, List<CustomerPickUpBranchModel>>(listOfBranchesCP.Row);

            foreach (var item in AllCustomerPickUpBranches)
            {
                foreach (var item2 in listOfBranchesCP.Row)
                {
                    item.WorkHours = _mapper.Map(item2.OTVDOBA.den, item.WorkHours);

                }
            }
        }

        else if (type == "balikovna")
        {
            var serializer = new XmlSerializer(typeof(BalikovnaPickUpPointsModel));
            var listOfBranchesBalikovna = (BalikovnaPickUpPointsModel)serializer.Deserialize(allBranches);
            FilterBalikovnaBranches(listOfBranchesBalikovna, parameters);

            foreach (var item in listOfBranchesBalikovna.Row)
            {
                item.WorkHours = new List<WorkHoursModel>();
                foreach (var item2 in item.OTEVDOBY.Den)
                {
                    foreach (var item3 in item2.OdDo)
                    {
                        var hour = new WorkHoursModel { Day = item2.Day, TimeFrom = item3.TimeFrom, TimeTo = item3.TimeTo };
                        item.WorkHours.Add(hour);
                    }
                }
            }
            AllCustomerPickUpBranches = _mapper.Map<List<RowBalikovna>, List<CustomerPickUpBranchModel>>(listOfBranchesBalikovna.Row);

        }

        return AllCustomerPickUpBranches;
    }
    private void FilterCeskaPostaBranches(CeskaPostaPickUpPointModel listOfBranchesCP, Dictionary<string, string> parameters)
    {
        if (parameters.TryGetValue("boxy", out string boxyParam))
        {
            var types = ParseParameterWithSeveralDefinitions(boxyParam);
            foreach (var item in types)
            {
                switch (item)
                {
                    case nameof(BoxesEnum.all):

                        break;

                    case nameof(BoxesEnum.carrierBoxAndAlzaBox):

                        break;

                    case nameof(BoxesEnum.carrierBoxAndPoint):
                        listOfBranchesCP.Row = listOfBranchesCP.Row.Where(i => i.ABCBOX == "A" || i.ABCBOX == "N").ToList();
                        break;

                    case nameof(BoxesEnum.onlyCarrierBox):
                        listOfBranchesCP.Row = listOfBranchesCP.Row.Where(i => i.ABCBOX == "A").ToList();
                        break;

                    case nameof(BoxesEnum.onlyPoint):
                        listOfBranchesCP.Row = listOfBranchesCP.Row.Where(i => i.ABCBOX == "N").ToList();
                        break;
                }
            }
        }

    }

    private void FilterBalikovnaBranches(BalikovnaPickUpPointsModel listOfBranchesBalikovna, Dictionary<string, string> parameters)
    {
        if (parameters.TryGetValue("boxy", out string boxyParam))
        {
            var types = ParseParameterWithSeveralDefinitions(boxyParam);
            switch (types.FirstOrDefault())
            {
                case nameof(BoxesEnum.all):

                    break;

                case nameof(BoxesEnum.carrierBoxAndAlzaBox):
                    listOfBranchesBalikovna.Row = listOfBranchesBalikovna.Row
                        .Where(i => i.TYP == "balíkovna-BOX").ToList();
                    break;

                case nameof(BoxesEnum.carrierBoxAndPoint):
                    listOfBranchesBalikovna.Row = listOfBranchesBalikovna.Row
                        .Where(i => i.TYP == "balíkovna-BOX" && !i.CustomerPickUpBranchName.Contains("AlzaBox") || i.TYP != "balíkovna-BOX").ToList();
                    break;

                case nameof(BoxesEnum.onlyCarrierBox):
                    listOfBranchesBalikovna.Row = listOfBranchesBalikovna.Row
                        .Where(i => i.TYP == "balíkovna-BOX" && !i.CustomerPickUpBranchName.Contains("AlzaBox")).ToList();
                    break;

                case nameof(BoxesEnum.onlyAlzaBox):
                    listOfBranchesBalikovna.Row = listOfBranchesBalikovna.Row
                        .Where(i => i.TYP == "balíkovna-BOX" && i.CustomerPickUpBranchName.Contains("AlzaBox")).ToList();
                    break;

                case nameof(BoxesEnum.onlyPoint):
                    listOfBranchesBalikovna.Row = listOfBranchesBalikovna.Row
                        .Where(i => i.TYP != "balíkovna-BOX").ToList();
                    break;
            }
        }
    }
}

