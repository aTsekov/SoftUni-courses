using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        private List<Car> cars;
        private int capacity;
        public List<Car> Cars { get; set; }
        public int Capacity { get; set; }
        public int Count 
        { 
            get { return Cars.Count; }
            
            
        }
        public Parking(int capacity)
        {
            Capacity = capacity;
            Cars = new List<Car>();
        }

        public string AddCar(Car Car)
        {
            string plate = Car.RegistrationNumber;
            foreach (Car car in Cars)
            {
                if (car.RegistrationNumber == plate)
                {
                    return "Car with that registration number, already exists!";
                }
            }

            if (Capacity <= Cars.Count)
            {
                return "Parking is full!";
            }
            else
            {
                Cars.Add(Car);
                return $"Successfully added new car {Car.Make} {Car.RegistrationNumber}";
            }
        }
        public string RemoveCar(string RegistrationNumber)
        {
            if (!(Cars.Any(c => c.RegistrationNumber == RegistrationNumber)))
            {
                return "Car with that registration number, doesn't exist!";
            }
            else
            {
                Cars.RemoveAll(c => c.RegistrationNumber == RegistrationNumber);
                return $"Successfully removed {RegistrationNumber}";
            }
        }
        public string GetCar(string RegistrationNumber)
        {
            var car = Cars.FirstOrDefault(c=>c.RegistrationNumber == RegistrationNumber);
            return car.ToString();
        }
        public void RemoveSetOfRegistrationNumber(List<string> RegistrationNumbers)
        {
            foreach (var regNum in RegistrationNumbers)
            {
                RemoveCar(regNum);
            }
        }


    }
}
