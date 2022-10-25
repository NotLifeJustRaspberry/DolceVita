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

        #region Add

        [TestMethod]
        public void Add_100Elements_Returned100()
        {
            Chain chain = new();
            for (int i = 1; i <= 100; i++)
                chain.Add(i);

            int expected = 100;

            int actual = chain.Count;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Add_10Elements_Returned10()
        {
            Chain chain = new();
            for (int i = 1; i <= 10; i++)
                chain.Add(i);

            int expected = 10;

            int actual = chain.Count;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Add_200Elements_Returned100()
        {
            Chain chain = new();
            for (int i = 1; i <= 200; i++)
                chain.Add(i);

            int expected = 100;

            int actual = chain.Count;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Add_10_0_4_Returned2()
        {
            Chain chain = new();
            chain.Add(10);
            chain.Add(0);
            chain.Add(4);

            int expected = 2;

            int actual = chain.Count;

            Assert.AreEqual(expected, actual);
        }

        #endregion

        [TestMethod]
        public void Clear_100Elements_Returned0()
        {
            int expected = 0;
            Chain chain = new();
            for (int i = 1; i <= 100; i++)
                chain.Add(i);

            chain.Clear();
            int actual = chain.Count;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Clear_0Elements_Returned0()
        {
            int expected = 0;
            Chain chain = new();

            chain.Clear();
            int actual = chain.Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsFull_100Elements_ReturnedTrue()
        {
            bool expected = true;
            Chain chain = new();
            for (int i = 1; i <= 100; i++)
                chain.Add(i);

            bool actual = chain.IsFull;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void IsFull_10Elements_ReturnedFalse()
        {
            bool expected = false;
            Chain chain = new();
            for (int i = 1; i <= 20; i++)
                chain.Add(i);

            bool actual = chain.IsFull;

            Assert.AreEqual(expected, actual);
        }
    }
}