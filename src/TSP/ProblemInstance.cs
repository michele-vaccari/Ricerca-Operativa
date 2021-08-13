using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSP
{
    public class ProblemInstance
    {
        public ProblemInstance(List<Stop> stops,
                               List<Transfer> transfers)
        {
            Nodes = GenerateNodes(stops, transfers);
        }

        public int TotalDocumentsToDeliver
        {
            get
            {
                var result = 0;

                foreach (var node in Nodes)
                    result += node.DocumentsToDeliver;

                return result;
            }
        }

        public List<Node> Nodes { get => nodes; private set => nodes = value; }
        private List<Node> nodes;
        private List<Node> GenerateNodes(List<Stop> stops,
                                         List<Transfer> transfers)
        {
            Nodes = new List<Node>();

            foreach (var stop in stops)
                Nodes.Add(GenerateNode(stop, transfers));

            return Nodes;
        }

        private Node GenerateNode(Stop stop, List<Transfer> transfers)
        {
            var documentsToPickUp = 0;
            var documentsToDeliver = 0;
            foreach (var transfer in transfers)
            {
                if (transfer.SourceStopName == stop.Name)
                    documentsToPickUp += transfer.NumberOfDocuments;
                else if (transfer.DestinationStopName == stop.Name)
                    documentsToDeliver += transfer.NumberOfDocuments;
            }

            return new Node(stop, documentsToPickUp, documentsToDeliver);
        }
    }
}
