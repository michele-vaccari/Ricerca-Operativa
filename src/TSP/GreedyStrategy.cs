using System;
using System.Collections.Generic;
using System.Linq;

namespace TSP
{
    public class GreedyStrategy
    {
        public GreedyStrategy(ProblemInstance problemInstance)
        {
            ProblemInstance = problemInstance;
            Van = new Van(5, problemInstance.Nodes.FirstOrDefault(), problemInstance.Transfers);
        }

        public void ComputeSteps()
        {
            var step = 0;
            SolutionNodes = new List<Node>();
            SolutionNodes.Add(Van.CurrentNode);

            // other steps
            while (Van.TransfersToDo.Count != 0 ||
                   Van.TransfersInProgress.Count != 0)
            {
                ++step;

                var border = GetBorder();
                var nearestNode = GetNearest(Van.CurrentNode, border);
                Van.GoTo(nearestNode);

                SolutionNodes.Add(Van.CurrentNode);

                Van.Delivery();

                Van.PickUp();
            }

            // last step: return to start point
            SolutionNodes.Add(SolutionNodes.FirstOrDefault());
        }

        private List<Node> GetBorder()
        {
            var border = new List<Node>();
            if (Van.TransfersInProgress.Count == 0)
            {
                // GreedyAdmissibilityTest
                foreach (var node in ProblemInstance.Nodes)
                    foreach (var nodeName in Van.NamesOfNodeToMakeThatHaveDocumentsToPickUp)
                        if (nodeName == node.Name)
                            border.Add(node);
            }
            else
            {
                foreach (var node in ProblemInstance.Nodes)
                    foreach (var transferInProgress in Van.TransfersInProgress)
                        if (transferInProgress.DestinationNodeName == node.Name)
                            border.Add(node);
            }
            return border;
        }

        private Node GetNearest(Node currentNode, List<Node> nodes)
        {
            if (nodes.Count == 0)
                return currentNode;

            var minimumDistance = currentNode.EclideanDistance(nodes.First());
            var candidateNode = nodes.First();
            nodes.Remove(candidateNode);

            foreach (var node in nodes)
            {
                var euclideanDistance = currentNode.EclideanDistance(node);
                if (euclideanDistance < minimumDistance)
                {
                    minimumDistance = euclideanDistance;
                    candidateNode = node;
                }
            }

            return candidateNode;
        }

        public ProblemInstance ProblemInstance { get; private set; }
        public Van Van { get; private set; }
        public List<Node> SolutionNodes { get; private set; }
    }
}
