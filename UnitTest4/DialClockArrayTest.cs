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
    public class DialClockArrayTest
    {
        [TestMethod]
        public void Constructor_WithoutParameters()
        {
            //Arrange
            int size = 5;
            DialClockArray array = new DialClockArray(size);
            //Act & Assert
            Assert.AreEqual(size, array.array.Length);
            for (int i = 0; i < size; i++)
            {
                Assert.IsNull(array.array[i]);
            }
        }

        [TestMethod]
        public void Indexer()
        {
            //Arrange
            DialClock[] data = { new DialClock(10, 20), new DialClock(30, 40) };
            DialClockArray array = new DialClockArray(data);
            //Act & Assert
            Assert.AreEqual(data[0], array[0]);
            Assert.AreEqual(data[1], array[1]);
        }

        [TestMethod]
        public void FindMaxAngle()
        { 
            //Arrange
            DialClock[] data = { new DialClock(10, 20), new DialClock(10, 40), new DialClock(5, 15), new DialClock(20, 50) };
            DialClockArray array = new DialClockArray(data);
            //Act & Assert
            Assert.AreEqual(data[0], DialClockArray.FindMaxAngle(array));
        }

        [TestMethod]
        public void IndexerSetNegativeIndex()
        {
            DialClockArray array = new DialClockArray(new DialClock[2]);
            Assert.ThrowsException<IndexOutOfRangeException>(() => { array[-1] = new DialClock(50, 60); });
        }


    }
}
