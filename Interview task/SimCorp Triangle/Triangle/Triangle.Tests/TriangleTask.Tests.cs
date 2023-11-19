using TriangleTask.Figures;
using TriangleTask.Interfaces;
using TriangleTask.Utilities;

namespace TriangleTask.Tests
{
    public class Tests
    {
        
        [Test]
        public void EquilateralTriangleTest()
        {
            // Arrange
            ITriangle triangle = new Triangle(3, 3, 3);

            // Act
            string result = FigureChecker.TriangleType(triangle);

            // Assert
            Assert.AreEqual("Equilateral", result);
        }

        [Test]
        public void IsoscelesTriangleTest()
        {
            // Arrange
            ITriangle triangle = new Triangle(3, 3, 5);

            // Act
            string result = FigureChecker.TriangleType(triangle);

            // Assert
            Assert.AreEqual("Isosceles", result);
        }

        [Test]
        public void ScaleneTriangleTest()
        {
            // Arrange
            ITriangle triangle = new Triangle(3, 4, 5);

            // Act
            string result = FigureChecker.TriangleType(triangle);

            // Assert
            Assert.AreEqual("Scalene", result);
        }

        [Test]
        public void TriangleWithNegativeSideShouldThrowException()
        {
            //Arrange&Act
            try
            {
                var triangleWithNegativeSide = new Triangle(-5, 5, 5);
            }
            catch (ArgumentException e)
            {
                //Assert
               Assert.AreEqual("The sides must be a positive number!", e.Message);
            }
            
           
        }

        [Test]
        public void TriangleWithImpossibleSides()
        {
            //Arrange&Act
            try
            {
                var triangleWithImpossibleSides = new Triangle(5, 5, 5000);
            }
            catch (ArgumentException e)
            {
                //Assert
                Assert.AreEqual("The sum of the lengths of any two sides of the triangle must be greater than or equal to the length of the third side.", e.Message);
            }


        }

        [Test]
        public void TriangleWithBigDecimalShouldBePossible()
        {
            //Arrange
            
            var triangle = new Triangle((decimal)5.55555555555555555555555555555, (decimal)5.555555555555555555555555555555555555, 5);

            // Act
            string result = FigureChecker.TriangleType(triangle);

            // Assert
            Assert.AreEqual("Isosceles", result);
            


        }
    }
}