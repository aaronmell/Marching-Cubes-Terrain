﻿using Eldemarkki.VoxelTerrain.Utilities;
using NUnit.Framework;
using Unity.Collections;

namespace Tests
{
    public class CounterTests
    {
        private Counter counter;

        [SetUp]
        public void SetupCounterTest()
        {
            counter = new Counter(Allocator.Temp);
        }

        [TearDown]
        public void TeardownCounterTest()
        {
            counter.Dispose();
        }

        [Test]
        public void Counter_Count_Initialized_As_0()
        {
            Assert.AreEqual(0, counter.Count);
        }

        [Test]
        public void Counter_Increment_Increases_Count_By_1()
        {
            counter.Increment();
            Assert.AreEqual(1, counter.Count);
        }

        [Test]
        public void Counter_Random_Increment_Sets_Count_To_N([Random(5, 100, 3)] int value)
        {
            for (int i = 0; i < value; i++)
            {
                counter.Increment();
            }

            Assert.AreEqual(value, counter.Count);
        }        
    }
}
