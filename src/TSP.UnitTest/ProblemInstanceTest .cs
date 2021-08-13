using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TSP.UnitTest
{
    [TestClass]
    public class ProblemInstanceTest
    {
        [TestMethod]
        public void GivenStopsAndTransfersThenNodesAreGeneratedSuccesfully()
        {
			var stops = new List<Stop>();
			stops.Add(new Stop("0", new Point(6, 7)));
			stops.Add(new Stop("1", new Point(9, 10)));
			stops.Add(new Stop("2", new Point(10, 7)));
			stops.Add(new Stop("3", new Point(4, 3)));
			stops.Add(new Stop("4", new Point(2, 10)));
			stops.Add(new Stop("5", new Point(10, 1)));

			var transfers = new List<Transfer>();
            transfers.Add(new Transfer("1", "2", 1));
            transfers.Add(new Transfer("1", "3", 2));
            transfers.Add(new Transfer("2", "1", 2));
            transfers.Add(new Transfer("3", "1", 1));
            transfers.Add(new Transfer("3", "2", 3));
            transfers.Add(new Transfer("4", "2", 1));
            transfers.Add(new Transfer("4", "3", 1));

			var expectedResult = new List<Node>();
			expectedResult.Add(new Node(new Stop("0", new Point(6, 7)), 0, 0));
			expectedResult.Add(new Node(new Stop("1", new Point(9, 10)), 3, 3));
			expectedResult.Add(new Node(new Stop("2", new Point(10, 7)), 2, 5));
			expectedResult.Add(new Node(new Stop("3", new Point(4, 3)), 4, 3));
			expectedResult.Add(new Node(new Stop("4", new Point(2, 10)), 2, 0));
			expectedResult.Add(new Node(new Stop("5", new Point(10, 1)), 0, 0));

			var problemInstance = new ProblemInstance(stops, transfers);

			Assert.IsTrue(problemInstance.Nodes.Except(expectedResult).ToList().Count == 0);
        }

		[TestMethod]
		public void GivenStopsAndTransfersThenTotalDocumentsToDeliverIsCalculatedCorrectly()
		{
			var stops = new List<Stop>();
			stops.Add(new Stop("0", new Point(6, 7)));
			stops.Add(new Stop("1", new Point(9, 10)));
			stops.Add(new Stop("2", new Point(10, 7)));
			stops.Add(new Stop("3", new Point(4, 3)));
			stops.Add(new Stop("4", new Point(2, 10)));
			stops.Add(new Stop("5", new Point(10, 1)));

			var transfers = new List<Transfer>();
			transfers.Add(new Transfer("1", "2", 1));
			transfers.Add(new Transfer("1", "3", 2));
			transfers.Add(new Transfer("2", "1", 2));
			transfers.Add(new Transfer("3", "1", 1));
			transfers.Add(new Transfer("3", "2", 3));
			transfers.Add(new Transfer("4", "2", 1));
			transfers.Add(new Transfer("4", "3", 1));

			var problemInstance = new ProblemInstance(stops, transfers);

			Assert.IsTrue(problemInstance.TotalDocumentsToDeliver == 11);
		}
	}
}
