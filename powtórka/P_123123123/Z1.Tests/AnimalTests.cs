using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Z1.Tests
{
    [TestFixture]
    [TestFixture]
    public class AnimalTests
    {
        [Test]
        [Category("CompareTo")]
        public void Animal_CompareTo_ShouldReturnZero_WhenNamesAreEqual()
        {
            Animal animal1 = new Dog("Max");
            Animal animal2 = new Dog("Max");

            Assert.AreEqual(0, animal1.CompareTo(animal2));
        }

        [Test]
        [Category("CompareTo")]
        public void Animal_CompareTo_ShouldReturnPositive_WhenFirstNameIsGreater()
        {
            Animal animal1 = new Dog("Max");
            Animal animal2 = new Dog("Charlie");

            Assert.Greater(animal1.CompareTo(animal2), 0);
        }

        [Test]
        [Category("EqualsHashCode")]
        public void Animal_Equals_ShouldReturnTrue_WhenNamesAreEqual()
        {
            Animal animal1 = new Dog("Max");
            Animal animal2 = new Dog("Max");

            Assert.IsTrue(animal1.Equals(animal2));
        }

        [Test]
        [Category("EqualsHashCode")]
        public void Animal_Equals_ShouldReturnFalse_WhenNamesAreDifferent()
        {
            Animal animal1 = new Dog("Max");
            Animal animal2 = new Dog("Charlie");

            Assert.IsFalse(animal1.Equals(animal2));
        }

        [Test]
        [Category("EqualsHashCode")]
        public void Animal_GetHashCode_ShouldReturnSameValue_ForEqualObjects()
        {
            Animal animal1 = new Dog("Max");
            Animal animal2 = new Dog("Max");

            Assert.AreEqual(animal1.GetHashCode(), animal2.GetHashCode());
        }

        [Test]
        [Category("EqualsHashCode")]
        public void Animal_GetHashCode_ShouldReturnDifferentValues_ForDifferentObjects()
        {
            Animal animal1 = new Dog("Max");
            Animal animal2 = new Dog("Charlie");

            Assert.AreNotEqual(animal1.GetHashCode(), animal2.GetHashCode());
        }
    }
}
