namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private Person[] people;
        private Database database;
        [SetUp]
        public void Setup()
        {
            people = new Person[] {
            new Person(123456, "Antoni"),
            new Person(123457, "Olga"),
            new Person(123458, "Ivan"),
            new Person(123459, "Pesho"),
            new Person(123410, "Gosho"),
            new Person(123411, "Maria"),
            new Person(123412, "Frank"),
            new Person(123413, "Tom"),
            new Person(123414, "Lili"),
            new Person(123415, "Metodi"),
            new Person(123416, "Stamat"),
            new Person(123417, "Zahari"),
            new Person(123418, "Petq"),
            new Person(1234519, "Asen"),
            new Person(123420, "Artur"),
            new Person(123421, "Mi6o"),


        };
            database = new Database(people);


        }
        [Test]
        public void ConstructorShouldThrowExceptionIfMoreTHan16People()
        {

            people = new Person[]
            {
            new Person(123456, "Antoni"),
            new Person(123457, "Olga"),
            new Person(123458, "Ivan"),
            new Person(123459, "Pesho"),
            new Person(123410, "Gosho"),
            new Person(123411, "Maria"),
            new Person(123412, "Frank"),
            new Person(123413, "Tom"),
            new Person(123414, "Lili"),
            new Person(123415, "Metodi"),
            new Person(123416, "Stamat"),
            new Person(123417, "Zahari"),
            new Person(123418, "Petq"),
            new Person(1234519, "Asen"),
            new Person(123420, "Artur"),
            new Person(123421, "Mi6o"),


            };
            database = new Database(people);

            Assert.Throws<InvalidOperationException>(() =>
            {
                var extraPerson = new Person(123423, "Cecii");
                database.Add(extraPerson);
            });

        }
        [Test]
        public void TestIfCOuntRetunrsCorrectValue()
        {
            people = new Person[]
            {
            new Person(123456, "Antoni"),
            new Person(123457, "Olga"),

            };
            database = new Database(people);

            int expectedCount = 2;
            int actualCount = database.Count;
            Assert.AreEqual(expectedCount, actualCount, "The count is correct");

        }
        [Test]
        public void CheckIfUsersAreUnique()
        {
            var person1 = new Person(123, "Antoni");
            var person2 = new Person(1223, "Antoni");

            Assert.Throws<InvalidOperationException>(() =>
            {

                database.Add(person1);
                database.Add(person2);
            }, "There is already user with this username!");

        }
        [Test]
        public void CheckIfIDsAreUnique()
        {
            var person1 = new Person(123, "Antoni");
            var person2 = new Person(123, "Gosho");

            Assert.Throws<InvalidOperationException>(() =>
            {

                database.Add(person1);
                database.Add(person2);
            }, "There is already user with this Id!");
            
        }
        [Test]
        public void TestIfPeopleAreRemoved()
        {
            people = new Person[]
            {
            new Person(123456, "Antoni"),
            new Person(123457, "Olga"),
            new Person(123257, "Gosho"),

            };
            database = new Database(people);

            
            var expextedCount = 2;
            database.Remove();
            var actualAcount = database.Count;
            Assert.AreEqual(expextedCount, actualAcount, "A person was sucsesfully deleted");
        }
        //*************To test after FindByUsername *******************
    }





}