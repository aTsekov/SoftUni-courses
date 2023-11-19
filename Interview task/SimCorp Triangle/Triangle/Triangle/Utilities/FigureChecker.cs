using TriangleTask.Figures;
using TriangleTask.Interfaces;


namespace TriangleTask.Utilities
{
    public static class FigureChecker
    {

        public static string TriangleType(ITriangle triangle) 
        {
            if (triangle.SideA == triangle.SideB && triangle.SideB == triangle.SideC)
            {
                return "Equilateral";
            }
            else if (triangle.SideA == triangle.SideB || triangle.SideA == triangle.SideC || triangle.SideB == triangle.SideC)
            {
                return "Isosceles";
            }
            else
            {
                return "Scalene";
            }
        }
    }
}
