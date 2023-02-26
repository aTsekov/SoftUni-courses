using SoftUni.Data;
using System;
using System.Text;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
            //Console.WriteLine(GetEmployee147(context));

            //P10
            //Console.WriteLine(GetDepartmentsWithMoreThan5Employees(context));

            //P11
            //Console.WriteLine(GetLatestProjects(context));
            
            //P12
            //Console.WriteLine(IncreaseSalaries(context));

            //P13 
            //Console.WriteLine(GetEmployeesByFirstNameStartingWithSa(context));

            //P14

            //Console.WriteLine(DeleteProjectById(context));

            //P15
            Console.WriteLine(RemoveTown(context));


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

        // P10
        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var departmentsWithMoreThan5Empl = context.Departments.Where(d => d.Employees.Count > 5)
                .Select( e => new
                {
                    DepartmentName = e.Name,
                    ManagerFirstName = e.Manager.FirstName,
                    ManagerLastName = e.Manager.LastName,
                    EmployeesCount = e.Employees.Count,
                    Employees = e.Employees.Select(ep => new
                    {
                        EmloyeeFirstName = ep.FirstName,
                        EmloyeeLastName = ep.LastName,
                        JobTitle = ep.JobTitle
                    }).OrderBy(ep => ep.EmloyeeFirstName).ThenBy(ep => ep.EmloyeeLastName).ToArray()
                }).OrderBy( e=> e.EmployeesCount).ThenBy(d => d.DepartmentName).ToArray();

            foreach (var d in departmentsWithMoreThan5Empl)
            {
                sb.AppendLine($"{d.DepartmentName} - {d.ManagerFirstName}  {d.ManagerLastName}");

                foreach (var e in d.Employees)
                {
                    sb.AppendLine($"{e.EmloyeeFirstName} {e.EmloyeeLastName} - {e.JobTitle}");
                }
            }


            return sb.ToString();
        }

        //P11

        public static string GetLatestProjects(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var projects = context.Projects
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .OrderBy(p => p.Name)
                .Select(p => new
                {
                    ProjectName = p.Name,
                    Description = p.Description,
                    StartDate = p.StartDate.ToString("M/d/yyyy h:mm:ss tt")
                })
                .ToArray();

            foreach (var project in projects)
            {
                sb.AppendLine($"{project.ProjectName}");
                sb.AppendLine($"{project.Description}");
                sb.AppendLine($"{project.StartDate}");
            }

            return sb.ToString();
        }

        //P12

        public static string IncreaseSalaries(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employeesToIncreaseSalary = context.Employees.Where(e =>
                e.Department.Name == "Engineering"
                || e.Department.Name == "Tool Design"
                || e.Department.Name == "Marketing"
                || e.Department.Name == "Information Services")
                .OrderBy(e => e.FirstName).ThenBy(e => e.LastName).ToList();

            foreach (var e in employeesToIncreaseSalary)
            {
                e.Salary *= 1.12m;
            }

            context.SaveChanges();

            foreach (var e in employeesToIncreaseSalary)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} (${e.Salary:F2})");
            }

            return sb.ToString().TrimEnd();

          
        }

        //P13
        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var emplsSA = context.Employees.Select(e => new
            {
                FirstName = e.FirstName,
                LastName = e.LastName,
                JobTitle = e.JobTitle,
                Salary = e.Salary
            }).Where(e => e.FirstName.StartsWith("Sa"))
                .OrderBy(e => e.FirstName).ThenBy( e=> e.LastName)
                .ToList();

            foreach (var e in emplsSA)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:F2})");
            }

            return sb.ToString().TrimEnd();
        }

        //P14

        public static string DeleteProjectById(SoftUniContext context)
        {
            var sb = new StringBuilder();

            //Find the project to delete
            var projectToDelete = context.Projects.Find(2);

            //Find the references in EmployeesProjects
            var referencedProjects =
                context.EmployeesProjects.Where(p => p.ProjectId == projectToDelete.ProjectId).ToArray();
            //Delete the reference and then the project itself. 
            context.EmployeesProjects.RemoveRange(referencedProjects);
            context.Projects.Remove(projectToDelete!);
            context.SaveChanges();

            var proj10 = context.Projects.Select(e => e.Name).Take(10).ToArray();

            foreach (var p in proj10)
            {
                sb.AppendLine(p);
            }


            return sb.ToString().TrimEnd();
        }

        //P15

        public static string RemoveTown(SoftUniContext context)
        {
            

            var townToDelete = context.Towns.FirstOrDefault(t => t.Name == "Seattle");

            var referencedAddresses = context.Addresses.Where( a => a.TownId == townToDelete.TownId).ToArray();

            int numberOfAddresses = referencedAddresses.Length;

            foreach (var e in context.Employees)
            {
                if (referencedAddresses.Any(a => a.AddressId == e.AddressId))
                {
                    e.AddressId = null;
                }
            }
            context.Addresses.RemoveRange(referencedAddresses);
            context.Towns.Remove(townToDelete!);
            context.SaveChanges();



            return $"{numberOfAddresses} addresses in Seattle were deleted";
        }
    }
}
