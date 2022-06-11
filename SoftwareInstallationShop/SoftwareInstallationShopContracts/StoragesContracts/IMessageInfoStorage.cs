using SoftwareInstallationShopContracts.BindingModels;
using SoftwareInstallationShopContracts.ViewModels;
using System.Collections.Generic;

namespace SoftwareInstallationShopContracts.StoragesContracts
{
    public interface IMessageInfoStorage
    {
        List<MessageInfoViewModel> GetFullList();
        List<MessageInfoViewModel> GetFilteredList(MessageInfoBindingModel model);
        void Insert(MessageInfoBindingModel model);
    }
}
