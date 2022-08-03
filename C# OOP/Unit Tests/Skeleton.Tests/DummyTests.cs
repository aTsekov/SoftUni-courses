using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    
    [TestFixture]
    public class DummyTests
        
    {
        private int attackpoints;
        private int durabilityPoints;
        private int health;
        private int experiance;

        [Test]
        public void LooseHealthWhenAttacked()
        {
            attackpoints = 10;
            durabilityPoints = 10;
            health = 10;
            experiance = 10;
            //Arrange
            Axe axe = new Axe(attackpoints, durabilityPoints);
            Dummy dummy = new Dummy(health, experiance);

           //Act
            axe.Attack(dummy);

            //Assert
            Assert.That(dummy.Health, !Is.GreaterThan(0), "The dummy should've die");
           
        }

        [Test]
        public void CheckIfThrowsExceptionWhenDummyIsDeadAndAttacked()
        {
            attackpoints = 11;
            durabilityPoints = 10;
            health = 10;
            experiance = 10;
            //Arrange
            Axe axe = new Axe(attackpoints, durabilityPoints);
            Dummy dummy = new Dummy(health, experiance);

            //Act


            //Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                axe.Attack(dummy);
                axe.Attack(dummy);
            },"Dummy is dead.");
        }
        [Test]
        public void DummyCanGiveEXWhenDead()
        {
            attackpoints = 11;
            durabilityPoints = 10;
            health = 10;
            experiance = 10;
            //Arrange
            Axe axe = new Axe(attackpoints, durabilityPoints);
            Dummy dummy = new Dummy(health, experiance);

            //Act
            axe.Attack(dummy);

            //Assert
            Assert.That(dummy.GiveExperience, Is.GreaterThan(0), "The  dummy gave it's experiance");

        }
        [Test]
        public void AliveDummyCannoGiveExperiance()
        {
            attackpoints = 5;
            durabilityPoints = 10;
            health = 10;
            experiance = 10;
            //Arrange
            Axe axe = new Axe(attackpoints, durabilityPoints);
            Dummy dummy = new Dummy(health, experiance);

            //Act
            axe.Attack(dummy);

            //Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                dummy.GiveExperience();
            }, "Target is not dead.");

        }

    }
}