using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TSP.UnitTest
{
    [TestClass]
    public class TxtNodesReaderTest
    {
        [TestMethod]
        public void GivenNodesInTxtFilesThenLoadAllNodesSuccesfully()
        {
            var txtNodesReader = new TxtNodesReader();
            var txtNodesFilePath = Path.Combine(Directory.GetCurrentDirectory(), @"Resources\nodes.txt");
            txtNodesReader.Load(txtNodesFilePath);

            var expectedResult = new List<Node>();
            expectedResult.Add(new Node("0", new Point(6, 7)));
            expectedResult.Add(new Node("1", new Point(9, 10)));
            expectedResult.Add(new Node("2", new Point(10, 7)));
            expectedResult.Add(new Node("3", new Point(4, 3)));
            expectedResult.Add(new Node("4", new Point(2, 10)));
            expectedResult.Add(new Node("5", new Point(10, 1)));

            Assert.IsTrue(txtNodesReader.Load(txtNodesFilePath).Except(expectedResult).ToList().Count == 0);
        }
    }
}
