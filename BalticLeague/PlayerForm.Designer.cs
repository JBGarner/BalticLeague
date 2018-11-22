namespace BalticLeague
{
    partial class PlayerForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.firstName = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.PlayerTeam = new System.Windows.Forms.ComboBox();
            this.Cancel = new System.Windows.Forms.Button();
            this.EditPlayer = new System.Windows.Forms.Button();
            this.DeletePlayer = new System.Windows.Forms.Button();
            this.SaveEdit = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.Injured = new System.Windows.Forms.CheckBox();
            this.playerCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lastName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.AddPlayer = new System.Windows.Forms.Button();
            this.Home = new System.Windows.Forms.Button();
            this.PlayerList = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PlayerList)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "First Name:";
            // 
            // firstName
            // 
            this.firstName.Enabled = false;
            this.firstName.Location = new System.Drawing.Point(67, 23);
            this.firstName.Name = "firstName";
            this.firstName.Size = new System.Drawing.Size(204, 20);
            this.firstName.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.PlayerTeam);
            this.groupBox1.Controls.Add(this.Cancel);
            this.groupBox1.Controls.Add(this.EditPlayer);
            this.groupBox1.Controls.Add(this.DeletePlayer);
            this.groupBox1.Controls.Add(this.SaveEdit);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.Injured);
            this.groupBox1.Controls.Add(this.playerCode);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lastName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.firstName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 224);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(629, 172);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Player details";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Enabled = false;
            this.label6.Location = new System.Drawing.Point(298, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Team:";
            // 
            // PlayerTeam
            // 
            this.PlayerTeam.FormattingEnabled = true;
            this.PlayerTeam.Location = new System.Drawing.Point(349, 58);
            this.PlayerTeam.Name = "PlayerTeam";
            this.PlayerTeam.Size = new System.Drawing.Size(225, 21);
            this.PlayerTeam.TabIndex = 13;
            // 
            // Cancel
            // 
            this.Cancel.Enabled = false;
            this.Cancel.Location = new System.Drawing.Point(205, 127);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 12;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // EditPlayer
            // 
            this.EditPlayer.Location = new System.Drawing.Point(6, 127);
            this.EditPlayer.Name = "EditPlayer";
            this.EditPlayer.Size = new System.Drawing.Size(75, 23);
            this.EditPlayer.TabIndex = 11;
            this.EditPlayer.Text = "Edit";
            this.EditPlayer.UseVisualStyleBackColor = true;
            this.EditPlayer.Click += new System.EventHandler(this.EditPlayer_Click);
            // 
            // DeletePlayer
            // 
            this.DeletePlayer.Enabled = false;
            this.DeletePlayer.Location = new System.Drawing.Point(301, 127);
            this.DeletePlayer.Name = "DeletePlayer";
            this.DeletePlayer.Size = new System.Drawing.Size(75, 23);
            this.DeletePlayer.TabIndex = 10;
            this.DeletePlayer.Text = "Delete Player";
            this.DeletePlayer.UseVisualStyleBackColor = true;
            this.DeletePlayer.Click += new System.EventHandler(this.DeletePlayer_Click);
            // 
            // SaveEdit
            // 
            this.SaveEdit.Enabled = false;
            this.SaveEdit.Location = new System.Drawing.Point(107, 127);
            this.SaveEdit.Name = "SaveEdit";
            this.SaveEdit.Size = new System.Drawing.Size(75, 23);
            this.SaveEdit.TabIndex = 9;
            this.SaveEdit.Text = "Save";
            this.SaveEdit.UseVisualStyleBackColor = true;
            this.SaveEdit.Click += new System.EventHandler(this.SaveEdit_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Injured?";
            // 
            // Injured
            // 
            this.Injured.AutoSize = true;
            this.Injured.Location = new System.Drawing.Point(67, 92);
            this.Injured.Name = "Injured";
            this.Injured.Size = new System.Drawing.Size(15, 14);
            this.Injured.TabIndex = 7;
            this.Injured.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Injured.UseVisualStyleBackColor = true;
            // 
            // playerCode
            // 
            this.playerCode.Enabled = false;
            this.playerCode.Location = new System.Drawing.Point(67, 58);
            this.playerCode.Name = "playerCode";
            this.playerCode.Size = new System.Drawing.Size(204, 20);
            this.playerCode.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Player code:";
            // 
            // lastName
            // 
            this.lastName.Enabled = false;
            this.lastName.Location = new System.Drawing.Point(349, 23);
            this.lastName.Name = "lastName";
            this.lastName.Size = new System.Drawing.Size(225, 20);
            this.lastName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(282, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Last Name:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Player list";
            // 
            // AddPlayer
            // 
            this.AddPlayer.Location = new System.Drawing.Point(662, 27);
            this.AddPlayer.Name = "AddPlayer";
            this.AddPlayer.Size = new System.Drawing.Size(75, 23);
            this.AddPlayer.TabIndex = 12;
            this.AddPlayer.Text = "Add Player";
            this.AddPlayer.UseVisualStyleBackColor = true;
            this.AddPlayer.Click += new System.EventHandler(this.AddPlayer_Click);
            // 
            // Home
            // 
            this.Home.Location = new System.Drawing.Point(666, 356);
            this.Home.Name = "Home";
            this.Home.Size = new System.Drawing.Size(71, 40);
            this.Home.TabIndex = 13;
            this.Home.Text = "Home";
            this.Home.UseVisualStyleBackColor = true;
            this.Home.Click += new System.EventHandler(this.Home_Click);
            // 
            // PlayerList
            // 
            this.PlayerList.AllowUserToAddRows = false;
            this.PlayerList.AllowUserToDeleteRows = false;
            this.PlayerList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PlayerList.Location = new System.Drawing.Point(13, 57);
            this.PlayerList.MultiSelect = false;
            this.PlayerList.Name = "PlayerList";
            this.PlayerList.ReadOnly = true;
            this.PlayerList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.PlayerList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.PlayerList.Size = new System.Drawing.Size(724, 150);
            this.PlayerList.TabIndex = 14;
            this.PlayerList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.PlayerList_CellClick);
            // 
            // PlayerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 415);
            this.Controls.Add(this.PlayerList);
            this.Controls.Add(this.Home);
            this.Controls.Add(this.AddPlayer);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.Name = "PlayerForm";
            this.Text = "Players";
            this.Load += new System.EventHandler(this.PlayerForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PlayerList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox firstName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox lastName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox Injured;
        private System.Windows.Forms.TextBox playerCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button SaveEdit;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button DeletePlayer;
        private System.Windows.Forms.Button EditPlayer;
        private System.Windows.Forms.Button AddPlayer;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Button Home;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox PlayerTeam;
        private System.Windows.Forms.DataGridView PlayerList;
    }
}