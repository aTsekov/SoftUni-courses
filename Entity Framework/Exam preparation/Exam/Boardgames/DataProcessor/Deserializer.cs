using System.Text;
using Boardgames.Data.Models;
using Boardgames.Data.Models.Enums;
using Boardgames.DataProcessor.ImportDto;
using Footballers;
using Newtonsoft.Json;

namespace Boardgames.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using Boardgames.Data;
   
    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCreator
            = "Successfully imported creator – {0} {1} with {2} boardgames.";

        private const string SuccessfullyImportedSeller
            = "Successfully imported seller - {0} with {1} boardgames.";

        public static string ImportCreators(BoardgamesContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            XmlHelper xmlHelper = new XmlHelper();

            ICollection<Creator> validCreators = new HashSet<Creator>();
            ICollection<Boardgame> validBoardgames = new HashSet<Boardgame>();

            ImportCreatorDto[] creatorsDtos = xmlHelper.Deserialize<ImportCreatorDto[]>(xmlString, "Creators");

            foreach (var creatorDto in creatorsDtos)
            {
                if (!IsValid(creatorDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Creator creator = new Creator()
                {
                    FirstName = creatorDto.FirstName,
                    LastName = creatorDto.LastName,

                };

                foreach (var boardgameDto in creatorDto.BoardgameDtos)
                {
                    if (!IsValid(boardgameDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Boardgame boardgame = new Boardgame()
                    {
                        Name = boardgameDto.Name,
                        Rating = boardgameDto.Rating,
                        YearPublished = boardgameDto.YearPublished,
                        CategoryType = (CategoryType)boardgameDto.CategoryType,
                        Mechanics = boardgameDto.Mechanics

                    };

                    creator.Boardgames.Add(boardgame);

                }

                validCreators.Add(creator);
                sb.AppendLine(string.Format(SuccessfullyImportedCreator, creator.FirstName, creator.LastName, creator.Boardgames.Count ));
            }

            context.AddRange(validCreators);
            context.SaveChanges();
                return sb.ToString().Trim();

        }

        public static string ImportSellers(BoardgamesContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ICollection<Seller> validSellers = new HashSet<Seller>();
            ImportSellersDto[] sellersDtos = JsonConvert.DeserializeObject<ImportSellersDto[]>(jsonString);
           // var validIds = new List<int>();

         //   var validBoardGameIDs = context.Boardgames.Select( b => b.Id).ToList();

            foreach (var sellerDto in sellersDtos)
            {
                if (!IsValid(sellerDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Seller seller = new Seller()
                {
                    Name = sellerDto.Name,
                    Address = sellerDto.Address,
                    Country = sellerDto.Country,
                    Website = sellerDto.Website,
                };

                foreach (var boardgameId in sellerDto.Boardgames.Distinct())
                {
                    //if (!validBoardGameIDs.Contains(boardgameId))
                    //{
                    //    sb.AppendLine(ErrorMessage);
                    //    continue;
                    //}

                    if (!IsValid(boardgameId))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Boardgame bg = context.Boardgames.Find(boardgameId);
                    if (bg == null)
                    {
                        sb.AppendLine(ErrorMessage);
                          continue;
                    }
                    //validIds.Add(boardgameId);

                    seller.BoardgamesSellers.Add(new BoardgameSeller()
                    {
                        Boardgame = bg
                    });
                    
                }
                validSellers.Add(seller);
                sb.AppendLine(string.Format(SuccessfullyImportedSeller, seller.Name, seller.BoardgamesSellers.Count));
            }

            context.Sellers.AddRange(validSellers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
