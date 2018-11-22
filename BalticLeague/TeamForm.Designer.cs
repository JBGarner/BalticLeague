namespace BalticLeague
{
    partial class TeamForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Home = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.AddNewTeam = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Delete = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            this.Edit = new System.Windows.Forms.Button();
            this.AddVenue = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.Venue = new System.Windows.Forms.ComboBox();
            this.TeamCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TeamName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.PlayerCombo = new System.Windows.Forms.ComboBox();
            this.AddPlayerToTeam = new System.Windows.Forms.Button();
            this.RemovePlayerFromTeam = new System.Windows.Forms.Button();
            this.PlayerDetails = new System.Windows.Forms.GroupBox();
            this.PlayerCode = new System.Windows.Forms.TextBox();
            this.PlayerName = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TeamListView = new System.Windows.Forms.DataGridView();
            this.TeamPlayerView = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.PlayerDetails.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TeamListView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TeamPlayerView)).BeginInit();
            this.SuspendLayout();
            // 
            // Home
            // 
            this.Home.Location = new System.Drawing.Point(695, 363);
            this.Home.Name = "Home";
            this.Home.Size = new System.Drawing.Size(71, 40);
            this.Home.TabIndex = 14;
            this.Home.Text = "Home";
            this.Home.UseVisualStyleBackColor = true;
            this.Home.Click += new System.EventHandler(this.Home_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Teams";
            // 
            // AddNewTeam
            // 
            this.AddNewTeam.Location = new System.Drawing.Point(301, 12);
            this.AddNewTeam.Name = "AddNewTeam";
            this.AddNewTeam.Size = new System.Drawing.Size(92, 23);
            this.AddNewTeam.TabIndex = 17;
            this.AddNewTeam.Text = "Add new team";
            this.AddNewTeam.UseVisualStyleBackColor = true;
            this.AddNewTeam.Click += new System.EventHandler(this.AddNewTeam_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Delete);
            this.groupBox1.Controls.Add(this.Cancel);
            this.groupBox1.Controls.Add(this.Save);
            this.groupBox1.Controls.Add(this.Edit);
            this.groupBox1.Controls.Add(this.AddVenue);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.Venue);
            this.groupBox1.Controls.Add(this.TeamCode);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.TeamName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(15, 211);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(378, 181);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Team Details";
            // 
            // Delete
            // 
            this.Delete.Location = new System.Drawing.Point(297, 123);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(75, 23);
            this.Delete.TabIndex = 31;
            this.Delete.Text = "Delete";
            this.Delete.UseVisualStyleBackColor = true;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(208, 123);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 30;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(112, 123);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(75, 23);
            this.Save.TabIndex = 29;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // Edit
            // 
            this.Edit.Location = new System.Drawing.Point(13, 122);
            this.Edit.Name = "Edit";
            this.Edit.Size = new System.Drawing.Size(75, 23);
            this.Edit.TabIndex = 7;
            this.Edit.Text = "Edit";
            this.Edit.UseVisualStyleBackColor = true;
            this.Edit.Click += new System.EventHandler(this.Edit_Click);
            // 
            // AddVenue
            // 
            this.AddVenue.Enabled = false;
            this.AddVenue.Location = new System.Drawing.Point(330, 92);
            this.AddVenue.Name = "AddVenue";
            this.AddVenue.Size = new System.Drawing.Size(31, 23);
            this.AddVenue.TabIndex = 6;
            this.AddVenue.Text = "+";
            this.AddVenue.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Venue:";
            // 
            // Venue
            // 
            this.Venue.Enabled = false;
            this.Venue.FormattingEnabled = true;
            this.Venue.Location = new System.Drawing.Point(80, 92);
            this.Venue.Name = "Venue";
            this.Venue.Size = new System.Drawing.Size(244, 21);
            this.Venue.TabIndex = 4;
            // 
            // TeamCode
            // 
            this.TeamCode.Enabled = false;
            this.TeamCode.Location = new System.Drawing.Point(80, 56);
            this.TeamCode.Name = "TeamCode";
            this.TeamCode.Size = new System.Drawing.Size(281, 20);
            this.TeamCode.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Team code:";
            // 
            // TeamName
            // 
            this.TeamName.Enabled = false;
            this.TeamName.Location = new System.Drawing.Point(80, 20);
            this.TeamName.Name = "TeamName";
            this.TeamName.Size = new System.Drawing.Size(281, 20);
            this.TeamName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Team name:";
            // 
            // PlayerCombo
            // 
            this.PlayerCombo.Enabled = false;
            this.PlayerCombo.FormattingEnabled = true;
            this.PlayerCombo.Location = new System.Drawing.Point(6, 24);
            this.PlayerCombo.Name = "PlayerCombo";
            this.PlayerCombo.Size = new System.Drawing.Size(235, 21);
            this.PlayerCombo.TabIndex = 20;
            // 
            // AddPlayerToTeam
            // 
            this.AddPlayerToTeam.Location = new System.Drawing.Point(261, 22);
            this.AddPlayerToTeam.Name = "AddPlayerToTeam";
            this.AddPlayerToTeam.Size = new System.Drawing.Size(75, 23);
            this.AddPlayerToTeam.TabIndex = 21;
            this.AddPlayerToTeam.Text = "Add to team";
            this.AddPlayerToTeam.UseVisualStyleBackColor = true;
            this.AddPlayerToTeam.Click += new System.EventHandler(this.AddPlayerToTeam_Click);
            // 
            // RemovePlayerFromTeam
            // 
            this.RemovePlayerFromTeam.Location = new System.Drawing.Point(270, 19);
            this.RemovePlayerFromTeam.Name = "RemovePlayerFromTeam";
            this.RemovePlayerFromTeam.Size = new System.Drawing.Size(75, 47);
            this.RemovePlayerFromTeam.TabIndex = 22;
            this.RemovePlayerFromTeam.Text = "Remove from team";
            this.RemovePlayerFromTeam.UseVisualStyleBackColor = true;
            this.RemovePlayerFromTeam.Click += new System.EventHandler(this.RemovePlayerFromTeam_Click);
            // 
            // PlayerDetails
            // 
            this.PlayerDetails.Controls.Add(this.PlayerCode);
            this.PlayerDetails.Controls.Add(this.RemovePlayerFromTeam);
            this.PlayerDetails.Controls.Add(this.PlayerName);
            this.PlayerDetails.Location = new System.Drawing.Point(415, 211);
            this.PlayerDetails.Name = "PlayerDetails";
            this.PlayerDetails.Size = new System.Drawing.Size(351, 76);
            this.PlayerDetails.TabIndex = 23;
            this.PlayerDetails.TabStop = false;
            this.PlayerDetails.Text = "Player details";
            // 
            // PlayerCode
            // 
            this.PlayerCode.Enabled = false;
            this.PlayerCode.Location = new System.Drawing.Point(7, 47);
            this.PlayerCode.Name = "PlayerCode";
            this.PlayerCode.Size = new System.Drawing.Size(257, 20);
            this.PlayerCode.TabIndex = 1;
            // 
            // PlayerName
            // 
            this.PlayerName.Enabled = false;
            this.PlayerName.Location = new System.Drawing.Point(7, 20);
            this.PlayerName.Name = "PlayerName";
            this.PlayerName.Size = new System.Drawing.Size(257, 20);
            this.PlayerName.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.PlayerCombo);
            this.groupBox2.Controls.Add(this.AddPlayerToTeam);
            this.groupBox2.Location = new System.Drawing.Point(415, 293);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(351, 64);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Add player to team";
            // 
            // TeamListView
            // 
            this.TeamListView.AllowUserToAddRows = false;
            this.TeamListView.AllowUserToDeleteRows = false;
            this.TeamListView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TeamListView.Location = new System.Drawing.Point(15, 49);
            this.TeamListView.MultiSelect = false;
            this.TeamListView.Name = "TeamListView";
            this.TeamListView.ReadOnly = true;
            this.TeamListView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.TeamListView.Size = new System.Drawing.Size(378, 150);
            this.TeamListView.TabIndex = 26;
            this.TeamListView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TeamListView_CellClick);
            // 
            // TeamPlayerView
            // 
            this.TeamPlayerView.AllowUserToAddRows = false;
            this.TeamPlayerView.AllowUserToDeleteRows = false;
            this.TeamPlayerView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TeamPlayerView.Enabled = false;
            this.TeamPlayerView.Location = new System.Drawing.Point(415, 49);
            this.TeamPlayerView.MultiSelect = false;
            this.TeamPlayerView.Name = "TeamPlayerView";
            this.TeamPlayerView.ReadOnly = true;
            this.TeamPlayerView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.TeamPlayerView.Size = new System.Drawing.Size(351, 150);
            this.TeamPlayerView.TabIndex = 27;
            this.TeamPlayerView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TeamPlayerView_CellClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(412, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 28;
            this.label5.Text = "Team Players";
            // 
            // TeamForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 415);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TeamPlayerView);
            this.Controls.Add(this.TeamListView);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.PlayerDetails);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.AddNewTeam);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Home);
            this.Name = "TeamForm";
            this.Text = "Teams";
            this.Load += new System.EventHandler(this.TeamForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.PlayerDetails.ResumeLayout(false);
            this.PlayerDetails.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TeamListView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TeamPlayerView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Home;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button AddNewTeam;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox TeamName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TeamCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button AddVenue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox Venue;
        private System.Windows.Forms.ComboBox PlayerCombo;
        private System.Windows.Forms.Button AddPlayerToTeam;
        private System.Windows.Forms.Button RemovePlayerFromTeam;
        private System.Windows.Forms.GroupBox PlayerDetails;
        private System.Windows.Forms.TextBox PlayerName;
        private System.Windows.Forms.TextBox PlayerCode;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView TeamListView;
        private System.Windows.Forms.DataGridView TeamPlayerView;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button Edit;
    }
}