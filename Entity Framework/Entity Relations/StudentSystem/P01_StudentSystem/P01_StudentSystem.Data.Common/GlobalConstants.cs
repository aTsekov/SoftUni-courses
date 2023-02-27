namespace P01_StudentSystem.Data.Common
{
    public class GlobalConstants
    {
        public const int StudentNameMaxLength = 100;

        public const int PhoneMaxMinLength = 10;
        public const int CourseNameMaxLength = 80;
        public const int ResourceNameMaxLength = 50;
        public const int ResourceUrlMaxLength = 2048;

        public const string ConnectionString = @"Server=.;Database=StudentSystem;User Id=sa;Password=SoftUn!2021;MultipleActiveResultSets=true;TrustServerCertificate=True";

    }
}