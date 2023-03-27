using Footballers.Data.Models;
using Footballers.DataProcessor.ImportDto;

namespace Footballers
{
    using AutoMapper;
    using Footballers.DataProcessor.ExportDto;

    // Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE OR RENAME THIS CLASS
    public class FootballersProfile : Profile
    {
        public FootballersProfile()
        {
            //this.CreateMap<Footballer, ExportCoachFootballerDto>();

            //this.CreateMap<Coach, ExportCoachDto>();

        }
    }
}
