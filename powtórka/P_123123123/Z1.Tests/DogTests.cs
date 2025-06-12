using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Z1.Tests
{
    [TestFixture]
    public class DogTests
    {
        [Test]
        [Category("MakeSound")]
        public void Dog_MakeSound_ShouldPrintWoof()
        {
            Dog dog = new Dog("Rex");

            using (var sw = new System.IO.StringWriter())
            {
                Console.SetOut(sw);
                dog.MakeSound();
                Assert.AreEqual("Woof!\r\n", sw.ToString());
            }
        }

        [Test]
        [Category("Move")]
        public void Dog_Move_ShouldPrintDogIsRunning()
        {
            Dog dog = new Dog("Rex");

            using (var sw = new System.IO.StringWriter())
            {
                Console.SetOut(sw);
                dog.Move();
                Assert.AreEqual("Dog is running!\r\n", sw.ToString());
            }
        }

        [Test]
        [Category("DogConstructor")]
        public void Dog_Name_ShouldBeSetCorrectly()
        {
            Dog dog = new Dog("Rex");
            Assert.AreEqual("Rex", dog.Name);
        }

        [Test]
        [Category("CompareTo")]
        public void Dog_CompareTo_ShouldReturnZero_WhenNamesAreEqual()
        {
            Dog dog1 = new Dog("Rex");
            Dog dog2 = new Dog("Rex");

            Assert.AreEqual(0, dog1.CompareTo(dog2));
        }

        [Test]
        [Category("CompareTo")]
        public void Dog_CompareTo_ShouldReturnPositive_WhenFirstNameIsGreater()
        {
            Dog dog1 = new Dog("Rex");
            Dog dog2 = new Dog("Bella");

            Assert.Greater(dog1.CompareTo(dog2), 0);
        }
    }
}
