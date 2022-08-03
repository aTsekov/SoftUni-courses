using NUnit.Framework;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        [Test]
        public void AxeLoosesDurabilityAfterAttack()
        {
            //Arrange - provide the needed into
            Axe axe = new Axe(10, 10); 
            Dummy dummy = new Dummy(10,10);
            // Act - The act section is where you act upon the system under test. You call one of its methods: pass the dependencies and capture the output value if any.
            axe.Attack(dummy);

            // Assert -The assert section allows you to make the claims about the outcome. This may include the return value. (Make sure the result is the same as the one provided here. If not the test will fail.
            Assert.That(axe.DurabilityPoints, Is.EqualTo(9), "Axe Durability doesn't change after attack.");
        }
    }
}