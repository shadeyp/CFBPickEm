using CFBPickEm.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFBPickEm.Core.Repository
{
    public class CFBRepository
    {
        private static List<Conference> conferences = new List<Conference>() {
            new Conference() {
               ConferenceId = 1, ConferenceName= "Big Ten West", ConferenceDeleted = false, ConferenceTeams = new List<Team>()
               {
                   new Team()
                   {
                       TeamId = 1,
                       TeamDeleted = false,
                       TeamName = "Nebraska",
                       TeamNickName = "Cornhuskers",
                       ConferenceId = 1
                   },
                   new Team()
                   {
                       TeamId = 2,
                       TeamDeleted = false,
                       TeamName = "Iowa",
                       TeamNickName = "Hawkeyes",
                       ConferenceId = 1
                   },
                   new Team()
                   {
                       TeamId = 3,
                       TeamDeleted = false,
                       TeamName = "Minnesota",
                       TeamNickName = "Gophers",
                       ConferenceId = 1
                   }
               }
            },
            new Conference() {
               ConferenceId = 2, ConferenceName= "Big Ten East", ConferenceDeleted = false, ConferenceTeams = new List<Team>()
               {
                   new Team()
                   {
                       TeamId = 4,
                       TeamDeleted = false,
                       TeamName = "Ohio State",
                       TeamNickName = "Buckeyes",
                       ConferenceId = 2
                   },
                   new Team()
                   {
                       TeamId = 5,
                       TeamDeleted = false,
                       TeamName = "Penn State",
                       TeamNickName = "Nintny Lions",
                       ConferenceId = 2
                   },
                   new Team()
                   {
                       TeamId = 6,
                       TeamDeleted = false,
                       TeamName = "Michigan",
                       TeamNickName = "Wolverines",
                       ConferenceId = 2
                   }
               }
            }
        };

        public Team GetTeamById(int teamId) {
            IEnumerable<Team> teams =
                from conference in conferences
                from team in conference.ConferenceTeams
                where team.TeamId == teamId
                && !team.TeamDeleted
                && !conference.ConferenceDeleted
                select team;

            return teams.FirstOrDefault();
        }
        public List<Team> GetAllTeams() {
            IEnumerable<Team> teams =
                from conference in conferences
                from team in conference.ConferenceTeams
                where !team.TeamDeleted
                select team;

            return teams.ToList<Team>();
        }

        public List<Conference> GetConferences() {
            return conferences;
        }

        public List<Team> GetTeamsForConference(int conferenceId) {
            var conf = conferences.Where(c => c.ConferenceId == conferenceId).FirstOrDefault();

            if (conf != null)
                return conf.ConferenceTeams;

            return null;
        }
    }
}
