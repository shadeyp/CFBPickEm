using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFBPickEm.Core.Model
{
    public class Conference
    {
        public int ConferenceId { get; set; }
        public string ConferenceName { get; set; }
        public List<Team> ConferenceTeams { get; set; }
        public bool ConferenceDeleted { get; set; }
    }
}
