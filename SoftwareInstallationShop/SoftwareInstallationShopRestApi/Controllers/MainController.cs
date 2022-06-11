using SoftwareInstallationShopContracts.BindingModels;
using SoftwareInstallationShopContracts.BusinessLogicsContracts;
using SoftwareInstallationShopContracts.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace SoftwareInstallationShopRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly IOrderLogic _order;
        private readonly IPackageLogic _package;
        private readonly IMessageInfoLogic _messageInfo;
        public MainController(IOrderLogic order, IPackageLogic package, IMessageInfoLogic messageInfo)
        {
            _order = order;
            _package = package;
            _messageInfo = messageInfo;
        }
        [HttpGet]
        public List<PackageViewModel> GetPackageList() => _package.Read(null)?.ToList();
        [HttpGet]
        public PackageViewModel GetPackage(int packageId) => _package.Read(new
       PackageBindingModel { Id = packageId })?[0];

        [HttpGet]
        public List<OrderViewModel> GetOrders(int clientId) => _order.Read(new
       OrderBindingModel
        { ClientId = clientId });
        [HttpGet]
        public List<MessageInfoViewModel> GetMessages(int clientId) => _messageInfo.Read(new
       MessageInfoBindingModel
        { ClientId = clientId });
        [HttpPost]
        public void CreateOrder(CreateOrderBindingModel model) =>
       _order.CreateOrder(model);
    }
}