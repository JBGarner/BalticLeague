using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalticLeague
{
    class Team
    {
        public string Name { get; set; }
        public string TeamCode { get; set; }
        public string HomeVenueCode { get; set; }

        private readonly Utilities Utilities = new Utilities();

        public Team(string Name, string HomeVenueCode, string TeamCode = null)
        {
            this.Name = Name;
            this.HomeVenueCode = HomeVenueCode;
            // If a team code is provided, then we use that. Else we overwrite
            if (TeamCode == null)
            {
                this.TeamCode = this.Utilities.GenerateCode(Name, 3, 3, false);
            }
            else
            {
                this.OverwriteTeamCode(TeamCode);
            }
        }

        /// <summary>
        /// Returns the team code for the team
        /// </summary>
        /// <returns></returns>
        public string GetTeamCode()
        {
            return this.TeamCode;
        }

        /// <summary>
        /// Overwrites the generated team code with a given string.
        /// For use if we are editing an existing player
        /// </summary>
        /// <param name="TeamCode"></param>
        private void OverwriteTeamCode(string TeamCode)
        {
            this.TeamCode = TeamCode;
        }
    }
}
