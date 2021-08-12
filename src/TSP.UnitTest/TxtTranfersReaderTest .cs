using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TSP.UnitTest
{
    [TestClass]
    public class TxtTransfersReaderTest
    {
        [TestMethod]
        public void GivenTransfersInTxtFilesThenLoadAllTransfersSuccesfully()
        {
            var txtTransfersReader = new TxtTransfersReader();
            var txtTransfersFilePath = Path.Combine(Directory.GetCurrentDirectory(), @"Resources\transfers.txt");
            txtTransfersReader.Load(txtTransfersFilePath);

            var expectedResult = new List<Transfer>();
            expectedResult.Add(new Transfer("1", "2", 1));
            expectedResult.Add(new Transfer("1", "3", 2));
            expectedResult.Add(new Transfer("2", "1", 2));
            expectedResult.Add(new Transfer("3", "1", 1));
            expectedResult.Add(new Transfer("3", "2", 3));
            expectedResult.Add(new Transfer("4", "2", 1));
            expectedResult.Add(new Transfer("4", "3", 1));

            Assert.IsTrue(txtTransfersReader.Load(txtTransfersFilePath).Except(expectedResult).ToList().Count == 0);
        }
    }
}
