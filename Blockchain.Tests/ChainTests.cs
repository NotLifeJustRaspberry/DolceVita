namespace Blockchain.Tests
{
    [TestClass]
    public class ChainTests
    {
        #region Equals

        [TestMethod]
        public void Equals_chainA_AND_chainA_ReturnedTrue()
        {
            Chain chainA = new();
            chainA.Add(647);
            chainA.Add(463);
            chainA.Add(-642);
            chainA.Add(-35);
            chainA.Add(99999);
            Chain chainB = chainA;
            bool expected = true;

            bool actual = chainB == chainA;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Equals_chainA_AND_chainB_ReturnedFalse()
        {
            Chain chainA = new();
            chainA.Add(647);
            chainA.Add(463);
            chainA.Add(-642);
            chainA.Add(-35);
            chainA.Add(99999);

            Chain chainB = new();
            chainA.Add(647);
            chainA.Add(463);
            chainA.Add(642);
            chainA.Add(35);
            chainA.Add(-4367);

            bool expected = false;

            bool actual = chainB == chainA;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Equals_chainA5_AND_chainB7_ReturnedFalse()
        {
            Chain chainA = new();
            chainA.Add(647);
            chainA.Add(463);
            chainA.Add(-642);
            chainA.Add(-35);
            chainA.Add(99999);

            Chain chainB = new();
            chainA.Add(647);
            chainA.Add(463);
            chainA.Add(-642);
            chainA.Add(-35);
            chainA.Add(99999);
            chainA.Add(345);
            chainA.Add(15469);

            bool expected = false;

            bool actual = chainB == chainA;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Equals_chainA5_AND_chainB4_ReturnedFalse()
        {
            Chain chainA = new();
            chainA.Add(647);
            chainA.Add(463);
            chainA.Add(-642);
            chainA.Add(-35);
            chainA.Add(99999);

            Chain chainB = new();
            chainA.Add(647);
            chainA.Add(463);
            chainA.Add(-642);
            chainA.Add(-35);

            bool expected = false;

            bool actual = chainB == chainA;

            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region NotEquals

        [TestMethod]
        public void NotEquals_chainA_AND_chainA_ReturnedFalse()
        {
            Chain chainA = new();
            chainA.Add(647);
            chainA.Add(463);
            chainA.Add(-642);
            chainA.Add(-35);
            chainA.Add(99999);
            Chain chainB = chainA;
            bool expected = false;

            bool actual = chainB != chainA;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void NotEquals_chainA_AND_chainB_ReturnedTrue()
        {
            Chain chainA = new();
            chainA.Add(647);
            chainA.Add(463);
            chainA.Add(-642);
            chainA.Add(-35);
            chainA.Add(99999);

            Chain chainB = new();
            chainA.Add(647);
            chainA.Add(463);
            chainA.Add(642);
            chainA.Add(35);
            chainA.Add(-4367);

            bool expected = true;

            bool actual = chainB != chainA;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void NotEquals_chainA5_AND_chainB7_ReturnedTrue()
        {
            Chain chainA = new();
            chainA.Add(647);
            chainA.Add(463);
            chainA.Add(-642);
            chainA.Add(-35);
            chainA.Add(99999);

            Chain chainB = new();
            chainA.Add(647);
            chainA.Add(463);
            chainA.Add(-642);
            chainA.Add(-35);
            chainA.Add(99999);
            chainA.Add(345);
            chainA.Add(15469);

            bool expected = true;

            bool actual = chainB != chainA;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void NotEquals_chainA5_AND_chainB4_ReturnedTrue()
        {
            Chain chainA = new();
            chainA.Add(647);
            chainA.Add(463);
            chainA.Add(-642);
            chainA.Add(-35);
            chainA.Add(99999);

            Chain chainB = new();
            chainA.Add(647);
            chainA.Add(463);
            chainA.Add(-642);
            chainA.Add(-35);

            bool expected = true;

            bool actual = chainB != chainA;

            Assert.AreEqual(expected, actual);
        }

        #endregion
    }
}