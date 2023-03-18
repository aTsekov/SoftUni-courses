using System.IO;
using System.Threading.Channels;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            using (CarDealerContext context = new CarDealerContext())
            {
                //context.Database.EnsureDeleted(); //use those only if there is a problem with the data and you need to re-import
                //context.Database.EnsureCreated();
                //P01
                //string inputJsonSuppliers = File.ReadAllText(@"../../../Datasets/suppliers.json");
                //Console.WriteLine(ImportSuppliers(context, inputJsonSuppliers));

                //P02
                string inputJsonParts = File.ReadAllText(@"../../../Datasets/parts.json");
                Console.WriteLine(ImportParts(context, inputJsonParts));


            }


        }

        //Problem 01
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            //1. First we need to create the mapper that will map the DTO and the entity. 
            IMapper mapper = CreateMapper();

            //2. We have to deserialize the inputJson (which is the data set) This means to transform the JSON into eligible data so it can be written in the DB.
            ImportSupplierDto[] supplierDtos = JsonConvert.DeserializeObject<ImportSupplierDto[]>(inputJson);


            ICollection<Supplier> validSuppliers = new HashSet<Supplier>();
            foreach (var supDto in supplierDtos)
            {
                //Map the DTO to the supplier
                //Supplier supplier = mapper.Map<Supplier>(supDto);

                Supplier sup = new Supplier()
                {
                    Name = supDto.Name,
                    IsImporter = supDto.IsImported
                };

                validSuppliers.Add(sup);
            }
            context.AddRange(validSuppliers);
            context.SaveChanges();

            return $"Successfully imported {validSuppliers.Count}.";

        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            IMapper mapper = CreateMapper();

            ImportPartsDto[] partsDtos = JsonConvert.DeserializeObject<ImportPartsDto[]>(inputJson);

            ICollection<Part> validParts = new HashSet<Part>();

            var validIds = context.Suppliers.Select(s => s.Id).ToList();

            foreach (var partDto in partsDtos)
            {
                //If the supplierId is not in the DB - it shold be skipped. 
                if (!validIds.Contains(partDto.SupplierId))
                {
                    continue;
                }

                Part part = mapper.Map<Part>(partDto);
                validParts.Add(part);
                
            }
            context.AddRange(validParts);
            context.SaveChanges();

            return $"Successfully imported {validParts.Count}.";
        }



        private static IMapper CreateMapper()
        {
            //In the Profile we made a link between the DTO and the Entity. Here we add the profile to the map configuration.
            return new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            }));
        }
    }
}