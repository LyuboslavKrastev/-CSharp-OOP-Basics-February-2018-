using System;
using System.Collections.Generic;
using System.Linq;

namespace _06_FootballTeamGenerator
{
    class Program
    {
        static void Main(string[] args)
        {

            string input;
            var teams = new List<Team>();

            while ((input = Console.ReadLine()) != "END")
            {
                try
                {
                    var tokens = input.Split(';');
                    var command = tokens[0];
                    switch (command)
                    {
                        case "Team":

                            var teamName = tokens[1];
                            if (FindTeam(teams, teamName) == null)
                            {
                                teams.Add(new Team(teamName));
                            }
                            break;

                        case "Add":

                            teamName = tokens[1];
                            Team currentTeam = FindTeam(teams, teamName);

                            if (currentTeam == null)
                            {
                                NonExistentTeamError(teamName);
                                continue;
                            }

                            var playerName = tokens[2];

                            var endurance = int.Parse(tokens[3]);
                            var sprint = int.Parse(tokens[4]);
                            var dribble = int.Parse(tokens[5]);
                            var passing = int.Parse(tokens[6]);
                            var shooting = int.Parse(tokens[7]);

                            var player = new Player(playerName, new Stats(endurance, sprint, dribble, passing, shooting));
                            currentTeam.Players.Add(player);
                            break;

                        case "Remove":

                            teamName = tokens[1];
                            currentTeam = FindTeam(teams, teamName);
                            playerName = tokens[2];

                            if (currentTeam == null)
                            {
                                NonExistentTeamError(teamName);
                                continue;
                            }

                            Player playerToBeRemoved = FindPlayer(currentTeam, playerName);

                            if (playerToBeRemoved == null)
                            {
                                NoneExistentPlayerError(teamName, playerName);
                                continue;
                            }

                            currentTeam.Players.Remove(playerToBeRemoved);

                            break;

                        case "Rating":
                            teamName = tokens[1];
                            currentTeam = FindTeam(teams, teamName);

                            if (currentTeam == null)
                            {
                                NonExistentTeamError(teamName);
                                continue;
                            }
                            Console.WriteLine(currentTeam);
                            break;
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static Player FindPlayer(Team currentTeam, string playerName)
        {
            return currentTeam.Players.FirstOrDefault(p => p.Name == playerName);
        }

        private static void NoneExistentPlayerError(string teamName, string playerName)
        {
            Console.WriteLine($"Player {playerName} is not in {teamName} team.");
        }

        private static void NonExistentTeamError(string teamName)
        {
            Console.WriteLine($"Team {teamName} does not exist.");
        }

        private static Team FindTeam(List<Team> teams, string teamName)
        {
            return teams.FirstOrDefault(t => t.Name == teamName);
        }
    }
}
