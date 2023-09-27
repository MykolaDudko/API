using ClassLibrary.Models;
using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace ClassLibrary.Context;

public class PatramDbContext : DbContext
{
    public DbSet<CarrierModel> Carriers { get; set; } = null!;
    public DbSet<ConsignorModel> Consignors { get; set; } = null!;
    public DbSet<CarrierBranchCategoryModel> CarrierBranchCategories { get; set; } = null!;
    public DbSet<CustomerPickUpBranchModel> CustomerPickUpBranches { get; set; } = null!;
    public DbSet<HandoverPointModel> HandoverPoint { get; set; } = null!;
    public DbSet<TransportServiceModel> TransportServices { get; set; } = null!;
    public DbSet<WorkHoursModel> WorkHours { get; set; } = null!;
    public DbSet<SelectabilityStatusModel> SelectabilityStatus { get; set; } = null!;
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure relationships between entities HandoverPoint and TransportService.
        modelBuilder.Entity<HandoverPointModel>().HasMany(p => p.TransportServicesWithDeliverySource)
            .WithOne(p => p.HandoverPointSource);
        modelBuilder.Entity<HandoverPointModel>().HasMany(p => p.TransportServicesWithDeliveryDestination)
            .WithOne(p => p.HandoverPointDestination);

        // Seed data for SelectabilityStatus.
        modelBuilder
       .Entity<SelectabilityStatusModel>().HasData(
           System.Enum.GetValues(typeof(SelectabilityStatusModelEnum))
               .Cast<SelectabilityStatusModelEnum>()
               .Select(e => new SelectabilityStatusModel()
               {
                   Id = e,
                   SelectabilityStatus = e.ToString()
               })
       );

        // Seed data for Carriers.
        modelBuilder
       .Entity<CarrierModel>().HasData(
            new CarrierModel { Id = 1, Name = "VIVANTIS", SelectabilityStatusId = SelectabilityStatusModelEnum.ENABLED },
            new CarrierModel { Id = 2, Name = "Česká pošta", SelectabilityStatusId = SelectabilityStatusModelEnum.ENABLED },
            new CarrierModel { Id = 3, Name = "PPL", SelectabilityStatusId = SelectabilityStatusModelEnum.ENABLED },
            new CarrierModel { Id = 4, Name = "Uloženka", SelectabilityStatusId = SelectabilityStatusModelEnum.ENABLED },
            new CarrierModel { Id = 5, Name = "GLS", SelectabilityStatusId = SelectabilityStatusModelEnum.ENABLED },
            new CarrierModel { Id = 6, Name = "Pošta bez hranic", SelectabilityStatusId = SelectabilityStatusModelEnum.ENABLED },
            new CarrierModel { Id = 7, Name = "In Time", SelectabilityStatusId = SelectabilityStatusModelEnum.ENABLED },
            new CarrierModel { Id = 8, Name = "Cargus", SelectabilityStatusId = SelectabilityStatusModelEnum.ENABLED },
            new CarrierModel { Id = 9, Name = "DHL", SelectabilityStatusId = SelectabilityStatusModelEnum.ENABLED },
            new CarrierModel { Id = 10, Name = "Slovenská pošta", SelectabilityStatusId = SelectabilityStatusModelEnum.ENABLED },
            new CarrierModel { Id = 11, Name = "DPD PickUp", SelectabilityStatusId = SelectabilityStatusModelEnum.ENABLED },
            new CarrierModel { Id = 12, Name = "DPD", SelectabilityStatusId = SelectabilityStatusModelEnum.ENABLED },
            new CarrierModel { Id = 13, Name = "Zásilkovna", SelectabilityStatusId = SelectabilityStatusModelEnum.ENABLED }
            );       
    }
    public PatramDbContext(DbContextOptions<PatramDbContext> options)
      : base(options)
    {

    }
}

