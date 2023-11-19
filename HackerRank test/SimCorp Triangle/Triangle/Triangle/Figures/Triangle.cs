using System.Text;
using TriangleTask.Interfaces;

namespace TriangleTask.Figures
{
    public class Triangle :ITriangle

    {
        private decimal _sideA;
        private decimal _sideB;
        private decimal _sideC;

        public Triangle(decimal sideA, decimal sideB, decimal sideC)
        {
            try
            {
                this.SideA = sideA;
                this.SideB = sideB;
                this.SideC = sideC;
                ValidateIfSidesArePositive();
                ValidateTriangle();
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                throw new ArgumentException(e.Message);
            }
            
        }

        public decimal SideA
        {
            get => _sideA;
            set
            {
                _sideA = value;
            }
        }

        public decimal SideB
        {
            get => _sideB;
            set
            {
                _sideB = value;
            }

        }

        public decimal SideC
        {
            get => _sideC;
            set
            {
                _sideC = value;
            }
        }

        //This method checks if the triangle is possible to be drawn and if the provided values are positive. 
        private void ValidateTriangle()
        {
            if (_sideA + _sideB <= _sideC || _sideA + _sideC <= _sideB || _sideB + _sideC <= _sideA)
            {
                throw new ArgumentException(
                    "The sum of the lengths of any two sides of the triangle must be greater than or equal to the length of the third side.");
            }

           
        }

        private void ValidateIfSidesArePositive()
        {
            if (_sideA < 0 || _sideB < 0 || _sideC < 0)
            {
                throw new ArgumentException(
                    "The sides must be a positive number!");
            }
        }
    }
}
