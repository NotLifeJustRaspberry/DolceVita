namespace Blockchain.Tests
{
    [TestClass]
    public class NodeTests
    {
        [TestMethod]
        public void Equals_10_null_AND_10_null_true()
        {
            // Arrange.
            Node a = new(10, null);
            Node b = new(10, null);
            bool expected = true;

            // Act.
            bool actual = a == b;

            // Assert.
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Equals_100_abcd_AND_100_abcd_true()
        {
            // Arrange.
            Node a = new(10, "abcd");
            Node b = new(10, "abcd");
            bool expected = true;

            // Act.
            bool actual = a == b;

            // Assert.
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Equals_10_null_AND_10_abcd_false()
        {
            // Arrange.
            Node a = new(10, null);
            Node b = new(10, "abcd");
            bool expected = false;

            // Act.
            bool actual = a == b;

            // Assert.
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Equals_m10_abcd_AND_m10_abcd_false()
        {
            // Arrange.
            Node a = new(-10, "abcd");
            Node b = new(10, "abcd");
            bool expected = false;

            // Act.
            bool actual = a == b;

            // Assert.
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Equals_m3457654635666_efvd40456fdg4vh479ogdfg_AND_9453345334570090_efvd40456fdg4vh479ogdfg_false()
        {
            // Arrange.
            Node a = new(-3457654635666, "efvd40456fdg4vh479ogdfg");
            Node b = new(9453345334570090, "efvd40456fdg4vh479ogdfg");
            bool expected = false;

            // Act.
            bool actual = a == b;

            // Assert.
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NotEquals_34_null_AND_34_null_false()
        {
            // Arrange.
            Node a = new(34, null);
            Node b = new(34, null);
            bool expected = false;

            // Act.
            bool actual = a != b;

            // Assert.
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void NotEquals_567_45fdf_AND_567_45fdf_false()
        {
            // Arrange.
            Node a = new(567, "45fdf");
            Node b = new(567, "45fdf");
            bool expected = false;

            // Act.
            bool actual = a != b;

            // Assert.
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void NotEquals_7_null_AND_7_gdeej_true()
        {
            // Arrange.
            Node a = new(7, null);
            Node b = new(7, "gdeej");
            bool expected = true;

            // Act.
            bool actual = a != b;

            // Assert.
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void NotEquals_137_qwerty34343_AND_m137_qwerty34343_true()
        {
            // Arrange.
            Node a = new(137, "qwerty34343");
            Node b = new(-137, "qwerty34343");
            bool expected = true;

            // Act.
            bool actual = a != b;

            // Assert.
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void NotEquals_m3457656753791_efvd4056456456384568448_AND_94533453645267_efvd5345345140_true()
        {
            // Arrange.
            Node a = new(-457656753791, "efvd4056456456384568448");
            Node b = new(94533453645267, "efvd5345345140");
            bool expected = true;

            // Act.
            bool actual = a != b;

            // Assert.
            Assert.AreEqual(expected, actual);
        }
    }
}