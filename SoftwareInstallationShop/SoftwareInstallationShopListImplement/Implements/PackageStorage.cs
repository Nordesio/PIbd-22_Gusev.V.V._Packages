using SoftwareInstallationShopContracts.BindingModels;
using SoftwareInstallationShopContracts.StoragesContracts;
using SoftwareInstallationShopContracts.ViewModels;
using SoftwareInstallationShopListImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace SoftwareInstallationShopListImplement.Implements
{
    public class PackageStorage : IPackageStorage
    {
        private readonly DataListSingleton source;
        public PackageStorage()
        {
            source = DataListSingleton.GetInstance();
        }
        public List<PackageViewModel> GetFullList()
        {
            var result = new List<PackageViewModel>();
            foreach (var component in source.Packages)
            {
                result.Add(CreateModel(component));
            }
            return result;
        }
        public List<PackageViewModel> GetFilteredList(PackageBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            var result = new List<PackageViewModel>();
            foreach (var product in source.Packages)
            {
                if (product.PackageName.Contains(model.PackageName))
                {
                    result.Add(CreateModel(product));
                }
            }
            return result;
        }
        public PackageViewModel GetElement(PackageBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            foreach (var product in source.Packages)
            {
                if (product.Id == model.Id || product.PackageName == model.PackageName)
                {
                    return CreateModel(product);
                }
            }
            return null;
        }
        public void Insert(PackageBindingModel model)
        {
            var tempProduct = new Package
            {
                Id = 1,
                PackageComponents = new Dictionary<int, int>()
            };
            foreach (var product in source.Packages)
            {
                if (product.Id >= tempProduct.Id)
                {
                    tempProduct.Id = product.Id + 1;
                }
            }
            source.Packages.Add(CreateModel(model, tempProduct));
        }
        public void Update(PackageBindingModel model)
        {
            Package tempProduct = null;
            foreach (var product in source.Packages)
            {
                if (product.Id == model.Id)
                {
                    tempProduct = product;
                }
            }
            if (tempProduct == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, tempProduct);
        }
        public void Delete(PackageBindingModel model)
        {
            for (int i = 0; i < source.Packages.Count; ++i)
            {
                if (source.Packages[i].Id == model.Id)
                {
                    source.Packages.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
        private static Package CreateModel(PackageBindingModel model, Package product)
        {
            product.PackageName = model.PackageName;
            product.Price = model.Price;
            // удаляем убранные
            foreach (var key in product.PackageComponents.Keys.ToList())
            {
                if (!model.PackageComponents.ContainsKey(key))
                {
                    product.PackageComponents.Remove(key);
                }
            }
            // обновляем существуюущие и добавляем новые
            foreach (var component in model.PackageComponents)
            {
                if (product.PackageComponents.ContainsKey(component.Key))
                {
                    product.PackageComponents[component.Key] = model.PackageComponents[component.Key].Item2;
                }
                else
                {
                    product.PackageComponents.Add(component.Key, model.PackageComponents[component.Key].Item2);
                }
            }
            return product;
        }
        private PackageViewModel CreateModel(Package product)
        {
            // требуется дополнительно получить список компонентов для изделия с названиями и их количество
        var productComponents = new Dictionary<int, (string, int)>();
            foreach (var pc in product.PackageComponents)
            {
                string componentName = string.Empty;
                foreach (var component in source.Components)
                {
                    if (pc.Key == component.Id)
                    {
                        componentName = component.ComponentName;
                        break;
                    }
                }
                productComponents.Add(pc.Key, (componentName, pc.Value));
            }
            return new PackageViewModel
            {
                Id = product.Id,
                PackageName = product.PackageName,
                Price = product.Price,
                PackageComponents = productComponents
            };
        }

    }
}
