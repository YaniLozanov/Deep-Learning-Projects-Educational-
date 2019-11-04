using System;
using System.Collections.Generic;
using System.Text;

namespace CarServiceMS.Web.ViewModels.AdminViewModels.Statuses
{
    public class CarStatusViewModel
    {
        public int Count { get; set; }

        public int InPrcessCount { get; set; }
        public int ReadyCount { get; set; }
        public int WaitingCount { get; set; }
    }
}
