using CFBPickEm.Core.Model;
using CFBPickEm.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFBPickEm.Core.Service
{
    public class CFBDataService
    {
        private static CFBRepository cfbRepo = new CFBRepository();

        public List<Team> GetAllTeams()
        {
            return cfbRepo.GetAllTeams();
        }

        public List<Conference> GetConferences()
        {
            return cfbRepo.GetConferences();
        }

        public Team GetTeamById(int teamId)
        {
            return cfbRepo.GetTeamById(teamId);
        }

        public List<Team> GetTeamsForConference(int conferenceId) {
            return cfbRepo.GetTeamsForConference(conferenceId);
        }
    }
}
