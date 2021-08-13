using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TSP.UnitTest
{
    [TestClass]
    public class NodeTest
    {
        [TestMethod]
        public void GivenNodeThenAllPropertiesAreConsistent()
        {
            var stop = new Stop("Test", new Point(1, 1));
            var node = new Node(stop, 1, 1);

            Assert.IsTrue(node.Stop == new Stop("Test", new Point(1, 1)) &&
                          node.DocumentsToPickUp == 1 &&
                          node.DocumentsToDeliver == 1);
        }

        [TestMethod]
        public void GivenTwoNodesWithSameValuesThenTwoNodesAreEqual()
        {
            var stop1 = new Stop("Test", new Point(1, 1));
            var node1 = new Node(stop1, 1, 1);

            var stop2 = new Stop("Test", new Point(1, 1));
            var node2 = new Node(stop2, 1, 1);

            Assert.IsTrue(node1 == node2);
        }

        [TestMethod]
        public void GivenTwoPointsWithDifferentValuesThenTwoPointsAreNotEqual()
        {
            var stop1 = new Stop("Test", new Point(1, 1));
            var node1 = new Node(stop1, 1, 1);

            var stop2 = new Stop("Test", new Point(1, 1));
            var node2 = new Node(stop2, 2, 1);

            Assert.IsTrue(node1 != node2);
        }
    }
}
