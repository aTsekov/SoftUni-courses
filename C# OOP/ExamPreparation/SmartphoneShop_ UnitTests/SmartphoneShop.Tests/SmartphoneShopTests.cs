using NUnit.Framework;
using System;

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
        }
      



    }
}