﻿using SoftwareInstallationShopContracts.BindingModels;
using SoftwareInstallationShopContracts.StoragesContracts;
using SoftwareInstallationShopContracts.ViewModels;
using SoftwareInstallationShopDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareInstallationShopDatabaseImplement.Implements
{
    public class ClientStorage : IClientStorage
    {
        public void Delete(ClientBindingModel model)
        {
            using var context = new SoftwareInstallationShopDatabase();
            Client element = context.Clients.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                context.Clients.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Клиент не найден");
            }
        }

        public ClientViewModel GetElement(ClientBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new SoftwareInstallationShopDatabase();

            var client = context.Clients.Include(x => x.Order)
            .FirstOrDefault(rec => rec.Email == model.Email ||
            rec.Id == model.Id);
            return client != null ?
            new ClientViewModel
            {
                Id = client.Id,
                ClientFIO = client.ClientFIO,
                Email = client.Email,
                Password = client.Password,
            } :
            null;

        }

        public List<ClientViewModel> GetFilteredList(ClientBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new SoftwareInstallationShopDatabase();

            return context.Clients.Include(x => x.Order)
            .Where(rec => rec.Email == model.Email && rec.Password == rec.Password)
            .Select(rec => new ClientViewModel
            {
                Id = rec.Id,
                ClientFIO = rec.ClientFIO,
                Email = rec.Email,
                Password = rec.Password,
            })
            .ToList();

        }

        public List<ClientViewModel> GetFullList()
        {
            using var context = new SoftwareInstallationShopDatabase();

            return context.Clients.Select(rec => new ClientViewModel
            {
                Id = rec.Id,
                ClientFIO = rec.ClientFIO,
                Email = rec.Email,
                Password = rec.Password,
            })
            .ToList();

        }

        public void Insert(ClientBindingModel model)
        {
            using var context = new SoftwareInstallationShopDatabase();

            context.Clients.Add(CreateModel(model, new Client()));
            context.SaveChanges();

        }

        public void Update(ClientBindingModel model)
        {
            using var context = new SoftwareInstallationShopDatabase();

            var element = context.Clients.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Клиент не найден");
            }
            CreateModel(model, element);
            context.SaveChanges();

        }
        private Client CreateModel(ClientBindingModel model, Client client)
        {
            client.ClientFIO = model.ClientFIO;
            client.Email = model.Email;
            client.Password = model.Password;
            return client;
        }
    }
}
