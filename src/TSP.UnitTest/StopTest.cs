using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TSP.UnitTest
{
    [TestClass]
    public class StopTest
    {
        [TestMethod]
        public void GivenTwoStopsWithSameValuesThenTwoStopsAreEqual()
        {
            var stop1 = new Stop("Test", new Point(1,1));
            var stop2 = new Stop("Test", new Point(1, 1));

            Assert.IsTrue(stop1 == stop2);
        }

        [TestMethod]
        public void GivenTwoStopsWithDifferentValuesThenTwoStopsAreNotEqual()
        {
            var stop1 = new Stop("Test1", new Point(1, 1));
            var stop2 = new Stop("Test", new Point(1, 1));

            Assert.IsTrue(stop1 != stop2);
        }
    }
}
