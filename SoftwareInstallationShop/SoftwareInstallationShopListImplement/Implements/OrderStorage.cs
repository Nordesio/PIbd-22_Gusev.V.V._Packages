using SoftwareInstallationShopContracts.BindingModels;
using SoftwareInstallationShopContracts.Enums;
using SoftwareInstallationShopContracts.StoragesContracts;
using SoftwareInstallationShopContracts.ViewModels;
using SoftwareInstallationShopListImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareInstallationShopListImplement.Implements
{
    public class OrderStorage : IOrderStorage
    {
        private readonly DataListSingleton source;

        public OrderStorage()
        {
            source = DataListSingleton.GetInstance();
        }

        public List<OrderViewModel> GetFullList()
        {
            var result = new List<OrderViewModel>();
            foreach (var order in source.Orders) result.Add(CreateModel(order));
            return result;
        }

        public List<OrderViewModel> GetFilteredList(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            List<OrderViewModel> result = new List<OrderViewModel>();
            foreach (var order in source.Orders)
            {
                if ((!model.DateFrom.HasValue && !model.DateTo.HasValue && order.DateCreate == model.DateCreate) ||
            (model.DateFrom.HasValue && model.DateTo.HasValue && order.DateCreate.Date >= model.DateFrom.Value.Date && order.DateCreate.Date <= model.DateTo.Value.Date) ||
                    (model.ClientId.HasValue && order.ClientId == model.ClientId) || (model.SearchStatus.HasValue && model.SearchStatus.Value == order.Status) ||
                    (model.ImplementerId.HasValue && order.ImplementerId == model.ImplementerId && model.Status == order.Status))
                {
                    result.Add(CreateModel(order));
                }
            }
            return result;
        }

        public OrderViewModel GetElement(OrderBindingModel model)
        {
            if (model == null) return null;

            foreach (var order in source.Orders)
            {
                if (order.Id == model.Id || order.PackageId == model.PackageId)
                {
                    return CreateModel(order);
                }
            }
            return null;
        }

        public void Insert(OrderBindingModel model)
        {
            var tempOrder = new Order { Id = 1 };

            foreach (var order in source.Orders)
            {
                if (order.Id >= tempOrder.Id) tempOrder.Id = order.Id + 1;
            }

            source.Orders.Add(CreateModel(model, tempOrder));
        }

        public void Update(OrderBindingModel model)
        {
            Order tempOrder = null;

            foreach (var order in source.Orders)
            {
                if (order.Id == model.Id) tempOrder = order;
            }

            if (tempOrder == null) throw new Exception("Элемент не найден");

            CreateModel(model, tempOrder);
        }

        public void Delete(OrderBindingModel model)
        {
            for (int i = 0; i < source.Orders.Count; ++i)
            {
                if (source.Orders[i].Id == model.Id.Value)
                {
                    source.Orders.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }

        private OrderViewModel CreateModel(Order order)
        {
            string packageName = null;
            for (int i = 0; i < source.Packages.Count; i++)
            {
                if (source.Packages[i].Id == order.PackageId)
                {
                    packageName = source.Packages[i].PackageName;
                    break;
                }
            }
            string clientFIO = null;
            for (int i = 0; i < source.Clients.Count; i++)
            {
                if (source.Clients[i].Id == order.ClientId)
                {
                    clientFIO = source.Clients[i].ClientFIO;
                    break;
                }
            }
            string implementerFIO = null;
            for (int i = 0; i < source.Implementers.Count; i++)
            {
                if (source.Implementers[i].Id == order.ImplementerId)
                {
                    implementerFIO = source.Implementers[i].ImplementerFIO;
                    break;
                }
            }
            return new OrderViewModel
            {
                Id = (int)order.Id,
                PackageId = order.PackageId,
                ClientId = order.ClientId,
                ImplementerId = order.ImplementerId,
                PackageName = packageName,
                ClientFIO = clientFIO,
                ImplementerFIO = implementerFIO,
                Count = order.Count,
                Sum = order.Sum,
                Status = Enum.GetName(order.Status),
                DateCreate = order.DateCreate,
                DateImplement = order.DateImplement
            };
        }


        private Order CreateModel(OrderBindingModel model, Order order)
        {
            order.PackageId = model.PackageId;
            order.ClientId = (int)model.ClientId;
            order.ImplementerId = model.ImplementerId;
            order.Count = model.Count;
            order.Sum = model.Sum;
            order.Status = model.Status;
            order.DateCreate = model.DateCreate;
            order.DateImplement = model.DateImplement;
            return order;
        }
    }
}
