namespace Gym.Core
{
    using Gym.Core.Contracts;
    using Gym.Models.Athletes;
    using Gym.Models.Athletes.Contracts;
    using Gym.Models.Equipment.Contracts;
    using Gym.Models.Gyms;
    using Gym.Models.Gyms.Contracts;
    using Gym.Repositories;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Controller : IController
    {
        private EquipmentRepository equipmentRepository; //Check if the name should be without "s"
        private ICollection<IGym> gyms;
        public Controller()
        {
            this.equipmentRepository = new EquipmentRepository();
            this.gyms = new List<IGym>();
        }
        public string AddGym(string gymType, string gymName)
        {
           IGym gym;
            if (gymType == "BoxingGym")
            {
                gym = new BoxingGym(gymName);
            }
            else if ( gymType == "WeightliftingGym")
            {
                gym = new WeightliftingGym(gymName);
            }
            else
            {
                throw new InvalidOperationException("Invalid gym type.");
            }
            gyms.Add(gym);
            return $"Successfully added {gymType}.";
        }
        public string AddEquipment(string equipmentType)
        {
            IEquipment eqipment;

            if (equipmentType == "BoxingGloves")
            {
                eqipment = new BoxingGloves();
            }
            else if (equipmentType == "Kettlebell")
            {
                eqipment = new Kettlebell();
            }
            else
            {
                throw new InvalidOperationException ("Invalid equipment type.");
            }
            this.equipmentRepository.Add(eqipment);
            return $"Successfully added {equipmentType}.";
        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            if (!equipmentRepository.Models.Any(e => e.GetType().Name == equipmentType))
            {
                throw new InvalidOperationException($"There isn’t equipment of type {equipmentType}.");
            }
            var gymToReceiveEquipment = gyms.FirstOrDefault( g => g.Name == gymName );
            var eqyTypeToBeGiven = equipmentRepository.Models.FirstOrDefault( e => e.GetType().Name == equipmentType);
            gymToReceiveEquipment.AddEquipment(eqyTypeToBeGiven);
            equipmentRepository.Remove(eqyTypeToBeGiven);
            return $"Successfully added {equipmentType} to {gymName}.";


        }
        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            if (athleteType != "Boxer"  || athleteType != "Weightlifter")
            {
                throw new InvalidOperationException($"Invalid athlete type.");
            }
            string gymType = gyms.FirstOrDefault( g => g.Name == gymName).GetType().Name;
            if (gymType == "BoxingGym" && athleteType == "Weightlifter")
            {
                return "The gym is not appropriate.";
            }
            else if (gymType == "WeightliftingGym" && athleteType == "Boxer")
            {
                return "The gym is not appropriate.";
            }
            else
            {
                IAthlete athlete; 
                if (athleteType == "Boxer")
                {
                     athlete = new Boxer(athleteName, motivation, numberOfMedals);
                }
                else
                {
                     athlete = new Weightlifter(athleteName, motivation, numberOfMedals);
                }
                gyms.FirstOrDefault( g => g.Name == gymName).AddAthlete(athlete);
                return $"Successfully added {athleteType} to {gymName}.";
            }
        }

        public string TrainAthletes(string gymName)
        {
            int counter = 0;
            foreach (var at in gyms.FirstOrDefault(g => g.Name == gymName).Athletes)
            {
                at.Exercise();
                counter ++;
            }
            return $"Exercise athletes: {counter}.";
        }
        public string EquipmentWeight(string gymName)
        {
            double weight = 0;
            var gym = gyms.FirstOrDefault(g => g.Name == gymName);
           
            foreach (var w in gym.Equipment)
            {
                weight+= w.Weight;
            }
            return $"The total weight of the equipment in the gym {gymName} is {weight:f2} grams.";
        }

        

        public string Report()
        {
            var sb = new StringBuilder();
            foreach (var gym in gyms)
            {
                sb.AppendLine(gym.GymInfo());
                sb.AppendLine();
            }
            return sb.ToString().TrimEnd();
        }

        
    }
}
