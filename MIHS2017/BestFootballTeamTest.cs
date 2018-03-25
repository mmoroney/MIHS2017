using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Text;

namespace MIHS2017
{
    [TestClass]
    public class BestFootballTeamTest
    {
        [TestMethod]
        public void TestBestFootballTeam()
        {
            Assert.AreEqual(
@"Thunderstrikes 3/0
Gorillas 0/2
Termites 2/1
Earthquakes 1/1
Waves 1/1
Emperors 0/2
",
            BestFootballTeam(new string[] {
                "Thunderstrikes Gorillas",
                "Termites Earthquakes",
                "Waves Emperors",
                "Earthquakes Gorillas",
                "Thunderstrikes Waves",
                "Termites Emperors",
                "Thunderstrikes Termites" }));
        }

        public static string BestFootballTeam(string[] games)
        {
            List<string> names = new List<string>();
            Dictionary<string, Team> teams = new Dictionary<string, Team>();

            foreach (string game in games)
            {
                string[] tokens = game.Split(' ');
                string winnerName = tokens[0];

                Team winner = getTeam(tokens[0], teams, names);
                winner.Wins++;

                Team loser = getTeam(tokens[1], teams, names);
                loser.Losses++;
            }

            StringBuilder sb = new StringBuilder();
            foreach(string name in names)
            {
                Team team = teams[name];
                sb.AppendLine(string.Format("{0} {1}/{2}", team.Name, team.Wins, team.Losses));
            }

            return sb.ToString();
        }

        private static Team getTeam(string name, Dictionary<string, Team> teams, List<string> order)
        {
            Team team;
            if (!teams.TryGetValue(name, out team))
            {
                team = new Team();
                team.Name = name;
                teams[name] = team;
                order.Add(name);
            }

            return team;
        }

        private class Team
        {
            public string Name { get; set; }
            public int Wins { get; set; }
            public int Losses { get; set; }
            public int Order { get; set; }
        }
    }
}
