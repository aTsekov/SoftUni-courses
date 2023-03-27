using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using Footballers.DataProcessor.ExportDto;
using Newtonsoft.Json;

namespace Footballers.DataProcessor
{
    using AutoMapper.QueryableExtensions;
    using AutoMapper;
    using Data;
    using System.Text;
    using System.Xml.Serialization;

    public class Serializer
    {
        [SuppressMessage("ReSharper.DPA", "DPA0007: Large number of DB records", MessageId = "count: 107")]
        public static string ExportCoachesWithTheirFootballers(FootballersContext context)
        {
            //var config = new MapperConfiguration(cfg =>
            //{
            //    cfg.AddProfile<FootballersProfile>();
            //});
            //var mapper = new Mapper(config);

            //StringBuilder sb = new StringBuilder();

            XmlHelper xmlHelper = new XmlHelper();

            var dtos = context.Coaches.Where(c => c.Footballers.Any())
                .Select(c => new ExportCoachDto()
                {
                    Name = c.Name,
                    FootballersCount = c.Footballers.Count,
                        Footballers = c.Footballers.Select(f => new ExportCoachFootballerDto()
                    {
                        Name = f.Name,
                        Position = f.PositionType.ToString()

                    }).OrderBy( f => f.Name).ToArray()
                }).OrderByDescending( c => c.FootballersCount).ThenBy( c => c.Name).ToArray();

            //ExportCoachDto[] coachDtos = context
            //    .Coaches
            //    .Where(c => c.Footballers.Any())
            //    .ProjectTo<ExportCoachDto>(config)
            //    .OrderBy(f => f.Footballers.Select( f=> f.Name))
            //    .OrderByDescending(c => c.FootballersCount)
            //    .ThenBy(c => c.Name)
            //    .ToArray();
            
            
            return xmlHelper.Serialize<ExportCoachDto[]>(dtos, "Coaches");
        }

        public static string ExportTeamsWithMostFootballers(FootballersContext context, DateTime date)
        {
            var teams = context.Teams
                .Where(t => t.TeamsFootballers.Any(f => f.Footballer.ContractStartDate >= date))
                .Select(t => new
                {
                    Name = t.Name,
                    Footballers = t.TeamsFootballers.Where(f => f.Footballer.ContractStartDate >= date)
                        .OrderByDescending(f => f.Footballer.ContractEndDate)
                        .ThenBy(f => f.Footballer.Name)
                        .Select(f => new ExportFootballersDto()
                        {
                            FootballerName = f.Footballer.Name,
                            ContractStartDate = f.Footballer.ContractStartDate.ToString("d",CultureInfo.InvariantCulture),
                            ContractEndDate = f.Footballer.ContractEndDate.ToString("d", CultureInfo.InvariantCulture),
                            BestSkillType = f.Footballer.BestSkillType.ToString(),
                            PositionType = f.Footballer.PositionType.ToString()


                        }).ToList()

                }).OrderByDescending(f => f.Footballers.Count)
                .ThenBy(t => t.Name).Take(5)
                .ToArray();

            return JsonConvert.SerializeObject(teams, Formatting.Indented);
        }
    }
}
