using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models;
public class CarrierModel: Entity
{
    public string Name { get; set; } = string.Empty;
    public List<CarrierBranchCategoryModel>? CarrierBranchCategory { get; set; }
    //public List<CarrierCollectionPlanModel> CarrierCollectionPlans { get; set; }
    public SelectabilityStatusModelEnum? SelectabilityStatusId { get; set; }
    public SelectabilityStatusModel? SelectabilityStatus { get; set; }
}
