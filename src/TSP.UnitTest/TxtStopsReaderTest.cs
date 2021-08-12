using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TSP.UnitTest
{
    [TestClass]
    public class TxtStopsReaderTest
    {
        [TestMethod]
        public void GivenStopsInTxtFilesThenLoadAllStopsSuccesfully()
        {
            var txtStopsReader = new TxtStopsReader();
            var txtStopsFilePath = Path.Combine(Directory.GetCurrentDirectory(), @"Resources\stops.txt");
            txtStopsReader.Load(txtStopsFilePath);

            var expectedResult = new List<Stop>();
            expectedResult.Add(new Stop("0", new Point(6, 7)));
            expectedResult.Add(new Stop("1", new Point(9, 10)));
            expectedResult.Add(new Stop("2", new Point(10, 7)));
            expectedResult.Add(new Stop("3", new Point(4, 3)));
            expectedResult.Add(new Stop("4", new Point(2, 10)));
            expectedResult.Add(new Stop("5", new Point(10, 1)));

            Assert.IsTrue(txtStopsReader.Load(txtStopsFilePath).Except(expectedResult).ToList().Count == 0);
        }
    }
}
