﻿using AutoMapper;
using CarDealer.DTOs.Export;
using CarDealer.DTOs.Import;
using CarDealer.Models;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            this.CreateMap<ImportSupplierDTO, Supplier>();
            this.CreateMap<ImportPartsDto,Part>();
            this.CreateMap<ImportCarDto,Car>();
            this.CreateMap<ImportSalesDto, Sale>();
            this.CreateMap<Car, ExportCarWithDistanceDto>();

        }
    }
}
