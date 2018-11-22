using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BalticLeague
{
    public partial class TeamForm : Form
    {
        List<Team> AllTeams;
        List<Player> TeamPlayers;

        Utilities Utilities = new Utilities();

        public TeamForm()
        {
            InitializeComponent();

            // Initialise the team and team player lists
            AllTeams = new List<Team>();
            TeamPlayers = new List<Player>();
        }

        private bool IsNewTeam = false;
        private bool IsEditMode = false;
        private Team TeamBeforeEdit;

        private void Home_Click(object sender, EventArgs e)
        {
            Home home = new Home
            {
                Tag = this
            };
            home.Show(this);
            Hide();
        }

        private void ToggleFormEditMode(Boolean editMode)
        {
            TeamListView.Enabled = !editMode;

        }

        private void ClearForm()
        {
            TeamName.Text = null;
            TeamCode.Text = null;
            Venue.SelectedValue = null;
            PlayerName.Text = null;
            PlayerCode.Text = null;
            PlayerCombo.SelectedValue = null;
        }

        private void AddNewTeam_Click(object sender, EventArgs e)
        {
            this.ClearForm();
            this.ToggleFormEditMode(true);
        }

        private void UpdateTeamPlayerList(string TeamCode)
        {
            // The TeamPlayers list should be a list of the contents of all files in the Data/players folder
            // where the player has a team code matching the ones provided
            // First clear the list
            TeamPlayers.Clear();

            List<Player> FilteredPlayers = new List<Player>();
            // Add all players to an interim list
            foreach (string file in Directory.EnumerateFiles(Utilities.PlayerDataFolder, "*.json"))
            {
                string contents = File.ReadAllText(file);
                FilteredPlayers.Add(JsonConvert.DeserializeObject<Player>(contents));
            }
            // Filter our player list to remove all players that don't have the team code
            FilteredPlayers.RemoveAll(p => p.CurrentTeamCode != TeamCode);

            // Overwrite the TeamPlayers list with the FilteredPlayers list
            TeamPlayers = FilteredPlayers;
            // Finally refresh the list
            this.RefreshTeamPlayerGridView();
        }

        private void UpdateTeamsList()
        {
            // The AllTeams list should be a list of the contents of all files in the Data/teams folder
            // First clear the teams list
            AllTeams.Clear();
            // Now update it with the contents of the files
            foreach (string file in Directory.EnumerateFiles(Utilities.TeamDataFolder, "*.json"))
            {
                string contents = File.ReadAllText(file);
                AllTeams.Add(JsonConvert.DeserializeObject<Team>(contents));
            }
            // Finally refresh the list
            this.RefreshTeamGridView();
        }

        /// <summary>
        /// Refreshes the Team Grid view
        /// </summary>
        private void RefreshTeamGridView()
        {
            TeamListView.DataSource = null;
            TeamListView.DataSource = AllTeams;
        }

        /// <summary>
        /// Refreshes the Team Player Grid view
        /// </summary>
        private void RefreshTeamPlayerGridView()
        {
            TeamPlayerView.DataSource = null;
            TeamPlayerView.DataSource = TeamPlayers;
        }

        /// <summary>
        /// Load the lists and update the Team view when the form is loaded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TeamForm_Load(object sender, EventArgs e)
        {
            this.UpdateTeamsList();
        }

        /// <summary>
        /// Loads a team into the data form
        /// </summary>
        /// <param name="Team"></param>
        private void LoadTeam(Team Team)
        {
            TeamName.Text = Team.Name;
            TeamCode.Text = Team.TeamCode;
            Venue.SelectedText = Team.HomeVenue.Name;

        }

        private Team GetTeamFromForm()
        {
            return new Team(TeamName.Text, this.GetVenue(TeamCode.Text), TeamCode.Text);
        }

        // TODO: Get the venue from the source data files
        private Venue GetVenue(string VenueCode)
        {
            return new Venue("", "", 0, "");
        }

        private void Delete_Click(object sender, EventArgs e)
        {

        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.LoadTeam(TeamBeforeEdit);
            this.IsEditMode = false;
            this.ToggleFormEditMode(this.IsEditMode);
        }

        private void Save_Click(object sender, EventArgs e)
        {

        }

        private void Edit_Click(object sender, EventArgs e)
        {
            this.IsEditMode = true;
            this.ToggleFormEditMode(this.IsEditMode);
        }
    }
}
