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

            Assert.IsTrue(chainA.Equals(chainB));
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

            Assert.IsFalse(chainA.Equals(chainB));
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

            Assert.IsFalse(chainA.Equals(chainB));
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

            Assert.IsFalse(chainA.Equals(chainB));
        }
        #endregion
    }
}