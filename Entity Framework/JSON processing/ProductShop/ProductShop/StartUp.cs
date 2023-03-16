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
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            ProductShopContext context = new ProductShopContext();

            //Read the json file.
            //P01
            //string inputJson =File.ReadAllText(@"../../../Datasets/users.json");

            //P02
            //string inputJson = File.ReadAllText(@"../../../Datasets/products.json");

            //P03
            //string inputJson = File.ReadAllText(@"../../../Datasets/categories.json");

            //P04
            string inputJson = File.ReadAllText(@"../../../Datasets/categories-products.json");


            string result = ImportCategoryProducts(context, inputJson);


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

        //Problem 2

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {

            IMapper mapper = CreateMapper();

            ImportProductDto[] productDtos = JsonConvert.DeserializeObject<ImportProductDto[]>(inputJson);

            ICollection<Product> validProducts = new HashSet<Product>();

            foreach (var productDto in productDtos)
            {
                Product product = mapper.Map<Product>(productDto);

                validProducts.Add(product);
            }

            context.Products.AddRange(validProducts);
            context.SaveChanges();

            return $"Successfully imported {validProducts.Count}";

        }

        //Problem 3
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            IMapper mapper = CreateMapper();

            ImportCategoryDto[] categoryDtos = JsonConvert.DeserializeObject<ImportCategoryDto[]>(inputJson);

            ICollection < Category > validCategories = new HashSet<Category>();

            foreach (var categoryDto in categoryDtos)
            {

                if (categoryDto.Name == null)
                {
                    continue;
                }
                Category category = mapper.Map<Category>(categoryDto);

                validCategories.Add(category);

            }

            context.Categories.AddRange((validCategories));
            context.SaveChanges();

            return $"Successfully imported {validCategories.Count}";
        }

        //Problem 4
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            
            ImportCategoryProductDto[] categoryProductDtos =
                JsonConvert.DeserializeObject<ImportCategoryProductDto[]>(inputJson);

            ICollection<CategoryProduct> validCategoryProducts = new HashSet<CategoryProduct>();

            foreach (var cpd in categoryProductDtos)
            {
                CategoryProduct cp = new CategoryProduct();
                cp.CategoryId = cpd.CategoryId;
                cp.ProductId = cpd.ProductId;


                validCategoryProducts.Add(cp);
            }
            context.AddRange(validCategoryProducts);
            context.SaveChanges();

            return $"Successfully imported {validCategoryProducts.Count}";
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