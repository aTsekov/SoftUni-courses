using NUnit.Framework;
using System;
using System.Linq;

namespace PlanetWars.Tests
{
    public class Tests
    {
        [TestFixture]
        public class PlanetWarsTests
        {

        }
        [Test]
        public void TestPlanetCtorInitialisations()
        {
            var planet = new Planet("Mars", 20.22);
            var expectedName = "Mars";
            var actualName = planet.Name;
            var expectedBudget = 20.22;
            var actualBudget = planet.Budget;

            Assert.AreEqual(expectedName, actualName, "Name is not the same");
            Assert.AreEqual(expectedBudget, actualBudget, "Budget is not the same");
        }
        [TestCase("")]
        [TestCase(null)]
        public void NullOrEmptyNameOfThePlanetShouldThrowException(string name)
        {
           Assert.Throws<ArgumentException>(() =>
           {
               var planet = new Planet(name, 20);
           }, "Invalid planet Name");
        }
        [TestCase(-0.5)]
        [TestCase(-1)]
        public void BudjetShouldNotDropBelowZero(double budget)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var planet = new Planet("Mars", budget);
            }, "Budget cannot drop below Zero!");
        }
        [Test]
        public void TestWeponCount()
        {
            var planet = new Planet("Mars", 20);
            var weapon = new Weapon("Laser", 5, 5);
            var weapon1 = new Weapon("Laser1", 5, 5);
            planet.AddWeapon(weapon);
            planet.AddWeapon(weapon1);
            var expectedCount = 2;
            var actualCount = planet.Weapons.Count;

            Assert.AreEqual(expectedCount, actualCount, "The weapons count is correct");
        }
        [Test]
        public void TestMilitaryPowerRationIsCorrectlyCalculated()
        {
            var planet = new Planet("Mars", 20);
            var weapon = new Weapon("Laser", 5, 5);
            var weapon1 = new Weapon("Laser1", 5, 5);
            planet.AddWeapon(weapon);
            planet.AddWeapon(weapon1);
            var expectedPowerRatio = 10;
            var actualPowerRatio = planet.MilitaryPowerRatio;
            

            Assert.AreEqual(expectedPowerRatio, actualPowerRatio, "The destruction level is correct");
        }
        [Test]
        public void CheckTheProfitMethodIncreasedTheBudget()
        {
            var planet = new Planet("Mars", 20);
            planet.Profit(200);
            var expectedBudget = 220;
            var actualBudget = planet.Budget;
            Assert.AreEqual(expectedBudget, actualBudget, "The budget is correct after the ProfitMethod is called");

        }
        [Test]
        public void CheckSpendFundsDecreasesTheBudget()
        {
            var planet = new Planet("Mars", 20);
            planet.SpendFunds(10);
            var expectedBudget = 10;
            var actualBudget = planet.Budget;
            Assert.AreEqual(expectedBudget, actualBudget, "The budget is correct after the SpendBudget is called");

        }
        [Test]
        public void EnsureMoreThanTheBudgetCannotBeSpendAndThrowsExcepion()
        {
            var planet = new Planet("Mars", 20);
            

            Assert.Throws<InvalidOperationException>(() =>
            {
                planet.SpendFunds(200);
            },"Not enough funds to finalize the deal.");

        }
        [Test]
        public void TestWeponIsAdded()
        {
            var planet = new Planet("Mars", 20);
            var weapon = new Weapon("Laser", 5, 5);
            var weapon1 = new Weapon("Laser1", 5, 5);
            planet.AddWeapon(weapon);
            planet.AddWeapon(weapon1);
            var expectedWeapon = weapon;
            Weapon actualWeapon = planet.Weapons.FirstOrDefault(w => w.Name == "Laser");

            Assert.AreEqual(expectedWeapon, actualWeapon, "The weapons count is correct");
        }
        [Test]
        public void OnlyUniqueWeaponsCanBeAdded()
        {
            var planet = new Planet("Mars", 20);
            var weapon = new Weapon("Laser", 5, 5);
            var weapon1 = new Weapon("Laser", 5, 5);
            planet.AddWeapon(weapon);
            

            Assert.Throws<InvalidOperationException>(() =>
            {
                planet.AddWeapon(weapon1);
            },$"There is already a {weapon.Name} weapon.");
        }
        [Test]
        public void EnsureWeaponIsRemoved()
        {
            var planet = new Planet("Mars", 20);
            var weapon = new Weapon("Laser", 5, 5);
            var weapon1 = new Weapon("Laser1", 5, 5);
            planet.AddWeapon(weapon);
            planet.AddWeapon(weapon1);
            planet.RemoveWeapon("Laser");

            bool expected = false; //It should be false because it was already deleted
            bool actual = planet.Weapons.Any(w => w.Name == "Laser");
            Assert.AreEqual(expected, actual, "The wepon was removed");

        }
        [Test]
        public void WeponUpgradeCannotFindTHeWeapon()
        {
            var planet = new Planet("Mars", 20);
            var weapon = new Weapon("Laser", 5, 5);
            var weapon1 = new Weapon("Laser1", 5, 5);
            planet.AddWeapon(weapon);
            planet.AddWeapon(weapon1);

            Assert.Throws<InvalidOperationException>(() =>
            {
                planet.UpgradeWeapon("Tank");
            },$"Tank does not exist in the weapon repository of {planet.Name}");
        }
        [Test]
        public void WeponUpgradeIncreasesDestructionLevel()
        {
            var planet = new Planet("Mars", 20);
            var weapon = new Weapon("Laser", 5, 5);
            var weapon1 = new Weapon("Laser1", 5, 5);
            planet.AddWeapon(weapon);
            planet.AddWeapon(weapon1);

            planet.UpgradeWeapon("Laser");
            var expectedDestruction = 6;
            var weaponTest = planet.Weapons.FirstOrDefault(w => w.Name == "Laser");
            var actualDestruction = weaponTest.DestructionLevel;

            Assert.AreEqual(expectedDestruction, actualDestruction, "The destruction was increased.");
        }
        [Test]
        public void OpponentIsTooStrongException()
        {
            var planet = new Planet("Mars", 20);
            var weapon = new Weapon("Laser", 5, 5);
            var weapon1 = new Weapon("Laser1", 5, 5);
            planet.AddWeapon(weapon);
            planet.AddWeapon(weapon1);
            var opponent = new Planet("Saturn", 300);
            var weaponOp = new Weapon("Laser", 5, 500);
            opponent.AddWeapon(weaponOp);

            Assert.Throws<InvalidOperationException>(() =>
            {
                planet.DestructOpponent(opponent);
            }, $"{opponent.Name} is too strong to declare war to!");
        }
        [Test]
        public void OpponentIsWeaker()
        {
            var planet = new Planet("Mars", 20);
            var weapon = new Weapon("Laser", 5, 5);
            var weapon1 = new Weapon("Laser1", 5, 5);
            planet.AddWeapon(weapon);
            planet.AddWeapon(weapon1);
            var opponent = new Planet("Saturn", 2);
            var weaponOp = new Weapon("Laser", 5, 2);
            opponent.AddWeapon(weaponOp);

            Assert.Pass(planet.DestructOpponent(opponent), $"{opponent.Name} is destructed!");
        }
        //+++++++++++ TEST WEAPONS CLASS++++++++++

        [Test]
        public void TestWeaponConstructorInitialisation()
        {
            var weapon = new Weapon("Laser", 20, 50);

            var expectedName = "Laser";
            double expectedPrice = 20;
            double expectedDestructionlevel = 50;

            var actualName = weapon.Name;
            var actualPrice = weapon.Price;
            var actualDestructionLevel = weapon.DestructionLevel;

            Assert.AreEqual(expectedName, actualName);
            Assert.AreEqual(expectedPrice, actualPrice);
            Assert.AreEqual(expectedDestructionlevel, actualDestructionLevel);

        }
        [Test]
        public void WeaponPriceCannotBeNegative()
        {
            Assert.Throws<ArgumentException>(() =>
          {
              var weapon = new Weapon("Laser", -2, 50);
          }, "Price cannot be negative.");
        }
        [Test]
        public void IncreseDestructionLevel()
        {
            var weapon = new Weapon("Laser", 10, 50);
            weapon.IncreaseDestructionLevel();
            var expectedDestLlvl = 51;
            var actual = weapon.DestructionLevel;

            Assert.AreEqual(actual, expectedDestLlvl);
        }
        [Test]
        public void IsNuclearWorkingCorrectly()
        {
            var weapon = new Weapon("Laser", 10, 50);
            weapon.IncreaseDestructionLevel();
            var expected = true;
            var actual = weapon.IsNuclear;

            

            Assert.AreEqual(actual, expected);
        }

    }
}
