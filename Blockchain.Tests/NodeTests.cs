namespace Blockchain.Tests
{
    [TestClass]
    public class NodeTests
    {
        #region Equals

        [TestMethod]
        public void Equals_10_null_AND_10_null_ReturnedTrue()
        {
            Node a = new(10, null);
            Node b = new(10, null);
            bool expected = true;

            bool actual = a == b;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Equals_100_abcd_AND_100_abcd_ReturnedTrue()
        {
            Node a = new(10, "abcd");
            Node b = new(10, "abcd");
            bool expected = true;

            bool actual = a == b;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Equals_10_null_AND_10_abcd_ReturnedFalse()
        {
            Node a = new(10, null);
            Node b = new(10, "abcd");
            bool expected = false;

            bool actual = a == b;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Equals_m10_abcd_AND_m10_abcd_ReturnedFalse()
        {
            Node a = new(-10, "abcd");
            Node b = new(10, "abcd");
            bool expected = false;

            bool actual = a == b;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Equals_m3457654635666_efvd40456fdg4vh479ogdfg_AND_9453345334570090_efvd40456fdg4vh479ogdfg_ReturnedFalse()
        {
            Node a = new(-3457654635666, "efvd40456fdg4vh479ogdfg");
            Node b = new(9453345334570090, "efvd40456fdg4vh479ogdfg");
            bool expected = false;

            bool actual = a == b;

            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region NotEquals

        [TestMethod]
        public void NotEquals_34_null_AND_34_null_ReturnedFalse()
        {
            Node a = new(34, null);
            Node b = new(34, null);
            bool expected = false;

            bool actual = a != b;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void NotEquals_567_45fdf_AND_567_45fdf_ReturnedFalse()
        {
            Node a = new(567, "45fdf");
            Node b = new(567, "45fdf");
            bool expected = false;

            bool actual = a != b;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void NotEquals_7_null_AND_7_gdeej_ReturnedTrue()
        {
            Node a = new(7, null);
            Node b = new(7, "gdeej");
            bool expected = true;

            bool actual = a != b;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void NotEquals_137_qwerty34343_AND_m137_qwerty34343_ReturnedTrue()
        {
            Node a = new(137, "qwerty34343");
            Node b = new(-137, "qwerty34343");
            bool expected = true;

            bool actual = a != b;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void NotEquals_m3457656753791_efvd4056456456384568448_AND_94533453645267_efvd5345345140_ReturnedTrue()
        {
            Node a = new(-457656753791, "efvd4056456456384568448");
            Node b = new(94533453645267, "efvd5345345140");
            bool expected = true;

            bool actual = a != b;

            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region Node

        [TestMethod]
        public void Node_0_null_ReturnedNullNullNull()
        {
            Node actual;
            int? expectedOperation = null;
            string? expectedCurrentHash = null;
            string? expectedPreviousHash = null;

            actual = new(0, null);

            Assert.AreEqual(expectedPreviousHash, actual.PreviousHash);
            Assert.AreEqual(expectedCurrentHash, actual.CurrentHash);
            Assert.AreEqual(expectedOperation, actual.Operation);

        }
        [TestMethod]
        public void Node_0_qwerty_ReturnedNullNullNull()
        {
            Node actual;
            int? expectedOperation = null;
            string? expectedCurrentHash = null;
            string? expectedPreviousHash = null;

            actual = new(0, "qwerty");

            Assert.AreEqual(expectedPreviousHash, actual.PreviousHash);
            Assert.AreEqual(expectedCurrentHash, actual.CurrentHash);
            Assert.AreEqual(expectedOperation, actual.Operation);
        }
        [TestMethod]
        public void Node_345_null_Returned345HashNull()
        {
            Node actual;
            int expectedOperation = 345;
            string? expectedCurrentHash = Node.Hash(345.ToString());
            string? expectedPreviousHash = null;

            actual = new(345, null);

            Assert.AreEqual(expectedPreviousHash, actual.PreviousHash);
            Assert.AreEqual(expectedCurrentHash, actual.CurrentHash);
            Assert.AreEqual(expectedOperation, actual.Operation);
        }
        [TestMethod]
        public void Node_345_sdfsdfds_Returned345HashHash()
        {
            Node actual;
            int expectedOperation = 345;
            string? expectedCurrentHash = Node.Hash(345.ToString());
            string? expectedPreviousHash = "sdfsdfds";

            actual = new(345, "sdfsdfds");

            Assert.AreEqual(expectedPreviousHash, actual.PreviousHash);
            Assert.AreEqual(expectedCurrentHash, actual.CurrentHash);
            Assert.AreEqual(expectedOperation, actual.Operation);
        }

        #endregion
    }
}