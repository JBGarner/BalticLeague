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
using Newtonsoft.Json;

namespace BalticLeague
{
    public partial class PlayerForm : Form
    {
        // Holds a list of all the players we're adding
        List<Player> AllPlayers;
        List<string> TeamNames;

        public PlayerForm()
        {
            InitializeComponent();
            // Initialise the player list
            AllPlayers = new List<Player>();
            TeamNames = new List<string>();
        }

        private bool IsNewPlayer = false;
        private bool IsEditMode = false;
        private Player PlayerBeforeEdit;

        Utilities Utilities = new Utilities();

        /// <summary>
        /// Changes the data form into edit mode, enabling fields that should be editable and the save / cancel buttons.
        /// Disables add and edit buttons, and the player list
        /// </summary>
        /// <param name="editMode"></param>
        private void ToggleFormEditMode(Boolean editMode)
        {
            IsEditMode = editMode;
            // Edit button should be disabled if we're in edit mode
            EditPlayer.Enabled = !editMode;
            // Add player button should be disabled if we're in edit mode
            AddPlayer.Enabled = !editMode;
            // Player list should be disabled if we're in edit mode so we can't click it again
            PlayerList.Enabled = !editMode;
            // Enable the save and cancel buttons if we're in edit mode
            SaveEdit.Enabled = editMode;
            Cancel.Enabled = editMode;
            // Enable the form fields so they can be edited
            firstName.Enabled = editMode;
            lastName.Enabled = editMode;
            Injured.Enabled = editMode;
            PlayerTeam.Enabled = editMode;
        }

        private void ClearForm()
        {
            firstName.Text = null;
            lastName.Text = null;
            playerCode.Text = null;
            Injured.Checked = false;
        }

        private void EditPlayer_Click(object sender, EventArgs e)
        {
            // Store the player details as they are before we edit anything
            PlayerBeforeEdit = this.GetPlayerDetailsFromForm();
            this.ToggleFormEditMode(true);
        }

        private void SaveEdit_Click(object sender, EventArgs e)
        {

            // Check all necessary fields have values. Throw a message if not
            if (firstName.Text == "" || lastName.Text == "")
            {
                MessageBox.Show("The First Name and Last Name fields are required.");
                return;
            }

            // Get the player as a new player object, and serialise to JSON
            Player Player = this.GetPlayerDetailsFromForm();

            
            // If we're not adding a new player, remove the existing player from the player list.
            if (this.IsNewPlayer == false)
            {
                AllPlayers.RemoveAll(p => p.PlayerCode == Player.PlayerCode);
            }

            // Add the player to the player list
            AllPlayers.Add(Player);

            // Save the player to the players.json file
            this.SavePlayerToJsonFile(Player);
                        
            // Refresh the data in the form
            this.LoadPlayer(Player);
            // Refresh the player view
            this.UpdatePlayerList();

            // Set the new player variable back to false so it doesn't bleed to the next edit
            this.IsNewPlayer = false;
            this.IsEditMode = false;

            // Put the form back in browse mode
            this.ToggleFormEditMode(this.IsEditMode);

            // Clear any value in the stored playerBeforeEdit var
            this.PlayerBeforeEdit = null;
        }

        /// <summary>
        /// Saves the player object as a new json file in Data/players.
        /// If a file already exists with the players code, then deletes that file first.
        /// </summary>
        /// <param name="Player"></param>
        private void SavePlayerToJsonFile(Player Player)
        {
            Utilities.SaveObjectAsJsonFile(Player, Utilities.PlayerDataFolder, Player.GetPlayerCode());
        }

        /// <summary>
        /// Cancels any edit in progress, reverting the form to the state it was in when the edit button was clicked
        /// Reverts the form to blank if 'Add new player' was clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cancel_Click(object sender, EventArgs e)
        {
            if(this.IsNewPlayer)
            {
                this.ClearForm();
            }
            else
            {
                this.LoadPlayer(PlayerBeforeEdit);
            }

            this.ToggleFormEditMode(false);
            // Reset the new / existing player bools
            this.IsNewPlayer = false;
            // Refresh the form so it shows the player as it was before we made any edits
        }

        /// <summary>
        /// Deletes the file for the player, then refreshes the player list view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeletePlayer_Click(object sender, EventArgs e)
        {
            // TODO: Handle errors that will happen if you delete a player who has associated lineups
            Player Player = this.GetPlayerDetailsFromForm();
            // Remove the player from the player list
            AllPlayers.RemoveAll(p => p.GetPlayerCode() == Player.GetPlayerCode());
            // Delete the players' file
            string FilePath = Utilities.PlayerDataFolder + "\\" + Player.GetPlayerCode() + ".json";
            if (File.Exists(FilePath))
            {
                File.Delete(FilePath);
            }
            this.UpdatePlayerList();
        }

