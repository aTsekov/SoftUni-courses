﻿using AutoMapper;
using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using CarDealer.Utilities;
using Castle.Core.Resource;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.IO;
using AutoMapper.QueryableExtensions;
using CarDealer.DTOs.Export;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            using CarDealerContext context = new CarDealerContext();

            //context.Database.EnsureDeleted(); //use those only if there is a problem with the data and you need to re-import
            //context.Database.EnsureCreated();

            //P09
            //string inputXml = File.ReadAllText(@"../../../Datasets/suppliers.xml");
            //Console.WriteLine(ImportSuppliers(context,inputXml));

            //P10
            //string inputXml = File.ReadAllText(@"../../../Datasets/parts.xml");
            //Console.WriteLine(ImportParts(context, inputXml));

            //P11
            //string inputXml = File.ReadAllText(@"../../../Datasets/cars.xml");
            //Console.WriteLine(ImportCars(context,inputXml));

            //P12
            //string inputXml = File.ReadAllText(@"../../../Datasets/customers.xml");
            //Console.WriteLine(ImportCustomers(context,inputXml

            //P13
            //string inputXml = File.ReadAllText(@"../../../Datasets/sales.xml");
            //Console.WriteLine(ImportSales(context, inputXml));

            //P14

            Console.WriteLine(GetCarsWithDistance(context));


        }

        //Problem 09
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            IMapper mapper = InitializeAutoMapper();

            XmlHelper xmlHelper = new XmlHelper();

            ImportSupplierDTO[] supplierDtos = xmlHelper.Deserialize<ImportSupplierDTO[]>(inputXml, "Suppliers");

            ICollection<Supplier> validSuppliers = new HashSet<Supplier>();

            foreach (var supDto in supplierDtos)
            {
                if (String.IsNullOrEmpty(supDto.Name))
                {
                    continue;
                }

                Supplier sup = mapper.Map<Supplier>(supDto);

                validSuppliers.Add(sup);
            }

            context.Suppliers.AddRange(validSuppliers);
            context.SaveChanges();

            return $"Successfully imported {validSuppliers.Count}";
        }


        //Problem 10
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            IMapper mapper = InitializeAutoMapper();
            XmlHelper xmlHelper = new XmlHelper();

            ImportPartsDto[] importPartsDtos = xmlHelper.Deserialize<ImportPartsDto[]>(inputXml, "Parts");

            ICollection<Part> validParts = new HashSet<Part>();
            ICollection<int> validSupplierIds = new HashSet<int>();

            validSupplierIds = context.Suppliers.Select( i => i.Id).ToList();

            foreach (var partDto in importPartsDtos)
            {
                if (!validSupplierIds.Contains(partDto.SupplierId))
                {
                    continue;
                }
                Part part = mapper.Map<Part>( partDto);
                validParts.Add(part);
            }

            context.Parts.AddRange(validParts);
            context.SaveChanges();
            return $"Successfully imported {validParts.Count}";
        }

        //Problem 11

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            IMapper mapper = InitializeAutoMapper();
            XmlHelper xmlHelper = new XmlHelper();
            ICollection<int> validParts = context.Parts.Select( p => p.Id).ToList();

            ICollection<Car> validCars = new HashSet<Car>();

            ImportCarDto[] carDtos = xmlHelper.Deserialize<ImportCarDto[]>(inputXml, "Cars");

            foreach (var carDto in carDtos)
            {
               
                if (!validParts.Contains(carDto.Parts.Select( p => p.PartId).FirstOrDefault()))
                {
                    continue;   
                }
               Car car = mapper.Map<Car>(carDto);
               foreach (var partDto in carDto.Parts.DistinctBy(p => p.PartId))
               {
                   if (!context.Parts.Any(p => p.Id == partDto.PartId))
                   {
                       continue;
                   }

                   PartCar carPart = new PartCar()
                   {
                       PartId = partDto.PartId
                   };

                   car.PartsCars.Add(carPart);
                }
               validCars.Add(car);                                                                          
                
            }
            context.Cars.AddRange(validCars);
            context.SaveChanges();
            return $"Successfully imported {validCars.Count}";
        }

        //Problem 12
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            XmlHelper xmlHelper = new XmlHelper();

            ImportCustomerDto[] customerDtos = xmlHelper.Deserialize<ImportCustomerDto[]>(inputXml, "Customers");

            ICollection<Customer> validCustomers = new HashSet<Customer>();

            foreach (var custDto in customerDtos)
            {
                Customer cust = new Customer()
                {
                    Name = custDto.Name,
                    BirthDate = DateTime.Parse(custDto.BirthDate),
                    IsYoungDriver = custDto.IsYoungDriver
                };

                validCustomers.Add(cust);
            }

            context.Customers.AddRange(validCustomers);
            context.SaveChanges();

            return $"Successfully imported {validCustomers.Count}";
        }

        //Problem 13

        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            IMapper mapper = InitializeAutoMapper();
            XmlHelper xmlHelper = new XmlHelper();

            ImportSalesDto[] saleDtos = xmlHelper.Deserialize<ImportSalesDto[]>(inputXml, "Sales");
            ICollection<Sale> validSales = new HashSet<Sale>();
            ICollection<int> validCarIds = context.Cars.Select( c=> c.Id).ToList();
            ICollection<int> validCustomerIds = context.Customers.Select( c=> c.Id).ToList();


            foreach (var saleDto in saleDtos)
            {
                if (!validCarIds.Contains(saleDto.CarId) /*|| !validCustomerIds.Contains(saleDto.CustomerId)*/)
                {
                    continue;
                }
                Sale sale = mapper.Map<Sale>(saleDto);
                validSales.Add(sale);
                
            }
            context.Sales.AddRange(validSales);
            context.SaveChanges();

            return $"Successfully imported {validSales.Count}";
        }

        //Problem 14

        public static string GetCarsWithDistance(CarDealerContext context)
        {
            IMapper mapper = InitializeAutoMapper();
            XmlHelper xmlHelper = new XmlHelper();

            var cars  = context.Cars.Where( c => c.TraveledDistance > 2000000)
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .ProjectTo<ExportCarWithDistanceDto>(mapper.ConfigurationProvider)
                .ToArray();


            return xmlHelper.Serialize<ExportCarWithDistanceDto[] >(cars, "cars");
        }

        private static IMapper InitializeAutoMapper()
            => new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            }));
    }
}