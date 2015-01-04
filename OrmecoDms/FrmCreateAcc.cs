using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace OrmecoDms
{
    public partial class FrmCreateAcc : C1.Win.C1Ribbon.C1RibbonForm
    {
        public Form Caller { get; set; }

        public FrmCreateAcc(Form parentForm)
        {
            InitializeComponent();
            Caller = parentForm;
        }

        private void FrmCreateAcc_FormClosed(object sender, FormClosedEventArgs e)
        {
            Caller.Close();
        }
        
        private void CmdSubmit_Click(object sender, EventArgs e)
        {
            var pass = TxtPass.Text;
            var repass = TxtRepass.Text;
            if (TxtFname.Text != "" && TxtLname.Text!= "" && 
                TxtUser.Text != "" && TxtPass.Text != "" && TxtRepass.Text != "")
            {
                if (pass != repass)
                {
                    const string match = "Password did not match";
                    MessageBox.Show(match);
                    TxtRepass.Focus();
                }
                else
                {
                    var fname = new SqlParameter();
                    var lname = new SqlParameter();
                    var uname = new SqlParameter();
                    var newpass = new SqlParameter();
                    fname.ParameterName = "@Fname";
                    lname.ParameterName = "@Lname";
                    uname.ParameterName = "@Uname";
                    newpass.ParameterName = "@Newpass";
                    fname.Value = TxtFname.Text;
                    lname.Value = TxtLname.Text;
                    uname.Value = TxtUser.Text;
                    newpass.Value = TxtPass.Text;

                    var str = new MdlConn().Str;
                    const string query = @"INSERT INTO dbo.DmsUsers (UserName, Password, FirstName, LastName,
                                Status) VALUES (@Uname, @Newpass, @Fname, @Lname, 0)";

                    var conn = new SqlConnection(str);
                    var cmd = new SqlCommand(query, conn);
                    cmd.Parameters.Add(fname);
                    cmd.Parameters.Add(lname);
                    cmd.Parameters.Add(uname);
                    cmd.Parameters.Add(newpass);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    finally 
                    {
                        
                        conn.Close();
                    }
                }

            }
            else
            {
                const string empty = "Please fill all fields";
                MessageBox.Show(empty);
            }
        }

        private void LnkLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            errorProvider1.SetError(TxtFname, "");
            var frmlog = new FrmLogin();
            frmlog.Show();
            Hide();
            
        }

        private void TxtFname_Leave(object sender, EventArgs e)
        {
            switch (TxtFname.Text)
            {
                case "":
                    errorProvider1.SetError(TxtFname, "Cannot be empty");
                    TxtFname.Focus();
                    break;
                default:
                    errorProvider1.SetError(TxtFname, "");
                    break;

            }
        }

        private void TxtLname_Leave(object sender, EventArgs e)
        {
            switch (TxtLname.Text)
            {
                case "":
                    errorProvider1.SetError(TxtLname, "Cannot be empty");
                    TxtLname.Focus();
                    break;
                default:
                    errorProvider1.SetError(TxtLname, "");
                    break;
            }
        }

        private void TxtUser_Leave(object sender, EventArgs e)
        {
            switch (TxtUser.Text)
            {
                case "":
                    errorProvider1.SetError(TxtUser, "Cannot be empty");
                    TxtUser.Focus();
                    break;
                default:
                    errorProvider1.SetError(TxtUser, "");
                    break;
            }
        }

        private void TxtPass_Leave(object sender, EventArgs e)
        {
            switch (TxtPass.Text)
            {
                case "":
                    errorProvider1.SetError(TxtPass, "Cannot be empty");
                    TxtPass.Focus();
                    break;
                default:
                    switch (TxtRepass.Text)
                    {
                        case "":
                            errorProvider1.SetError(TxtPass, "");
                            break;
                        default:
                            if (TxtPass.Text != TxtRepass.Text)
                            {
                                errorProvider1.SetError(TxtRepass, "Password did not match");
                            }
                            else
                            {
                                errorProvider1.SetError(TxtRepass, "");
                            }
                            break;
                    }
                    break;
            }
        }

        private void TxtRepass_Leave(object sender, EventArgs e)
        {
            if (TxtRepass.Text == null)
            {
                errorProvider1.SetError(TxtRepass, "Cannot be empty");
                TxtRepass.Focus();
            }
            else if (TxtPass.Text != TxtRepass.Text)
            {
                errorProvider1.SetError(TxtRepass, "Password did not match");
            }
            else
            {
                errorProvider1.SetError(TxtRepass, "");
            }
        }
    }
}
