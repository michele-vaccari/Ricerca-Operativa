using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TSP.UnitTest
{
    [TestClass]
    public class GreedyStrategyTest
	{
        [TestMethod]
        public void GivenProblemInstanceThenGreedySuccesfully()
        {
			var stops = new List<Node>();
			stops.Add(new Node("0", new Point(6, 7)));
			stops.Add(new Node("1", new Point(9, 10)));
			stops.Add(new Node("2", new Point(10, 7)));
			stops.Add(new Node("3", new Point(4, 3)));
			stops.Add(new Node("4", new Point(2, 10)));
			stops.Add(new Node("5", new Point(10, 1)));

			var transfers = new List<Transfer>();
            transfers.Add(new Transfer("1", "2", 1));
            transfers.Add(new Transfer("1", "3", 2));
            transfers.Add(new Transfer("2", "1", 2));
            transfers.Add(new Transfer("3", "1", 1));
            transfers.Add(new Transfer("3", "2", 3));
            transfers.Add(new Transfer("4", "2", 1));
            transfers.Add(new Transfer("4", "3", 1));

			var problemInstance = new ProblemInstance(stops, transfers, 5);

			var greedyStrategy = new GreedyStrategy(problemInstance);
			greedyStrategy.ComputeSteps();

			var expectedResult = new List<Node>();
			expectedResult.Add(new Node("0", new Point(6, 7)));
			expectedResult.Add(new Node("2", new Point(10, 7)));
			expectedResult.Add(new Node("1", new Point(9, 10)));
			expectedResult.Add(new Node("2", new Point(10, 7)));
			expectedResult.Add(new Node("3", new Point(4, 3)));
			expectedResult.Add(new Node("2", new Point(10, 7)));
			expectedResult.Add(new Node("1", new Point(9, 10)));
			expectedResult.Add(new Node("4", new Point(2, 10)));
			expectedResult.Add(new Node("3", new Point(4, 3)));
			expectedResult.Add(new Node("2", new Point(10, 7)));
			expectedResult.Add(new Node("0", new Point(6, 7)));

			var result = greedyStrategy.SolutionNodes;

			Assert.IsTrue(result.Except(expectedResult).ToList().Count == 0);
        }
	}
}
