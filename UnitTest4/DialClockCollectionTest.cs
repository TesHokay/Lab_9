using Lab_9;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    [TestClass]
    public class DialClockCollectionTest
    {
        [TestMethod]
        public void Collection_ShouldInitializeHoursAndMinutes()
        {
            //Act & Assert
            DialClockCollection collection = new DialClockCollection();
            Assert.IsNotNull(collection.Clocks);
            Assert.AreEqual(0, collection.Clocks.Count);
        }

        [TestMethod]
        public void Collection_EmptyInputs()
        {
            //Arrange
            DialClockCollection copy = new DialClockCollection(null);
            //Act & Assert
            Assert.IsNotNull(copy.Clocks);
            Assert.AreEqual(0, copy.Clocks.Count);
        }

        [TestMethod]
        public void PrintCollection_EmptyInput()
        {
            DialClockCollection original = new DialClockCollection();
            DialClockCollection copy = new DialClockCollection(original);
            Assert.IsNotNull(copy.Clocks);
            Assert.AreEqual(0, copy.Clocks.Count);
        }

        [TestMethod]
        public void PrintCollection_NonEmptyCollection()
        {
            try
            {
                DialClockCollection.PrintCollection(null);
                Assert.IsTrue(true);
            }
            catch (Exception)
            {
                Assert.Fail("Коллекция пуста или не задана");
            }
        }

        [TestMethod]
        public void PrintCollection_NonEmptyCollection2()
        {
            DialClockCollection collection = new DialClockCollection();
            collection.Clocks.Add(new DialClock(10, 20));
            try
            {
                DialClockCollection.PrintCollection(collection);
                Assert.IsTrue(true);
            }
            catch (Exception)
            {
                Assert.Fail("Коллекция пуста или не задана");
            }
        }
    }
}
