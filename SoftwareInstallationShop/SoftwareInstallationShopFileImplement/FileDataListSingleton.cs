﻿using SoftwareInstallationShopContracts.Enums;
using SoftwareInstallationShopFileImplement.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;


namespace SoftwareInstallationShopFileImplement
{
    public class FileDataListSingleton
    {
        private static FileDataListSingleton instance;
        private readonly string ComponentFileName = "Component.xml";
        private readonly string OrderFileName = "Order.xml";
        private readonly string PackageFileName = "Package.xml";
        public List<Component> Components { get; set; }
        public List<Order> Orders { get; set; }
        public List<Package> Packages { get; set; }
        private FileDataListSingleton()
        {
            Components = LoadComponents();
            Orders = LoadOrders();
            Packages = LoadPackages();
        }
        public static FileDataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new FileDataListSingleton();
            }
            return instance;
        }
        ~FileDataListSingleton()
        {
            SaveComponents();
            SaveOrders();
            SaveProducts();
        }
        private List<Component> LoadComponents()
        {
            var list = new List<Component>();
            if (File.Exists(ComponentFileName))
            {
                var xDocument = XDocument.Load(ComponentFileName);
                var xElements = xDocument.Root.Elements("Component").ToList(); foreach (var elem in xElements)
                {
                    list.Add(new Component
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        ComponentName = elem.Element("ComponentName").Value
                    });
                }
            }
            return list;
        }
        private List<Order> LoadOrders()
        {
            var list = new List<Order>();
            if (File.Exists(OrderFileName))
            {
                XDocument xDocument = XDocument.Load(OrderFileName);
                var xElements = xDocument.Root.Elements("Order").ToList();

                foreach (var elem in xElements)
                {
                    list.Add(new Order
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        PackageId = Convert.ToInt32(elem.Element("IceCreamId").Value),
                        Count = Convert.ToInt32(elem.Element("Count").Value),
                        Sum = Convert.ToDecimal(elem.Element("Sum").Value),
                        Status = (OrderStatus)Enum.Parse(typeof(OrderStatus), elem.Element("Status").Value),
                        DateCreate = Convert.ToDateTime(elem.Element("DateCreate").Value),
                        DateImplement = string.IsNullOrEmpty(elem.Element("DateImplement").Value) ? (DateTime?)null :
                            Convert.ToDateTime(elem.Element("DateImplement").Value)
                    });
                }
            }
            return list;
        }
        private List<Package> LoadPackages()
        {
            var list = new List<Package>();
            if (File.Exists(PackageFileName))
            {
                var xDocument = XDocument.Load(PackageFileName);
                var xElements = xDocument.Root.Elements("Package").ToList();
                foreach (var elem in xElements)
                {
                    var prodComp = new Dictionary<int, int>();
                    foreach (var component in
                   elem.Element("PackageComponents").Elements("PackageComponent").ToList())
                    {
                        prodComp.Add(Convert.ToInt32(component.Element("Key").Value),
                       Convert.ToInt32(component.Element("Value").Value));
                    }
                    list.Add(new Package
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        PackageName = elem.Element("PackageName").Value,
                        Price = Convert.ToDecimal(elem.Element("Price").Value),
                        PackageComponents = prodComp
                    });
                }
            }
            return list;
        }
        private void SaveComponents()
        {
            if (Components != null)
            {
                var xElement = new XElement("Components");
                foreach (var component in Components)
                {
                    xElement.Add(new XElement("Component",
                    new XAttribute("Id", component.Id),
                    new XElement("ComponentName", component.ComponentName)));
                }
                var xDocument = new XDocument(xElement); xDocument.Save(ComponentFileName);
            }
        }
        private void SaveOrders()
        {
            if (Orders != null)
            {
                var xElement = new XElement("Orders");

                foreach (var order in Orders)
                {
                    xElement.Add(new XElement("Order",
                    new XAttribute("Id", order.Id),
                    new XElement("PackageId", order.PackageId),
                    new XElement("Count", order.Count),
                    new XElement("Sum", order.Sum),
                    new XElement("Status", order.Status),
                    new XElement("DateCreate", order.DateCreate),
                    new XElement("DateImplement", order.DateImplement)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(OrderFileName);
            }
        }
        private void SaveProducts()
        {
            if (Packages != null)
            {
                var xElement = new XElement("Products");
                foreach (var product in Packages)
                {
                    var compElement = new XElement("ProductComponents");
                    foreach (var component in product.ProductComponents)
                    {
                        compElement.Add(new XElement("ProductComponent",
                        new XElement("Key", component.Key),
                        new XElement("Value", component.Value)));
                    }
                    xElement.Add(new XElement("Product",
                     new XAttribute("Id", product.Id),
                     new XElement("ProductName", product.ProductName),
                     new XElement("Price", product.Price),
                     compElement));
                }
                var xDocument = new XDocument(xElement);
                xDocument.Save(PackageFileName);
            }
        }
    }
}
