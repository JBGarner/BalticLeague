﻿using Newtonsoft.Json;
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
        List<string> VenueLookup;

        Utilities Utilities = new Utilities();

        public TeamForm()
        {
            InitializeComponent();

            // Initialise the team, team player and venueCore lists
            AllTeams = new List<Team>();
            TeamPlayers = new List<Player>();
            VenueLookup = new List<string>();

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
            // Disable the player view, fields and add / remove from team buttons
            // These will be enabled by other functions
            TeamPlayerView.Enabled = false;
            PlayerCode.Enabled = false;
            PlayerName.Enabled = false;
            PlayerCombo.Enabled = false;

            // Add to team and remove from team should always be disabled unless we've done something to activate them
            AddPlayerToTeam.Enabled = false;
            RemovePlayerFromTeam.Enabled = false;

            // The delete button should be disabled unless we've enabled it by selecting a row
            Delete.Enabled = false;

            // The add button should only be enabled if we're in browse mode
            AddNewTeam.Enabled = !editMode;

            // The save and cancel buttons should be enabled in edit mode only
            Save.Enabled = editMode;
            Cancel.Enabled = editMode;

            // Team input fields should be enabled in edit mode
            TeamName.Enabled = editMode;
            Venue.Enabled = editMode;

        }

        /// <summary>
        /// Clears all data the data form fields
        /// </summary>
        private void ClearForm()
        {
            TeamName.Text = null;
            TeamCode.Text = null;
            Venue.SelectedItem = VenueLookup.First();
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
            this.UpdateVenueList();
            this.UpdateTeamsList();
        }

        /// <summary>
        /// Get team details from the form to a team object
        /// </summary>
        /// <returns></returns>
        private Team GetTeamDetailsFromForm()
        {
            string _TeamCode = TeamCode.Text;
            if (_TeamCode == "")
            {
                _TeamCode = null;
            }
            return new Team(TeamName.Text, Utilities.GetVenueByName(Venue.Text).VenueCode, _TeamCode);
        }

        private void LoadTeam(Team Team)
        {
            // Refresh the Team details in the form;
            TeamName.Text = Team.Name;
            TeamCode.Text = Team.TeamCode;

            // Get the name we expect to appear in the venue;
            string VenueName = Utilities.GetVenueByCode(Team.HomeVenueCode).Name;

            // Set the venue lookup to the relevant text value
            Venue.SelectedIndex = VenueLookup.IndexOf(VenueName);

            // Clear othe populated fields
            PlayerCode.Text = null;
            PlayerName.Text = null;
            PlayerCombo.SelectedText = null;
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
            // Clear the form
            this.ClearForm();
            // Revert the form to browse mode;
            this.ToggleFormEditMode(false);
        }

        /// <summary>
        /// Saves the team to disk as a json file
        /// </summary>
        /// <param name="Team"></param>
        private void SaveTeamAsJsonFile(Team Team)
        {
            Utilities.SaveObjectAsJsonFile(Team, Utilities.TeamDataFolder, Team.TeamCode);
        }

        /// <summary>
        /// Cancels the edit in progress. Reverts the form to browse mode and re-loads the team as it was before the edit started
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cancel_Click(object sender, EventArgs e)
        {
            if(IsNewTeam)
            {
                this.ClearForm();
            }
            else
            {
                this.LoadTeam(TeamBeforeEdit);
            }
            this.IsEditMode = false;
            this.ToggleFormEditMode(this.IsEditMode);
            this.TeamBeforeEdit = null;
        }

        private void Save_Click(object sender, EventArgs e)
        {
            // Check all necessary fields have values. Throw a message if not
            if (TeamName.Text == "" || Venue.SelectedItem.ToString() == "")
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

        /// <summary>
        /// Loads the team details into the form
        /// Enables the player list, and Updates it player list with all the players that play for the team
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TeamListView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Team Team = this.GetTeamDetailsFromGrid(TeamListView.SelectedRows[0]);
            // Load the team into the form
            this.LoadTeam(Team);
            // Enable the player list and update it with the players in the team
            TeamPlayerView.Enabled = true;
            this.UpdateTeamPlayerList(Team.TeamCode);
            // Enable the delete button
            Delete.Enabled = true;
            
        }

        /// <summary>
        /// Populates the relevant read only fields on the team form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TeamPlayerView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Player Player = this.GetPlayerDetailsFromGrid(TeamPlayerView.SelectedRows[0]);
            PlayerName.Text = Player.FirstName + " " + Player.LastName;
            PlayerCode.Text = Player.PlayerCode;

        }


        private void RemovePlayerFromTeam_Click(object sender, EventArgs e)
        {
            // Get the currently selected player from the grid
            Player Player = this.GetPlayerDetailsFromGrid(TeamPlayerView.SelectedRows[0]);
            // Set the team code to null
            Player.CurrentTeamCode = null;
            // Save the player
            Utilities.SaveObjectAsJsonFile(Player, Utilities.PlayerDataFolder, Player.GetPlayerCode());
        }

        private void AddPlayerToTeam_Click(object sender, EventArgs e)
        {
            // Get the currently selected player from the grid
            Player Player = this.GetPlayerDetailsFromGrid(TeamPlayerView.SelectedRows[0]);
            // Set the team code to null
            Player.CurrentTeamCode = TeamCode.Text;
            Utilities.SaveObjectAsJsonFile(Player, Utilities.PlayerDataFolder, Player.GetPlayerCode());
        }

        private Player GetPlayerDetailsFromGrid(DataGridViewRow row)
        {
            string FirstName = row.Cells[0].Value.ToString();
            string LastName = row.Cells[1].Value.ToString();
            string PlayerCode = row.Cells[4].Value.ToString();
            string PlayerTeam = row.Cells[3].Value.ToString();
            bool IsInjured = Convert.ToBoolean(row.Cells[2].Value);
            Player Player = new Player(FirstName, LastName, IsInjured, PlayerTeam, PlayerCode);
            return Player;
        }

        private Team GetTeamDetailsFromGrid(DataGridViewRow row)
        {
            string TeamName = row.Cells[0].Value.ToString();
            string TeamCode = row.Cells[1].Value.ToString();
            Venue Venue = Utilities.GetVenueByCode(row.Cells[2].Value.ToString());
            Team Team = new Team(TeamName, Venue.VenueCode, TeamCode);
            return Team;
        }

        // Updates the venues list with a list of venues for lookups
        private void UpdateVenueList()
        {
            // Clear the existing lookup
            VenueLookup.Clear();
            // First add a blank value to the venue list
            VenueLookup.Add("");
            // Go through the list of venues and create a list of Venues for lookups
            foreach (string file in Directory.EnumerateFiles(Utilities.VenueDataFolder, "*.json"))
            {
                string contents = File.ReadAllText(file);
                Venue Venue = JsonConvert.DeserializeObject<Venue>(contents);
                VenueLookup.Add(Venue.Name);
            }
            // set the data source for the venue lookup
            this.RefreshVenueLookup();
        }

        private void RefreshVenueLookup()
        {
            Venue.DataSource = null;
            Venue.DataSource = VenueLookup;
        }
    }
}
