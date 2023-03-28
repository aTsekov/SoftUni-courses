
using Artillery.Data.Models.Enums;
using Artillery.DataProcessor.ExportDto;
using Footballers;
using Newtonsoft.Json;

namespace Artillery.DataProcessor
{
    using Artillery.Data;
    using Artillery.Data.Models;

    public class Serializer
    {
        public static string ExportShells(ArtilleryContext context, double shellWeight)
        {
            var shells = context.Shells.Where(s => s.ShellWeight > shellWeight)
                .Select(s => new
                {
                    ShellWeight = s.ShellWeight,
                    Caliber = s.Caliber,
                    Guns = s.Guns.Where(g => ((int)g.GunType) == 3)
                        .Select(g => new
                        {
                            GunType = g.GunType.ToString(),
                            GunWeight = g.GunWeight,
                            BarrelLength = g.BarrelLength,
                            Range = g.Range > 3000 ? "Long-range" : "Regular range",

                        }).OrderByDescending(w => w.GunWeight).ToArray()
                }).OrderBy(s => s.ShellWeight).ToArray();

            return JsonConvert.SerializeObject(shells, Formatting.Indented);

         
        }

        public static string ExportGuns(ArtilleryContext context, string manufacturer)
        {
            XmlHelper xmlHelper = new XmlHelper();
            //var result = context.Guns.Where(x => x.Manufacturer.ManufacturerName == manufacturer)
            //    .Select(x => new ExportCountriesDto
            //    {
            //        Manufacturer = x.Manufacturer.ManufacturerName,
            //        GunType = x.GunType.ToString(),
            //        BarrelLength = x.BarrelLength,
            //        GunWeight = x.GunWeight,
            //        Range = x.Range,
            //        Countries = x.CountriesGuns.Where(x => x.Country.ArmySize > 4500000)
            //            .Select(a => new CountriesExportDto
            //            {
            //                CountryName = a.Country.CountryName,
            //                ArmySize = a.Country.ArmySize
            //            })
            //            .OrderBy(x => x.ArmySize)
            //            .ToArray()
            //    })
            //    .OrderBy(x => x.BarrelLength)
            //    .ToArray();

            var result = context.Guns.Where( g => g.Manufacturer.ManufacturerName == manufacturer)
                .Select( g => new ExportCountriesDto()
                {
                    Manufacturer = g.Manufacturer.ManufacturerName,
                    GunType = g.GunType.ToString(),
                    BarrelLength = g.BarrelLength,
                    GunWeight = g.GunWeight,
                    Range = g.Range,
                    Countries = g.CountriesGuns.Where(c => c.Country.ArmySize > 4500000)
                        .Select( c => new CountriesExportDto
                    {
                            CountryName = c.Country.CountryName,
                            ArmySize = c.Country.ArmySize
                    }).OrderBy(x => x.ArmySize).ToArray()

                }).OrderBy(x => x.BarrelLength)
                .ToArray();

            return xmlHelper.Serialize<ExportCountriesDto[]>( result, "Guns");
        }
    }
}
