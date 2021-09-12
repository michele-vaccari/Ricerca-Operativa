using System;
using System.Collections.Generic;
using System.Linq;

namespace TSP
{
    public class Van
    {
        public Van(uint capacity,
                   Node startNode,
                   List<Transfer> transfersToDo)
        {
            Capacity = capacity;
            CurrentNode = startNode;
            TransfersToDo = transfersToDo;
            TransfersInProgress = new List<Transfer>();
            TransfersCompleted = new List<Transfer>();
        }

        public void GoTo(Node node)
        {
            CurrentNode = node;
        }

        public uint Delivery()
        {
            var transfersCompleted = new List<Transfer>();

            foreach (var transferInProgress in TransfersInProgress)
                if (CurrentNode.Name == transferInProgress.DestinationNodeName)
                    transfersCompleted.Add(transferInProgress);

            // remove completed transfers from loaded transfers
            foreach (var transferCompleted in transfersCompleted)
            {
                TransfersCompleted.Add(transferCompleted);
                TransfersInProgress.Remove(transferCompleted);
            }

            // returns the number of documents delivered
            uint documentsDelivered = 0;
            foreach (var transferCompleted in transfersCompleted)
                documentsDelivered += Convert.ToUInt32(transferCompleted.NumberOfDocuments);

            return documentsDelivered;
        }

        public uint PickUp()
        {
            if (AvailableSpace == 0)
                return 0;
            
            var transfersInProgress = new List<Transfer>();

            foreach (var transferToDo in TransfersToDo)
            {
                if (transferToDo.SourceNodeName == CurrentNode.Name)
                {
                    if (AvailableSpace == 0)
                        break;
                    else if (transferToDo.NumberOfDocuments <= AvailableSpace)
                        transfersInProgress.Add(transferToDo);
                    else
                    {
                        transfersInProgress.Add(new Transfer(transferToDo.SourceNodeName, transferToDo.DestinationNodeName, Convert.ToInt32(AvailableSpace)));
                        transferToDo.NumberOfDocuments -= Convert.ToInt32(AvailableSpace);
                        break;
                    }
                }
            }

            foreach (var transferInProgress in transfersInProgress)
            {
                // add transfers to be taken over
                TransfersInProgress.Add(transferInProgress);
                // remove transfers taken over
                TransfersToDo.Remove(transferInProgress);
            }

            // returns the number of documents picked up
            uint documentsPickedUp = 0;
            foreach (var transferInProgress in transfersInProgress)
                documentsPickedUp += Convert.ToUInt32(transferInProgress.NumberOfDocuments);

            return documentsPickedUp;
        }

        public uint Load
        {
            get
            {
                uint result = 0;
                foreach (var transfer in TransfersInProgress)
                    result += Convert.ToUInt32(transfer.NumberOfDocuments);

                return result;
            }
        }

        public List<string> NamesOfNodeToMakeThatHaveDocumentsToPickUp
        {
            get
            {
                return TransfersToDo.Select(transferToDo => transferToDo.SourceNodeName).Distinct().ToList();
            }
        }

        public uint Capacity { get; private set; }
        public uint AvailableSpace => Capacity - Load;

        public Node CurrentNode { get; private set; }

        public List<Transfer> TransfersToDo { get; private set; }
        public List<Transfer> TransfersInProgress { get; private set; }
        public List<Transfer> TransfersCompleted { get; private set; }
    }
}
