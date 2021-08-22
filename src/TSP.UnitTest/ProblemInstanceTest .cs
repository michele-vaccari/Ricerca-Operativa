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
		public void GivenProblemInstanceThenAllPropertiesAreConsistent()
		{
			var nodes = new List<Node>();
			var transfers = new List<Transfer>();
			uint vanCapacity = 5;

			var problemInstance = new ProblemInstance(nodes, transfers, vanCapacity);

			Assert.IsTrue(problemInstance.Nodes.Except(new List<Node>()).ToList().Count == 0 &&
						  problemInstance.Transfers.Except(new List<Transfer>()).ToList().Count == 0 &&
						  problemInstance.VanCapacity == 5);
		}

		[TestMethod]
        public void GivenNodesAndTransfersThenTotalDocumentsToTransferAreCalculatedSuccesfully()
        {
			var nodes = new List<Node>();
			nodes.Add(new Node("0", new Point(6, 7)));
			nodes.Add(new Node("1", new Point(9, 10)));
			nodes.Add(new Node("2", new Point(10, 7)));
			nodes.Add(new Node("3", new Point(4, 3)));
			nodes.Add(new Node("4", new Point(2, 10)));
			nodes.Add(new Node("5", new Point(10, 1)));

			var transfers = new List<Transfer>();
            transfers.Add(new Transfer("1", "2", 1));
            transfers.Add(new Transfer("1", "3", 2));
            transfers.Add(new Transfer("2", "1", 2));
            transfers.Add(new Transfer("3", "1", 1));
            transfers.Add(new Transfer("3", "2", 3));
            transfers.Add(new Transfer("4", "2", 1));
            transfers.Add(new Transfer("4", "3", 1));

			var problemInstance = new ProblemInstance(nodes, transfers, 5);

			Assert.IsTrue(problemInstance.TotalDocumentsToTransfer == 11);
        }
	}
}
