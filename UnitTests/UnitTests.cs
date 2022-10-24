using Microsoft.Win32.SafeHandles;

namespace Blockchain
{
    [TestClass]
    public class NodeTests
    {
        [TestMethod]
        public static void Eq_10_null_AND_10_null_true()
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
    }
}