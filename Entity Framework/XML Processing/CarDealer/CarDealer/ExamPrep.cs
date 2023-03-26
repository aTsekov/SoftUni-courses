
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using Newtonsoft.Json;

namespace CarDealer
{
    internal class ExamPrep
    {



    }



    // JSON
    //IMPORT - DESERIALIZE
    public static string ImportParts(CarDealerContext context, string inputJson)
    {
        IMapper mapper = CreateMapper();

        ImportPartsDto[] partsDtos = JsonConvert.DeserializeObject<ImportPartsDto[]>(inputJson);

        ICollection<Part> validParts = new HashSet<Part>();

        var validIds = context.Suppliers.Select(s => s.Id).ToList();

        foreach (var partDto in partsDtos)
        {
            //If the supplierId is not in the DB - it shold be skipped. 
            if (!validIds.Contains(partDto.SupplierId))
            {
                continue;
            }

            Part part = mapper.Map<Part>(partDto);
            validParts.Add(part);

        }

        context.AddRange(validParts);
        context.SaveChanges();
    }

    //JSON
    //EXPORT - SERIALIZE

    public static string GetCarsWithTheirListOfParts(CarDealerContext context)
    {
        var carsWithParts = context.Cars.Select(c => new
        {
            car = new
            {
                Make = c.Make,
                Model = c.Model,
                TraveledDistance = c.TraveledDistance
            },
            parts = c.PartsCars.Select(p => new
            {
                Name = p.Part.Name,
                Price = p.Part.Price.ToString("F2")
            }).ToList()



        }).ToList();

        var result = JsonConvert.SerializeObject(carsWithParts, Formatting.Indented);
        return result;
    }




