namespace BalticLeague
{
    partial class VenueForm
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
            this.VenueList = new System.Windows.Forms.DataGridView();
            this.AddVenue = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.VenueCode = new System.Windows.Forms.TextBox();
            this.VenueName = new System.Windows.Forms.TextBox();
            this.Delete = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            this.Edit = new System.Windows.Forms.Button();
            this.Capacity = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Address = new System.Windows.Forms.TextBox();
            this.Home = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.VenueList)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // VenueList
            // 
            this.VenueList.AllowUserToAddRows = false;
            this.VenueList.AllowUserToDeleteRows = false;
            this.VenueList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.VenueList.Location = new System.Drawing.Point(14, 41);
            this.VenueList.MultiSelect = false;
            this.VenueList.Name = "VenueList";
            this.VenueList.ReadOnly = true;
            this.VenueList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.VenueList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.VenueList.Size = new System.Drawing.Size(453, 150);
            this.VenueList.TabIndex = 0;
            this.VenueList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.VenueList_CellClick);
            // 
            // AddVenue
            // 
            this.AddVenue.Location = new System.Drawing.Point(390, 12);
            this.AddVenue.Name = "AddVenue";
            this.AddVenue.Size = new System.Drawing.Size(75, 23);
            this.AddVenue.TabIndex = 1;
            this.AddVenue.Text = "AddVenue";
            this.AddVenue.UseVisualStyleBackColor = true;
            this.AddVenue.Click += new System.EventHandler(this.AddVenue_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.VenueCode);
            this.groupBox1.Controls.Add(this.VenueName);
            this.groupBox1.Controls.Add(this.Delete);
            this.groupBox1.Controls.Add(this.Cancel);
            this.groupBox1.Controls.Add(this.Save);
            this.groupBox1.Controls.Add(this.Edit);
            this.groupBox1.Controls.Add(this.Capacity);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.Address);
            this.groupBox1.Location = new System.Drawing.Point(13, 214);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(372, 215);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Venue Details";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(173, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Venue Code:";
            // 
            // VenueCode
            // 
            this.VenueCode.Enabled = false;
            this.VenueCode.Location = new System.Drawing.Point(246, 130);
            this.VenueCode.Name = "VenueCode";
            this.VenueCode.Size = new System.Drawing.Size(114, 20);
            this.VenueCode.TabIndex = 9;
            // 
            // VenueName
            // 
            this.VenueName.Enabled = false;
            this.VenueName.Location = new System.Drawing.Point(67, 22);
            this.VenueName.Name = "VenueName";
            this.VenueName.Size = new System.Drawing.Size(293, 20);
            this.VenueName.TabIndex = 8;
            // 
            // Delete
            // 
            this.Delete.Enabled = false;
            this.Delete.Location = new System.Drawing.Point(285, 169);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(75, 23);
            this.Delete.TabIndex = 7;
            this.Delete.Text = "Delete";
            this.Delete.UseVisualStyleBackColor = true;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // Cancel
            // 
            this.Cancel.Enabled = false;
            this.Cancel.Location = new System.Drawing.Point(194, 169);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 6;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // Save
            // 
            this.Save.Enabled = false;
            this.Save.Location = new System.Drawing.Point(102, 169);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(75, 23);
            this.Save.TabIndex = 5;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // Edit
            // 
            this.Edit.Enabled = false;
            this.Edit.Location = new System.Drawing.Point(6, 169);
            this.Edit.Name = "Edit";
            this.Edit.Size = new System.Drawing.Size(75, 23);
            this.Edit.TabIndex = 4;
            this.Edit.Text = "Edit";
            this.Edit.UseVisualStyleBackColor = true;
            this.Edit.Click += new System.EventHandler(this.Edit_Click);
            // 
            // Capacity
            // 
            this.Capacity.Enabled = false;
            this.Capacity.Location = new System.Drawing.Point(67, 130);
            this.Capacity.Name = "Capacity";
            this.Capacity.Size = new System.Drawing.Size(100, 20);
            this.Capacity.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Capacity:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Address:";
            // 
            // Address
            // 
            this.Address.Enabled = false;
            this.Address.Location = new System.Drawing.Point(67, 52);
            this.Address.Multiline = true;
            this.Address.Name = "Address";
            this.Address.Size = new System.Drawing.Size(293, 69);
            this.Address.TabIndex = 0;
            // 
            // Home
            // 
            this.Home.Location = new System.Drawing.Point(391, 372);
            this.Home.Name = "Home";
            this.Home.Size = new System.Drawing.Size(74, 57);
            this.Home.TabIndex = 3;
            this.Home.Text = "Home";
            this.Home.UseVisualStyleBackColor = true;
            this.Home.Click += new System.EventHandler(this.Home_Click);
            // 
            // VenueForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 439);
            this.Controls.Add(this.Home);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.AddVenue);
            this.Controls.Add(this.VenueList);
            this.Name = "VenueForm";
            this.Text = "Venues";
            this.Load += new System.EventHandler(this.VenueForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.VenueList)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView VenueList;
        private System.Windows.Forms.Button AddVenue;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Home;
        private System.Windows.Forms.TextBox Address;
        private System.Windows.Forms.TextBox Capacity;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Edit;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox VenueCode;
        private System.Windows.Forms.TextBox VenueName;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.Label label4;
    }
}