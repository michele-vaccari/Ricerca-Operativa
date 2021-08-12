using System;
using System.Collections.Generic;
using System.Linq;

namespace TSP
{
    public class TxtTransfersReader
    {
        public TxtTransfersReader()
        {
        }

        public List<Transfer> Load(string filePath)
        {
            transfers = new List<Transfer>();
            ReadTransfersFromFile(filePath);
            return transfers;
        }

        private void ReadTransfersFromFile(string filePath)
        {
            string line;
            var streamReader = new System.IO.StreamReader(filePath);
            while ((line = streamReader.ReadLine()) != null)
                transfers.Add(ParseLineToTransfer(line));

            streamReader.Close();
        }
        private Transfer ParseLineToTransfer(string line)
        {
            var splitted = line.Split(' ');
            return new Transfer(splitted[0],
                                splitted[1],
                                int.Parse(splitted[2]));
        }

        private List<Transfer> transfers;
    }
}
