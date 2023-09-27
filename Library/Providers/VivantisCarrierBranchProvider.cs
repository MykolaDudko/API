using AutoMapper;
using ClassLibrary.DTOs;
using ClassLibrary.Models;

namespace ClassLibrary.Providers;

public class VivantisCarrierBranchProvider : BaseCarrierBranchProvider
{
    public override string Id => "vivantis";
    public override string Name => "Osobní odběr Pardubice";
    public override string Url => "";
    public override string ParameterHint => "<chrudim|praha|pardubice>";

    List<CustomerPickUpBranchModel> AllCustomerPickUpBranches;
    private readonly IHttpClientFactory _factory;
    private readonly IMapper _mapper;

    public VivantisCarrierBranchProvider(IMapper mapper, IHttpClientFactory factory)
    {
        _factory = factory;
        _mapper = mapper;
    }
    public override async Task<List<CustomerPickUpBranchModel>> GetBranchesAsync(string parameterString, CancellationToken ct)
    {
        var parameters = ParseParameters(parameterString, new List<string>() { "shop" });
        switch (parameters.FirstOrDefault(i => i.Key == "shop").Value)
        {
            case "chrudim":
                AllCustomerPickUpBranches = new List<CustomerPickUpBranchModel> {
                    {
                    new CustomerPickUpBranchModel
                    {
                        CarrierBranchId = "VVCHRUDIM001",
                        CustomerPickUpBranchName = "Recepce VIVANTIS, a.s.",
                        City = "Chrudim",
                        Street = "Školní náměstí 14",
                        ZipCode = "53701",
                        Email = "info@vivantis.cz",
                        WorkHours = new List<WorkHoursModel>
                  {
                      new WorkHoursModel
                      {
                         Day = 1,
                         TimeFrom = "7:30",
                         TimeTo = "18:00"
                      },
                      new WorkHoursModel
                      {
                         Day = 2,
                         TimeFrom = "7:30",
                         TimeTo = "18:00"
                      },
                      new WorkHoursModel
                      {
                         Day = 3,
                         TimeFrom = "7:30",
                         TimeTo = "18:00"
                      },
                      new WorkHoursModel
                      {
                         Day = 4,
                         TimeFrom = "7:30",
                         TimeTo = "18:00"
                      },
                      new WorkHoursModel
                      {
                         Day = 5,
                         TimeFrom = "7:30",
                         TimeTo = "18:00"
                      }
                  },
                        CountryCode = "CZE",
                        CardPayment = true,
                        Url = "https://www.vivantis.cz/vydejna-chrudim/",
                        Photo = "https://img.vivantiscdn.net/ams/-/1363/1d3bdee087bbc904643f31d919a7eeeb.png",
                         Location = new NetTopologySuite.Geometries.Point(49.9515909, 15.7981796)
                    }
                }
                    }; break;

            case "praha":

                AllCustomerPickUpBranches = new List<CustomerPickUpBranchModel>
            { new CustomerPickUpBranchModel
              {
                 CarrierBranchId = "VVPRAHA001",
                 CustomerPickUpBranchName = "Obchodní pasáž Oasis Florenc",
                  City = "Praha 8",
                  Street = "Sokolovská 394/17, Pobřežní 394/12",
                  ZipCode = "18000",
                  Email = "info@vivantis.cz",
                  WorkHours = new List<WorkHoursModel>
                  {
                      new WorkHoursModel
                      {
                         Day = 1,
                         TimeFrom = "8:00",
                         TimeTo = "19:00"
                      },
                      new WorkHoursModel
                      {
                         Day = 2,
                         TimeFrom = "8:00",
                         TimeTo = "19:00"
                      },
                      new WorkHoursModel
                      {
                         Day = 3,
                         TimeFrom = "7:30",
                         TimeTo = "19:00"
                      },
                      new WorkHoursModel
                      {
                         Day = 4,
                         TimeFrom = "8:00",
                         TimeTo = "19:00"
                      },
                      new WorkHoursModel
                      {
                         Day = 5,
                         TimeFrom = "8:00",
                         TimeTo = "19:00"
                      },
                      new WorkHoursModel
                      {
                         Day = 6,
                         TimeFrom = "9:00",
                         TimeTo = "13:00"
                      }
                  },
                  CountryCode = "CZE",
                  CardPayment = true,
                  Url = "https://www.vivantis.cz/vydejna-praha/",
                  Photo = "https://img.vivantiscdn.net/ams/-/1365/36bda3779b02f9b3de18d650b2c03c11.png",
                  Location = new NetTopologySuite.Geometries.Point(50.0917275, 14.4401970)
              }
            };
                break;
            case "pardubice":

                AllCustomerPickUpBranches = new List<CustomerPickUpBranchModel>
            { new CustomerPickUpBranchModel
              {
                 CarrierBranchId = "VVPARDUBICE001",
                 CustomerPickUpBranchName = "OC Grand",
                  City = "Pardubice",
                  Street = "nám. Republiky 1400",
                  ZipCode = "53002",
                  Email = "info@vivantis.cz",
                  WorkHours = new List<WorkHoursModel>
                  {
                      new WorkHoursModel
                      {
                         Day = 1,
                         TimeFrom = "8:00",
                         TimeTo = "19:00"
                      },
                      new WorkHoursModel
                      {
                         Day = 2,
                         TimeFrom = "8:00",
                         TimeTo = "19:00"
                      },
                      new WorkHoursModel
                      {
                         Day = 3,
                         TimeFrom = "7:30",
                         TimeTo = "19:00"
                      },
                      new WorkHoursModel
                      {
                         Day = 4,
                         TimeFrom = "8:00",
                         TimeTo = "19:00"
                      },
                      new WorkHoursModel
                      {
                         Day = 5,
                         TimeFrom = "8:00",
                         TimeTo = "19:00"
                      },
                      new WorkHoursModel
                      {
                         Day = 6,
                         TimeFrom = "9:00",
                         TimeTo = "19:00"
                      }
                  },
                  CountryCode = "CZE",
                  CardPayment = true,
                  Url = "https://www.vivantis.cz/vydejna-pardubice/",
                  Photo = "https://img.vivantiscdn.net/ams/-/6400/4b3a6b1303a84c011d7087a6bdd3ef0c.png",
                  Location = new NetTopologySuite.Geometries.Point(50.038054, 15.7763977)
              }
            }; break;
        }
        return AllCustomerPickUpBranches;
    }
}
