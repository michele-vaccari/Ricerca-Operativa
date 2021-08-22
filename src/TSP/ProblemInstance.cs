using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSP
{
    public class ProblemInstance
    {
        public ProblemInstance(List<Node> nodes,
                               List<Transfer> transfers,
                               uint vanCapacity)
        {
            Nodes = nodes;
            Transfers = transfers;
            VanCapacity = vanCapacity;
        }

        public int TotalDocumentsToTransfer
        {
            get
            {
                var result = 0;

                foreach (var transfer in Transfers)
                    result += transfer.NumberOfDocuments;

                return result;
            }
        }

        public List<Node> Nodes { get; private set; }
        public List<Transfer> Transfers { get; private set; }
        public uint VanCapacity { get; private set; }
    }
}
