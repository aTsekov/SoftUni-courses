using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _005___________Teamwork_Projects
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numOfTeams = int.Parse(Console.ReadLine());
            List<Team> teamList = new List<Team>();

            

            for (int i = 0; i < numOfTeams; i++)
            {
                string[] teamInfo = Console.ReadLine().Split('-',StringSplitOptions.RemoveEmptyEntries).ToArray();

                string creator = teamInfo[0];
                string teamName1 = teamInfo[1];
                if (teamList.Any(t => t.TeamName == teamName1))
                {
                    Console.WriteLine($"Team {teamName1} was already created!");
                    continue;
                }
                if (teamList.Any(t => t.TeamCreator == creator))
                {
                    Console.WriteLine($"{creator} cannot create another team!");
                    continue;
                }
                
                    Team newTeam = new Team(creator, teamName1);

                    teamList.Add(newTeam);
                    Console.WriteLine($"Team {teamName1} has been created by {creator}!");
               
                

            }

            string[] addToTeam = Console.ReadLine().Split("->", StringSplitOptions.RemoveEmptyEntries).ToArray();
            

            while (addToTeam[0] != "end of assignment")
            {
                string memberName = addToTeam[0];
                string teamName = addToTeam[1];
                Team searchedTeam = teamList.FirstOrDefault(t => t.TeamName == teamName);

                if (searchedTeam == null)
                {
                    Console.WriteLine($"Team {teamName} does not exist!");
                    //continue;
                }


                if (IsAlreadyMemberOfTeam(teamList, memberName))
                {
                    Console.WriteLine($"Member {memberName} cannot join team {teamName}!");
                    //continue;
                }

                if (teamList.Any(t => t.TeamCreator == memberName))
                {
                    //Creator of a team cannot be a member of another team
                    Console.WriteLine($"Member {memberName} cannot join team {teamName}!");
                    //continue;
                }
                addToTeam = Console.ReadLine().Split("->", StringSplitOptions.RemoveEmptyEntries).ToArray();

                searchedTeam.AddMember(memberName);
            }

            List<Team> teamsWithMembers = teamList
                .Where(t => t.Members.Count > 0)
                .OrderByDescending(t => t.Members.Count)
                .ThenBy(t => t.TeamName)
                .ToList();
            List<Team> teamsToDisband = teamList
                .Where(t => t.Members.Count == 0)
                .OrderBy(t => t.TeamName)
                .ToList();

            PrintValidTeams(teamsWithMembers);
            PrintInvalidTeams(teamsToDisband);
        }
        static bool IsAlreadyMemberOfTeam(List<Team> teams, string memberName)
        {
            foreach (Team team in teams)
            {
                if (team.Members.Contains(memberName))
                {
                    return true;
                }
            }

            return false;
        }

        static void PrintValidTeams(List<Team> validTeams)
        {
            foreach (Team validTeam in validTeams)
            {
                Console.WriteLine($"{validTeam.TeamName}");
                Console.WriteLine($"- {validTeam.TeamCreator}");

                foreach (string currMember in validTeam.Members.OrderBy(m => m))
                {
                    Console.WriteLine($"-- {currMember}");
                }
            }

          
        }

        //This is the way for printing invalid objects
        static void PrintInvalidTeams(List<Team> invalidTeams)
        {
            Console.WriteLine("Teams to disband:");
            foreach (Team invalidTeam in invalidTeams)
            {
                Console.WriteLine($"{invalidTeam.TeamName}");
            }
        }

       
    }
}
    class Team
    {
        public Team(string creator, string teamName)
        {
            this.TeamCreator = creator;
            this.TeamName = teamName;

            this.Members = new List<string>(); // инициализирам си листа в конструктора

        }
        public string TeamCreator { get; set; }
        public string TeamName { get; set; }
        public List<string> Members { get; set; }

        public void AddMember(string member)
        {
            //There may be some validations!!!
            this.Members.Add(member);
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.TeamName}");
            sb.AppendLine($"- {this.TeamCreator}");

            foreach (string currMember in this.Members.OrderBy(m => m))
            {
                sb.AppendLine($"-- {currMember}");
            }

            return sb.ToString().TrimEnd();
        }

    }

