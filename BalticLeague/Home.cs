using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BalticLeague
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Navigates to the Players form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HomePlayers_Click(object sender, EventArgs e)
        {
            PlayerForm playerForm = new PlayerForm
            {
                Tag = this
            };
            playerForm.Show(this);
            Hide();
        }

        /// <summary>
        /// Navigates to the Teams form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HomeTeams_Click(object sender, EventArgs e)
        {
            TeamForm teamForm = new TeamForm
            {
                Tag = this
            };
            teamForm.Show(this);
            Hide();
        }

        /// <summary>
        /// Navigates to the Venues form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Venues_Click(object sender, EventArgs e)
        {
            VenueForm venueForm = new VenueForm
            {
                Tag = this
            };
            venueForm.Show(this);
            Hide();
        }

        /// <summary>
        /// Navigates to the Matches form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Matches_Click(object sender, EventArgs e)
        {
            // TODO: implement once the form is complete
        }

        /// <summary>
        /// Navigates to the lineup form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Lineups_Click(object sender, EventArgs e)
        {
            // TODO: implement once the form is complete
        }

        /// <summary>
        /// Opens a pop-up box with help on using the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Help_Click(object sender, EventArgs e)
        {
            string HelpMessage =
                "Click the 'Players' button to add, edit or delete a player.\n\n" +
                "Click the 'Teams' button to add, edit or delete teams, and add or remove players to or from the team.\n\n" +
                "Click the 'Venues' button to add, edit or delete a venue.\n\n" +
                "Click the 'Lineups' button to add, edit or delete a lineup for a team.\n\n" +
                "Click the 'Matches' button to add, edit or delete a Match";


            MessageBox.Show(HelpMessage);
        }
    }
}
