using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSP
{
    public class Node : IEquatable<Node>
    {
        public Node(Stop stop,
                    int documentsToPickUp,
                    int documentsToDeliver)
        {
            Stop = stop;
            DocumentsToPickUp = documentsToPickUp;
            DocumentsToDeliver = documentsToDeliver;
        }

        public Stop Stop { get; private set; }
        public int DocumentsToPickUp { get; private set; }
        public int DocumentsToDeliver { get; private set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Node);
        }

        public bool Equals(Node other)
        {
            return other != null &&
                   EqualityComparer<Stop>.Default.Equals(Stop, other.Stop) &&
                   DocumentsToPickUp == other.DocumentsToPickUp &&
                   DocumentsToDeliver == other.DocumentsToDeliver;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Stop, DocumentsToPickUp, DocumentsToDeliver);
        }

        public static bool operator ==(Node left, Node right)
        {
            return EqualityComparer<Node>.Default.Equals(left, right);
        }

        public static bool operator !=(Node left, Node right)
        {
            return !(left == right);
        }
    }
}
