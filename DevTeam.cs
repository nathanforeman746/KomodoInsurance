using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamProject
{
    public class DevTeam
    {
        public string DevTeamName { get; set; }
        public int DevTeamID { get; set; }
        public List<Developer> DevTeamMembers { get; set;}

        public DevTeam() { }

        public DevTeam(string devTeamName, int devTeamID, List<Developer> devTeamMembers)
        {
            DevTeamName = devTeamName;
            DevTeamID = devTeamID;
            DevTeamMembers = devTeamMembers;
        }
    }
}
