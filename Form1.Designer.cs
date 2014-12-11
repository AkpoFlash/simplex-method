namespace WindowsFormsApplication3
{
    partial class Main_form
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main_form));
            this.panel2 = new System.Windows.Forms.Panel();
            this.privileges_but = new System.Windows.Forms.Button();
            this.exit_but = new System.Windows.Forms.Button();
            this.Back_setting = new System.Windows.Forms.Button();
            this.del_user = new System.Windows.Forms.Button();
            this.BgColor = new System.Windows.Forms.Button();
            this.Back_but2 = new System.Windows.Forms.Button();
            this.Next_but2 = new System.Windows.Forms.Button();
            this.Back_but = new System.Windows.Forms.Button();
            this.Next_but = new System.Windows.Forms.Button();
            this.Font_but = new System.Windows.Forms.Button();
            this.fontDialog = new System.Windows.Forms.FontDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.BottomToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.TopToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.RightToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.LeftToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.ContentPanel = new System.Windows.Forms.ToolStripContentPanel();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.panel3 = new System.Windows.Forms.Panel();
            this.make_user_but = new System.Windows.Forms.Button();
            this.make_admin_but = new System.Windows.Forms.Button();
            this.delete_but = new System.Windows.Forms.Button();
            this.error_lab = new System.Windows.Forms.Label();
            this.Registration = new System.Windows.Forms.Button();
            this.password_lab = new System.Windows.Forms.Label();
            this.username_lab = new System.Windows.Forms.Label();
            this.Login = new System.Windows.Forms.Button();
            this.password_login = new System.Windows.Forms.TextBox();
            this.username_login = new System.Windows.Forms.TextBox();
            this.Header_lab = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.Limit_lab = new System.Windows.Forms.Label();
            this.Num_unknow_lab = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.databaseDataSet = new WindowsFormsApplication3.DatabaseDataSet();
            this.usersTableAdapter = new WindowsFormsApplication3.DatabaseDataSetTableAdapters.UsersTableAdapter();
            this.panel2.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.databaseDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.panel2.Controls.Add(this.privileges_but);
            this.panel2.Controls.Add(this.exit_but);
            this.panel2.Controls.Add(this.Back_setting);
            this.panel2.Controls.Add(this.del_user);
            this.panel2.Controls.Add(this.BgColor);
            this.panel2.Controls.Add(this.Back_but2);
            this.panel2.Controls.Add(this.Next_but2);
            this.panel2.Controls.Add(this.Back_but);
            this.panel2.Controls.Add(this.Next_but);
            this.panel2.Controls.Add(this.Font_but);
            this.panel2.Location = new System.Drawing.Point(0, 523);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(984, 39);
            this.panel2.TabIndex = 1;
            // 
            // privileges_but
            // 
            this.privileges_but.Location = new System.Drawing.Point(345, 7);
            this.privileges_but.Name = "privileges_but";
            this.privileges_but.Size = new System.Drawing.Size(75, 23);
            this.privileges_but.TabIndex = 11;
            this.privileges_but.Text = "Privileges";
            this.privileges_but.UseVisualStyleBackColor = true;
            this.privileges_but.Visible = false;
            this.privileges_but.Click += new System.EventHandler(this.privileges_but_Click);
            // 
            // exit_but
            // 
            this.exit_but.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exit_but.Location = new System.Drawing.Point(5, 7);
            this.exit_but.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.exit_but.Name = "exit_but";
            this.exit_but.Size = new System.Drawing.Size(75, 23);
            this.exit_but.TabIndex = 10;
            this.exit_but.Text = "Exit";
            this.exit_but.UseVisualStyleBackColor = true;
            this.exit_but.Visible = false;
            this.exit_but.Click += new System.EventHandler(this.exit_but_Click);
            // 
            // Back_setting
            // 
            this.Back_setting.Location = new System.Drawing.Point(816, 7);
            this.Back_setting.Name = "Back_setting";
            this.Back_setting.Size = new System.Drawing.Size(75, 23);
            this.Back_setting.TabIndex = 9;
            this.Back_setting.Text = "<< Back";
            this.Back_setting.UseVisualStyleBackColor = true;
            this.Back_setting.Visible = false;
            this.Back_setting.Click += new System.EventHandler(this.Back_setting_Click);
            // 
            // del_user
            // 
            this.del_user.Location = new System.Drawing.Point(260, 7);
            this.del_user.Name = "del_user";
            this.del_user.Size = new System.Drawing.Size(75, 23);
            this.del_user.TabIndex = 8;
            this.del_user.Text = "Delete";
            this.del_user.UseVisualStyleBackColor = true;
            this.del_user.Visible = false;
            this.del_user.Click += new System.EventHandler(this.del_user_Click);
            // 
            // BgColor
            // 
            this.BgColor.Location = new System.Drawing.Point(175, 7);
            this.BgColor.Name = "BgColor";
            this.BgColor.Size = new System.Drawing.Size(75, 23);
            this.BgColor.TabIndex = 7;
            this.BgColor.Text = "BgColor";
            this.BgColor.UseVisualStyleBackColor = true;
            this.BgColor.Visible = false;
            this.BgColor.Click += new System.EventHandler(this.BgColor_Click);
            // 
            // Back_but2
            // 
            this.Back_but2.Location = new System.Drawing.Point(816, 7);
            this.Back_but2.Name = "Back_but2";
            this.Back_but2.Size = new System.Drawing.Size(75, 23);
            this.Back_but2.TabIndex = 6;
            this.Back_but2.Text = "<< Back";
            this.Back_but2.UseVisualStyleBackColor = true;
            this.Back_but2.Visible = false;
            this.Back_but2.Click += new System.EventHandler(this.Back_but2_Click);
            // 
            // Next_but2
            // 
            this.Next_but2.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.Next_but2.Location = new System.Drawing.Point(899, 7);
            this.Next_but2.Name = "Next_but2";
            this.Next_but2.Size = new System.Drawing.Size(75, 23);
            this.Next_but2.TabIndex = 5;
            this.Next_but2.Text = "Next >>";
            this.Next_but2.UseVisualStyleBackColor = true;
            this.Next_but2.Visible = false;
            this.Next_but2.Click += new System.EventHandler(this.Next_but2_Click);
            // 
            // Back_but
            // 
            this.Back_but.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Back_but.Location = new System.Drawing.Point(816, 7);
            this.Back_but.Name = "Back_but";
            this.Back_but.Size = new System.Drawing.Size(75, 23);
            this.Back_but.TabIndex = 6;
            this.Back_but.Text = "<< Back";
            this.Back_but.UseVisualStyleBackColor = true;
            this.Back_but.Visible = false;
            this.Back_but.Click += new System.EventHandler(this.Back_but_Click);
            // 
            // Next_but
            // 
            this.Next_but.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Next_but.Location = new System.Drawing.Point(899, 8);
            this.Next_but.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.Next_but.Name = "Next_but";
            this.Next_but.Size = new System.Drawing.Size(74, 21);
            this.Next_but.TabIndex = 5;
            this.Next_but.Text = "Next >>";
            this.Next_but.UseVisualStyleBackColor = true;
            this.Next_but.Visible = false;
            this.Next_but.Click += new System.EventHandler(this.Next_but_Click);
            // 
            // Font_but
            // 
            this.Font_but.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Font_but.Location = new System.Drawing.Point(90, 7);
            this.Font_but.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.Font_but.Name = "Font_but";
            this.Font_but.Size = new System.Drawing.Size(75, 23);
            this.Font_but.TabIndex = 6;
            this.Font_but.Text = "Font";
            this.Font_but.UseVisualStyleBackColor = true;
            this.Font_but.Visible = false;
            this.Font_but.Click += new System.EventHandler(this.Font_but_Click);
            // 
            // fontDialog
            // 
            this.fontDialog.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.fontDialog.MaxSize = 14;
            this.fontDialog.MinSize = 10;
            // 
            // BottomToolStripPanel
            // 
            this.BottomToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.BottomToolStripPanel.Name = "BottomToolStripPanel";
            this.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.BottomToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.BottomToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // TopToolStripPanel
            // 
            this.TopToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.TopToolStripPanel.Name = "TopToolStripPanel";
            this.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.TopToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.TopToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // RightToolStripPanel
            // 
            this.RightToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.RightToolStripPanel.Name = "RightToolStripPanel";
            this.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.RightToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.RightToolStripPanel.Size = new System.Drawing.Size(0, 0);
            this.RightToolStripPanel.Visible = false;
            // 
            // LeftToolStripPanel
            // 
            this.LeftToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftToolStripPanel.Name = "LeftToolStripPanel";
            this.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.LeftToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.LeftToolStripPanel.Size = new System.Drawing.Size(0, 0);
            this.LeftToolStripPanel.Visible = false;
            // 
            // ContentPanel
            // 
            this.ContentPanel.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.ContentPanel.Size = new System.Drawing.Size(984, 562);
            // 
            // toolStripContainer1
            // 
            this.toolStripContainer1.BottomToolStripPanelVisible = false;
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.panel3);
            this.toolStripContainer1.ContentPanel.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(984, 562);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.RightToolStripPanelVisible = false;
            this.toolStripContainer1.Size = new System.Drawing.Size(984, 562);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            this.toolStripContainer1.TopToolStripPanelVisible = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FloralWhite;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.make_user_but);
            this.panel3.Controls.Add(this.make_admin_but);
            this.panel3.Controls.Add(this.delete_but);
            this.panel3.Controls.Add(this.error_lab);
            this.panel3.Controls.Add(this.Registration);
            this.panel3.Controls.Add(this.password_lab);
            this.panel3.Controls.Add(this.username_lab);
            this.panel3.Controls.Add(this.Login);
            this.panel3.Controls.Add(this.password_login);
            this.panel3.Controls.Add(this.username_login);
            this.panel3.Controls.Add(this.Header_lab);
            this.panel3.Controls.Add(this.comboBox2);
            this.panel3.Controls.Add(this.Limit_lab);
            this.panel3.Controls.Add(this.Num_unknow_lab);
            this.panel3.Controls.Add(this.comboBox1);
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(984, 526);
            this.panel3.TabIndex = 1;
            // 
            // make_user_but
            // 
            this.make_user_but.Location = new System.Drawing.Point(484, 211);
            this.make_user_but.Name = "make_user_but";
            this.make_user_but.Size = new System.Drawing.Size(70, 23);
            this.make_user_but.TabIndex = 11;
            this.make_user_but.Text = "User";
            this.make_user_but.UseVisualStyleBackColor = true;
            this.make_user_but.Visible = false;
            this.make_user_but.Click += new System.EventHandler(this.make_user_but_Click);
            // 
            // make_admin_but
            // 
            this.make_admin_but.Location = new System.Drawing.Point(404, 211);
            this.make_admin_but.Name = "make_admin_but";
            this.make_admin_but.Size = new System.Drawing.Size(70, 23);
            this.make_admin_but.TabIndex = 10;
            this.make_admin_but.Text = "Admin";
            this.make_admin_but.UseVisualStyleBackColor = true;
            this.make_admin_but.Visible = false;
            this.make_admin_but.Click += new System.EventHandler(this.make_admin_but_Click);
            // 
            // delete_but
            // 
            this.delete_but.Location = new System.Drawing.Point(565, 186);
            this.delete_but.Name = "delete_but";
            this.delete_but.Size = new System.Drawing.Size(70, 23);
            this.delete_but.TabIndex = 9;
            this.delete_but.Text = "Delete";
            this.delete_but.UseVisualStyleBackColor = true;
            this.delete_but.Visible = false;
            this.delete_but.Click += new System.EventHandler(this.delete_but_Click);
            // 
            // error_lab
            // 
            this.error_lab.AutoSize = true;
            this.error_lab.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.error_lab.ForeColor = System.Drawing.Color.Maroon;
            this.error_lab.Location = new System.Drawing.Point(401, 307);
            this.error_lab.Name = "error_lab";
            this.error_lab.Size = new System.Drawing.Size(0, 17);
            this.error_lab.TabIndex = 8;
            // 
            // Registration
            // 
            this.Registration.Location = new System.Drawing.Point(404, 263);
            this.Registration.Name = "Registration";
            this.Registration.Size = new System.Drawing.Size(75, 23);
            this.Registration.TabIndex = 4;
            this.Registration.Text = "Registration";
            this.Registration.UseVisualStyleBackColor = true;
            this.Registration.Click += new System.EventHandler(this.Registration_Click);
            // 
            // password_lab
            // 
            this.password_lab.AutoSize = true;
            this.password_lab.Location = new System.Drawing.Point(401, 211);
            this.password_lab.Name = "password_lab";
            this.password_lab.Size = new System.Drawing.Size(56, 13);
            this.password_lab.TabIndex = 7;
            this.password_lab.Text = "Password:";
            // 
            // username_lab
            // 
            this.username_lab.AutoSize = true;
            this.username_lab.Location = new System.Drawing.Point(401, 172);
            this.username_lab.Name = "username_lab";
            this.username_lab.Size = new System.Drawing.Size(58, 13);
            this.username_lab.TabIndex = 2;
            this.username_lab.Text = "Username:";
            // 
            // Login
            // 
            this.Login.Location = new System.Drawing.Point(484, 263);
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(70, 23);
            this.Login.TabIndex = 3;
            this.Login.Text = "Login";
            this.Login.UseVisualStyleBackColor = true;
            this.Login.Click += new System.EventHandler(this.Login_Click);
            // 
            // password_login
            // 
            this.password_login.Location = new System.Drawing.Point(404, 226);
            this.password_login.Name = "password_login";
            this.password_login.Size = new System.Drawing.Size(150, 20);
            this.password_login.TabIndex = 2;
            this.password_login.UseSystemPasswordChar = true;
            // 
            // username_login
            // 
            this.username_login.Location = new System.Drawing.Point(404, 188);
            this.username_login.Name = "username_login";
            this.username_login.Size = new System.Drawing.Size(150, 20);
            this.username_login.TabIndex = 1;
            // 
            // Header_lab
            // 
            this.Header_lab.AutoEllipsis = true;
            this.Header_lab.AutoSize = true;
            this.Header_lab.BackColor = System.Drawing.Color.FloralWhite;
            this.Header_lab.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Header_lab.Location = new System.Drawing.Point(7, 6);
            this.Header_lab.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Header_lab.Name = "Header_lab";
            this.Header_lab.Size = new System.Drawing.Size(628, 20);
            this.Header_lab.TabIndex = 4;
            this.Header_lab.Text = "This calculator is designed for solving linear programming (LP) using the simplex" +
    " method.";
            this.Header_lab.Visible = false;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.comboBox2.Location = new System.Drawing.Point(253, 226);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.comboBox2.MaxLength = 1;
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(100, 21);
            this.comboBox2.TabIndex = 2;
            this.comboBox2.Text = "2";
            this.comboBox2.Visible = false;
            // 
            // Limit_lab
            // 
            this.Limit_lab.AutoSize = true;
            this.Limit_lab.BackColor = System.Drawing.Color.FloralWhite;
            this.Limit_lab.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Limit_lab.Location = new System.Drawing.Point(7, 227);
            this.Limit_lab.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Limit_lab.Name = "Limit_lab";
            this.Limit_lab.Size = new System.Drawing.Size(137, 20);
            this.Limit_lab.TabIndex = 2;
            this.Limit_lab.Text = "limiting conditions:";
            this.Limit_lab.Visible = false;
            // 
            // Num_unknow_lab
            // 
            this.Num_unknow_lab.AutoSize = true;
            this.Num_unknow_lab.BackColor = System.Drawing.Color.FloralWhite;
            this.Num_unknow_lab.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Num_unknow_lab.Location = new System.Drawing.Point(7, 187);
            this.Num_unknow_lab.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Num_unknow_lab.Name = "Num_unknow_lab";
            this.Num_unknow_lab.Size = new System.Drawing.Size(163, 20);
            this.Num_unknow_lab.TabIndex = 1;
            this.Num_unknow_lab.Text = "Number of unknowns:";
            this.Num_unknow_lab.Visible = false;
            // 
            // comboBox1
            // 
            this.comboBox1.AutoCompleteCustomSource.AddRange(new string[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.comboBox1.BackColor = System.Drawing.SystemColors.Window;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.comboBox1.Location = new System.Drawing.Point(253, 187);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.comboBox1.MaxLength = 1;
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(100, 21);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.Text = "2";
            this.comboBox1.Visible = false;
            // 
            // databaseDataSet
            // 
            this.databaseDataSet.DataSetName = "DatabaseDataSet";
            this.databaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // usersTableAdapter
            // 
            this.usersTableAdapter.ClearBeforeFill = true;
            // 
            // Main_form
            // 
            this.AllowDrop = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(984, 562);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.toolStripContainer1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.MaximizeBox = false;
            this.Name = "Main_form";
            this.RightToLeftLayout = true;
            this.Text = "Simplex_metod";
            this.Load += new System.EventHandler(this.Main_form_Load);
            this.panel2.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.databaseDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button Font_but;
        private System.Windows.Forms.FontDialog fontDialog;
        private System.Windows.Forms.Button Next_but;
        private System.Windows.Forms.Button Back_but;
        private System.Windows.Forms.Button Back_but2;
        private System.Windows.Forms.Button Next_but2;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button BgColor;
        private System.Windows.Forms.ToolStripPanel BottomToolStripPanel;
        private System.Windows.Forms.ToolStripPanel TopToolStripPanel;
        private System.Windows.Forms.ToolStripPanel RightToolStripPanel;
        private System.Windows.Forms.ToolStripPanel LeftToolStripPanel;
        private System.Windows.Forms.ToolStripContentPanel ContentPanel;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private DatabaseDataSet databaseDataSet;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label Header_lab;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label Limit_lab;
        private System.Windows.Forms.Label Num_unknow_lab;
        private System.Windows.Forms.ComboBox comboBox1;
        private DatabaseDataSetTableAdapters.UsersTableAdapter usersTableAdapter;
        private System.Windows.Forms.TextBox password_login;
        private System.Windows.Forms.TextBox username_login;
        private System.Windows.Forms.Button Login;
        private System.Windows.Forms.Label password_lab;
        private System.Windows.Forms.Label username_lab;
        private System.Windows.Forms.Button Registration;
        private System.Windows.Forms.Label error_lab;
        private System.Windows.Forms.Button del_user;
        private System.Windows.Forms.Button delete_but;
        private System.Windows.Forms.Button Back_setting;
        private System.Windows.Forms.Button exit_but;
        private System.Windows.Forms.Button privileges_but;
        private System.Windows.Forms.Button make_user_but;
        private System.Windows.Forms.Button make_admin_but;
    }
}
