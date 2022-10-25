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
        public void Equals_m34576_efvd40_AND_94533453_efvd40_false()
        {
            // Arrange.
            Node a = new(-34576, "efvd40");
            Node b = new(94533453, "efvd40");
            bool expected = false;

            // Act.
            bool actual = a == b;

            // Assert.
            Assert.AreEqual(expected, actual);
        }
    }
}