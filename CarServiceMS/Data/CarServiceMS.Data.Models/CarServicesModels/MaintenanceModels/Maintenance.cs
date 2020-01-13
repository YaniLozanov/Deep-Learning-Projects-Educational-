using CarServiceMS.Data.Models.CarServicesModels;
using CarServiceMS.Data.Models.CarServicesModels.MaintenanceModels;
using System.Collections.Generic;

namespace CarServiceMS.Data.Models
{
    public class Maintenance : CarServiceAbstractModel
    {
        public IEnumerable<MaintenancePart> Parts { get; set; }
    }
}
