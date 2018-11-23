namespace BalticLeague
{
    partial class Home
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
            this.HomePlayers = new System.Windows.Forms.Button();
            this.HomeTeams = new System.Windows.Forms.Button();
            this.Matches = new System.Windows.Forms.Button();
            this.Venues = new System.Windows.Forms.Button();
            this.Lineups = new System.Windows.Forms.Button();
            this.Help = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // HomePlayers
            // 
            this.HomePlayers.Location = new System.Drawing.Point(12, 38);
            this.HomePlayers.Name = "HomePlayers";
            this.HomePlayers.Size = new System.Drawing.Size(92, 40);
            this.HomePlayers.TabIndex = 0;
            this.HomePlayers.Text = "Players";
            this.HomePlayers.UseVisualStyleBackColor = true;
            this.HomePlayers.Click += new System.EventHandler(this.HomePlayers_Click);
            // 
            // HomeTeams
            // 
            this.HomeTeams.Location = new System.Drawing.Point(208, 38);
            this.HomeTeams.Name = "HomeTeams";
            this.HomeTeams.Size = new System.Drawing.Size(92, 40);
            this.HomeTeams.TabIndex = 1;
            this.HomeTeams.Text = "Teams";
            this.HomeTeams.UseVisualStyleBackColor = true;
            this.HomeTeams.Click += new System.EventHandler(this.HomeTeams_Click);
            // 
            // Matches
            // 
            this.Matches.Location = new System.Drawing.Point(404, 38);
            this.Matches.Name = "Matches";
            this.Matches.Size = new System.Drawing.Size(92, 40);
            this.Matches.TabIndex = 2;
            this.Matches.Text = "Matches";
            this.Matches.UseVisualStyleBackColor = true;
            this.Matches.Click += new System.EventHandler(this.Matches_Click);
            // 
            // Venues
            // 
            this.Venues.Location = new System.Drawing.Point(110, 38);
            this.Venues.Name = "Venues";
            this.Venues.Size = new System.Drawing.Size(92, 40);
            this.Venues.TabIndex = 4;
            this.Venues.Text = "Venues";
            this.Venues.UseVisualStyleBackColor = true;
            this.Venues.Click += new System.EventHandler(this.Venues_Click);
            // 
            // Lineups
            // 
            this.Lineups.Location = new System.Drawing.Point(306, 38);
            this.Lineups.Name = "Lineups";
            this.Lineups.Size = new System.Drawing.Size(92, 40);
            this.Lineups.TabIndex = 5;
            this.Lineups.Text = "Lineups";
            this.Lineups.UseVisualStyleBackColor = true;
            this.Lineups.Click += new System.EventHandler(this.Lineups_Click);
            // 
            // Help
            // 
            this.Help.Location = new System.Drawing.Point(208, 101);
            this.Help.Name = "Help";
            this.Help.Size = new System.Drawing.Size(92, 23);
            this.Help.TabIndex = 6;
            this.Help.Text = "Help";
            this.Help.UseVisualStyleBackColor = true;
            this.Help.Click += new System.EventHandler(this.Help_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 136);
            this.Controls.Add(this.Help);
            this.Controls.Add(this.Lineups);
            this.Controls.Add(this.Venues);
            this.Controls.Add(this.Matches);
            this.Controls.Add(this.HomeTeams);
            this.Controls.Add(this.HomePlayers);
            this.Name = "Home";
            this.Text = "Home";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button HomePlayers;
        private System.Windows.Forms.Button HomeTeams;
        private System.Windows.Forms.Button Matches;
        private System.Windows.Forms.Button Venues;
        private System.Windows.Forms.Button Lineups;
        private System.Windows.Forms.Button Help;
    }
}