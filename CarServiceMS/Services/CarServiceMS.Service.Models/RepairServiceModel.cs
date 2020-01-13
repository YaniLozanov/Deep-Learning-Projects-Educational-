using System.Collections.Generic;

namespace CarServiceMS.Service.Models
{
    public class RepairServiceModel : CarServicesAbstractServiceModel
    {
        public IEnumerable<RepairPartServiceModel> Parts { get; set; }

        public IEnumerable<ReportedDefectServiceModel> ReportedDefects { get; set; }

    }
}
