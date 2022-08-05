namespace Database.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DatabaseTests
    {
        [TestCase(new int[] { })]
        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 2 })]
        [TestCase(new int[] { 1, 3, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        [TestCase(new int[] { 1 })]
        public void ConstructorShouldHaveLessThan16Elements(int[] arr)
        {
            // Arrange

            Database db = new Database(arr);

            //Act
            int[] actualArr = db.Fetch(); //This is the copy of the original array made by the method Fetch()
            int[] expectedArr = arr;

            int actualCount = db.Count;
            int expectedCount = actualArr.Length;

            //Assert

            CollectionAssert.AreEqual(expectedArr, actualArr,
                "Database ctor should be initialized correctly!");
            Assert.AreEqual(expectedCount, actualCount,
                "Ctor should set initial value for count field correctly!");



        }
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18 })]
        public void ConstructorShouldNotAllowMoreThan16Elements(int[] arr)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                Database database = new Database(arr);

            }, "Array's capacity must be exactly 16 integers!");
        }
        [Test]
        public void TestIfCountReturntTheActualCount()
        {
            //Arrange
            int[] testCount = new int[] { 1, 2, 3 };
            Database db = new Database(testCount);

            //Act
            int[] actualArr = db.Fetch();

            int actualCount = actualArr.Length;
            int expectedCount = testCount.Length;
            //Assert
            Assert.AreEqual(expectedCount, actualCount,
                "The count returnts the actualcount of the arr");



        }
        [Test]
        public void CountShouldReturnZeroIfTheArrayIsEmpty()
        {
            //Arrange
            int[] testCount = new int[] { };
            Database db = new Database(testCount);

            //Act
            int[] actualArr = db.Fetch();
            int actualCount = actualArr.Length;
            int expectedCount = testCount.Length;

            //Assert
            Assert.AreEqual(actualCount, expectedCount,
                "If array is empty the count should be 0");
        }
        [Test]
        public void TestIfAddsToNextElement()
        {
            //Arrange
            int[] arr = new int[] { 1, 2, 3 };
            Database database = new Database(arr);
            database.Add(58);

            //Act
            int expectedElement = 58;
            int[] actualArr = database.Fetch();
            int actualElement = actualArr[actualArr.Length - 1];

            //Assert

            Assert.AreEqual(expectedElement, actualElement,
                "The two elements are added at the last position");


        }
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18 })]
        public void TestIfAddCanAddMoreThan16Elements(int[] arr)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                Database database = new Database(arr);
            });
        }
        [Test]
        public void TestIfLastElementIsRemoved()
        {
            int[] arr = new int[] { 1, 2, 3, 4 };
            Database db = new Database(arr);

            db.Remove();
            int[] actualArr = db.Fetch();
            int actualLastEl = actualArr[actualArr.Length - 1];
            int expectedLastEl = 3;
            Assert.AreEqual(expectedLastEl, actualLastEl,
                "The last element gets removed!");
        }
        [Test]
        public void ThrowExceptionWehnTryingToRemoveElementFromEmpryDataBase()
        {
            //Arrange
            int[] arr = new int[] { };
            Database database = new Database(arr);

            //Act&Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Remove();
            });

        }
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1 })]
        public void TestIfFetchMakesACopyOfOriginalArr(int[] arr)
        {
            //Arrange
            Database db = new Database(arr);
            
            //Act
            int[] actualArr = db.Fetch();
            int[] expectedArr = arr;

            //Assert
            CollectionAssert.AreEqual(expectedArr, actualArr,
                "Fetch should return copy of existing data.");
        }
    }
}
