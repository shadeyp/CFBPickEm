using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFBPickEm.Core.Model
{
    public class Team
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public bool TeamDeleted { get; set; }
        public string TeamNickName { get; set; }
    }
}
