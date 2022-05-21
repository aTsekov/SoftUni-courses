namespace Zoo
{
    public class Animal
    {
        public Animal(string species, string diet, double weight, double lenght)
        {
            Species = species;
            Diet = diet;
            Weight = weight;
            Lenght = lenght;
        }
        private string species;
        private string diet;
        private double weight;
        private double lenght;

        public string Species
        {
            get { return species; }
            set { species = value; }
        }
        public string Diet
        {
            get { return diet; }
            set { diet = value; }
        }
        public double Weight
        {
            get { return weight; }
            set { weight = value; }
        }
        public double Lenght
        {
            get { return lenght; }
            set { lenght = value; }
        }

        public void ToString(string specie, string diet, double weight)
        {
            System.Console.WriteLine($"The {specie} is a {diet} and weighs {weight} kg.");
        }

        
    }
}
