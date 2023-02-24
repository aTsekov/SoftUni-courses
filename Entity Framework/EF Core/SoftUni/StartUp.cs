using SoftUni.Data;
using System;
using System.Text;
using System.Linq;
using System.Threading.Channels;
using SoftUni.Models;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext context = new SoftUniContext();

            //P03
            //Console.WriteLine( GetEmployeesFullInformation(context));

            //P04
            //Console.WriteLine(GetEmployeesWithSalaryOver50000(context));

            //P05
            //Console.WriteLine(GetEmployeesFromResearchAndDevelopment(context));

            //P06
            Console.WriteLine(AddNewAddressToEmployee(context));
            
        }


        // P03
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var sb = new StringBuilder();
            var employees = context.Employees.Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.MiddleName,
                    e.JobTitle,
                    e.Salary,
                    e.EmployeeId
                }).OrderBy(e => e.EmployeeId).
                ToList();

            foreach (var empl in employees)
            {
                sb.AppendLine($"{empl.FirstName} {empl.LastName} {empl.MiddleName} {empl.JobTitle} {empl.Salary:F2}");
            }
            return sb.ToString();

        }

        //P04
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employees = context.Employees.Where(e => e.Salary > 50000)
                .OrderBy(e => e.FirstName).Select(e => new
            {
                e.FirstName,
                e.Salary
            }).ToArray();
                

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} - {e.Salary:F2}");
            }
            return sb.ToString();

        }
        //P05

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employees = context.Employees
                .Where(e => e.Department.Name == "Research and Development")
                .OrderBy(e => e.Salary).ThenByDescending(e => e.FirstName)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.Department.Name,
                    e.Salary
                })
                .ToArray();

            foreach (var e in employees)
            {
               
                sb.AppendLine($"{e.FirstName} {e.LastName} " + $"from {e.Name} - ${e.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        //P06
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {


            var sb = new StringBuilder();

            Address adr = new Address()
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };


            var nakov = context.Employees.FirstOrDefault(e => e.LastName == "Nakov");
            nakov.Address = adr;

            context.SaveChanges();

            var empls = context.Employees.OrderByDescending(e => e.AddressId).Take(10)
                .Select(e => e.Address.AddressText).ToArray();

            foreach (var e in empls)
            {
                sb.AppendLine(e);
            }

            return sb.ToString();
        }
    }
}
