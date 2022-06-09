using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SoftwareInstallationShopContracts.Attributes;
using System.Threading.Tasks;

namespace SoftwareInstallationShopContracts.ViewModels
{
    public class ReportPackageComponentViewModel
    {
        public string PackageName { get; set; }
        public int TotalCount { get; set; }
        public List<Tuple<string, int>> Components { get; set; }
    }
}
