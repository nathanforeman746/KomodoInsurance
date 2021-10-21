using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamProject
{
    public class DevTeamRepo
    {
        private List<DevTeam> _devTeams = new List<DevTeam>();

        //Create
        public bool AddDevTeamToList(DevTeam devTeam)
        {
            int startingTeamCount = _devTeams.Count();
            _devTeams.Add(devTeam);

            if (_devTeams.Count() > startingTeamCount)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //Read
        public List<DevTeam> GetDevTeams()
        {
            return _devTeams;
        }
        //Update
        public bool UpdateDevTeams(DevTeam oldTeam, DevTeam newTeam)
        {
            if(oldTeam != null & newTeam != null)
            {
                oldTeam.DevTeamName = newTeam.DevTeamName;
                oldTeam.DevTeamID = newTeam.DevTeamID;
                oldTeam.DevTeamMembers = newTeam.DevTeamMembers;
                return true;
            }
            else
            {
                return false;
            }
        }
        //Delete
        public bool RemoveDevTeamFromList(int devTeamID)
        {
            DevTeam removeDevTeamID = GetDevTeamID(devTeamID);

            int startingTeamCount = _devTeams.Count;
            _devTeams.Remove(removeDevTeamID);

            if(startingTeamCount > _devTeams.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //Get Team by ID
        public DevTeam GetDevTeamID(int getDevID)
        {
            foreach(DevTeam devTeam in _devTeams)
            {
                if(devTeam.DevTeamID == getDevID)
                {
                    return devTeam;
                }
            }
            return null;
        }
        //Add Developers to Team
        public bool AddDevToTeam(int AddDevToTeam)
        {
            DevTeam newDevID = GetDevTeamID(AddDevToTeam);

            int startingTeamCount = _devTeams.Count();
            _devTeams.Add(newDevID);

            if(_devTeams.Count > startingTeamCount)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

}
