using DevTeamProject;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DevTeamsConsole
{
    class ProgramUI
    {
        private DeveloperRepo _developerRepoUI = new DeveloperRepo();
        private DevTeamRepo _devTeamRepoUI = new DevTeamRepo();

        // method that runs/starts the application
        public void Run()
        {
            SetContent();
            DevMenu();

        }
        private void DevMenu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {

                // display options to the user
                Console.WriteLine("\nSelect a Menu Option:\n" +
                    "1. Create a New Development Team.\n" +
                    "2. Create a New Developer.\n" +
                    "3. View Development Teams.\n" +
                    "4. View Existing Development Teams + Members.\n" +
                    "5. View Existing Developers.\n" +
                    "6. Add Developer to a Development Team.\n" +
                    "7. Remove a Development Team.\n" +
                    "8. Remove a Developer.\n" +
                    "9. Update a Developer.\n" +
                    "10. Update a Development Team.\n" +
                    "11. View Developers Needing Pluralsight Access.\n" +
                    "0. Exit\n");

                //get the user's input
                string devMenuInput = Console.ReadLine();

                switch (devMenuInput)
                {
                    case "1":
                        //Create New Dev Team 
                        CreateDevTeam();
                        break;
                    case "2":
                        //Create New Developer
                        CreateNewDeveloper();
                        break;
                    case "3":
                        //View Dev Teams
                        DisplayIndTeam();
                        break;
                    case "4":
                        //View Teams & Members
                        DisplayAllDevTeams();
                        break;
                    case "5":
                        //View Current Devs
                        DisplayAllDevelopers();
                        break;
                    case "6":
                        //Add Developer to Team
                        AddDevToTeam();
                        break;
                    case "7":
                        //Remove Dev Team
                        RemoveDevTeam();
                        break;
                    case "8":
                        //Remove a Dev
                        RemoveDeveloper();
                        break;
                    case "9":
                        //Update Developer
                        UpdateDeveloper();
                        break;
                    case "10":
                        //Update Dev Team
                        UpdateTeam();
                        break;
                    case "11":
                        //View Devs that need PluralSight
                        PluralAccess();
                        break;
                    case "0":
                        //Exit
                        Console.WriteLine("Exiting the Program....");
                        Thread.Sleep(1500);
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("/nPlease Enter a Valid Number.");
                        break;
                }
                Console.WriteLine("\nPlease Press Any Key to Continue...\n");
                Console.ReadKey();
                Console.Clear();
            }
        }
        private void CreateDevTeam()
        {
            bool exitMethodCreate = true;
            while (exitMethodCreate)
            {
                // #1 on menu
                Console.Clear();
                DevTeam newDevTeam = new DevTeam();

                // create a new dev team
                Console.WriteLine("\nEnter a Name for the New Development Team.");
                string devTeamName = Console.ReadLine();

                newDevTeam.DevTeamName = devTeamName;

                Console.WriteLine("\nEnter the Development Team ID #: 1 to 10");
                string devTeamStr = Console.ReadLine();

                int devTeamIdInt = Convert.ToInt32(devTeamStr);
                newDevTeam.DevTeamID = CheckTeamIdRange(devTeamIdInt);

                Console.WriteLine("\nType \"Exit\" When Finished with Entries.");
                string exitCreDevTeam = Console.ReadLine().ToLower();

                bool createDevTeam = _devTeamRepoUI.AddDevTeamToList(newDevTeam);

                if (createDevTeam == true)
                {
                    Console.WriteLine("\nDevelopment Teams Added.");
                }

                if (exitCreDevTeam == "exit")
                {
                    exitMethodCreate = false;
                }
            }
        }
        private void CreateNewDeveloper()
        {
            bool exitMethodCreate2 = true;
            while (exitMethodCreate2)
            {
                // #2 on menu
                Console.Clear();
                Developer newDeveloper = new Developer();

                // create a new developer
                Console.WriteLine("\nEnter the Developer's First Name.");
                string firstNameStr = Console.ReadLine();
                newDeveloper.FirstName = firstNameStr;

                Console.WriteLine("\nEnter the Developer's Last Name.");
                string LastNameStr = Console.ReadLine();
                newDeveloper.LastName = LastNameStr;

                Console.WriteLine("\nEnter the Developer's ID #: 1 to 30.");
                string devIdStr = Console.ReadLine();
                newDeveloper.DevId = CheckDevIdRange(Convert.ToInt32(devIdStr));

                int devIdInt = Convert.ToInt32(devIdStr);

                Console.WriteLine("\nEnter (Yes/No) if the Developer possesses a Pluralsight License.");
                string devLicense = Console.ReadLine().ToLower();

                if (devLicense == "yes")
                {
                    newDeveloper.HasAccess = true;
                }
                else
                {
                    newDeveloper.HasAccess = false;
                }

                bool addDeveloper = _developerRepoUI.AddDevToList(newDeveloper);

                Console.WriteLine("\nType \"Exit\" When Finished with Entries.");
                string exitCreDev = Console.ReadLine().ToLower();

                if (addDeveloper == true)
                {
                    Console.WriteLine("\nDevelopers Added.");
                }

                if (exitCreDev == "exit")
                {
                    exitMethodCreate2 = false;
                }
            }
        }
        private void DisplayIndTeam()
        {
            // #3 
            Console.Clear();
            List<DevTeam> listIndDevT = _devTeamRepoUI.GetDevTeams();

            foreach (DevTeam devTe in listIndDevT)
            {
                Console.WriteLine($"\nDevelopment Team Name: {devTe.DevTeamName}" +
                    $"\nDevelopment Team ID Number: {devTe.DevTeamID}");

            }
        }
        private void DisplayAllDevTeams()
        {
            // #4 on the menu
            Console.Clear();
            List<DevTeam> listofDevTeams = _devTeamRepoUI.GetDevTeams();

            foreach (DevTeam devTeams in listofDevTeams)
            {
                Console.WriteLine($"\nDevelopment Team ID Number: {devTeams.DevTeamID}" +
                    $"\nDevelopment Team Name: {devTeams.DevTeamName}");
                foreach (Developer dev in devTeams.DevTeamMembers)
                {
                    Console.WriteLine($"\nDeveloper ID#: {dev.DevId}" +
                        $"\nDeveloper First Name: {dev.FirstName}" +
                        $"\nDeveloper Last Name: {dev.LastName}");
                }
            }
        }

        private void DisplayAllDevelopers()
        {
            // #5 on the menu   
            Console.Clear();
            List<Developer> listofDevelopers = _developerRepoUI.GetDevelopers();

            foreach (Developer developer in listofDevelopers)
            {
                Console.WriteLine($"\nDeveloper ID Number: {developer.DevId}" +
                    $"\nDeveloper First Name: {developer.FirstName}" +
                    $"\nDeveloper Last Name: {developer.LastName}" +
                    $"\nDeveloper Has a License: {developer.HasAccess}\n");
            }
        }
        private void AddDevToTeam()
        {
            bool exitMethodAddTeam = true;
            while (exitMethodAddTeam)
            {
                // #6 on menu
                Console.Clear();
                List<Developer> addDevelopers = _developerRepoUI.GetDevelopers();
                List<DevTeam> devAddTeam = _devTeamRepoUI.GetDevTeams();

                // display all content
                DisplayBoth();

                Console.WriteLine("\nPlease Enter Developer ID # (1 to 30): \n");
                string localDev = Console.ReadLine();
                int localDevId = CheckDevIdRange(Convert.ToInt32(localDev));

                Console.WriteLine($"\nPlease Enter the Development Team Number to Assign Developer.");
                string localDevTeamStr = Console.ReadLine();

                int localDevTeamId = Convert.ToInt32(localDevTeamStr);

                DevTeam checkedDevId = _devTeamRepoUI.GetDevTeamID(localDevTeamId);

                foreach (DevTeam developerId in devAddTeam)
                {
                    if (localDevTeamId <= 10)
                    {
                        if (checkedDevId == null)
                        {
                            Console.WriteLine($"\nDeveloper Number: {localDev} Added to Development Team Number: {localDevTeamStr}\n");
                            _devTeamRepoUI.AddDevToTeam(localDevTeamId);
                            Thread.Sleep(1500);
                        }
                        else
                        {
                            Console.WriteLine($"\nDeveloper Number: {localDev} is Already Assigned Development Team.\n");
                            Thread.Sleep(1500);
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nPlease Enter a Valid Development Team ID #:\n");

                    }

                    Console.WriteLine("\nType \"Exit\" When Finished with Entries.");
                    string exitMethDis = Console.ReadLine().ToLower();

                    if (exitMethDis == "exit")
                    {
                        exitMethodAddTeam = false;
                    }
                }
            }
        }
        private void RemoveDevTeam()
        {
            // #7 on menu
            List<DevTeam> removeDevTeam = _devTeamRepoUI.GetDevTeams();

            Console.Clear();

            // display all content
            DisplayIndTeam();

            Console.WriteLine("\nEnter the Development Team ID #:(1-10) for Removal.\n");
            string removeDevTeamID = Console.ReadLine();

            int removeDevTeamInt = Convert.ToInt32(removeDevTeamID);

            _devTeamRepoUI.RemoveDevTeamFromList(removeDevTeamInt);

        }
        private void RemoveDeveloper()
        {
            // #8 on the menu
            List<Developer> removeDeveloper = _developerRepoUI.GetDevelopers();

            Console.Clear();

            DisplayAllDevelopers();

            Console.WriteLine("\nEnter the Developer ID #:(1-30) for Removal.\n");
            int removeDevId = Convert.ToInt32(Console.ReadLine());

            bool confirmDevDelete = _developerRepoUI.RemoveDeveloperFromList(removeDevId);

            if (confirmDevDelete == true)
            {
                Console.WriteLine($"\n2nd Cofirmation, Development Team {confirmDevDelete} was Removed.\n");

            }
        }
        private void UpdateDeveloper()
        {
            // #9
            Developer newDev = new Developer();

            Console.Clear();

            DisplayAllDevelopers();

            Console.WriteLine("\nEnter the ID Number of Developer for Updating.");
            int originId = Convert.ToInt32(Console.ReadLine());

            Developer oldDev = _developerRepoUI.GetDevID(originId);

            Console.WriteLine("\nEnter the Developer's New ID #: 1 to 30.");
            newDev.DevId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\nEnter the Developer's New First Name.");
            newDev.FirstName = Console.ReadLine();

            Console.WriteLine("\nEnter the Developer's New Last Name.");
            newDev.LastName = Console.ReadLine();

            Console.WriteLine("\nEnter (Yes/No) if the Developer *Posseses a Pluralsight License.");
            string hasAccess = Console.ReadLine().ToLower();

            if (hasAccess == "yes")
            {
                newDev.HasAccess = true;
            }
            else
            {
                newDev.HasAccess = false;
            }

            _developerRepoUI.UpdateDevelopers(oldDev, newDev);
        }
        private void UpdateTeam()
        {
            // #10
            DevTeam newTeam = new DevTeam();

            Console.Clear();

            DisplayIndTeam();

            Console.WriteLine("\nEnter the Development Team ID Number for Updating.");
            int teOriginId = Convert.ToInt32(Console.ReadLine());

            DevTeam oldDev = _devTeamRepoUI.GetDevTeamID(teOriginId);

            Console.WriteLine("\nEnter the Development Team NEW ID #: 1 to 10");
            newTeam.DevTeamID = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\nEnter the NEW Name for the Development Team.");
            newTeam.DevTeamName = Console.ReadLine();

            newTeam.DevTeamMembers = oldDev.DevTeamMembers;

            _devTeamRepoUI.UpdateDevTeams(oldDev, newTeam);
        }
        private void PluralAccess()
        {
            // #11 on menu
            Console.Clear();

            List<Developer> pluralDev = _developerRepoUI.GetDeveloperPluralSight();

            foreach (Developer dev in pluralDev)
            {
                Console.WriteLine($"\nDeveloper ID: {dev.DevId}" +
                    $"\nFirst Name: {dev.FirstName}" +
                    $"\nLast Name: {dev.LastName}.\n");
            }
        }
        // Data verification Functions
        public int CheckDevIdRange(int idNumCheck)
        {
            if (idNumCheck <= 30)
            {
                return idNumCheck;
            }
            else
            {
                Console.WriteLine("\nPlease Re-Enter the Developer's ID #: 1 to 30.\n");
                string devIdStrRe = Console.ReadLine();
                // ExitConsole(Convert.ToString(devIdStrRe));

                idNumCheck = Convert.ToInt32(devIdStrRe);
                return idNumCheck;
            }

        }
        private int CheckTeamIdRange(int idTeamCheck)
        {
            if (idTeamCheck <= 10)
            {
                return idTeamCheck;
            }
            else
            {
                Console.WriteLine("\nPlease Re-Enter the Developer's ID #: 1 to 10.\n");
                string devIdStrRe = Console.ReadLine();
                // ExitConsole(Convert.ToString(devIdStrRe));

                idTeamCheck = Convert.ToInt32(devIdStrRe);
                return idTeamCheck;
            }

        }
        private void DisplayBoth()
        {
            List<Developer> displayBoth = _developerRepoUI.GetDevelopers();
            List<DevTeam> displayTeam = _devTeamRepoUI.GetDevTeams();

            foreach (Developer dev in displayBoth)
            {
                Console.WriteLine($"\nDeveloper ID Number: {dev.DevId}" +
                    $"\nDeveloper First Name: {dev.FirstName}" +
                    $"\nDeveloper Last Name: {dev.LastName}" +
                    $"\nDeveloper Has a License: {dev.HasAccess}\n");
            }

            foreach (DevTeam devTeam in displayTeam)
            {
                Console.WriteLine($"\nDevelopment Team Name: {devTeam.DevTeamName}" +
                $"\nDevelopment Team ID Number: {devTeam.DevTeamID}");

            }
        }

        //Seed Content
        private void SetContent()
        {
            Developer dev1 = new Developer("Bruce", "Wayne", 1, false);
            Developer dev2 = new Developer("Adam", "Sandler", 2, false);
            Developer dev3 = new Developer("Robert", "Downey Jr.", 3, true);
            Developer dev4 = new Developer("Jason", "Bourne", 4, false);
            Developer dev5 = new Developer("Jack", "Reacher", 5, true);
            Developer dev6 = new Developer("John", "Smith", 6, true);
            Developer dev7 = new Developer("James", "Bond", 7, true);

            _developerRepoUI.AddDevToList(dev1);
            _developerRepoUI.AddDevToList(dev2);
            _developerRepoUI.AddDevToList(dev3);
            _developerRepoUI.AddDevToList(dev4);
            _developerRepoUI.AddDevToList(dev5);
            _developerRepoUI.AddDevToList(dev6);
            _developerRepoUI.AddDevToList(dev7);

            List<Developer> devTeamMem1 = new List<Developer>();
            devTeamMem1.Add(dev1);
            devTeamMem1.Add(dev2);
            devTeamMem1.Add(dev3);

            List<Developer> devTeamMem2 = new List<Developer>();
            devTeamMem2.Add(dev4);
            devTeamMem2.Add(dev5);
            devTeamMem2.Add(dev6);

            List<Developer> devTeamMem3 = new List<Developer>();
            devTeamMem3.Add(dev1);
            devTeamMem3.Add(dev4);
            devTeamMem3.Add(dev7);

            List<Developer> devTeamMem4 = new List<Developer>();
            devTeamMem4.Add(dev2);
            devTeamMem4.Add(dev3);
            devTeamMem4.Add(dev5);
            devTeamMem4.Add(dev7);

            DevTeam devT1 = new DevTeam("Orange", 1, devTeamMem1);
            DevTeam devT2 = new DevTeam("Sapphire", 2, devTeamMem2);
            DevTeam devT3 = new DevTeam("Blue", 3, devTeamMem3);
            DevTeam devT4 = new DevTeam("Grey", 4, devTeamMem4);

            _devTeamRepoUI.AddDevTeamToList(devT1);
            _devTeamRepoUI.AddDevTeamToList(devT2);
            _devTeamRepoUI.AddDevTeamToList(devT3);
            _devTeamRepoUI.AddDevTeamToList(devT4);
        }
    }
}
