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

        /// <summary>
        /// Clears all data the data form fields
        /// </summary>
        private void ClearForm()
        {
            TeamName.Text = null;
            TeamCode.Text = null;
            Venue.SelectedValue = null;
            PlayerName.Text = null;
            PlayerCode.Text = null;
            PlayerCombo.SelectedValue = null;
        }

        /// <summary>
        /// Clears the data form and puts it in edit mode ready for a new entry
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddNewTeam_Click(object sender, EventArgs e)
        {
            this.ClearForm();
            this.IsNewTeam = true;
            this.IsEditMode = true;
            this.ToggleFormEditMode(this.IsEditMode);
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

        private Team GetTeamDetailsFromForm()
        {
            return new Team(TeamName.Text, this.GetVenue(TeamCode.Text), TeamCode.Text);
        }

        private void RefreshTeamForm(Team Team)
        {
            // Refresh the Team details in the form;
            TeamName.Text = Team.Name;
            TeamCode.Text = Team.TeamCode;
            Venue.SelectedText = Team.HomeVenue.Name;

            // Clear othe populated fields
            PlayerCode.Text = null;
            PlayerName.Text = null;
            PlayerCombo.SelectedText = null;
        }

        // TODO: Get the venue from the source data files
        private Venue GetVenue(string VenueCode)
        {
            return new Venue("", "", 0, "");
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            // TODO: Handle errors that will happen if you delete a team who has associated lineups, players or matches
            Team Team = this.GetTeamDetailsFromForm();
            // Remove the player from the player list
            AllTeams.RemoveAll(t => t.TeamCode == Team.TeamCode);
            // Delete the players' file
            string FilePath = Utilities.TeamDataFolder + "\\" + Team.TeamCode + ".json";
            if (File.Exists(FilePath))
            {
                File.Delete(FilePath);
            }
            this.UpdateTeamsList();
        }

        /// <summary>
        /// Saves the team to disk as a json file
        /// </summary>
        /// <param name="Team"></param>
        private void SaveTeamAsJsonFile(Team Team)
        {
            Utilities.SaveObjectAsJsonFile(Team, Utilities.TeamDataFolder, Team.TeamCode);
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.LoadTeam(TeamBeforeEdit);
            this.IsEditMode = false;
            this.ToggleFormEditMode(this.IsEditMode);
            this.TeamBeforeEdit = null;
        }

        private void Save_Click(object sender, EventArgs e)
        {
            // Check all necessary fields have values. Throw a message if not
            if (TeamName.Text == "" || Venue.SelectedText == "")
            {
                MessageBox.Show("The Team Name and Venue fields are required.");
                return;
            }

            Team Team = this.GetTeamDetailsFromForm();

            // If we're not adding a new team, remove the existing ateam from the teams list.
            if (this.IsNewTeam == false)
            {
                AllTeams.RemoveAll(t => t.TeamCode == Team.TeamCode);
            }

            // Add the team to the teams list
            AllTeams.Add(Team);

            // Save the player to the players.json file
            this.SaveTeamAsJsonFile(Team);

            // Refresh the data in the form
            this.LoadTeam(Team);
            // Refresh the player view
            this.UpdateTeamsList();

            // Set the new player variable back to false so it doesn't bleed to the next edit
            this.IsNewTeam = false;

            // Put the form back in browse mode
            this.ToggleFormEditMode(false);

            // Clear any value in the stored playerBeforeEdit var
            this.TeamBeforeEdit = null;
        }

        /// <summary>
        /// Puts the form in edit mode, and gets the team before any edits are made so we can cancel the edit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Edit_Click(object sender, EventArgs e)
        {
            this.TeamBeforeEdit = this.GetTeamDetailsFromForm();
            this.IsEditMode = true;
            this.ToggleFormEditMode(this.IsEditMode);
        }
    }
}
