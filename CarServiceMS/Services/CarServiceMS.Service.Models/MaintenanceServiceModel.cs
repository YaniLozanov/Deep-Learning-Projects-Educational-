using System;
using System.Collections.Generic;
using System.Text;

namespace CarServiceMS.Service.Models
{
    public class MaintenanceServiceModel : CarServicesAbstractServiceModel
    {
        public IEnumerable<MaintenancePartServiceModel> Parts { get; set; }

    }
}
