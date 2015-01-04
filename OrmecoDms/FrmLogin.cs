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
    public partial class FrmLogin : C1.Win.C1Ribbon.C1RibbonForm
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void CmdLogin_Click(object sender, EventArgs e)
        {
            var loguser = TxtLogUser.Text;
            var logpass = TxtLogPass.Text;
            if (loguser != "" & logpass != "" )
            {
                var uName = new SqlParameter();
                var pWord = new SqlParameter();
                uName.ParameterName = "@UserName";
                pWord.ParameterName = "@PassWord";
                uName.Value = TxtLogUser.Text;
                pWord.Value = TxtLogPass.Text;

                var str = new MdlConn().Str;
                const string query = "select * from dbo.DmsUsers where UserName=@UserName and Password=@PassWord";

                var conn = new SqlConnection(str);
                var cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(uName);
                cmd.Parameters.Add(pWord);

                const string denied = "Invalid User Name or Password";

                try
                {
                    conn.Open();
                    var rdr = cmd.ExecuteReader();
                    rdr.Read();

                    if (rdr.HasRows)
                    {
                        var frmmain = new FrmMain();
                        frmmain.UserId = (int)rdr["Id"];
                        frmmain.Department = (string)rdr["Department"];
                        frmmain.Stats = (int) rdr["Status"];
                        frmmain.FullName = (string) rdr["FirstName"] + " " + (string) rdr["LastName"];
                        frmmain.Show();
                    }
                    else
                    {
                        MessageBox.Show(denied);
                    }
                }
                finally
                {
                    conn.Close();

                }
            }
            else if (loguser != "" & logpass == "")
            {
                TxtLogPass.Focus();
            }
            else if ((loguser == "" & logpass != "") | (loguser =="" & logpass == ""))
            {
                TxtLogUser.Focus();
            }



        }

        private void LnkCreateAcc_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var createAccount = new FrmCreateAcc(this);
            createAccount.Show();
            Hide();
        }

        private void FrmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void TxtLogUser_Validating(object sender, CancelEventArgs e)
        {
            if (TxtLogUser.Text == "")
            {
                //e.Cancel = true;
                errorProvider1.SetError(TxtLogUser, "Field cannot be empty");
            }
            else
            {
                errorProvider1.SetError(TxtLogUser, "");
            }
        }

        private void TxtLogPass_Validating(object sender, CancelEventArgs e)
        {
            if (TxtLogPass.Text == "")
            {
                //e.Cancel = true;
                errorProvider1.SetError(TxtLogPass, "Field cannot be empty");
            }
            else
            {
                errorProvider1.SetError(TxtLogPass, "");  
            }
        }
    }
}
