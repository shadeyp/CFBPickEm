using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFBPickEm.Core.Model
{
    public class Game
    {
        public int GameId { get; set; }
        public int GameHomeTeamId { get; set; }
        public int GameVistorTeamId { get; set; }
        public bool GameDeleted { get; set; }
        public DateTime GameStartTime { get; set; }
        public int GameHomeScore { get; set; }
        public int GameVistorScore { get; set; }
        public int GamePointSpred { get; set; }
        public string GameTeamFavored { get; set; }
        public string GameLocation { get; set; }
    }
}
