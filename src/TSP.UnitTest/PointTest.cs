using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TSP.UnitTest
{
    [TestClass]
    public class PointTest
    {
        [TestMethod]
        public void GivenTwoPointsWithSameValuesThenTwoPointsAreEqual()
        {
            var point1 = new Point(1, 1);
            var point2 = new Point(1, 1);

            Assert.IsTrue(point1 == point2);
        }

        [TestMethod]
        public void GivenTwoPointsWithDifferentValuesThenTwoPointsAreNotEqual()
        {
            var point1 = new Point(1, 1);
            var point2 = new Point(1, 2);

            Assert.IsTrue(point1 != point2);
        }

        [TestMethod]
        public void GivenTwoPointsWithDifferentValuesThenEuclideanDistanceIsCalculatedCorrectly()
        {
            var point1 = new Point(1, 1);
            var point2 = new Point(1, 2);

            Assert.IsTrue(point1.EuclideanDistance(point2) == 1);
        }
    }
}
