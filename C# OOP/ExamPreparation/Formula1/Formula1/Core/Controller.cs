namespace Formula1.Core
{
    using Formula1.Core.Contracts;
    using Formula1.Models;
    using Formula1.Models.Contracts;
    using Formula1.Repositories;
    using Formula1.Utilities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Controller : IController
    {
        private PilotRepository pilotRepository;
        private RaceRepository raceRepository;
        private FormulaOneCarRepository carRepository;
        public Controller()
        {
            pilotRepository = new PilotRepository();
            raceRepository = new RaceRepository();
            carRepository = new FormulaOneCarRepository();
        }
        public string CreatePilot(string fullName)
        {
            var pilot = new Pilot(fullName);
            if (pilotRepository.Models.Any( p => p.FullName == fullName))
            {
                throw new InvalidOperationException($"Pilot {fullName} is already created.");
            }
            
            pilotRepository.Add(pilot);
            return $"Pilot {fullName} is created.";
        }
        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            IFormulaOneCar car = null; 
            if (type == "Williams")
            {
                car = new Williams(model, horsepower, engineDisplacement);
                
            }
            else if (type == "Ferrari")
            {
                car = new Ferrari (model, horsepower, engineDisplacement);
                
            }
            else
            {
                throw new InvalidOperationException($"Formula one car type { type } is not valid.");
            }
            if (carRepository.Models.Any(c => c.Model == car.Model))
            {
                throw new InvalidOperationException($"Formula one car { model } is already created.");
            }
            
            carRepository.Add(car);
            return $"Car { type }, model { model } is created.";
        }

        public string CreateRace(string raceName, int numberOfLaps)
        {
            Race race = new Race(raceName, numberOfLaps);
            if (raceRepository.Models.Any( r => r.RaceName == raceName))
            {
                throw new InvalidOperationException($"Race { raceName } is already created.");
            }
            raceRepository.Add(race);
            return $"Race { raceName } is created.";

        }
        public string AddCarToPilot(string pilotName, string carModel)
        {
            var car = carRepository.Models.FirstOrDefault(c => c.Model == carModel);
            var pilot = pilotRepository.Models.FirstOrDefault ( p => p.FullName == pilotName);
            if ((!pilotRepository.Models.Any( p => p.FullName == pilotName)) || pilot.Car != null)
            {
                throw new InvalidOperationException($"Pilot { pilotName } does not exist or has a car."); // Possibly a mistake as I am not sure if the value is null when the pilot does not have a car. 
            }
            if (!carRepository.Models.Any(c => c.Model == carModel))
            {
                throw new NullReferenceException($"Car { carModel } does not exist.");
            }
            pilot.AddCar(car);
            carRepository.Remove(car);
            return $"Pilot { pilotName } will drive a {car.GetType().Name} { carModel } car.";
        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            var race = raceRepository.Models.FirstOrDefault( r => r.RaceName == raceName);
            var pilot = pilotRepository.Models.FirstOrDefault(p => p.FullName == pilotFullName);
            if (!raceRepository.Models.Any( r => r.RaceName == raceName))
            {
                throw new NullReferenceException($"Race { raceName } does not exist.");
            }
            if ((!pilotRepository.Models.Any(p => p.FullName == pilotFullName)) || pilot.CanRace == false || race.Pilots.Any( p => p.FullName == pilotFullName))
            { //If the pilot does not exist, or the pilot can not race, or the pilot is already in the race
                throw new InvalidOperationException($"Pilot { pilotFullName } does not exist or has a car."); // Possibly a mistake as I am not sure if the value is null when the pilot does not have a car. 
            }
            race.AddPilot(pilot);
            return $"Pilot { pilotFullName } is added to the { raceName } race.";

        }
        public string StartRace(string raceName)
        {
            
        }


        public string PilotReport()
        {
            throw new NotImplementedException();
        }

        public string RaceReport()
        {
            throw new NotImplementedException();
        }

        
    }
}
