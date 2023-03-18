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
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                //P01
                string inputJson = File.ReadAllText(@"../../../Datasets/suppliers.json");
                Console.WriteLine(ImportSuppliers(context, inputJson));

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