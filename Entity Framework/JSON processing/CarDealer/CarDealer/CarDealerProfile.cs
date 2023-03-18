using AutoMapper;
using CarDealer.DTOs.Import;
using CarDealer.Models;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            //This is the link between the DTO and the entity when we import data in the DB.
            this.CreateMap<ImportSupplierDto, Supplier>();

            this.CreateMap<ImportPartsDto,Part>();

            this.CreateMap<ImportCarDto,Car>();

            this.CreateMap<ImportSalesDto, Sale>();



        }
    }
}
