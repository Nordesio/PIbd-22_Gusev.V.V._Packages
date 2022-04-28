using System;
using System.Collections.Generic;
using SoftwareInstallationShopContracts.BindingModels;
using SoftwareInstallationShopContracts.ViewModels;


namespace SoftwareInstallationShopContracts.BusinessLogicsContracts
{
    public  interface IMessageInfoLogic
    {
        List<MessageInfoViewModel> Read(MessageInfoBindingModel model);
        void CreateOrUpdate(MessageInfoBindingModel model);
    }
}
