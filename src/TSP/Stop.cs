using System;
using System.Collections.Generic;

namespace TSP
{
    public class Stop : IEquatable<Stop>
    {
        public Stop(string name, Point point)
        {
            Name = name;
            Point = point;
        }

        public string Name { get; private set; }
        public Point Point { get; private set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Stop);
        }

        public bool Equals(Stop other)
        {
            return other != null &&
                   Name == other.Name &&
                   EqualityComparer<Point>.Default.Equals(Point, other.Point);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Point);
        }

        public static bool operator ==(Stop left, Stop right)
        {
            return EqualityComparer<Stop>.Default.Equals(left, right);
        }

        public static bool operator !=(Stop left, Stop right)
        {
            return !(left == right);
        }
    }
}
