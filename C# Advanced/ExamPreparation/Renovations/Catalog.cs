using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Catalog
    {
        public Catalog(string nameCatalog, int neededRenovators, string project)
        {
            RenovatorsList = new List<Renovator>();
            this.NameCatalog = nameCatalog;
            this.NeededRenovators = neededRenovators;
            this.Project = project;
        }
        public List<Renovator> RenovatorsList { get; set; }
        public string NameCatalog { get; set; }
        public int NeededRenovators { get; set; }
        public string Project { get; set; }
        public int Count
        {
            get { return this.RenovatorsList.Count; }
        }

        public string AddRenovator(Renovator renovator)
        {
            if (string.IsNullOrWhiteSpace(renovator.Name) || string.IsNullOrWhiteSpace(renovator.Type))
            {
                return $"Invalid renovator's information.";
            }
            else if (RenovatorsList.Count == NeededRenovators)
            {
                return $"Renovators are no more needed.";
            }
            else if (renovator.Rate > 350) // should be =???
            {
                return $"Invalid renovator's rate.";
            }
            else
            {
                RenovatorsList.Add(renovator);
                return $"Successfully added {renovator.Name} to the catalog.";
            }
        }
        public bool RemoveRenovator(string name)
        {
            if (RenovatorsList.Any(r => r.Name == name))
            {
                RenovatorsList.RemoveAll(r => r.Name == name);
                return true;
            }
            else
            {
                return false;
            }
        }
        public int RemoveRenovatorBySpecialty(string type)
        {
            if (RenovatorsList.Any(r => r.Type == type))
            {
                int countOfRemoved = RenovatorsList.Count(r => r.Type == type); // is this way of getting the count a mistake? 
                RenovatorsList.RemoveAll(r => r.Type == type);
                return countOfRemoved;
            }
            else
            {
                return 0;
            }
        }
        public Renovator HireRenovator(string name)
        {
            if (RenovatorsList.Any(r => r.Name == name))
            {
                Renovator reno = RenovatorsList.FirstOrDefault(r => r.Name == name);
                reno.Hired = true;
                return reno;
            }
            else
            {
                return null;
            }
        }
        public List<Renovator> PayRenovators(int days)
        {
            var workingRenos = RenovatorsList.FindAll(r => r.Days >= days);
            return workingRenos;
        }
        public string Report()
        {
            var availableRenos = RenovatorsList.Where(d => d.Hired == true);

            return $"Renovators available for Project {Project}:{Environment.NewLine}{string.Join(Environment.NewLine, availableRenos)}";
        }

    }
}
