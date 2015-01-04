namespace OrmecoDms
{
    partial class FrmCreateAcc
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
            this.c1ThemeController1 = new C1.Win.C1Themes.C1ThemeController();
            this.c1StatusBar1 = new C1.Win.C1Ribbon.C1StatusBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LnkLogin = new System.Windows.Forms.LinkLabel();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.TxtLname = new Telerik.WinControls.UI.RadTextBox();
            this.TxtFname = new Telerik.WinControls.UI.RadTextBox();
            this.TxtPass = new Telerik.WinControls.UI.RadTextBox();
            this.TxtUser = new Telerik.WinControls.UI.RadTextBox();
            this.CmdSubmit = new Telerik.WinControls.UI.RadButton();
            this.TxtRepass = new Telerik.WinControls.UI.RadTextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.c1ThemeController1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1StatusBar1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtLname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtFname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtPass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmdSubmit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtRepass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // c1StatusBar1
            // 
            this.c1StatusBar1.Location = new System.Drawing.Point(0, 528);
            this.c1StatusBar1.Name = "c1StatusBar1";
            this.c1StatusBar1.Size = new System.Drawing.Size(557, 22);
            this.c1ThemeController1.SetTheme(this.c1StatusBar1, "VS2013Purple");
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.LnkLogin);
            this.panel1.Controls.Add(this.radLabel1);
            this.panel1.Controls.Add(this.TxtLname);
            this.panel1.Controls.Add(this.TxtFname);
            this.panel1.Controls.Add(this.TxtPass);
            this.panel1.Controls.Add(this.TxtUser);
            this.panel1.Controls.Add(this.CmdSubmit);
            this.panel1.Controls.Add(this.TxtRepass);
            this.panel1.Location = new System.Drawing.Point(34, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(482, 476);
            this.panel1.TabIndex = 1;
            this.c1ThemeController1.SetTheme(this.panel1, "(default)");
            // 
            // LnkLogin
            // 
            this.LnkLogin.ActiveLinkColor = System.Drawing.Color.Purple;
            this.LnkLogin.AutoSize = true;
            this.LnkLogin.CausesValidation = false;
            this.LnkLogin.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LnkLogin.LinkColor = System.Drawing.Color.ForestGreen;
            this.LnkLogin.Location = new System.Drawing.Point(49, 435);
            this.LnkLogin.Name = "LnkLogin";
            this.LnkLogin.Size = new System.Drawing.Size(251, 21);
            this.LnkLogin.TabIndex = 24;
            this.LnkLogin.TabStop = true;
            this.LnkLogin.Text = " Already have account? Log in here";
            this.c1ThemeController1.SetTheme(this.LnkLogin, "(default)");
            this.LnkLogin.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LnkLogin_LinkClicked);
            // 
            // radLabel1
            // 
            this.radLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.ForeColor = System.Drawing.Color.LimeGreen;
            this.radLabel1.Location = new System.Drawing.Point(139, 42);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Padding = new System.Windows.Forms.Padding(0, 9, 0, 9);
            this.radLabel1.Size = new System.Drawing.Size(188, 55);
            this.radLabel1.TabIndex = 23;
            this.radLabel1.Text = "Create Account";
            // 
            // TxtLname
            // 
            this.TxtLname.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtLname.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtLname.Location = new System.Drawing.Point(263, 114);
            this.TxtLname.Name = "TxtLname";
            this.TxtLname.NullText = "Last Name";
            this.TxtLname.Padding = new System.Windows.Forms.Padding(4, 9, 0, 9);
            this.TxtLname.Size = new System.Drawing.Size(178, 42);
            this.TxtLname.TabIndex = 18;
            this.TxtLname.Leave += new System.EventHandler(this.TxtLname_Leave);
            ((Telerik.WinControls.UI.RadTextBoxElement)(this.TxtLname.GetChildAt(0))).Padding = new System.Windows.Forms.Padding(4, 9, 0, 9);
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.TxtLname.GetChildAt(0).GetChildAt(2))).ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(173)))), ((int)(((byte)(18)))));
            // 
            // TxtFname
            // 
            this.TxtFname.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtFname.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtFname.Location = new System.Drawing.Point(53, 114);
            this.TxtFname.Name = "TxtFname";
            this.TxtFname.NullText = "First Name";
            this.TxtFname.Padding = new System.Windows.Forms.Padding(4, 9, 0, 9);
            this.TxtFname.Size = new System.Drawing.Size(180, 42);
            this.TxtFname.TabIndex = 17;
            this.TxtFname.Leave += new System.EventHandler(this.TxtFname_Leave);
            ((Telerik.WinControls.UI.RadTextBoxElement)(this.TxtFname.GetChildAt(0))).Padding = new System.Windows.Forms.Padding(4, 9, 0, 9);
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.TxtFname.GetChildAt(0).GetChildAt(2))).ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(173)))), ((int)(((byte)(18)))));
            // 
            // TxtPass
            // 
            this.TxtPass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtPass.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPass.Location = new System.Drawing.Point(53, 234);
            this.TxtPass.Name = "TxtPass";
            this.TxtPass.NullText = "New Password";
            this.TxtPass.Padding = new System.Windows.Forms.Padding(4, 9, 0, 9);
            this.TxtPass.Size = new System.Drawing.Size(388, 42);
            this.TxtPass.TabIndex = 20;
            this.TxtPass.Leave += new System.EventHandler(this.TxtPass_Leave);
            ((Telerik.WinControls.UI.RadTextBoxElement)(this.TxtPass.GetChildAt(0))).Padding = new System.Windows.Forms.Padding(4, 9, 0, 9);
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.TxtPass.GetChildAt(0).GetChildAt(2))).ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(173)))), ((int)(((byte)(18)))));
            // 
            // TxtUser
            // 
            this.TxtUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtUser.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(3)))), ((int)(((byte)(3)))));
            this.TxtUser.Location = new System.Drawing.Point(53, 178);
            this.TxtUser.Name = "TxtUser";
            this.TxtUser.NullText = "User Name";
            this.TxtUser.Padding = new System.Windows.Forms.Padding(4, 9, 0, 9);
            this.TxtUser.Size = new System.Drawing.Size(388, 42);
            this.TxtUser.TabIndex = 19;
            this.TxtUser.Leave += new System.EventHandler(this.TxtUser_Leave);
            ((Telerik.WinControls.UI.RadTextBoxElement)(this.TxtUser.GetChildAt(0))).Padding = new System.Windows.Forms.Padding(4, 9, 0, 9);
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.TxtUser.GetChildAt(0).GetChildAt(2))).ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(173)))), ((int)(((byte)(18)))));
            // 
            // CmdSubmit
            // 
            this.CmdSubmit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CmdSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdSubmit.Location = new System.Drawing.Point(53, 379);
            this.CmdSubmit.Name = "CmdSubmit";
            this.CmdSubmit.Size = new System.Drawing.Size(388, 41);
            this.CmdSubmit.TabIndex = 22;
            this.CmdSubmit.Text = "Submit";
            this.CmdSubmit.ThemeName = "TelerikMetro";
            this.CmdSubmit.Click += new System.EventHandler(this.CmdSubmit_Click);
            // 
            // TxtRepass
            // 
            this.TxtRepass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtRepass.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtRepass.Location = new System.Drawing.Point(53, 290);
            this.TxtRepass.Name = "TxtRepass";
            this.TxtRepass.NullText = "Confirm Password";
            this.TxtRepass.Padding = new System.Windows.Forms.Padding(4, 9, 0, 9);
            this.TxtRepass.Size = new System.Drawing.Size(388, 42);
            this.TxtRepass.TabIndex = 21;
            this.TxtRepass.Leave += new System.EventHandler(this.TxtRepass_Leave);
            ((Telerik.WinControls.UI.RadTextBoxElement)(this.TxtRepass.GetChildAt(0))).Padding = new System.Windows.Forms.Padding(4, 9, 0, 9);
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.TxtRepass.GetChildAt(0).GetChildAt(2))).ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(173)))), ((int)(((byte)(18)))));
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FrmCreateAcc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(557, 550);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.c1StatusBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCreateAcc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ormeco Dms";
            this.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Custom;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmCreateAcc_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.c1ThemeController1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1StatusBar1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtLname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtFname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtPass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmdSubmit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtRepass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.Themes.TelerikMetroTheme telerikMetroTheme1;
        private C1.Win.C1Themes.C1ThemeController c1ThemeController1;
        private C1.Win.C1Ribbon.C1StatusBar c1StatusBar1;
        private System.Windows.Forms.Panel panel1;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadTextBox TxtLname;
        private Telerik.WinControls.UI.RadTextBox TxtFname;
        private Telerik.WinControls.UI.RadTextBox TxtPass;
        private Telerik.WinControls.UI.RadTextBox TxtUser;
        private Telerik.WinControls.UI.RadButton CmdSubmit;
        private Telerik.WinControls.UI.RadTextBox TxtRepass;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.LinkLabel LnkLogin;
    }
}
