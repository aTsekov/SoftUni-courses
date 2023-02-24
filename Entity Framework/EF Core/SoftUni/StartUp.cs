using SoftUni.Data;
using System;
using System.Text;
using System.Linq;
using System.Threading.Channels;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
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
            //Console.WriteLine(AddNewAddressToEmployee(context));
            
            //P07
            //Console.WriteLine(GetEmployeesInPeriod(context));
            
            //P08
            //Console.WriteLine(GetAddressesByTown(context));

            //P09
            Console.WriteLine(GetEmployee147(context));


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

        //P07
        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var emplsWIthProj = context.Employees.Take(10)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    ManagerFirstName = e.Manager.FirstName,
                    ManagerLastName = e.Manager.LastName,
                    Projects = e.EmployeesProjects
                        .Where(ep => ep.Project.StartDate.Year >= 2001 && ep.Project.StartDate.Year <= 2003)
                        .Select(ep => new
                        {
                            ProjectName = ep.Project.Name,
                            StartDate = ep.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt"),
                            EndDate = ep.Project.EndDate.HasValue
                                ? ep.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt")
                                : "not finished"
                        }).ToArray()
                }).ToArray();

            //SELECT the first 10 employees with their names and their managers'names.
            //WHERE the project start date is between 2001 and 2003.
            //Make the  format of the date be M/d/yyyy h:mm:ss tt and if the project has not finished put "not finished"

            foreach (var e in emplsWIthProj)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - Manager: {e.ManagerFirstName} {e.ManagerLastName}");
                foreach (var p in e.Projects)
                {
                    sb.AppendLine($"--{p.ProjectName} - {p.StartDate} - {p.EndDate}");
                }
            }

            return sb.ToString();
        }

        //P08
        public static string GetAddressesByTown(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var addresses = context.Addresses
                .Select(e => new
                {
                    AddressText = e.AddressText,
                    TownName = e.Town.Name,
                    EmployeeCount = e.Employees.Count
                }).OrderByDescending( e => e.EmployeeCount)
                .ThenBy(a => a.TownName).ThenBy(a => a.AddressText).Take(10).ToArray();

            foreach (var a in addresses)
            {
                sb.AppendLine($"{a.AddressText}, {a.TownName} - {a.EmployeeCount} employees");
            }


            return sb.ToString();
        }

        //P09

        public static string GetEmployee147(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employee = context.Employees.Where(e => e.EmployeeId == 147)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    Projects = e.EmployeesProjects
                        .Select(ep => new
                        {
                            ProjectName = ep.Project.Name
                        }).OrderBy( p=> p.ProjectName).ToList()
                }).ToArray();

            
            

            foreach (var p in employee)
            {
                sb.AppendLine($"{p.FirstName} {p.LastName} - {p.JobTitle}");
                foreach (var pr in p.Projects)
                {
                    sb.AppendLine(pr.ProjectName);
                }
            }

            return sb.ToString();
        }
    }
}
