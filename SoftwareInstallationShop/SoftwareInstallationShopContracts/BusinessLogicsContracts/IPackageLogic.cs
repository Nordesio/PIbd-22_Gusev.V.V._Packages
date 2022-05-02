using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoftwareInstallationShopContracts.BindingModels;
using SoftwareInstallationShopContracts.ViewModels;

namespace SoftwareInstallationShopContracts.BusinessLogicsContracts
{
    public interface IPackageLogic
    {
        List<PackageViewModel> Read(PackageBindingModel model);
        void CreateOrUpdate(PackageBindingModel model);
        void Delete(PackageBindingModel model);
    }
}
