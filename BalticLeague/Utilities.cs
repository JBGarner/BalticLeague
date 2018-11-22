using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BalticLeague
{
    /// <summary>
    /// Utilities class to hold generic functions used in multiple classes so as to keep the code dry
    /// </summary>
    class Utilities
    {

        public readonly string PlayerDataFolder = @"../../Data/players";
        public readonly string TeamDataFolder = @"../../Data/teams";
        public readonly string VenueDataFolder = @"../../Data/venues";
        public readonly string LineupDataFolder = "../../Data/lineups";
        public readonly string MatchDataFolder = "../../Data/matches";

        /// <summary>
        /// Returns a code consisting of the first n characters of a given string, and a random number with a given number of digits
        /// </summary>
        /// <param name="Chars"></param>
        /// <param name="NumChars"></param>
        /// <param name="NumDigits"></param>
        /// <param name="CharsFirst"></param>
        /// <returns></returns>
        public string GenerateCode(string Chars, int NumChars, int NumDigits, bool CharsFirst)
        {
            // Remove any spaces from the Chars string
            string TrimmedChars = Chars.Replace(" ", "");
            // Get the first 4 chars of the last name to a string and convert to upper case
            string CodeChars = TrimmedChars.Substring(0, NumChars).ToUpper();
            // If the result is less than 3 characters (e.g. because the team name was less than 3 chars to start with)
            // Then add however many 'X's are required to bring it to the required number
            if (CodeChars.Length < NumChars)
            {
                int MissingChars = NumChars - CodeChars.Length;
                for (int ii = 0; ii < MissingChars; ii++)
                {
                    CodeChars += "X";
                }
            }
            // Get a random number of sufficient digits as a string
            int RandomNumber = this.GetRandomNumer(NumDigits);

            if (CharsFirst)
            {
                return CodeChars + RandomNumber.ToString();
            }
            return RandomNumber.ToString() + CodeChars;
        }

        public void ShowAlertMessage(string message)
        {
            MessageBox.Show(message);
        }

        /// <summary>
        /// Gets a random number n digits long
        /// </summary>
        /// <param name="NumberOfDigits"></param>
        /// <returns></returns>
        private int GetRandomNumer(int NumberOfDigits)
        {
            double Min = 1;
            double Max = 9;

            if (NumberOfDigits > 1)
            {
                Min = Min * Math.Pow(10, NumberOfDigits - 1);
                Max = (Max + 1) * Math.Pow(10, NumberOfDigits - 1) - 1;
            }
            Random _random = new Random();
            int RandomNumber = _random.Next(Convert.ToInt32(Min), Convert.ToInt32(Max));
            return RandomNumber;
        }

        /// <summary>
        /// Generic Utility to save an object as a json file 
        /// </summary>
        /// <param name="Object">The Object to be serialized to Json and saved</param>
        /// <param name="FolderPath">The path to the folder where the file will be saved</param>
        /// <param name="FileName">The name of the file with no extension</param>
        public void SaveObjectAsJsonFile(Object Object, string FolderPath, string FileName)
        {
            string DataStore = FolderPath + "\\" + FileName + ".json"; 
            string JSON = JsonConvert.SerializeObject(Object);

            // Create the directory if it doesn't exist
            Directory.CreateDirectory(FolderPath);

            // Delete any pre-existing file for the venue
            if (File.Exists(DataStore))
            {
                File.Delete(DataStore);
            }

            // Save the new venue info
            using (var writer = new System.IO.StreamWriter(DataStore, true))
            {
                writer.WriteLine(JSON.ToString());
                writer.Close();
            }
        }
    }
}
