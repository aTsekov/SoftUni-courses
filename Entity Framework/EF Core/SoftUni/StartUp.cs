using SoftUni.Data;
using System;
using System.Text;
using System.Linq;
using System.Threading.Channels;

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
    }
}
