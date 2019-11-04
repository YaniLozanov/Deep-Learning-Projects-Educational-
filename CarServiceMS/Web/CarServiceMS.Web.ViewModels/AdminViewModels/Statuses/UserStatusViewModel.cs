using System;
using System.Collections.Generic;
using System.Text;

namespace CarServiceMS.Web.ViewModels.AdminViewModels.Statuses
{
    public class UserStatusViewModel
    {
        public int Count { get; set; }

        public int OrdinaryCount { get; set; }
        public int AdminsCount { get; set; }
        public int BannedCount { get; set; }
    }
}
