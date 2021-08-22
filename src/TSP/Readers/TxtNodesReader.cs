using System;
using System.Collections.Generic;
using System.Linq;

namespace TSP
{
    public class TxtNodesReader
    {
        public TxtNodesReader()
        {
        }

        public List<Node> Load(string filePath)
        {
            nodes = new List<Node>();
            ReadNodesFromFile(filePath);
            return nodes;
        }

        private void ReadNodesFromFile(string filePath)
        {
            string line;
            var streamReader = new System.IO.StreamReader(filePath);
            while ((line = streamReader.ReadLine()) != null)
                nodes.Add(ParseLineToNode(line));

            streamReader.Close();
        }
        private Node ParseLineToNode(string line)
        {
            var splitted = line.Split(' ');
            var x = int.Parse(splitted[1]);
            var y = int.Parse(splitted[2]);
            return new Node(splitted[0], new Point(x, y));
        }

        private List<Node> nodes;
    }
}
