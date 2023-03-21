using AutoMapper;
using CarDealer.Data;
using CarDealer.DTOs;
using CarDealer.Models;
using CarDealer.Utilities;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            using CarDealerContext contect = new CarDealerContext();

            //context.Database.EnsureDeleted(); //use those only if there is a problem with the data and you need to re-import
            //context.Database.EnsureCreated();

            //P09
            string inputXml = File.ReadAllText(@"../../../Datasets/suppliers.xml");
            Console.WriteLine(ImportSuppliers(contect,inputXml));
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

        private static IMapper InitializeAutoMapper()
            => new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            }));
    }
}