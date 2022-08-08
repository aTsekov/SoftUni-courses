using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
        [TestCase(" ", 20)]
        [TestCase(null, 20)]
        
        public void TestConstructorModelName(string modelName, int maximumBatterCharge)
        {

            var phone = new Smartphone(modelName, maximumBatterCharge);


            Assert.That((string.IsNullOrWhiteSpace(modelName)), "modelName data  should bevalid");
            

        }
        
        [TestCase("Iphone", -10)]
        [TestCase("Iphone", -1)]
        public void TestConstructorMaxBatteryCharge(string modelName, int maximumBatterCharge)
        {

            var phone = new Smartphone(modelName, maximumBatterCharge);


            
            Assert.That((maximumBatterCharge < 0), "maximumBatterCharge should be positive");

        }

        
         [Test]
        public void MaximumBatteryCharge()
        {
            int maximumBatteryCharge = -1;
            
            Assert.That(maximumBatteryCharge < 0, "string maximumBatteryCharge must be positive");
            
         
          
        }
        [Test]
        public void CapacityMustBeAbove0()
        {
            
            Assert.Throws<ArgumentException>(() =>
            {
                var shop = new Shop(-1);
            },"Invalid capacity.");
        }
        [Test]
        public void TestShopCount()
        {
            var phone1 = new Smartphone("Samsung", 50);
            var phone2 = new Smartphone("Iphone", 50);
            var shop = new Shop(3);
            shop.Add(phone1);
            shop.Add(phone2);
            int expectedCount = 2;
            int actualCount = shop.Count;
            Assert.AreEqual(expectedCount, actualCount, "The count is correct");
        }
        [Test]
        public void AssureAddAllowsOnlyUniquePhones()
        {
            var phone1 = new Smartphone("Samsung", 50);
            var phone2 = new Smartphone("Samsung", 50);
            var shop = new Shop(3);
            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Add(phone1);
                shop.Add(phone2);
            }, $"The phone model {phone1.ModelName} already exist.");
            
        }
        [Test]
        public void CheckIfMorePhonesThanCapacityCanBeAdded()
        {
            var phone1 = new Smartphone("Iphone", 50);
            var phone2 = new Smartphone("Samsung", 50);
            var phone3 = new Smartphone("Nokia", 50);
            var shop = new Shop(2);
            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Add(phone1);
                shop.Add(phone2);
                shop.Add(phone3);
            }, $"The shop is full.");
        }[Test]
        public void CheckIfThrowsExceptionIfYouTryToRemovePhoneWhichDoesNotExists()
        {
            var phone1 = new Smartphone("Iphone", 50);
            var phone2 = new Smartphone("Samsung", 50);            
            var shop = new Shop(2);
            shop.Add(phone1);
            shop.Add(phone2);
            var modelName = "Nokia";
            var phone3 = new Smartphone(modelName, 40);

            Assert.Throws<InvalidOperationException>(() =>
            {

                shop.Remove(phone3.ModelName);

            },$"The phone model {phone3.ModelName} doesn't exist.");
        }
        [Test]
        public void CheckIfActuallythePhoneIsDeleted()
        {
            var phone1 = new Smartphone("Iphone", 50);
            var phone2 = new Smartphone("Samsung", 50);            
            var shop = new Shop(2);
            shop.Add(phone1);
            shop.Add(phone2);

            shop.Remove("Samsung");
            var expectedCount = shop.Count;
            var actualCount = 1;

            Assert.AreEqual(expectedCount, actualCount,"The phone is actually deleted");
        }  
        [Test]
        public void TestPhoneIfphoneExists()
        {
      
            string modelName = "Nokia";
            
            Assert.Throws<InvalidOperationException>(() =>
            {

                var shop = new Shop(2);
                shop.TestPhone(modelName, 20);
                

            },$"The phone model {modelName} doesn't exist.");
        }
        [Test]
        public void TestPhoneIfCurrentBateryChargeIsReduced()
        {
            string modelName = "Nokia";
            int batteryUsage = 5;
            Smartphone phone1 = new Smartphone(modelName, 15);
            phone1.CurrentBateryCharge = 10;
            var shop = new Shop(2);
            shop.Add(phone1);
            shop.TestPhone("Nokia", batteryUsage);
            int expectedBatteryUsage = 5;
            var actualBatteryUsage = phone1.CurrentBateryCharge;

            Assert.AreEqual(expectedBatteryUsage, actualBatteryUsage, "The substraction of battery charge works as expected");
        }
       [Test]
       public void TessIfChargePhoneThrowsException()
        {
            string modelName = "Nokia";

            Assert.Throws<InvalidOperationException>(() =>
            {

                var shop = new Shop(2);
                shop.ChargePhone(modelName);


            }, $"The phone model {modelName} doesn't exist.");
        }

        [Test]
        public void TestIfPhoneIsCharged()
        {
            string modelName = "Nokia";
            int batteryUsage = 5;
            Smartphone phone1 = new Smartphone(modelName, 15);
            phone1.CurrentBateryCharge = 10;
            var shop = new Shop(2);
            shop.Add(phone1);
            shop.ChargePhone("Nokia");
            int expectedBatteryUsage = phone1.MaximumBatteryCharge;
            var actualBatteryUsage = phone1.CurrentBateryCharge;

            Assert.AreEqual(expectedBatteryUsage, actualBatteryUsage, "The phone is fully charged");
        }



    }
}