using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamProject
{
    public class DeveloperRepo
    {
        public List<Developer> _developerDirectory = new List<Developer>();

        //Create
        public bool AddDevToList(Developer developer)
        {
            int startingDevCount = _developerDirectory.Count();
            _developerDirectory.Add(developer);
            bool wasAdded = _developerDirectory.Count > startingDevCount ? true : false;
            return wasAdded;
        }
        //Read
        public List<Developer> GetDevelopers()
        {
            return _developerDirectory;
        }
        //Update
        public bool UpdateDevelopers(Developer oldDev, Developer newDev)
        {
            //Update Developer content
            if (oldDev != null)
            {
                oldDev.FirstName = newDev.FirstName;
                oldDev.LastName = newDev.LastName;
                oldDev.DevId = newDev.DevId;
                oldDev.HasAccess = newDev.HasAccess;
                return true;
            }
            else
            {
                return false;
            }
        }
        //Delete
        public bool RemoveDeveloperFromList(int devID)
        {
            Developer removeDevID = GetDevID(devID);

            int startingDevIDCount = _developerDirectory.Count;
            _developerDirectory.Remove(removeDevID);

            if(startingDevIDCount > _developerDirectory.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //Get Developer by ID
        public Developer GetDevID(int idNum)
        {
            foreach(Developer developer in _developerDirectory)
            {
                if(developer.DevId == idNum)
                {
                    return developer;
                }
            }
            return null;
        }
        public List<Developer> GetDeveloperPluralSight()
        {
            List<Developer> pluralDevID = new List<Developer>();
            foreach(Developer developer in _developerDirectory)
            {
                if(developer.HasAccess == false)
                {
                    pluralDevID.Add(developer);
                }
            }
            return pluralDevID;
        }

        public bool RemoveDeveloperFromList(Developer developer, object devID)
        {
            throw new NotImplementedException();
        }
    }

}


