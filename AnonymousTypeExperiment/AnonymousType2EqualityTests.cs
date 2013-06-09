using NUnit.Framework;

namespace AnonymousTypeExperiment
{
    // ReSharper disable InconsistentNaming

    [TestFixture]
    internal class AnonymousType2EqualityTests
    {
        [Test]
        public void ObjectEquals_GivenTwoEquivalentInstancesOfAnAnonymousType_ReturnsTrue()
        {
            // Arrange
            var object1 = new {Prop1 = "ABC", Prop2 = 123, Prop3 = 456};
            var object2 = new {Prop1 = "ABC", Prop2 = 123, Prop3 = 456};

            // Act
            var actual = object1.Equals(object2);

            // Assert
            Assert.That(actual, Is.True);
        }

        [Test]
        public void EqualityOperator_GivenTwoEquivalentInstancesOfAnAnonymousType_ReturnsFalse()
        {
            // Arrange
            var object1 = new { Prop1 = "ABC", Prop2 = 123, Prop3 = 456 };
            var object2 = new { Prop1 = "ABC", Prop2 = 123, Prop3 = 456 };

            // Act
            var actual = object1 == object2;

            // Assert
            Assert.That(actual, Is.False);
        }

        [Test]
        public void ReferenceEquals_GivenTwoEquivalentInstancesOfAnAnonymousType_ReturnsFalse()
        {
            // Arrange
            var object1 = new { Prop1 = "ABC", Prop2 = 123, Prop3 = 456 };
            var object2 = new { Prop1 = "ABC", Prop2 = 123, Prop3 = 456 };

            // Act
            var actual = ReferenceEquals(object1, object2);

            // Assert
            Assert.That(actual, Is.False);
        }
    }
}
