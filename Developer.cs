using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamProject
{
    public class Developer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int DevId { get; set; }
        public bool HasAccess { get; set; }

    public Developer() { }
    public Developer(string firstName, string lastName, int devID, bool hasAccess)
        {
            FirstName = firstName;
            LastName = lastName;
            DevId = devID;
            HasAccess = hasAccess;
        }
    }
    
}
