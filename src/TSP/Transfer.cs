using System;
using System.Collections.Generic;

namespace TSP
{
    public class Transfer : IEquatable<Transfer>
    {
        public Transfer(string sourceStopName,
                        string destinationStopName,
                        int numberOfDocuments)
        {
            SourceStopName = sourceStopName;
            DestinationStopName = destinationStopName;
            NumberOfDocuments = numberOfDocuments;
        }

        public string SourceStopName { get; private set; }
        public string DestinationStopName { get; private set; }
        public int NumberOfDocuments { get; private set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Transfer);
        }

        public bool Equals(Transfer other)
        {
            return other != null &&
                   SourceStopName == other.SourceStopName &&
                   DestinationStopName == other.DestinationStopName &&
                   NumberOfDocuments == other.NumberOfDocuments;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(SourceStopName, DestinationStopName, NumberOfDocuments);
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
