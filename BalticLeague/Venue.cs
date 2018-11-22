using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalticLeague
{
    class Venue 
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int Capacity { get; set; }
        // TODO: Would prefer this to be private, but doesn't seem to save if it is and I don't have time to debug it properly...
        public string VenueCode { get; set; }

        private Utilities Utilities = new Utilities();

        public Venue(string Name, string Address, int Capacity, string VenueCode = null)
        {
            this.Name = Name;
            this.Address = Address;
            this.Capacity = Capacity;
            // If no venue code is passed in, generate a new one
            if (VenueCode == null)
            {
                this.VenueCode = Utilities.GenerateCode(Name, 3, 3, true);
            }
            // If a code is passed in, use that instead (to enable venue editing)
            else
            {
                this.VenueCode = VenueCode;
            }
        }

        /// <summary>
        /// Returns the venue code for the venue
        /// </summary>
        /// <returns></returns>
        public string GetVenueCode()
        {
            return this.VenueCode;
        }
    }
}
