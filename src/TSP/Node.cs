using System;
using System.Collections.Generic;

namespace TSP
{
    public class Node : IEquatable<Node>
    {
        public Node(string name, Point point)
        {
            Name = name;
            Point = point;
        }

        public string Name { get; private set; }
        public Point Point { get; private set; }

        public double EclideanDistance(Node other)
        {
            return Point.EuclideanDistance(other.Point);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Node);
        }

        public bool Equals(Node other)
        {
            return other != null &&
                   Name == other.Name &&
                   EqualityComparer<Point>.Default.Equals(Point, other.Point);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Point);
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
