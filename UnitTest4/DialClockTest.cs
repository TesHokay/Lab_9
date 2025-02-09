using Lab_9;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTest
{
    [TestClass]
    public class DialClockTest
    {
        [TestMethod]
        public void Constructor_WithParameters()
        {
            //Arrange
            DialClock clock = new DialClock(10, 30);
            //Act & Assert
            Assert.AreEqual(10, clock.Hours);
            Assert.AreEqual(30, clock.Minutes);
        }

        [TestMethod]
        public void Constructor_WithoutParameters()
        {
            //Arrange
            DialClock clock = new DialClock();
            //Act & Assert
            Assert.AreEqual(0, clock.Hours);
            Assert.AreEqual(0, clock.Minutes);
        }

        [TestMethod]
        public void Constructor_Copy()
        {
            //Arrange
            DialClock clock = new DialClock(10, 30);
            DialClock clock1 = new DialClock(clock);
            //Act & Assert
            Assert.AreEqual(10, clock1.Hours);
            Assert.AreEqual(30, clock1.Minutes);
        }

        [TestMethod]
        public void CalculatingAngle()
        {
            //Arrange
            int hours = 3;
            int minutes = 30;
            double expectedAngle = 75;

            // Act & Assert
            double actualAngle = DialClock.CalculateAngle(hours, minutes);
            Assert.AreEqual(expectedAngle, actualAngle);
        }

        [TestMethod]
        public void OperationAdd()
        {
            //Arrange
            DialClock dc = new DialClock(10, 30);

            //Act & Assert
            DialClock result = dc + 40;
            Assert.AreEqual(11, result.hours);
            Assert.AreEqual(10, result.minutes);
        }

        [TestMethod]
        public void OperationSub()
        {
            //Arrange
            DialClock dc = new DialClock(10, 30);

            //Act & Assert
            DialClock result = dc - 40;
            Assert.AreEqual(9, result.hours);
            Assert.AreEqual(50, result.minutes);
        }

        [TestMethod]
        public void OverloadedOperationAddUnit()
        {
            //Arrange
            DialClock clock = new DialClock(10, 30);
            DialClock incrementedClock = ++clock;

            //Act & Assert
            Assert.AreEqual(10, incrementedClock.Hours);
            Assert.AreEqual(31, incrementedClock.Minutes);
        }

        [TestMethod]
        public void OverloadedOperationSubUnit()
        {
            //Arrange
            DialClock clock = new DialClock(10, 30);
            DialClock incrementedClock = --clock;

            //Act & Assert
            Assert.AreEqual(10, incrementedClock.Hours);
            Assert.AreEqual(29, incrementedClock.Minutes);
        }

        [TestMethod]
        public void ConvertingToString()
        {
            //Arrange
            DialClock clock = new DialClock(10, 30);
            string result = clock.ToString();
            //Act & Assert
            Assert.AreEqual("10:30", result);
        }

        [TestMethod]
        public void OperationSubRight()
        {
            //Arrange
            DialClock clock = new DialClock(10, 30);
            DialClock result = 10 - clock; 
            //Act & Assert
            Assert.AreEqual(10, result.Hours);
            Assert.AreEqual(20, result.Minutes);
        }

        [TestMethod]
        public void OperationAddRight()
        {
            //Arrange
            DialClock clock = new DialClock(10, 30);
            DialClock result = 10 + clock;
            //Act & Assert
            Assert.AreEqual(10, result.Hours);
            Assert.AreEqual(40, result.Minutes);
        }

        [TestMethod]
        public void InfoAboutObject()
        {
            //Arrange
            DialClock clock = new DialClock(10, 30);
            string result = clock.Info();
            //Act & Assert
            Assert.AreEqual("Часы: 10, Минуты: 30", result);
        }


    }
}
