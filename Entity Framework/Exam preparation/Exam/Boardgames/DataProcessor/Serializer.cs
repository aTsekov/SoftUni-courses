using Boardgames.DataProcessor.ExportDto;
using Newtonsoft.Json;

namespace Boardgames.DataProcessor
{
    using Boardgames.Data;
    using Footballers;

    public class Serializer
    {
        public static string ExportCreatorsWithTheirBoardgames(BoardgamesContext context)
        {
            XmlHelper xmlHelper = new XmlHelper();
            var creators = context.Creators.Where(c => c.Boardgames.Count >= 1).ToArray()
                .Select(c => new ExportCreatorDto()
                {
                    BoardgamesCount = c.Boardgames.Count,
                    CreatorName = $"{c.FirstName} {c.LastName}",
                    BoardgamesDtos = c.Boardgames.Select(c => new ExportBoardgamesDto()
                    {
                        BoardgameName = c.Name,
                        BoardgameYearPublished = c.YearPublished.ToString(),

                    }).OrderBy(g => g.BoardgameName).ToArray()
                }).OrderByDescending(c => c.BoardgamesCount).ThenBy(c => c.CreatorName).ToArray();

            return xmlHelper.Serialize<ExportCreatorDto[]>(creators, "Creators");

        }

        public static string ExportSellersWithMostBoardgames(BoardgamesContext context, int year, double rating)
        {
            var sellers = context.Sellers
                .Where(s => s.BoardgamesSellers.Any(se =>
                    se.Boardgame.YearPublished > year && se.Boardgame.Rating <= rating))
                .Select(s => new
                {
                    Name = s.Name,
                    Website = s.Website,
                    Boardgames = s.BoardgamesSellers.Where( b => b.Boardgame.YearPublished >= year && b.Boardgame.Rating <= rating).Select( b => new
                    {
                        Name = b.Boardgame.Name,
                        Rating = b.Boardgame.Rating,
                        Mechanics = b.Boardgame.Mechanics,
                        Category = b.Boardgame.CategoryType.ToString(),

                    }).OrderByDescending(b => b.Rating).ThenBy(b => b.Name).ToArray()

                }).OrderByDescending(s => s.Boardgames.Length).ThenBy(s => s.Name).Take(5).ToArray();


            


            return JsonConvert.SerializeObject(sellers, Formatting.Indented);

        }
    }
}