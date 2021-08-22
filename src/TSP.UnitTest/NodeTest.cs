using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TSP.UnitTest
{
    [TestClass]
    public class NodeTest
    {
        [TestMethod]
        public void GivenNodeThenAllPropertiesAreConsistent()
        {
            var node = new Node("Test", new Point(1, 1));

            Assert.IsTrue(node.Name == "Test" &&
                          node.Point == new Point(1, 1));
        }

        [TestMethod]
        public void GivenTwoNodesWithSameValuesThenTwoNodesAreEqual()
        {
            var node1 = new Node("Test", new Point(1,1));
            var node2 = new Node("Test", new Point(1, 1));

            Assert.IsTrue(node1 == node2);
        }

        [TestMethod]
        public void GivenTwoNodesWithDifferentValuesThenTwoNodesAreNotEqual()
        {
            var node1 = new Node("Test1", new Point(1, 1));
            var stop2 = new Node("Test", new Point(1, 1));

            Assert.IsTrue(node1 != stop2);
        }

        [TestMethod]
        public void GivenTwoNodesThenEuclideanDistanceIsCalculatedCorrectly()
        {
            var point1 = new Point(1, 1);
            var point2 = new Point(1, 2);

            Assert.IsTrue(point1.EuclideanDistance(point2) == 1);
        }
    }
}
