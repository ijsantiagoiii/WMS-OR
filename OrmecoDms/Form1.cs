using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.RichTextBox;
using Telerik.WinControls.UI;
using System.Windows.Forms.VisualStyles;
using Telerik.WinControls;
using Telerik.WinControls.Data;


namespace OrmecoDms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Tick += new EventHandler(TimerTick); // Everytime timer ticks, timer_Tick will be called
            timer1.Interval = (1000) * (5);              // Timer will tick evert second
            timer1.Enabled = true;                       // Enable the timer
            timer1.Start();                              // Start the timer




        }

        /*
        var str = new MdlConn().Str;
        //const string query = "select * from dbo.DmsRivInfoes";
        const string query = "SELECT * From dbo.DmsRivInfoes WHERE Id=1"; //2014100005
        //const string query2 = "SELECT * From dbo.DmsArticleInfoes WHERE DmsRivInfoId=2014100005";

        var conn = new SqlConnection(str);
        var cmd = new SqlCommand(query, conn);
        //var cmd2 = new SqlCommand(query2, conn);
        try
        {
            conn.Open();
            var rdr = cmd.ExecuteReader();
            //var rdr2 = cmd2.ExecuteReader();
            radGridView1.MasterTemplate.LoadFrom(rdr);
            var firstChildTemplate = new GridViewTemplate();

            radGridView1.MasterTemplate.Templates.Add(firstChildTemplate);
            firstChildTemplate.AllowAddNewRow = true;
            firstChildTemplate.Columns.Add("Name");
            firstChildTemplate.Columns["Name"].IsVisible = false;
            firstChildTemplate.Columns.Add("Product Num");
            firstChildTemplate.Columns.Add("Quantity");
            firstChildTemplate.Columns.Add("DIscount");
            firstChildTemplate.Columns.Add("Total");
            //var firstLevelTemplate = radGridView1.MasterTemplate.Templates[0];

            var relation = new GridViewRelation(radGridView1.MasterTemplate);
            relation.ChildTemplate = firstChildTemplate;
            relation.RelationName = "ArticleInfo";
            relation.ParentColumnNames.Add("Id");
            relation.ChildColumnNames.Add("Name");
            radGridView1.Relations.Add(relation);

        }
        finally
        {
            conn.Close();
                
        }
        */

        /*
        private void button1_Click(object sender, EventArgs e)
        {


            var nId = new SqlParameter();
            var nUId = new SqlParameter();
            var nDept = new SqlParameter();
            var nRem = new SqlParameter();
            //var nDate = new SqlParameter();
            var nPos = new SqlParameter();
            var nStat = new SqlParameter();
            nId.ParameterName = "@ID";
            nUId.ParameterName = "@UID";
            nDept.ParameterName = "@Dept";
            nRem.ParameterName = "@Rem";
            //nDate.ParameterName = "@Date";
            nPos.ParameterName = "@Pos";
            nStat.ParameterName = "@Stat";

            var str = new MdlConn().Str;
            const string query = @"INSERT INTO dbo.NewRivInfoes (Id, UserId, Department, Remarks,
                                     PosCtr, Status) VALUES (@ID, @UID, @Dept,
                                    @Rem, @Pos, @Stat)";
            var conn = new SqlConnection(str);
            var cmd = new SqlCommand(query, conn);
            cmd.Parameters.Add(nId);
            cmd.Parameters.Add(nUId);
            cmd.Parameters.Add(nDept);
            cmd.Parameters.Add(nRem);
            //cmd.Parameters.Add(nDate);
            cmd.Parameters.Add(nPos);
            cmd.Parameters.Add(nStat);

            int i = radGridView1.RowCount;
            for (int j = 0; j < i; j++)
            {
                var a = radGridView1.Rows[j].Cells[0].Value;
                //var b = (DateTime)radGridView1.Rows[j].Cells[4].Value;
                var c = radGridView1.Rows[j].Cells[5].Value;
                var d = radGridView1.Rows[j].Cells[6].Value;
                textBox1.Text = a.ToString();
                textBox2.Text = (string)radGridView1.Rows[j].Cells[1].Value;
                textBox3.Text = (string)radGridView1.Rows[j].Cells[2].Value;
                textBox4.Text = (string)radGridView1.Rows[j].Cells[3].Value;
                //dateTimePicker1.Value =b;
                textBox6.Text = c.ToString();
                textBox7.Text = d.ToString();
                nId.Value = textBox1.Text;
                nUId.Value = textBox2.Text;
                nDept.Value = textBox3.Text;
                nRem.Value = textBox4.Text;
                //nDate.Value = dateTimePicker1.Value;
                nPos.Value = textBox6.Text;
                nStat.Value = textBox7.Text;



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

        private void button2_Click(object sender, EventArgs e)
        {
            var nId = new SqlParameter();
            var nUId = new SqlParameter();
            var nDept = new SqlParameter();
            var nRem = new SqlParameter();
            //var nDate = new SqlParameter();
            var nPos = new SqlParameter();
            var nStat = new SqlParameter();
            nId.ParameterName = "@ID";
            nUId.ParameterName = "@UID";
            nDept.ParameterName = "@Dept";
            nRem.ParameterName = "@Rem";
            //nDate.ParameterName = "@Date";
            nPos.ParameterName = "@Pos";
            nStat.ParameterName = "@Stat";

            var str = new MdlConn().Str;
            const string query = @"INSERT INTO dbo.NewRivInfoes (Id, UserId, Department, Remarks,
                                     PosCtr, Status) VALUES (@ID, @UID, @Dept,
                                    @Rem, @Pos, @Stat)";
            var conn = new SqlConnection(str);
            var cmd = new SqlCommand(query, conn);
            cmd.Parameters.Add(nId);
            cmd.Parameters.Add(nUId);
            cmd.Parameters.Add(nDept);
            cmd.Parameters.Add(nRem);
            //cmd.Parameters.Add(nDate);
            cmd.Parameters.Add(nPos);
            cmd.Parameters.Add(nStat);


            var nId2 = new SqlParameter();
            var nUId2 = new SqlParameter();
            var nDept2 = new SqlParameter();
            var nRem2 = new SqlParameter();

            nId2.ParameterName = "@ID2";
            nUId2.ParameterName = "@UID2";
            nDept2.ParameterName = "@Dept2";
            nRem2.ParameterName = "@Rem2";


            const string query2 = @"INSERT INTO dbo.NewArticleInfoes (Id, NewRivInfoId, Lot, 
                                            Article) VALUES (@ID2, @UID2, @Dept2, @Rem2)";
            var cmd2 = new SqlCommand(query2, conn);

            cmd2.Parameters.Add(nId2);
            cmd2.Parameters.Add(nUId2);
            cmd2.Parameters.Add(nDept2);
            cmd2.Parameters.Add(nRem2);

            foreach (var riv in radGridView1.Rows)
            {

                var a = riv.Cells[0].Value;
                //var b = (DateTime)radGridView1.Rows[j].Cells[4].Value;
                var c = riv.Cells[5].Value;
                var d = riv.Cells[6].Value;
                textBox1.Text = a.ToString();
                textBox2.Text = (string)riv.Cells[1].Value;
                textBox3.Text = (string)riv.Cells[2].Value;
                textBox4.Text = (string)riv.Cells[3].Value;
                //dateTimePicker1.Value =b;
                textBox6.Text = c.ToString();
                textBox7.Text = d.ToString();
                nId.Value = textBox1.Text;
                nUId.Value = textBox2.Text;
                nDept.Value = textBox3.Text;
                nRem.Value = textBox4.Text;
                //nDate.Value = dateTimePicker1.Value;
                nPos.Value = textBox6.Text;
                nStat.Value = textBox7.Text;
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();

                }
                finally
                {

                    conn.Close();
                }

                foreach (var art in riv.ChildRows)
                {

                    var f = art.Cells[1].Value;
                    var g = art.Cells[0].Value;
                    var h = art.Cells[2].Value;
                    textBox1.Text = f.ToString();
                    textBox2.Text = g.ToString();
                    textBox3.Text = h.ToString();
                    textBox4.Text = (string)art.Cells[3].Value;

                    nId2.Value = textBox1.Text;
                    nUId2.Value = textBox2.Text;
                    nDept2.Value = textBox3.Text;
                    nRem2.Value = textBox4.Text;
                    try
                    {
                        conn.Open();
                        cmd2.ExecuteNonQuery();
                        cmd2.Dispose();

                    }
                    finally
                    {

                        conn.Close();
                    }
                }
            }
        }
        */

        void TimerTick(object sender, EventArgs e)
        {

            var str = new MdlConn().Str;
            const string query = "SELECT * From dbo.NewRivInfoes WHERE PosCtr=1 ORDER BY DateCreated DESC";
            var conn = new SqlConnection(str);
            var cmd = new SqlCommand(query, conn);

            try
            {
                conn.Open();
                var rdr = cmd.ExecuteReader();
                //var rdr2 = cmd2.ExecuteReader();
                GrdRiv.MasterTemplate.LoadFrom(rdr);
                GrdRiv.MasterTemplate.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;

            }
            finally
            {
                conn.Close();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //var window1 = this.radDock1.DockWindows["FrmMain"];
            //documentWindow1.Show();
           documentWindow1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            documentWindow1.Close();
            
        }

    }
}
