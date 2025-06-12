using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Z1.Tests
{
    [TestFixture]
    public class CatTests
    {
        [Test]
        [Category("MakeSound")]
        public void Cat_MakeSound_ShouldPrintMeow()
        {
            Cat cat = new Cat("Whiskers");

            using (var sw = new System.IO.StringWriter())
            {
                Console.SetOut(sw);
                cat.MakeSound();
                Assert.AreEqual("Meow!\r\n", sw.ToString());
            }
        }

        [Test]
        [Category("CatConstructor")]
        public void Cat_Name_ShouldBeSetCorrectly()
        {
            Cat cat = new Cat("Whiskers");
            Assert.AreEqual("Whiskers", cat.Name);
        }

        [Test]
        [Category("CompareTo")]
        public void Cat_CompareTo_ShouldReturnZero_WhenNamesAreEqual()
        {
            Cat cat1 = new Cat("Whiskers");
            Cat cat2 = new Cat("Whiskers");

            Assert.AreEqual(0, cat1.CompareTo(cat2));
        }

        [Test]
        [Category("CompareTo")]
        public void Cat_CompareTo_ShouldReturnPositive_WhenFirstNameIsGreater()
        {
            Cat cat1 = new Cat("Whiskers");
            Cat cat2 = new Cat("Bella");

            Assert.Greater(cat1.CompareTo(cat2), 0);
        }

        [Test]
        [Category("EqualsHashCode")]
        public void Cat_Equals_ShouldReturnTrue_WhenNamesAreEqual()
        {
            Cat cat1 = new Cat("Whiskers");
            Cat cat2 = new Cat("Whiskers");

            Assert.IsTrue(cat1.Equals(cat2));
        }

        [Test]
        [Category("EqualsHashCode")]
        public void Cat_Equals_ShouldReturnFalse_WhenNamesAreDifferent()
        {
            Cat cat1 = new Cat("Whiskers");
            Cat cat2 = new Cat("Bella");

            Assert.IsFalse(cat1.Equals(cat2));
        }

        [Test]
        [Category("EqualsHashCode")]
        public void Cat_GetHashCode_ShouldReturnSameValue_ForEqualObjects()
        {
            Cat cat1 = new Cat("Whiskers");
            Cat cat2 = new Cat("Whiskers");

            Assert.AreEqual(cat1.GetHashCode(), cat2.GetHashCode());
        }

        [Test]
        [Category("EqualsHashCode")]
        public void Cat_GetHashCode_ShouldReturnDifferentValues_ForDifferentObjects()
        {
            Cat cat1 = new Cat("Whiskers");
            Cat cat2 = new Cat("Bella");

            Assert.AreNotEqual(cat1.GetHashCode(), cat2.GetHashCode());
        }
    }
}
