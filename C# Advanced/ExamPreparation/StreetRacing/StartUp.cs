using System;

namespace StreetRacing
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            //Sample Code Usage:

            //Initialize Race
            Race race = new Race("RockPort Race", "Sprint", 1, 4, 150); //capacity 4

            //Initialize Car
            Car car = new Car("BMW", "320ci", "NFS2005", 150, 1450); //Yes
            Car car1 = new Car("VW", "320ci", "NFS2005", 150, 1450); //No
            Car car2 = new Car("Audi", "320ci", "NFS2006", 150, 1450);// yes
            Car car3 = new Car("Renault", "320ci", "NFS2007", 150, 1450);//Yes
            Car car4 = new Car("Renault", "320ci", "NFS2008", 150, 1450);//Yes
            Car car5 = new Car("Renault", "320ci", "NFS2009", 150, 1450);//no
            Car car6 = new Car("Renault", "320ci", "NFS2010", 150, 1450);//No

            //Print car
            Console.WriteLine(car.ToString());

            //Make: BMW
            //Model: 320ci
            //License Plate: NFS2005
            //Horse Power: 150
            //Weight: 1450

            //Add car
            race.Add(car);
            race.Add(car1);
            race.Add(car2);
            race.Add(car3);
            race.Add(car4);
            race.Add(car5);
            race.Add(car6);

            //Remove car
            Console.WriteLine(race.Remove("NFS2005")); // True

            Car carOne = new Car("BMW", "320cd", "NFS2007", 150, 1350);
            Car carTwo = new Car("Audi", "A3", "NFS2004", 131, 1300);

            //Add cars
            race.Add(carOne);
            race.Add(carTwo);

            //GetMostPowerfulCar
            Console.WriteLine(race.GetMostPowerfulCar());

            //Make: BMW
            //Model: 320cd
            //License Plate: NFS2007
            //Horse Power: 150
            //Weight: 1350


            //Print Race report
            Console.WriteLine(race.Report());

            //Race: RockPort Race - Type: Sprint (Laps: 1)
            //Make: BMW
            //Model: 320cd
            //License Plate: NFS2007
            //Horse Power: 150
            //Weight: 1350
            //Make: Audi
            //Model: A3
            //License Plate: NFS2004
            //Horse Power: 131
            //Weight: 1300
        }
    }
}
