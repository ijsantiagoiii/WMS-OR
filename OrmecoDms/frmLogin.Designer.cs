namespace OrmecoDms
{
    partial class FrmLogin
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
            this.components = new System.ComponentModel.Container();
            this.telerikMetroTheme1 = new Telerik.WinControls.Themes.TelerikMetroTheme();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.TxtLogUser = new Telerik.WinControls.UI.RadTextBox();
            this.CmdLogin = new Telerik.WinControls.UI.RadButton();
            this.TxtLogPass = new Telerik.WinControls.UI.RadTextBox();
            this.c1StatusBar1 = new C1.Win.C1Ribbon.C1StatusBar();
            this.c1ThemeController1 = new C1.Win.C1Themes.C1ThemeController();
            this.LnkCreateAcc = new System.Windows.Forms.LinkLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtLogUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmdLogin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtLogPass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1StatusBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1ThemeController1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // radLabel2
            // 
            this.radLabel2.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel2.ForeColor = System.Drawing.Color.LimeGreen;
            this.radLabel2.Location = new System.Drawing.Point(79, 216);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Padding = new System.Windows.Forms.Padding(0, 9, 0, 9);
            this.radLabel2.Size = new System.Drawing.Size(253, 55);
            this.radLabel2.TabIndex = 20;
            this.radLabel2.Text = "Sign in your Account";
            // 
            // TxtLogUser
            // 
            this.TxtLogUser.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtLogUser.Location = new System.Drawing.Point(64, 288);
            this.TxtLogUser.MaxLength = 15;
            this.TxtLogUser.Name = "TxtLogUser";
            this.TxtLogUser.NullText = "User Name";
            this.TxtLogUser.Padding = new System.Windows.Forms.Padding(4, 9, 0, 9);
            this.TxtLogUser.Size = new System.Drawing.Size(283, 42);
            this.TxtLogUser.TabIndex = 17;
            this.TxtLogUser.Validating += new System.ComponentModel.CancelEventHandler(this.TxtLogUser_Validating);
            ((Telerik.WinControls.UI.RadTextBoxElement)(this.TxtLogUser.GetChildAt(0))).Padding = new System.Windows.Forms.Padding(4, 9, 0, 9);
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.TxtLogUser.GetChildAt(0).GetChildAt(2))).ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(173)))), ((int)(((byte)(18)))));
            // 
            // CmdLogin
            // 
            this.CmdLogin.BackColor = System.Drawing.SystemColors.Control;
            this.CmdLogin.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdLogin.ForeColor = System.Drawing.SystemColors.Control;
            this.CmdLogin.Location = new System.Drawing.Point(64, 377);
            this.CmdLogin.Name = "CmdLogin";
            this.CmdLogin.Size = new System.Drawing.Size(283, 42);
            this.CmdLogin.TabIndex = 19;
            this.CmdLogin.Text = "Sign in";
            this.CmdLogin.ThemeName = "TelerikMetro";
            this.CmdLogin.Click += new System.EventHandler(this.CmdLogin_Click);
            // 
            // TxtLogPass
            // 
            this.TxtLogPass.BackColor = System.Drawing.Color.White;
            this.TxtLogPass.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtLogPass.Location = new System.Drawing.Point(64, 329);
            this.TxtLogPass.MaxLength = 25;
            this.TxtLogPass.Name = "TxtLogPass";
            this.TxtLogPass.NullText = "Password";
            this.TxtLogPass.Padding = new System.Windows.Forms.Padding(4, 9, 0, 9);
            this.TxtLogPass.PasswordChar = '•';
            this.TxtLogPass.Size = new System.Drawing.Size(283, 42);
            this.TxtLogPass.TabIndex = 18;
            this.TxtLogPass.Validating += new System.ComponentModel.CancelEventHandler(this.TxtLogPass_Validating);
            ((Telerik.WinControls.UI.RadTextBoxElement)(this.TxtLogPass.GetChildAt(0))).Padding = new System.Windows.Forms.Padding(4, 9, 0, 9);
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.TxtLogPass.GetChildAt(0).GetChildAt(2))).ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(173)))), ((int)(((byte)(18)))));
            // 
            // c1StatusBar1
            // 
            this.c1StatusBar1.Location = new System.Drawing.Point(0, 528);
            this.c1StatusBar1.Name = "c1StatusBar1";
            this.c1StatusBar1.Size = new System.Drawing.Size(478, 22);
            this.c1ThemeController1.SetTheme(this.c1StatusBar1, "VS2013Purple");
            // 
            // LnkCreateAcc
            // 
            this.LnkCreateAcc.ActiveLinkColor = System.Drawing.Color.Purple;
            this.LnkCreateAcc.AutoSize = true;
            this.LnkCreateAcc.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LnkCreateAcc.LinkColor = System.Drawing.Color.ForestGreen;
            this.LnkCreateAcc.Location = new System.Drawing.Point(60, 442);
            this.LnkCreateAcc.Name = "LnkCreateAcc";
            this.LnkCreateAcc.Size = new System.Drawing.Size(188, 21);
            this.LnkCreateAcc.TabIndex = 22;
            this.LnkCreateAcc.TabStop = true;
            this.LnkCreateAcc.Text = " Create your account here";
            this.c1ThemeController1.SetTheme(this.LnkCreateAcc, "(default)");
            this.LnkCreateAcc.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LnkCreateAcc_LinkClicked);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.radLabel2);
            this.panel1.Controls.Add(this.LnkCreateAcc);
            this.panel1.Controls.Add(this.TxtLogPass);
            this.panel1.Controls.Add(this.CmdLogin);
            this.panel1.Controls.Add(this.TxtLogUser);
            this.panel1.Location = new System.Drawing.Point(32, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(411, 489);
            this.panel1.TabIndex = 24;
            this.c1ThemeController1.SetTheme(this.panel1, "(default)");
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FrmLogin
            // 
            this.AcceptButton = this.CmdLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(478, 550);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.c1StatusBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ormeco Dms";
            this.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Custom;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmLogin_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtLogUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmdLogin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtLogPass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1StatusBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1ThemeController1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.Themes.TelerikMetroTheme telerikMetroTheme1;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadTextBox TxtLogUser;
        private Telerik.WinControls.UI.RadButton CmdLogin;
        private Telerik.WinControls.UI.RadTextBox TxtLogPass;
        private C1.Win.C1Ribbon.C1StatusBar c1StatusBar1;
        private C1.Win.C1Themes.C1ThemeController c1ThemeController1;
        private System.Windows.Forms.LinkLabel LnkCreateAcc;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ErrorProvider errorProvider1;

    }
}
