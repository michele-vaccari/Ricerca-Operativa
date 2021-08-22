using System;
using System.Collections.Generic;

namespace TSP
{
    public class Transfer : IEquatable<Transfer>
    {
        public Transfer(string sourceNodeName,
                        string destinationStopName,
                        int numberOfDocuments)
        {
            SourceNodeName = sourceNodeName;
            DestinationNodeName = destinationStopName;
            NumberOfDocuments = numberOfDocuments;
        }

        public string SourceNodeName { get; private set; }
        public string DestinationNodeName { get; private set; }
        public int NumberOfDocuments { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Transfer);
        }

        public bool Equals(Transfer other)
        {
            return other != null &&
                   SourceNodeName == other.SourceNodeName &&
                   DestinationNodeName == other.DestinationNodeName &&
                   NumberOfDocuments == other.NumberOfDocuments;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(SourceNodeName, DestinationNodeName, NumberOfDocuments);
        }

        public static bool operator ==(Transfer left, Transfer right)
        {
            return EqualityComparer<Transfer>.Default.Equals(left, right);
        }

        public static bool operator !=(Transfer left, Transfer right)
        {
            return !(left == right);
        }
    }
}
