using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TSP.UnitTest
{
    [TestClass]
    public class TranferTest
    {
        [TestMethod]
        public void GivenTwoTranfersWithSameValuesThenTwoTransfersAreEqual()
        {
            var transfer1 = new Transfer("Test", "Test", 1);
            var transfer2 = new Transfer("Test", "Test", 1);

            Assert.IsTrue(transfer1 == transfer2);
        }

        [TestMethod]
        public void GivenTwoTranfersWithDifferentValuesThenTwoTransfersAreNotEqual()
        {
            var transfer1 = new Transfer("Test", "Test", 1);
            var transfer2 = new Transfer("Test", "Test", 2);

            Assert.IsTrue(transfer1 != transfer2);
        }
    }
}
