using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Channels;
using Artillery.Data.Models;
using Artillery.Data.Models.Enums;
using Artillery.DataProcessor.ImportDto;
using Footballers;

namespace Artillery.DataProcessor
{
    using AutoMapper;
    using Artillery.Data;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data.";

        private const string SuccessfulImportCountry = "Successfully import {0} with {1} army personnel.";

        private const string SuccessfulImportManufacturer = "Successfully import manufacturer {0} founded in {1}.";

        private const string SuccessfulImportShell = "Successfully import shell caliber #{0} weight {1} kg.";

        private const string SuccessfulImportGun = "Successfully import gun {0} with a total weight of {1} kg. and barrel length of {2} m.";

        public static string ImportCountries(ArtilleryContext context, string xmlString)
        {
            XmlHelper xmlHelper = new XmlHelper();
            StringBuilder sb = new StringBuilder();

            ImportCountryDto[] countriesDtos = xmlHelper.Deserialize<ImportCountryDto[]>(xmlString, "Countries");

            ICollection<Country> validCountries = new HashSet<Country>();

            foreach (var country in countriesDtos)
            {

                if (!IsValid(country))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Country con = new Country()
                {
                    CountryName = country.CountryName,
                    ArmySize = country.ArmySize
                };

                validCountries.Add(con);
                sb.AppendLine(string.Format(SuccessfulImportCountry, con.CountryName, con.ArmySize));

            }

            context.AddRange(validCountries);
            context.SaveChanges();

            return sb.ToString().TrimEnd();

        }

        public static string ImportManufacturers(ArtilleryContext context, string xmlString)
        {
            XmlHelper xmlHelper = new XmlHelper();
            StringBuilder sb = new StringBuilder();

            ImportManufacturerDto[] manufacturarDtos = xmlHelper.Deserialize<ImportManufacturerDto[]>(xmlString, "Manufacturers");

            ICollection<Manufacturer> validManufacturers = new HashSet<Manufacturer>();

            foreach (var man in manufacturarDtos)
            {

                if (!IsValid(man))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                

                Manufacturer manf = new Manufacturer()
                {
                    ManufacturerName = man.ManufacturerName,
                    Founded = man.Founded,
                };
                if (validManufacturers.Any( m => m.ManufacturerName == manf.ManufacturerName))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

               

                validManufacturers.Add(manf);

                var manCountry = manf.Founded.Split(", ").ToArray();
                var last = manCountry.Skip(Math.Max(0,manCountry.Count() - 2)).ToArray();

                sb.AppendLine(string.Format(SuccessfulImportManufacturer, manf.ManufacturerName, string.Join(", ",last)));

            }

            

            context.AddRange(validManufacturers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportShells(ArtilleryContext context, string xmlString)
        {
            XmlHelper xmlHelper = new XmlHelper();
            StringBuilder sb = new StringBuilder();

            ICollection<Shell> validShells = new HashSet<Shell>();

            ImportShellDto[] shellDtos = xmlHelper.Deserialize<ImportShellDto[]>(xmlString, "Shells");

            foreach (var shell in shellDtos)
            {
                if (!IsValid(shell))
                {
                    sb.AppendLine(ErrorMessage); 
                    continue;
                }

                Shell shellToAdd = new Shell()
                {
                    ShellWeight = shell.ShellWeight,
                    Caliber = shell.Caliber,
                };

                validShells.Add(shellToAdd);
                sb.AppendLine(string.Format(SuccessfulImportShell, shellToAdd.Caliber, shellToAdd.ShellWeight));

            }

            context.Shells.AddRange(validShells);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportGuns(ArtilleryContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ImportGunDto[] gunDtos = JsonConvert.DeserializeObject<ImportGunDto[]>(jsonString);
            var validGunTypes = new string[] { "Howitzer", "Mortar", "FieldGun", "AntiAircraftGun", "MountainGun", "AntiTankGun" };
            ICollection<Gun> validGuns = new HashSet<Gun>();
            ICollection<CountryGun> validCOuntryGuns = new HashSet<CountryGun>();

            foreach (var gun in gunDtos)
            {
                if (!IsValid(gun)|| !validGunTypes.Contains(gun.GunType))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Gun gunToAdd = new Gun()
                {
                    ManufacturerId = gun.ManufacturerId,
                    GunWeight = gun.GunWeight,
                    BarrelLength = gun.BarrelLength,
                    NumberBuild = gun.NumberBuild,
                    Range = gun.Range,
                    GunType = (GunType)Enum.Parse(typeof(GunType),gun.GunType),
                    ShellId = gun.ShellId,
                };

                foreach (var cgIds in gun.Countries)
                {
                    CountryGun cg = new CountryGun()
                    {
                        Gun = gunToAdd,
                        CountryId = cgIds.Id,
                    };
                    validCOuntryGuns.Add(cg);
                }
                validGuns.Add(gunToAdd);
                sb.AppendLine(string.Format(SuccessfulImportGun, gunToAdd.GunType, gunToAdd.GunWeight, gunToAdd.BarrelLength));
            }

            context.Guns.AddRange(validGuns);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }
        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}