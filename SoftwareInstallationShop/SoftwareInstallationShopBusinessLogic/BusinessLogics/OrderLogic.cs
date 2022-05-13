using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoftwareInstallationShopContracts.BindingModels;
using SoftwareInstallationShopContracts.BusinessLogicsContracts;
using SoftwareInstallationShopContracts.StoragesContracts;
using SoftwareInstallationShopContracts.ViewModels;
using SoftwareInstallationShopContracts.Enums;
using SoftwareInstallationShopBusinessLogic.MailWorker;

namespace SoftwareInstallationShopBusinessLogic.BusinessLogics
{
    public class OrderLogic : IOrderLogic
    {
        private readonly IOrderStorage _orderStorage;
        private readonly AbstractMailWorker _mailWorker;
        private readonly IClientStorage _clientStorage;

        public OrderLogic(IOrderStorage orderStorage, IClientStorage clientStorage, AbstractMailWorker mailWorker)
        {
            _orderStorage = orderStorage;
            _mailWorker = mailWorker;
            _clientStorage = clientStorage;
        }

        public List<OrderViewModel> Read(OrderBindingModel model)
        {
            if (model == null)
            {
                return _orderStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<OrderViewModel> { _orderStorage.GetElement(model) };
            }
            return _orderStorage.GetFilteredList(model);
        }

        public void CreateOrder(CreateOrderBindingModel model)
        {
            _orderStorage.Insert(new OrderBindingModel
            {
                PackageId = model.PackageId,
                ClientId = model.ClientId,
                Count = model.Count,
                Sum = model.Sum,
                DateCreate = DateTime.Now,
                Status = OrderStatus.Принят
            });
            _mailWorker.MailSendAsync(new MailSendInfoBindingModel
            {
                MailAddress = _clientStorage.GetElement(new ClientBindingModel { Id = model.ClientId })?.Email,
                Subject = "Заказ создан",
                Text = $"Дата: {DateTime.Now}, сумма: {model.Sum}"
            });
        }

        public void TakeOrderInWork(ChangeStatusBindingModel model)
        {
            var order = _orderStorage.GetElement(new OrderBindingModel { Id = model.OrderId });

            if (order == null) throw new Exception("Элемент не найден");

            if (!order.Status.Contains(OrderStatus.Принят.ToString())) throw new Exception("Не в статусе \"Принят\"");

            _orderStorage.Update(new OrderBindingModel
            {
                Id = order.Id,
                PackageId = order.PackageId,
                ClientId = order.ClientId,
                ImplementerId = model.ImplementerId,
                Count = order.Count,
                Sum = order.Sum,
                DateCreate = order.DateCreate,
                DateImplement = DateTime.Now,
                Status = OrderStatus.Выполняется,
            });
            _mailWorker.MailSendAsync(new MailSendInfoBindingModel
            {
                MailAddress = _clientStorage.GetElement(new ClientBindingModel { Id = order.ClientId })?.Email,
                Subject = "Заказ выполняется",
                Text = $"Заказ №{order.Id} выполняется, Дата: {DateTime.Now}"
            });
        }

        public void FinishOrder(ChangeStatusBindingModel model)
        {
            var order = _orderStorage.GetElement(new OrderBindingModel { Id = model.OrderId });

            if (order == null) throw new Exception("Элемент не найден");

            if (!order.Status.Contains(OrderStatus.Выполняется.ToString())) throw new Exception("Не в статусе \"Выполняется\"");

            _orderStorage.Update(new OrderBindingModel
            {
                Id = order.Id,
                PackageId = order.PackageId,
                ClientId = order.ClientId,
                ImplementerId = order.ImplementerId,
                DateImplement = order.DateImplement,
                Count = order.Count,
                Sum = order.Sum,
                DateCreate = order.DateCreate,
                Status = OrderStatus.Готов,
            });
            _mailWorker.MailSendAsync(new MailSendInfoBindingModel
            {
                MailAddress = _clientStorage.GetElement(new ClientBindingModel { Id = order.ClientId })?.Email,
                Subject = "Заказ готов!",
                Text = $"Заказ №{order.Id} готов, Дата: {DateTime.Now}"
            });
        }

        public void DeliveryOrder(ChangeStatusBindingModel model)
        {
            var order = _orderStorage.GetElement(new OrderBindingModel { Id = model.OrderId });

            if (order == null) throw new Exception("Элемент не найден");

            if (!order.Status.Contains(OrderStatus.Готов.ToString())) throw new Exception("Не в статусе \"Готов\"");

            _orderStorage.Update(new OrderBindingModel
            {
                Id = order.Id,
                PackageId = order.PackageId,
                ClientId = order.ClientId,
                ImplementerId = order.ImplementerId,
                Count = order.Count,
                Sum = order.Sum,
                DateCreate = order.DateCreate,
                DateImplement = order.DateImplement,
                Status = OrderStatus.Выдан,
            });
            _mailWorker.MailSendAsync(new MailSendInfoBindingModel
            {
                MailAddress = _clientStorage.GetElement(new ClientBindingModel { Id = order.ClientId })?.Email,
                Subject = "Заказ выдан",
                Text = $"Заказ №{order.Id} выдан, Дата: {DateTime.Now}"
            });
        }
    }
}
