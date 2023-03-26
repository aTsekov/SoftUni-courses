using System.Globalization;
using System.Text;
using AutoMapper;
using Footballers.Data.Models;
using Footballers.DataProcessor.ImportDto;
using Newtonsoft.Json;

namespace Footballers.DataProcessor
{
    using Footballers.Data;
    using Footballers.Data.Models.Enums;
    using System.ComponentModel.DataAnnotations;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCoach
            = "Successfully imported coach - {0} with {1} footballers.";

        private const string SuccessfullyImportedTeam
            = "Successfully imported team - {0} with {1} footballers.";

        public static string ImportCoaches(FootballersContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            XmlHelper xmlHelper = new XmlHelper();

            ImportCoachDto[] coachDtos = xmlHelper.Deserialize<ImportCoachDto[]>(xmlString, "Coaches");

            ICollection<Coach> validCoaches = new HashSet<Coach>();
            

            foreach (var coachDto in coachDtos)
            {
                ICollection<Footballer> validFootballers = new HashSet<Footballer>();
                if (string.IsNullOrEmpty(coachDto.Name) || string.IsNullOrEmpty(coachDto.Nationality))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Coach coach = new Coach()
                {
                    Name = coachDto.Name,
                    Nationality = coachDto.Nationality,
                };
                if (!IsValid(coach))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                

                foreach (var footbaler in coachDto.Footballers)
                {
                    if (string.IsNullOrEmpty(footbaler.ContractStartDate)
                        || string.IsNullOrEmpty(footbaler.ContractEndDate))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    DateTime start = DateTime.ParseExact(footbaler.ContractStartDate,"dd/MM/yyyy",CultureInfo.InvariantCulture);
                    DateTime end = DateTime.ParseExact(footbaler.ContractEndDate, "dd/MM/yyyy", CultureInfo.InvariantCulture); ;

                    if (string.IsNullOrEmpty(footbaler.Name) ||start > end)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Footballer footballer = new Footballer()
                    {
                        Name = footbaler.Name,
                        ContractStartDate = start,
                        ContractEndDate = end,
                        BestSkillType = (BestSkillType)footbaler.BestSkillType,
                        PositionType = (PositionType)footbaler.PositionType,

                    };
                    if (!IsValid(footballer))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    validFootballers.Add(footballer);
                    
                }
                coach.Footballers = validFootballers;
               // sb.AppendLine($"Successfully imported coach - {coach.Name} with {coach.Footballers.Count} footballers.");
                sb.AppendLine(string.Format(SuccessfullyImportedCoach, coach.Name,coach.Footballers.Count));


                validCoaches.Add(coach);
            }

            context.AddRange(validCoaches);
            context.SaveChanges();

            return sb.ToString();
        }

        public static string ImportTeams(FootballersContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            ImportTeamDto[] teamDtos = JsonConvert.DeserializeObject<ImportTeamDto[]>(jsonString);

            ICollection<Team> validTeams = new HashSet<Team>();

            //var validFootballersInDb = context.Footballers.Select(( f => f.Id)).ToList();

            foreach (var teamDto in teamDtos)
            {
                if (!IsValid(teamDto) || string.IsNullOrEmpty(teamDto.Name) || string.IsNullOrEmpty(teamDto.Nationality)
                    ||string.IsNullOrEmpty(teamDto.Trophies) || int.Parse(teamDto.Trophies) == 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }


                Team team = new Team()
                {
                    Name = teamDto.Name,
                    Nationality = teamDto.Nationality,
                    Trophies = int.Parse(teamDto.Trophies),
                };

                foreach (int footballerId in teamDto.Footballers.Distinct())
                {
                    //if (!validFootballersInDb.Contains(footballerId))
                    //{
                    //    sb.AppendLine(ErrorMessage);
                    //    continue;
                    //}

                    Footballer foot = context.Footballers.Find(footballerId);
                    if (foot == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    team.TeamsFootballers.Add(new TeamFootballer()
                    {
                        Footballer = foot
                    });
                    

                }


                validTeams.Add(team);
                sb.AppendLine(string.Format(SuccessfullyImportedTeam,team.Name,team.TeamsFootballers.Count));

            }

            

            context.Teams.AddRange(validTeams);
            context.SaveChanges();

            return sb.ToString();

        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
