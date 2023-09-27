using AutoMapper;
using System.Reflection;

namespace ClassLibrary.Providers;

public class CarrierBranchProviderService
{
    public IReadOnlyList<ICarrierBranchProvider> AvailableProviders { get; }
    private readonly IHttpClientFactory _factory;
    private readonly IMapper _mapper;

    public CarrierBranchProviderService(IHttpClientFactory factory, IMapper mapper)
    {
        _factory = factory;
        _mapper = mapper;
        AvailableProviders = GetAllProviders();
    }

    public ICarrierBranchProvider GetById(string id)
    {
        return AvailableProviders.Single(x => x.Id == id);
    }

    private IReadOnlyList<ICarrierBranchProvider> GetAllProviders()
    {
        var providers = Assembly.GetAssembly(typeof(CarrierBranchProviderService))
                                       .GetTypes()
                                       .Where(x => x != null && typeof(ICarrierBranchProvider).IsAssignableFrom(x) && !x.IsAbstract)
                                       .Select(x => (ICarrierBranchProvider)Activator.CreateInstance(x, _mapper, _factory))
                                       .ToList();

        var errorProviderId = providers.GroupBy(x => x.Id.Trim(), StringComparer.OrdinalIgnoreCase)
                                       .FirstOrDefault(x => x.Count() > 1 || String.IsNullOrEmpty(x.Key));

        if (errorProviderId != null)
        {
            if (String.IsNullOrEmpty(errorProviderId.Key))
                throw new Exception(String.Format("Invalid property [Id] in class \"{0}\"! It must have value.", errorProviderId.First().GetType().Name));
            else
                throw new Exception(String.Format("[Id] \"{0}\" already exists! It must be unique.", errorProviderId.Key));
        }

        return providers;
    }
}
