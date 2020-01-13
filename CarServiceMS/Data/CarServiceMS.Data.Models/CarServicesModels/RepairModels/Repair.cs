using CarServiceMS.Data.Models.CarServicesModels;
using System.Collections.Generic;

namespace CarServiceMS.Data.Models
{
    public class Repair : CarServiceAbstractModel
    {
        public IEnumerable<RepairPart> Parts { get; set; }

        public IEnumerable<ReportedDefect> ReportedDefects { get; set; }

    }
}