        /// <summary>
        /// Opens a new blank player form in edit mode
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddPlayer_Click(object sender, EventArgs e)
        {
            this.IsNewPlayer = true;
            this.ClearForm();
            this.ToggleFormEditMode(true);

        }

        /// <summary>
        /// Navigates back to the home page and hides the current form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Home_Click(object sender, EventArgs e)
        {
            Home home= new Home
            {
                Tag = this
            };
            home.Show(this);
            Hide();
        }

        /// <summary>
        /// Refrehses the data form to show details for a given player
        /// </summary>
        /// <param name="Player"></param>
        private void LoadPlayer(Player Player)
        {
            firstName.Text = Player.FirstName;
            lastName.Text = Player.LastName;
            playerCode.Text = Player.PlayerCode;
            Injured.Checked = Player.IsInjured;
        }

        /// <summary>
        /// TODO: When clicking in a row in the data grid view, populate the fields with the player details
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlayerList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Do nothing if we're in edit mode, to prevent losing edits
            if (IsEditMode)
            {
                return;
            }
            // Get the player details for the selected row
            Player Player = GetPlayerFromDataGrid(PlayerList.SelectedRows[0]);
            // Add the values to the relevant fields
            this.LoadPlayer(Player);
        }
        /// <summary>
        /// Gets a player object for a given list view row
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private Player GetPlayerFromDataGrid(DataGridViewRow row)
        {
            string FirstName = row.Cells[0].Value.ToString();
            string LastName = row.Cells[1].Value.ToString();
            string PlayerCode = row.Cells[4].Value.ToString();
            string PlayerTeam = row.Cells[3].Value.ToString();
            bool IsInjured = Convert.ToBoolean(row.Cells[2].Value);
            Player Player = new Player(FirstName, LastName, IsInjured, PlayerTeam, PlayerCode);
            return Player;
        }

        /// <summary>
        /// Refreshes the player list view after making changes
        /// </summary>
        private void RefreshPlayerListView()
        {
            // Update the players list view with any updates
            PlayerList.DataSource = null;
            PlayerList.DataSource = AllPlayers;
        }

        /// <summary>
        /// Load the player list from data files when the form is loaded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlayerForm_Load(object sender, EventArgs e)
        {
            this.UpdatePlayerList();
            this.UpdateTeamList();
        }

        /// <summary>
        /// Returns a player object from the details in the form
        /// </summary>
        /// <returns></returns>
        private Player GetPlayerDetailsFromForm()
        {
            string PlayerCode = playerCode.Text;
            // If there is no player code (e.g. because we're adding a new player), set PlayerCode to null
            // Since we want to get a new code for the player
            if (PlayerCode == "")
            {
                PlayerCode = null;
            }
            // Get the team code for the team that we've selected
            string TeamName = PlayerTeam.SelectedItem.ToString();
            string TeamCode = null;
            // Get the code for a team from the Team combo box if we've selected a team
            if (TeamName != "" && TeamName != null)
            {
                TeamCode = Utilities.GetTeamByTeamName(TeamName).TeamCode;
            }

            Player myPlayer = new Player(firstName.Text, lastName.Text, Injured.Checked, TeamCode, PlayerCode);
            return myPlayer;
        }

        /// <summary>
        /// Updates the player list from the data files, then refreshes the view
        /// </summary>
        private void UpdatePlayerList()
        {
            // The AllPlayers list should be a list of the contents of all files in the Data/players folder
            // First clear the player list
            AllPlayers.Clear();
            // Now update it with the contents of the files
            foreach(string file in Directory.EnumerateFiles(Utilities.PlayerDataFolder, "*.json"))
            {
                string contents = File.ReadAllText(file);
                AllPlayers.Add(JsonConvert.DeserializeObject<Player>(contents));
            }
            // Finally refresh the list
            this.RefreshPlayerListView();
        }

        /// <summary>
        /// Updates the venues list with a list of venues for lookups
        /// </summary>
        private void UpdateTeamList()
        {
            // Clear the existing lookup
            TeamNames.Clear();
            // First add a blank value to the venue list
            TeamNames.Add("");
            // Go through the list of venues and create a list of Venues for lookups
            foreach (string file in Directory.EnumerateFiles(Utilities.TeamDataFolder, "*.json"))
            {
                string contents = File.ReadAllText(file);
                Team Team = JsonConvert.DeserializeObject<Team>(contents);
                TeamNames.Add(Team.Name);
            }
            // set the data source for the venue lookup
            this.RefreshTeamLookup();
        }

        /// <summary>
        /// Refreshes the data source of the team lookup
        /// </summary>
        private void RefreshTeamLookup()
        {
            PlayerTeam.DataSource = null;
            PlayerTeam.DataSource = TeamNames;
        }
    }
}
