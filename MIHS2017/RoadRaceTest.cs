using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Text;

namespace MIHS2017
{
    [TestClass]
    public class RoadRaceTest
    {
        [TestMethod]
        public void TestRoadRace()
        {
            Assert.AreEqual("Seattle Phoenix Dallas Miami 38", RoadRace(new string[] {
                "Boise Detroit 13",
                "Seattle Sacramento 10",
                "Phoenix Dallas 18",
                "Detroit Sacramento 15",
                "Seattle Portland 5",
                "Miami Detroit 14",
                "Dallas Miami 8",
                "Phoenix Seattle 12",
                "Dallas Boise 7"
            }));
        }

        public string RoadRace(string[] input)
        {
            List<Vertex> vertices = new List<Vertex>();
            List<Edge> edges = new List<Edge>();

            foreach(string s in input)
            {
                string[] tokens = s.Split(' ');
                AddVertex(tokens[0], vertices);
                AddVertex(tokens[1], vertices);
                edges.Add(new Edge { Source = tokens[0], Destination = tokens[1], Distance = int.Parse(tokens[2]) });
            }

            Vertex start = vertices.First(v => v.Name == "Seattle");
            start.Distance = 0;

            for(int i = 0; i < vertices.Count - 1; i++)
            {
                foreach(Edge edge in edges)
                {
                    Vertex source = vertices.First(v => v.Name == edge.Source);
                    Vertex destination = vertices.First(v => v.Name == edge.Destination);

                    Relax(source, destination, edge);
                    Relax(destination, source, edge);
                }
            }

            StringBuilder sb = new StringBuilder();

            Vertex current = vertices.First(v => v.Name == "Miami");
            sb.Append(current.Name + " " + current.Distance.ToString());

            while(!string.IsNullOrEmpty(current.Predecessor))
            {
                sb.Insert(0, " ");
                current = vertices.First(v => v.Name == current.Predecessor);
                sb.Insert(0, current.Name);
            }

            return sb.ToString();
        }

        private class Edge
        {
            public string Source;
            public string Destination;
            public int Distance;
        }

        private class Vertex
        {
            public string Name;
            public int Distance;
            public string Predecessor;
        }

        private static void AddVertex(string name, List<Vertex> vertices)
        {
            if(!vertices.Any(v => v.Name == name))
                vertices.Add(new Vertex { Name = name, Distance = int.MaxValue, Predecessor = string.Empty });
        }

        private static void Relax(Vertex source, Vertex destination, Edge edge)
        {
            if (source.Distance != int.MaxValue && destination.Distance > source.Distance + edge.Distance)
            {
                destination.Distance = source.Distance + edge.Distance;
                destination.Predecessor = source.Name;
            }
        }
    }
}
