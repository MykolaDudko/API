
using AutoMapper;
using ClassLibrary.DTOs;
using ClassLibrary.Exceptions;
using ClassLibrary.Filter;
using ClassLibrary.Models;
using ClassLibrary.Providers;
using ClassLibrary.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ClassLibrary.Extensions;

public class СustomerPickUpBranchManager
{
    private readonly IMapper _mapper;
    private readonly CarrierBranchCategoryRepository _carrierBranchCategoryRepository;
    private readonly CustomerPickupBranchRepository _customerPickupBranchRepository;
    private readonly CarrierBranchProviderService _providerService;

    public СustomerPickUpBranchManager(IMapper mapper,
      CarrierBranchCategoryRepository carrierBranchCategoryRepository,
        CustomerPickupBranchRepository customerPickupBranchRepository,
        CarrierBranchProviderService providerService)
    {
        _mapper = mapper;
        _carrierBranchCategoryRepository = carrierBranchCategoryRepository;
        _customerPickupBranchRepository = customerPickupBranchRepository;
        _providerService = providerService;
    }

    public async Task FetchAllAsync(CancellationToken ct)
    {
        var categoryQuery = _carrierBranchCategoryRepository.GetEntityLinqQueryable();
        categoryQuery = categoryQuery.Where(i=>i.IsDeleted != true);
        var allCategories = await _carrierBranchCategoryRepository.GetListAsync(categoryQuery, ct);
        var branchQuery = _customerPickupBranchRepository.GetEntityLinqQueryable();
        branchQuery = branchQuery.Include(i => i.Carrier).Where(i => i.IsEnabled == true && i.IsExists == true);
        var selectedBranches = await _customerPickupBranchRepository.GetListAsync(branchQuery, ct);
        foreach (var category in allCategories)
        {
            await FetchBranches(category, selectedBranches.Where(i => i.CarrierBranchCategoryId == category.Id).ToList(), ct);
        }
    }
    public async Task FetchByCategoryIdAsync(int id, CancellationToken ct)
    {

        // Get the carrier branch category by ID.
        var categoryQuery = _carrierBranchCategoryRepository.GetEntityLinqQueryable();
        categoryQuery = categoryQuery.Where(i => i.Id == id && i.IsDeleted != true);
        var category = await _carrierBranchCategoryRepository.GetAsync(categoryQuery, ct);
        var branchQuery = _customerPickupBranchRepository.GetEntityLinqQueryable();
        branchQuery = branchQuery.Include(i => i.Carrier).Where(i => i.CarrierBranchCategoryId == category.Id && i.IsEnabled == true && i.IsExists == true);
        var selectedBranches = await _customerPickupBranchRepository.GetListAsync(branchQuery, ct);

        await FetchBranches(category, selectedBranches, ct);
    }

    public async Task FetchBranches(CarrierBranchCategoryModel category, List<CustomerPickUpBranchModel> dbBranches, CancellationToken ct)
    {
        // Fetch customer pick-up branches from the provider for the given category.
        var branches = await _providerService.GetById(category.ProviderId).GetBranchesAsync(category.Parameters, ct);
        branches.ForEach(i => { i.CarrierBranchCategoryId = category.Id; i.CarrierId = category.CarrierId; });

        // Filter out branches that already exist in the database and mark deleted branches.
        var deletedBranches = dbBranches.Where(p => !branches.Any(l => p.CarrierBranchId == l.CarrierBranchId && l.CarrierBranchCategoryId == p.CarrierBranchCategoryId)).ToList();

        // Update deleted branches in the database.
        deletedBranches.ForEach(i => i.IsExists = false);
        await _customerPickupBranchRepository.UpdateRangeAsync(deletedBranches, ct);

        // Filter out new branches and add them to the database.
        var result = branches.Where(p => !dbBranches.Any(l => p.CarrierBranchId == l.CarrierBranchId && l.CarrierBranchCategoryId == p.CarrierBranchCategoryId)).ToList();
        await _customerPickupBranchRepository.AddListAsync(result, ct);
    }

    /// <summary>
    /// Loads customer pick-up branches from a specific provider without inserting to the database.
    /// </summary>
    /// <param name="providerId">The provider ID.</param>
    /// <param name="filter">The LoadCustomerPickupBranchFromProviderFilter instance.</param>
    /// <returns>A list of CustomerPickUpBranchDTO representing fetched branches from the provider.</returns>
    public async Task<List<CustomerPickUpBranchResponse>> LoadDataFromProviderAsync(string providerId, LoadCustomerPickupBranchFromProviderFilter filter, CancellationToken ct)
    {
        var provider = _providerService.GetById(providerId);
        if (provider != null)
        {
            // Fetch customer pick-up branches from the provider.
            var branches = await provider.GetBranchesAsync(filter.Parameters, ct);
            return _mapper.Map<List<CustomerPickUpBranchResponse>>(branches.Skip(filter.Offset).Take(filter.Limit).ToList());
        }
        else
        {
            throw new ObjectNotFoundException($"Provider {providerId} does not exist");
        }
    }
}