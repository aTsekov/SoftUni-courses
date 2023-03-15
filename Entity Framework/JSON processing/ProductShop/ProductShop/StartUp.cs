namespace ProductShop
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    using Data;
    using DTOs.Import;
    using Models;

    public class StartUp
    {
        public static void Main()
        {
            ProductShopContext context = new ProductShopContext();

            //Read the json file. 
            string inputJson = 
               File.ReadAllText(@"../../../Datasets/users.json");

            string result = ImportUsers(context, inputJson);
            Console.WriteLine(result);
        }

        // Problem 01
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            IMapper mapper = CreateMapper(); //Create the mapper that will be used to map each obj(user) to the DTO.


            //The inputJson is deserialized. The reason for using an [] for ImportUserDto[] is because in the data set
            //the all objects are wrapped in an array. 
            ImportUserDto[] userDtos =
                JsonConvert.DeserializeObject<ImportUserDto[]>(inputJson);

            //Initialize a collection to keep the valid users.
            ICollection<User> validUsers = new HashSet<User>();
            foreach (ImportUserDto userDto in userDtos)
            {
                //Create new user and map it to the userDto(this is each object from the data set)
                User user = mapper.Map<User>(userDto);

                //Add the user to the collection of valid users
                validUsers.Add(user);
            }

            //Add the users to the DB and save the changes. 
            context.Users.AddRange(validUsers);
            context.SaveChanges();

            return $"Successfully imported {validUsers.Count}";
        }

       

        private static IMapper CreateMapper()
        {
            //In the Profile we made a link between the DTO and the Entity. Here we add the profile to the map configuration.
            return new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            }));
        }

        
    }
}