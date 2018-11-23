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
    public partial class VenueForm : Form
    {
        public VenueForm()
        {
            InitializeComponent();
            // Initialise the Venues list
            AllVenues = new List<Venue>();
        }

        private Utilities Utilities = new Utilities();

        List<Venue> AllVenues;

        private bool IsEditMode = false;
        private bool IsNewVenue = false;

        private Venue VenueBeforeEdit;

        /// <summary>
        /// Updates the venue list from source data files when the form is loaded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VenueForm_Load(object sender, EventArgs e)
        {
            this.UpdateVenueList();

        }

        private void ToggleFormEditMode(bool isEditMode)
        {
            // Add, Edit and Delete buttons should only be enabled if we're not in edit mode
            AddVenue.Enabled = !isEditMode;
            Edit.Enabled = !isEditMode;
            Delete.Enabled = !isEditMode;

            // Save and Cancel buttons should only be enabled if we're in edit mode
            Save.Enabled = isEditMode;
            Cancel.Enabled = isEditMode;

            // VenueList should only be enabled if we're not in edit mode
            VenueList.Enabled = !isEditMode;

            // Input fields should only be enabled if we're in edit mode
            VenueName.Enabled = isEditMode;
            Address.Enabled = isEditMode;
            Capacity.Enabled = isEditMode;
        }

        private void UpdateVenueList()
        {
            // The AllPlayers list should be a list of the contents of all files in the Data/players folder
            // First clear the player list
            AllVenues.Clear();
            // Now update it with the contents of the files
            foreach (string file in System.IO.Directory.EnumerateFiles(Utilities.VenueDataFolder, "*.json"))
            {
                string contents = File.ReadAllText(file);
                AllVenues.Add(JsonConvert.DeserializeObject<Venue>(contents));
            }
            // Finally refresh the list
            this.RefreshVenueListView();

        }

        /// <summary>
        /// Refreshes the venue list data
        /// </summary>
        private void RefreshVenueListView()
        {
            VenueList.DataSource = null;
            VenueList.DataSource = AllVenues;
        }

        /// <summary>
        /// Clears all values in the data form
        /// </summary>
        private void ClearForm()
        {
            VenueName.Text = null;
            Capacity.Text = null;
            VenueCode.Text = null;
            Address.Text = null;
        }
        
        /// <summary>
        /// Returns a Venue object from the data in the form
        /// </summary>
        /// <returns></returns>
        private Venue GetVenueDetailsFromForm()
        {
            string Code = VenueCode.Text;
            // If there is no venue code (e.g. because we're adding a new venue), set VenueCode to null
            // Since we want to get a new code for the player
            if (Code == "")
            {
                Code = null;
            }
            // Convert the capacity to a number
            int.TryParse(Capacity.Text, out int ConvertedCapacity);
            // Return a new venue
            Venue MyVenue = new Venue(VenueName.Text, Address.Text, ConvertedCapacity, Code);
            return MyVenue;
        }

        /// <summary>
        /// Returns to the home page if we're not in edit mode.
        /// If we are, show an appropriate alert message
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Home_Click(object sender, EventArgs e)
        {
            if (!this.IsEditMode)
            {
                Home home = new Home
                {
                    Tag = this
                };
                home.Show(this);
                Hide();
            }
            else
            {
                Utilities.ShowAlertMessage("Please save or cancel your edit before navigating away from this form.");
            }
        }

        /// <summary>
        /// Toggles the form into Edit mode. Gets a copy of the currently loaded Venue so it can be reset on cancel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Edit_Click(object sender, EventArgs e)
        {
            this.IsEditMode = true;
            // Get the vene from the form before we edit it
            this.VenueBeforeEdit = this.GetVenueDetailsFromForm();
            this.ToggleFormEditMode(IsEditMode);
        }

        /// <summary>
        /// Saves the Venue. If it already exists, deletes and recreated the venue on disk. Updates the venue list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Save_Click(object sender, EventArgs e)
        {
            // Check all necessary fields have values
            if (VenueName.Text == "" || Address.Text == "" || Capacity.Text == "")
            {
                MessageBox.Show("The Name, Address and Capacity fields are required.");
                return;
            }

            Venue newVenue = this.GetVenueDetailsFromForm();

            // If we're not adding a new venue, then remove the venue with the venue code from the list
            if (IsNewVenue == false)
            {
                AllVenues.RemoveAll(v => v.GetVenueCode() == newVenue.GetVenueCode());
            }

            // Add the new Venue to the Venue list
            AllVenues.Add(newVenue);

            // Save the venue to disk
            this.SaveVenueToJsonFile(newVenue);

            // Refresh the field values (so the venue code is displayed if we're adding a new venue)
            this.RefreshVenueDetails(newVenue);

            // Update the venue list
            this.UpdateVenueList();

            // Finally set the form to browse mode, and update the venue list
            this.IsEditMode = false;
            this.IsNewVenue = false;
            this.ToggleFormEditMode(IsEditMode);
            
            this.VenueBeforeEdit = null;
        }

        /// <summary>
        /// Saves a venue as a json file in the Venues folder
        /// </summary>
        /// <param name="Venue"></param>
        private void SaveVenueToJsonFile(Venue Venue)
        {
            Utilities.SaveObjectAsJsonFile(Venue, Utilities.VenueDataFolder, Venue.GetVenueCode());
        }

        /// <summary>
        /// Revert the form to browse mode and re-load the venue as was before we clicked Edit.
        /// If we were adding a venue, clear the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cancel_Click(object sender, EventArgs e)
        {
            if(this.IsNewVenue)
            {
                this.ClearForm();
            }
            else
            {
                this.LoadVenue(VenueBeforeEdit);
            }

            this.IsEditMode = false;
            this.IsNewVenue = false;

            this.ToggleFormEditMode(IsEditMode);
            this.VenueBeforeEdit = null;
        }

        /// <summary>
        /// Deletes a venue from disk and updates the venue list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Delete_Click(object sender, EventArgs e)
        {
            // TODO: Handle errors that will happen if you delete a venue who has associated matches / teams
            Venue Venue = this.GetVenueDetailsFromForm();
            // Remove the player from the player list
            AllVenues.RemoveAll(v => v.GetVenueCode() == Venue.GetVenueCode());
            // Delete the players' file
            string FilePath = Utilities.VenueDataFolder + "\\" + Venue.GetVenueCode() + ".json";
            if (File.Exists(FilePath))
            {
                File.Delete(FilePath);
            }
            this.UpdateVenueList();
            // Clear the form, and disable the delete and edit buttons.
            this.ClearForm();
            Delete.Enabled = false;
            Edit.Enabled = false;

        }

        /// <summary>
        /// Puts the form into edit mode and clears it, ready for a new Venue
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddVenue_Click(object sender, EventArgs e)
        {
            this.IsNewVenue = true;
            this.IsEditMode = true;
            this.ClearForm();
            this.ToggleFormEditMode(this.IsEditMode);
        }

        private void LoadVenue(Venue Venue)
        {
            Address.Text = Venue.Address;
            VenueName.Text = Venue.Name;
            Capacity.Text = Venue.Capacity.ToString();
            VenueCode.Text = Venue.GetVenueCode();
        }

        /// <summary>
        /// Refrehses the data form to show details for a given venue
        /// </summary>
        /// <param name="Player"></param>
        private void RefreshVenueDetails(Venue Venue)
        {
            VenueName.Text = Venue.Name;
            Address.Text = Venue.Address;
            VenueCode.Text = Venue.GetVenueCode();
            Capacity.Text = Venue.Capacity.ToString();
        }

        /// <summary>
        /// Loads the venue from the clicked row into the data form, and ensures the form is in browse mode.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VenueList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Do nothing if we're in edit mode, as we don't want to overwirte an edit in progress
            if (IsEditMode)
            {
                return;
            }
            // Get the player details for the selected row
            Venue Venue = GetVenueFromDataGrid(VenueList.SelectedRows[0]);
            // Add the values to the relevant fields
            this.LoadVenue(Venue);
            // Enable the edit and delete buttons, as they're disabled until something is selected
            this.ToggleFormEditMode(false);
        }

        /// <summary>
        /// Gets a venue object for a given list view row
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private Venue GetVenueFromDataGrid(DataGridViewRow row)
        {
            string Name = row.Cells[0].Value.ToString();
            string Address = row.Cells[1].Value.ToString();
            Int32.TryParse(row.Cells[2].Value.ToString(), out int Capacity);
            string VenueCode = row.Cells[3].Value.ToString();
            Venue Venue = new Venue(Name, Address, Capacity, VenueCode);
            return Venue;
        }
    }
}
