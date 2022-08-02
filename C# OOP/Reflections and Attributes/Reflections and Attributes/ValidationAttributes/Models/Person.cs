namespace ValidationAttributes.Models
{
    using ValidationAttributes.Utilities.Attributes;

    public class Person
    {
        private const int AgeMinValue = 12;
        private const int AgeMaxValue = 90;

        public Person (string fullName, int age)
        {
            this.FullName = fullName;
            this.Age = age;
        }

        [MyRequired] //With this attribute we make the FullName property to be a required property.
        public string FullName { get; set; }

        [MyRange(AgeMinValue, AgeMaxValue)] //We make sure the age is in the valid range.
        public int Age { get; set; }
    }
}
