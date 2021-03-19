namespace ContactsAppUI
{
    partial class ContactsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContactsForm));
            this.RemoveButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.ContactsListBox = new System.Windows.Forms.ListBox();
            this.IdVkTextBox = new System.Windows.Forms.TextBox();
            this.EmailTextBox = new System.Windows.Forms.TextBox();
            this.SurnameTextBox = new System.Windows.Forms.TextBox();
            this.PhoneTextBox = new System.Windows.Forms.TextBox();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.PhoneLabel = new System.Windows.Forms.Label();
            this.BirthDayLabel = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.SurnameLabel = new System.Windows.Forms.Label();
            this.IdVKLabel = new System.Windows.Forms.Label();
            this.EmailLabel = new System.Windows.Forms.Label();
            this.dateBirthDay = new System.Windows.Forms.DateTimePicker();
            this.FindLabel = new System.Windows.Forms.Label();
            this.FindTextBox = new System.Windows.Forms.TextBox();
            this.EditButton = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripSplitButton();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripDropDownButton();
            this.addContactToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripSplitButton();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // RemoveButton
            // 
            this.RemoveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RemoveButton.Image = ((System.Drawing.Image)(resources.GetObject("RemoveButton.Image")));
            this.RemoveButton.Location = new System.Drawing.Point(74, 402);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(28, 23);
            this.RemoveButton.TabIndex = 0;
            this.RemoveButton.UseVisualStyleBackColor = true;
            this.RemoveButton.Click += new System.EventHandler(this.Remove_Click);
            // 
            // AddButton
            // 
            this.AddButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AddButton.Image = ((System.Drawing.Image)(resources.GetObject("AddButton.Image")));
            this.AddButton.Location = new System.Drawing.Point(12, 402);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(28, 23);
            this.AddButton.TabIndex = 6;
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.Add_Click);
            // 
            // ContactsListBox
            // 
            this.ContactsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ContactsListBox.FormattingEnabled = true;
            this.ContactsListBox.Location = new System.Drawing.Point(12, 57);
            this.ContactsListBox.Margin = new System.Windows.Forms.Padding(1);
            this.ContactsListBox.Name = "ContactsListBox";
            this.ContactsListBox.Size = new System.Drawing.Size(217, 316);
            this.ContactsListBox.TabIndex = 7;
            // 
            // IdVkTextBox
            // 
            this.IdVkTextBox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.IdVkTextBox.Location = new System.Drawing.Point(317, 167);
            this.IdVkTextBox.Name = "IdVkTextBox";
            this.IdVkTextBox.Size = new System.Drawing.Size(369, 20);
            this.IdVkTextBox.TabIndex = 9;
            // 
            // EmailTextBox
            // 
            this.EmailTextBox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.EmailTextBox.Location = new System.Drawing.Point(317, 136);
            this.EmailTextBox.Name = "EmailTextBox";
            this.EmailTextBox.Size = new System.Drawing.Size(369, 20);
            this.EmailTextBox.TabIndex = 10;
            // 
            // SurnameTextBox
            // 
            this.SurnameTextBox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.SurnameTextBox.Location = new System.Drawing.Point(317, 27);
            this.SurnameTextBox.Name = "SurnameTextBox";
            this.SurnameTextBox.Size = new System.Drawing.Size(369, 20);
            this.SurnameTextBox.TabIndex = 11;
            // 
            // PhoneTextBox
            // 
            this.PhoneTextBox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.PhoneTextBox.Location = new System.Drawing.Point(317, 108);
            this.PhoneTextBox.Name = "PhoneTextBox";
            this.PhoneTextBox.Size = new System.Drawing.Size(369, 20);
            this.PhoneTextBox.TabIndex = 12;
            // 
            // NameTextBox
            // 
            this.NameTextBox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.NameTextBox.Location = new System.Drawing.Point(317, 55);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(369, 20);
            this.NameTextBox.TabIndex = 13;
            // 
            // PhoneLabel
            // 
            this.PhoneLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.PhoneLabel.AutoSize = true;
            this.PhoneLabel.Location = new System.Drawing.Point(265, 111);
            this.PhoneLabel.Name = "PhoneLabel";
            this.PhoneLabel.Size = new System.Drawing.Size(41, 13);
            this.PhoneLabel.TabIndex = 3;
            this.PhoneLabel.Text = "Phone:";
            // 
            // BirthDayLabel
            // 
            this.BirthDayLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.BirthDayLabel.AutoSize = true;
            this.BirthDayLabel.Location = new System.Drawing.Point(256, 87);
            this.BirthDayLabel.Name = "BirthDayLabel";
            this.BirthDayLabel.Size = new System.Drawing.Size(50, 13);
            this.BirthDayLabel.TabIndex = 2;
            this.BirthDayLabel.Text = "BirthDay:";
            // 
            // NameLabel
            // 
            this.NameLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(268, 58);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(38, 13);
            this.NameLabel.TabIndex = 1;
            this.NameLabel.Text = "Name:";
            // 
            // SurnameLabel
            // 
            this.SurnameLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.SurnameLabel.AutoSize = true;
            this.SurnameLabel.Location = new System.Drawing.Point(254, 30);
            this.SurnameLabel.Name = "SurnameLabel";
            this.SurnameLabel.Size = new System.Drawing.Size(52, 13);
            this.SurnameLabel.TabIndex = 0;
            this.SurnameLabel.Text = "Surname:";
            // 
            // IdVKLabel
            // 
            this.IdVKLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.IdVKLabel.AutoSize = true;
            this.IdVKLabel.Location = new System.Drawing.Point(261, 170);
            this.IdVKLabel.Name = "IdVKLabel";
            this.IdVKLabel.Size = new System.Drawing.Size(45, 13);
            this.IdVKLabel.TabIndex = 5;
            this.IdVKLabel.Text = "vk.com:";
            // 
            // EmailLabel
            // 
            this.EmailLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.EmailLabel.AutoSize = true;
            this.EmailLabel.Location = new System.Drawing.Point(271, 139);
            this.EmailLabel.Name = "EmailLabel";
            this.EmailLabel.Size = new System.Drawing.Size(35, 13);
            this.EmailLabel.TabIndex = 4;
            this.EmailLabel.Text = "Email:";
            // 
            // dateBirthDay
            // 
            this.dateBirthDay.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.dateBirthDay.Location = new System.Drawing.Point(317, 81);
            this.dateBirthDay.Name = "dateBirthDay";
            this.dateBirthDay.Size = new System.Drawing.Size(140, 20);
            this.dateBirthDay.TabIndex = 14;
            // 
            // FindLabel
            // 
            this.FindLabel.AutoSize = true;
            this.FindLabel.Location = new System.Drawing.Point(12, 30);
            this.FindLabel.Name = "FindLabel";
            this.FindLabel.Size = new System.Drawing.Size(30, 13);
            this.FindLabel.TabIndex = 15;
            this.FindLabel.Text = "Find:";
            // 
            // FindTextBox
            // 
            this.FindTextBox.Location = new System.Drawing.Point(48, 27);
            this.FindTextBox.Name = "FindTextBox";
            this.FindTextBox.Size = new System.Drawing.Size(181, 20);
            this.FindTextBox.TabIndex = 16;
            // 
            // EditButton
            // 
            this.EditButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.EditButton.Image = ((System.Drawing.Image)(resources.GetObject("EditButton.Image")));
            this.EditButton.Location = new System.Drawing.Point(43, 402);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(28, 23);
            this.EditButton.TabIndex = 17;
            this.EditButton.UseVisualStyleBackColor = true;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(702, 25);
            this.toolStrip1.TabIndex = 18;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("fileToolStripMenuItem.Image")));
            this.fileToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(41, 22);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addContactToolStripMenuItem,
            this.editToolStripMenuItem1,
            this.removeToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(40, 22);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // addContactToolStripMenuItem
            // 
            this.addContactToolStripMenuItem.Name = "addContactToolStripMenuItem";
            this.addContactToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.addContactToolStripMenuItem.Text = "Add Contact";
            this.addContactToolStripMenuItem.Click += new System.EventHandler(this.Add_Click);
            // 
            // editToolStripMenuItem1
            // 
            this.editToolStripMenuItem1.Name = "editToolStripMenuItem1";
            this.editToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.editToolStripMenuItem1.Text = "Edit";
            this.editToolStripMenuItem1.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.removeToolStripMenuItem.Text = "Remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.Remove_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("helpToolStripMenuItem.Image")));
            this.helpToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(48, 22);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // ContactsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 440);
            this.Controls.Add(this.dateBirthDay);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.SurnameLabel);
            this.Controls.Add(this.EmailLabel);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.PhoneTextBox);
            this.Controls.Add(this.BirthDayLabel);
            this.Controls.Add(this.IdVKLabel);
            this.Controls.Add(this.PhoneLabel);
            this.Controls.Add(this.SurnameTextBox);
            this.Controls.Add(this.EmailTextBox);
            this.Controls.Add(this.IdVkTextBox);
            this.Controls.Add(this.EditButton);
            this.Controls.Add(this.FindTextBox);
            this.Controls.Add(this.FindLabel);
            this.Controls.Add(this.ContactsListBox);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.RemoveButton);
            this.Controls.Add(this.toolStrip1);
            this.MaximumSize = new System.Drawing.Size(844, 547);
            this.MinimumSize = new System.Drawing.Size(689, 463);
            this.Name = "ContactsForm";
            this.Text = "ContactsApp";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button RemoveButton;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.ListBox ContactsListBox;
        private System.Windows.Forms.TextBox IdVkTextBox;
        private System.Windows.Forms.TextBox EmailTextBox;
        private System.Windows.Forms.TextBox SurnameTextBox;
        private System.Windows.Forms.TextBox PhoneTextBox;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.TextBox FindTextBox;
        private System.Windows.Forms.Label FindLabel;
        private System.Windows.Forms.DateTimePicker dateBirthDay;
        private System.Windows.Forms.Label SurnameLabel;
        private System.Windows.Forms.Label EmailLabel;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label BirthDayLabel;
        private System.Windows.Forms.Label IdVKLabel;
        private System.Windows.Forms.Label PhoneLabel;
        private System.Windows.Forms.ToolStripDropDownButton editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addContactToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSplitButton helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripSplitButton fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}