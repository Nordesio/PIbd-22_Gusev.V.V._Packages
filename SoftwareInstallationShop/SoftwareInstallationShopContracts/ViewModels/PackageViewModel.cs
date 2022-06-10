using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SoftwareInstallationShopContracts.Attributes;
using System.Threading.Tasks;
using System.ComponentModel;

namespace SoftwareInstallationShopContracts.ViewModels
{
    /// <summary>
    /// Изделие, изготавливаемое в магазине
    /// </summary>
    public class PackageViewModel
    {
        [Column(title: "Номер", width: 100, visible: false)]
        public int Id { get; set; }
        [Column(title: "Название изделия", width: 150)]
        public string PackageName { get; set; }
        [Column(title: "Цена", width: 100)]
        public decimal Price { get; set; }
        [Column(title: "Компоненты", gridViewAutoSize: GridViewAutoSize.Fill)]
        public Dictionary<int, (string, int)> PackageComponents { get; set; }
        public string GetComponents()
        {
            string stringComp = string.Empty;
            if (PackageComponents != null)
            {
                foreach (var comp in PackageComponents)
                {
                    stringComp += comp.Key + ") " + comp.Value.Item1 + ": " + comp.Value.Item2 + ", ";
                }
            }
            return stringComp;
        }
    }
}
