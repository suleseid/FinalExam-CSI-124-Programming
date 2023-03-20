using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TeamClass_Library;

namespace FinalExam_CSI_124_Programming
{
   public static class Data
    {
        public static UserAccount currentManager = null;
        public static string userFilePath = @"managerList.json";
        public static List<UserAccount> managers = new List<UserAccount>();
        public static string teamRosterExtension = @"_team.csv";
        //JSON
        //CSV

        static Data()
        {
            ReadManager();
        }
        public static string FullTeamFilePath()
        {
            return currentManager.Name + teamRosterExtension;   
        }
        public static void SerilizedTeamRoster()
        {

            JsonSerializerOptions jso = new JsonSerializerOptions()
            {
                WriteIndented = true
            };

            string jsonManager = JsonSerializer.Serialize(managers, jso);

            File.WriteAllText(Data.userFilePath, jsonManager);
        }

        public static void ReadManager()
        {

            // ---- Read file back
            // File destination
            string filePath = Data.userFilePath;
            // Reads all text from file
            string listFromFile = File.ReadAllText(filePath);
            // COnverts text to List of Name
            managers = JsonSerializer.Deserialize<List<UserAccount>>(listFromFile);
        }

    }
}
