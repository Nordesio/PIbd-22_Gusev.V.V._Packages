using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoftwareInstallationShopContracts.StoragesContracts;
using SoftwareInstallationShopContracts.ViewModels;
using SoftwareInstallationShopContracts.BindingModels;
using SoftwareInstallationShopDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;

namespace SoftwareInstallationShopDatabaseImplement.Implements
{
    public class OrderStorage : IOrderStorage
    {
        public List<OrderViewModel> GetFullList()
        {
            using var context = new SoftwareInstallationShopDatabase();
            return context.Orders
                .Include(rec => rec.Package)
                .Include(rec => rec.Client)
                .Include(rec => rec.Implementer)
                .ToList()
                .Select(CreateModel)
                .ToList();
        }
        public List<OrderViewModel> GetFilteredList(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new SoftwareInstallationShopDatabase();
            return context.Orders
            .Include(rec => rec.Package)
               .Include(rec => rec.Client)
               .Include(rec => rec.Implementer)
               .Where(rec => (!model.DateFrom.HasValue && !model.DateTo.HasValue &&
                    rec.DateCreate.Date == model.DateCreate.Date) ||
                    (model.DateFrom.HasValue && model.DateTo.HasValue &&
                    rec.DateCreate.Date >= model.DateFrom.Value.Date && rec.DateCreate.Date <=
                    model.DateTo.Value.Date) ||
                    (model.ClientId.HasValue && rec.ClientId == model.ClientId) ||
                    (model.SearchStatus.HasValue && model.SearchStatus.Value ==
                    rec.Status) ||
                    (model.ImplementerId.HasValue && rec.ImplementerId == model.ImplementerId && model.Status == rec.Status))
               .Select(CreateModel)
               .ToList();
        }
        public OrderViewModel GetElement(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new SoftwareInstallationShopDatabase();
            var order = context.Orders
            .Include(rec => rec.Package)
             .Include(rec => rec.Client)
             .Include(rec => rec.Implementer)
            .FirstOrDefault(rec => rec.Id == model.Id || rec.Id == model.Id);
            return order != null ? CreateModel(order) : null;
        }
        public void Insert(OrderBindingModel model)
        {
            using var context = new SoftwareInstallationShopDatabase();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                context.Orders.Add(CreateModel(model, new Order()));
                context.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }
        public void Update(OrderBindingModel model)
        {
            using var context = new SoftwareInstallationShopDatabase();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                var element = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, element);
                context.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }
        public void Delete(OrderBindingModel model)
        {
            using var context = new SoftwareInstallationShopDatabase();
            Order element = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                context.Orders.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        private static Order CreateModel(OrderBindingModel model, Order order)
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
        private static OrderViewModel CreateModel(Order order)
        {
           
            return new OrderViewModel
            {
                Id = order.Id,
                PackageId = order.PackageId,
                PackageName = order.Package.PackageName,
                ClientFIO = order.Client.ClientFIO,
                ClientId = order.ClientId,
                ImplementerId = order.ImplementerId,
                ImplementerFIO = order.ImplementerId.HasValue ? order.Implementer.ImplementerFIO : string.Empty,
                Count = order.Count,
                Sum = order.Sum,
                Status = Enum.GetName(order.Status),
                DateCreate = order.DateCreate,
                DateImplement = order.DateImplement
            };
        }
    }
}
