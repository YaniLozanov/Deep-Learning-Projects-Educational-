using Panda.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Panda.Services
{
    public interface IPackagesService
    {
        void AddPackage(Package package);

        Package GetPackage(string id);

        PackageStatus GetPackageStatus(string status);

        void UpdatePackage(Package package);

        IQueryable<Package> GetPackagesWithRecipientAndStatus();
    }
}
