using System;
using System.Collections.Generic;
using System.Linq;

namespace TSP
{
    public class TxtStopsReader
    {
        public TxtStopsReader()
        {
        }

        public List<Stop> Load(string filePath)
        {
            stops = new List<Stop>();
            ReadStopFromFile(filePath);
            return stops;
        }

        private void ReadStopFromFile(string filePath)
        {
            string line;
            var streamReader = new System.IO.StreamReader(filePath);
            while ((line = streamReader.ReadLine()) != null)
                stops.Add(ParseLineToStop(line));

            streamReader.Close();
        }
        private Stop ParseLineToStop(string line)
        {
            var splitted = line.Split(' ');
            var x = int.Parse(splitted[1]);
            var y = int.Parse(splitted[2]);
            return new Stop(splitted[0], new Point(x, y));
        }

        private List<Stop> stops;
    }
}
