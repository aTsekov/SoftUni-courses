namespace Gyms.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;

    public class GymsTests
    {
        //Should I have here [SetUp]???

        [Test]
        public void TestConstructorInitialisation()
        {
            Gym gym = new Gym("BasicFit", 50);

            string expectedName = "BasicFit";
            string actualName = gym.Name;
            int expectedCapacity = 50;
            int actualCapacity = gym.Capacity;

            Assert.AreEqual(expectedName, actualName);
            Assert.AreEqual(expectedCapacity, actualCapacity);
        }
        [TestCase("")]
        [TestCase(null)]
        public void TestNamePropertyThrowsExceptionWhenNameIsNulOrEmpty(string testName)
        {


            Assert.Throws<ArgumentNullException>(() =>
            {
                Gym gym = new Gym(testName, 50);
            }, "Invalid gym name.");
        }
        [Test]
        public void TestCapacityPropertyThrowsExceptionWhenCapacityIsNegative()
        {


            Assert.Throws<ArgumentException>(() =>
            {
                Gym gym = new Gym("BasicFit", -50);
            }, "Invalid gym capacity.");
        }
        [Test]
        public void TestCountRetunrsCorrectNumber()
        {
            var athlete = new Athlete("Gosho Popov");
            var athlete2 = new Athlete("Mosho Popov");
            var athlete3 = new Athlete("Sasho Popov");
            Gym gym = new Gym("BasicFit", 50);
            gym.AddAthlete(athlete);
            gym.AddAthlete(athlete2);
            gym.AddAthlete(athlete3);
            int expectedCount = 3;
            int actualCount = gym.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }
        [Test]
        public void TestIfMorePeopleThanCapacityCanBeAdded()
        {
            var athlete = new Athlete("Gosho Popov");
            var athlete2 = new Athlete("Mosho Popov");

            Gym gym = new Gym("BasicFit", 1);
            gym.AddAthlete(athlete);

            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.AddAthlete(athlete2);
            }, "The gym is full.");
        }
        [Test]
        public void TestIfActuallyRemovesAtlethes()
        {
            var athlete = new Athlete("Gosho Popov");
            var athlete2 = new Athlete("Mosho Popov");

            Gym gym = new Gym("BasicFit", 3);
            gym.AddAthlete(athlete);
            gym.AddAthlete(athlete2);


            gym.RemoveAthlete("Gosho Popov");

            int expectedCount = 1;
            int actualCount = gym.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }
        [Test]
        public void TestIfRemoveMethodThrowsExceptionifAthleteDoesNoExist()
        {
            var athlete = new Athlete("Gosho Popov");
            var athlete2 = new Athlete("Mosho Popov");

            Gym gym = new Gym("BasicFit", 3);
            gym.AddAthlete(athlete);
            gym.AddAthlete(athlete2);

            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.RemoveAthlete("Pesho Popov");
            }, $"The athlete Pesho Popov doesn't exist.");
        }
        [Test]
        public void TestIfInjuredAthleteMethodThrowsExceptionifAthleteDoesNoExist()
        {
            var athlete = new Athlete("Gosho Popov");
            var athlete2 = new Athlete("Mosho Popov");

            Gym gym = new Gym("BasicFit", 3);
            gym.AddAthlete(athlete);
            gym.AddAthlete(athlete2);

            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.InjureAthlete("Pesho Popov");
            }, $"The athlete Pesho Popov doesn't exist.");
        }

        [Test]
        public void TestIfInjuredAthleteMethodsetsTheAthleteToInjured()
        {
            var athlete = new Athlete("Gosho Popov");
            var athlete2 = new Athlete("Mosho Popov");

            Gym gym = new Gym("BasicFit", 3);
            gym.AddAthlete(athlete);
            gym.AddAthlete(athlete2);
            gym.InjureAthlete("Gosho Popov");
            Athlete ath = gym.InjureAthlete("Gosho Popov");

            Assert.AreEqual(true, ath.IsInjured);
            Assert.AreEqual("Gosho Popov", ath.FullName);

        }
        [Test]
        public void ReportMethodShouldReturnInformationAboutGymAndAthletesInIt()
        {
            Gym gym = new Gym("BasicFit", 3);

            gym.AddAthlete(new Athlete("Gosho"));
            gym.AddAthlete(new Athlete("Posho"));
            gym.AddAthlete(new Athlete("Mosho"));

            Athlete injuredAthlete = gym.InjureAthlete("Mosho");

            string report = gym.Report();

            Assert.AreEqual("Active athletes at BasicFit: Gosho, Posho", report);
        }
    }


    
}
