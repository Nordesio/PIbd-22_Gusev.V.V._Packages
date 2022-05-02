using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoftwareInstallationShopContracts.BindingModels;
using SoftwareInstallationShopContracts.BusinessLogicsContracts;
using SoftwareInstallationShopContracts.StoragesContracts;
using SoftwareInstallationShopContracts.ViewModels;

namespace SoftwareInstallationShopBusinessLogic.BusinessLogics
{
    public  class PackageLogic : IPackageLogic
    {
        private readonly IPackageStorage packageStorage;

        public PackageLogic(IPackageStorage _packageStorage)
        {
            packageStorage = _packageStorage;
        }

        public List<PackageViewModel> Read(PackageBindingModel model)
        {
            if (model == null)
            {
                return packageStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<PackageViewModel> { packageStorage.GetElement(model) };
            }
            return packageStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(PackageBindingModel model)
        {
            var element = packageStorage.GetElement(new PackageBindingModel { PackageName = model.PackageName });

            if (element != null && element.Id != model.Id) throw new Exception("Уже есть компонент с таким названием");

            if (model.Id.HasValue)
            {
                packageStorage.Update(model);
            }
            else
            {
                packageStorage.Insert(model);
            }
        }

        public void Delete(PackageBindingModel model)
        {
            var element = packageStorage.GetElement(new PackageBindingModel { Id = model.Id });

            if (element == null) throw new Exception("Элемент не найден");

            packageStorage.Delete(model);
        }
    }
}
