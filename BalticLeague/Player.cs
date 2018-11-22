using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalticLeague
{
    class Player
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsInjured { get; set; }
        public string CurrentTeamCode { get; set; }
        // TODO: Would prefer this to be private, but doesn't seem to save if it is and I don't have time to debug it properly...
        public string PlayerCode { get; set; }

        private readonly Utilities Utilities = new Utilities();

        public Player(string FirstName, string LastName, bool isInjured, string CurrentTeamCode = null, string PlayerCode = null)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.IsInjured = IsInjured;
            this.CurrentTeamCode = CurrentTeamCode;
            
            // If a player code is provided, then use that player code 
            // Otherwise, generate a new one
            if (PlayerCode == null)
            {
                this.PlayerCode = this.Utilities.GenerateCode(LastName, 3, 4, true);
            }
            else
            {
                this.PlayerCode = PlayerCode;
            }
        }

        /// <summary>
        /// Returns the player code for the player 
        /// </summary>
        /// <returns></returns>
        public string GetPlayerCode()
        {
            return PlayerCode;
        }
    }
}
