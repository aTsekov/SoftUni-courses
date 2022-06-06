namespace FishingNet
{
    public class Fish
    {

        private string _FishType;
        private double _Lenght;
        private double _Weight;
        public Fish(string fishType, double lenght, double weight)
        {
            _FishType = fishType;
            _Lenght = lenght;
            _Weight = weight;
        }
        public string FishType
        {
            get { return _FishType; }
            set { _FishType = value; }
        }
        public double Lenght
        {
            get { return _Lenght; }
            set { _Lenght = value; }
        }
        public double Weight
        {
            get { return _Weight; }
            set { _Weight = value; }
        }
        public override string ToString()
        {
            return ($"There is a {FishType}, {Lenght} cm. long, and {Weight} gr. in weight.");
        }

    }
}
