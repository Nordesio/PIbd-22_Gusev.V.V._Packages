using SoftwareInstallationShopContracts.BindingModels;
using SoftwareInstallationShopContracts.StoragesContracts;
using SoftwareInstallationShopContracts.ViewModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoftwareInstallationShopFileImplement.gg;
namespace SoftwareInstallationShopFileImplement.Implements
{
    class OrderStorage : IOrderStorage
    {
        private readonly FileDataListSingleton source;

        public OrderStorage()
        {
            source = FileDataListSingleton.GetInstance();
        }
        public void Delete(OrderBindingModel model)
        {
            Order order = source.Orders.FirstOrDefault(rec => rec.Id == model.Id);
            if (order != null)
            {
                source.Orders.Remove(order);
            }
            else
            {
                throw new Exception("Заказ не найден");
            }
        }
        public List<OrderViewModel> GetFullList()
        {
            return source.Orders.Select(CreateModel).ToList();
        }

        public List<OrderViewModel> GetFilteredList(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            return source.Orders.Where(rec => rec.PackageId.ToString().Contains(model.PackageId.ToString())).Select(CreateModel).ToList();
        }

        public OrderViewModel GetElement(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            var order = source.Orders.FirstOrDefault(rec => rec.PackageId == model.PackageId || rec.Id == model.Id);

            return order != null ? CreateModel(order) : null;
        }

        public void Insert(OrderBindingModel model)
        {
            int maxId = (int)(source.Orders.Count > 0 ? source.Orders.Max(rec => rec.Id) : 0);

            var order = new Order { Id = maxId + 1 };
            source.Orders.Add(CreateModel(model, order));
        }

        public void Update(OrderBindingModel model)
        {
            var order = source.Orders.FirstOrDefault(rec => rec.Id == model.Id);
            if (order == null)
            {
                throw new Exception("Заказ не найден");
            }

            CreateModel(model, order);
        }

        private Order CreateModel(OrderBindingModel model, Order order)
        {
            order.PackageId = model.PackageId;
            order.Count = model.Count;
            order.Sum = model.Sum;
            order.Status = model.Status;
            order.DateCreate = model.DateCreate;
            order.DateImplement = model.DateImplement;
            return order;
        }

        private OrderViewModel CreateModel(Order order)
        {
            Package package = source.Packages.FirstOrDefault(x => x.Id == order.PackageId);
            if (package == null)
            {
                throw new Exception("Мороженое не найдено");
            }
            return new OrderViewModel
            {
                Id = (int)order.Id,
                PackageId = order.PackageId,
                PackageName = package.PackageName,
                Count = order.Count,
                Sum = order.Sum,
                Status = Enum.GetName(order.Status),
                DateCreate = order.DateCreate,
                DateImplement = order.DateImplement
            };
        }
    }
}
