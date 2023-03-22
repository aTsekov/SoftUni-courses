using AutoMapper;
using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using CarDealer.Utilities;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.IO;

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
            string inputXml = File.ReadAllText(@"../../../Datasets/cars.xml");
            Console.WriteLine(ImportCars(context,inputXml));

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
        private static IMapper InitializeAutoMapper()
            => new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            }));
    }
}