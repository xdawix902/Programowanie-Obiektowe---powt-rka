﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Z1.Tests
{
    [TestFixture]
    public class ZooTests
    {
        private Zoo zoo;
        private Dog dog;
        private Cat cat;

        [SetUp]
        public void SetUp()
        {
            zoo = new Zoo();
            dog = new Dog("Rex");
            cat = new Cat("Whiskers");
        }

        [Test]
        [Category("Zoo")]
        public void AddAnimal_ShouldAddAnimalToZoo()
        {
            zoo.AddAnimal(dog);
            Assert.Contains(dog, zoo.Animals);
        }

        [Test]
        [Category("ZooEvent")]
        public void AddAnimal_ShouldRaiseAnimalAddedEvent()
        {
            bool eventRaised = false;
            zoo.AnimalAdded += (sender, e) => eventRaised = true;

            zoo.AddAnimal(dog);

            Assert.IsTrue(eventRaised);
        }

        [Test]
        [Category("ZooEvent")]
        public void AddAnimal_ShouldPassCorrectAnimalInEventArgs()
        {
            Animal eventAnimal = null;
            zoo.AnimalAdded += (sender, e) => eventAnimal = e.Animal;

            zoo.AddAnimal(dog);

            Assert.AreEqual(dog, eventAnimal);
        }

        [Test]
        [Category("Zoo")]
        public void AddAnimal_ShouldHandleMultipleAnimals()
        {
            zoo.AddAnimal(dog);
            zoo.AddAnimal(cat);

            Assert.Contains(dog, zoo.Animals);
            Assert.Contains(cat, zoo.Animals);
        }

        [Test]
        [Category("ZooEvent")]
        public void AddAnimal_ShouldNotRaiseEventWhenNoSubscribers()
        {
            zoo.AddAnimal(dog);
            // No assertions needed, just ensuring no exceptions are thrown
            Assert.Pass();
        }
    }
}
