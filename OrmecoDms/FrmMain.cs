using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Telerik.WinControls;
using Telerik.WinControls.Data;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Data;

namespace OrmecoDms
{
    public partial class FrmMain : C1.Win.C1Ribbon.C1RibbonForm
    {
        public int UserId;
        public int Stats;
        public string Department;
        public string FullName;
        public string[] DropDownSource = new[] {"kg", "box", "bundle"};
        public BindingList<DropSource> DropSources = new BindingList<DropSource>(); 
        
        
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {

            var str = new MdlConn().Str;
            var conn = new SqlConnection(str);

            const string notifcount = "SELECT  COUNT(*) FROM dbo.DmsActionLogs";
            var notifcountcmd = new SqlCommand(notifcount, conn);

            if (Stats == 0)
            {
                PnlCreateRiv.Visible = false;
                PnlPendingReq.Visible = false;
                PnlApproving.Visible = false;
                PnlRivTools.Visible = false;
                PnlApprovalTools.Visible = false;
                PnlAccount.Visible = true;
                PnlActionDetails.Visible = false;
                PnlNotifs.Visible = false;

                radButton1.Visible = false;
                radButton2.Visible = true;
                radButton3.Visible = false;
                //radButton4.Visible = false;
                radButton5.Visible = false;
                BtnViewPending.Visible = false;
                BtnNewRiv.Visible = false;
                BtnNotifs.Visible = false;
            }
            else
            {
                radButton1.Visible = true;
                radButton2.Visible = true;
                radButton3.Visible = true;
                //radButton4.Visible = true;
                radButton5.Visible = true;
                BtnViewPending.Visible = true;
                BtnNewRiv.Visible = true;
                BtnNotifs.Visible = true;

                try
                {
                    conn.Open();
                    var cntnotif = (int)notifcountcmd.ExecuteScalar();
                    BtnNotifs.Text = string.Format("{0} Notification", cntnotif);
                }
                finally
                {
                    conn.Close();
                }

                DrpdwnDept.Items.Add("ISD");
                DrpdwnDept.Items.Add("OGM");
                DrpdwnDept.Items.Add("Warehouse");
                DrpdwnDept.Items.Add("Accounting");
                DrpdwnDept.Items.Add("HR");


                //var descriptor = new GroupDescriptor();
                //descriptor.GroupNames.Add("Lot Number", ListSortDirection.Ascending);
                //GrdRiv.GroupDescriptors.Add(descriptor);

                //----------------------------------------------------------------------------------
                //Creating master template's columns 
                var lot = new GridViewDecimalColumn("Lot Number");
                var article = new GridViewTextBoxColumn("Article Details");

                //Setting their properties
                lot.Width = 100;
                article.Width = 665;
                lot.DecimalPlaces = 0;

                //Adding to the GridView
                GrdRiv.MasterTemplate.Columns.Add(lot);
                GrdRiv.MasterTemplate.Columns.Add(article);
                GrdRiv.EnableAlternatingRowColor = true;
                GrdRiv.MasterTemplate.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;

                //----------------------------------------------------------------------------------
                //----------------------------------------------------------------------------------



                //----------------------------------------------------------------------------------
                //Creating child template
                var items = new GridViewTemplate();

                //Adding to master template
                GrdRiv.MasterTemplate.Templates.Add(items);
                items.AllowAddNewRow = true;


                //Creating child template's columns
                var fk = new GridViewDecimalColumn("Lot");
                var itemname = new GridViewTextBoxColumn("Item Name");
                var unit = new GridViewComboBoxColumn("Unit");

                DropSources.Add(new DropSource("Kg(s)"));
                DropSources.Add(new DropSource("Box(es)"));
                DropSources.Add(new DropSource("Piece(s)"));
                DropSources.Add(new DropSource("Bundle(s)"));
                //Setting their properties
                unit.DataSource = DropSources;//DropDownSource;//new [] {"kg","box","bundle"};
                unit.DropDownStyle = RadDropDownStyle.DropDown;

                unit.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                var quantity = new GridViewDecimalColumn("Quantity");
                itemname.Width = 300;
                unit.Width = 150;
                quantity.Width = 150;
                quantity.DecimalPlaces = 0;

                //Adding columns to the child template
                items.Columns.Add(fk);
                items.Columns["Lot"].IsVisible = false;
                items.Columns.Add(itemname);
                items.Columns.Add(unit);
                items.Columns.Add(quantity);
                items.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
                //----------------------------------------------------------------------------------
                //----------------------------------------------------------------------------------


                //----------------------------------------------------------------------------------
                //Creating Relation
                var relation = new GridViewRelation(GrdRiv.MasterTemplate);
                relation.ChildTemplate = items;
                relation.RelationName = "ArticleItems";
                relation.ParentColumnNames.Add("Lot Number");
                relation.ChildColumnNames.Add("Lot");
                GrdRiv.Relations.Add(relation);

                //----------------------------------------------------------------------------------
                //----------------------------------------------------------------------------------


                //----------------------------------------------------------------------------------
                //Creating master template's columns 
                var lot2 = new GridViewDecimalColumn("Lot Number");
                var article2 = new GridViewTextBoxColumn("Article Details");

                //Adding to the GridView
                GrdArtApproved.MasterTemplate.Columns.Add(lot2);
                GrdArtApproved.MasterTemplate.Columns.Add(article2);
                GrdArtApproved.EnableAlternatingRowColor = true;
                GrdArtApproved.MasterTemplate.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;

                //----------------------------------------------------------------------------------
                //----------------------------------------------------------------------------------

            


            }

            
        }

        private void BntSubmit_Click(object sender, EventArgs e)
        {
            //----------------------------------------------------------------------------------

            //Set the connection
            var str = new MdlConn().Str;
            var conn = new SqlConnection(str);

            const string lstriv = "SELECT TOP 1 Id FROM dbo.DmsRivInfoes ORDER BY Id DESC";
            const string lstart = "SELECT TOP 1 Id FROM dbo.DmsArticleInfoes ORDER BY Id DESC";
            const string lstitem = "SELECT TOP 1 Id FROM dbo.DmsItemInfoes ORDER BY Id DESC";
            const string cntriv = "SELECT  COUNT(*) FROM dbo.DmsRivInfoes";
            const string cntart = "SELECT  COUNT(*) FROM dbo.DmsArticleInfoes";
            const string cntitem = "SELECT  COUNT(*) FROM dbo.DmsItemInfoes";


            var lstrivcmd = new SqlCommand(lstriv, conn);
            var lstartcmd = new SqlCommand(lstart, conn);
            var lstitemcmd = new SqlCommand(lstitem, conn);
            var cntrivcmd = new SqlCommand(cntriv, conn);
            var cntartcmd = new SqlCommand(cntart, conn);
            var cntitemcmd = new SqlCommand(cntitem, conn);


            //Instantiate parameters for first table
            var rivid = new SqlParameter();
            rivid.ParameterName = "@rivid";
            var uid = new SqlParameter();
            uid.ParameterName = "@uid";
            var dept = new SqlParameter();
            dept.ParameterName = "@dept";
            var rem = new SqlParameter();
            rem.ParameterName = "@rem";
            var date = new SqlParameter();
            date.ParameterName = "@date";
            var pos = new SqlParameter();
            pos.ParameterName = "@pos";
            var stat = new SqlParameter();
            stat.ParameterName = "@stat";


            const string rivquery = "INSERT INTO dbo.DmsRivInfoes (Id, UserId, Department, " +
                        "Remarks, DateCreated, PosCtr, Status) VALUES (@rivid, @uid, @dept, " +
                        "@rem, @date, @pos, @stat)";
            var rivcmd = new SqlCommand(rivquery, conn);
            rivcmd.Parameters.Add(rivid);
            rivcmd.Parameters.Add(uid);
            rivcmd.Parameters.Add(dept);
            rivcmd.Parameters.Add(rem);
            rivcmd.Parameters.Add(date);
            rivcmd.Parameters.Add(pos);
            rivcmd.Parameters.Add(stat);

            //Instantiate parameters for second table
            var artid = new SqlParameter();
            artid.ParameterName = "@artid";
            var forrivid = new SqlParameter();
            forrivid.ParameterName = "@forrivid";
            var lot = new SqlParameter();
            lot.ParameterName = "@lot";
            var art = new SqlParameter();
            art.ParameterName = "@art";

            const string artquery = "INSERT INTO dbo.DmsArticleInfoes (Id, DmsRivInfoId, Lot, " +
                                    "Article) VALUES (@artid, @forrivid, @lot, @art)";
            var artcmd = new SqlCommand(artquery, conn);
            artcmd.Parameters.Add(artid);
            artcmd.Parameters.Add(forrivid);
            artcmd.Parameters.Add(lot);
            artcmd.Parameters.Add(art);

            //Instantiate paramters for last table
            var itemid = new SqlParameter();
            itemid.ParameterName = "@itemid";
            var forartid = new SqlParameter();
            forartid.ParameterName = "@forartid";
            var qty = new SqlParameter();
            qty.ParameterName = "@qty";
            var itemname = new SqlParameter();
            itemname.ParameterName = "@itemname";
            //var unit = new SqlParameter();
            //unit.ParameterName = "@unit";

            const string itemquery = "INSERT INTO dbo.DmsItemInfoes (Id, DmsArticleInfoId, Qty, " +
                                     "Item) VALUES (@itemid, @forartid, @qty, @itemname)";
            var itemcmd = new SqlCommand(itemquery, conn);
            itemcmd.Parameters.Add(itemid);
            itemcmd.Parameters.Add(forartid);
            itemcmd.Parameters.Add(qty);
            itemcmd.Parameters.Add(itemname);
            //itemcmd.Parameters.Add(unit);

            var yrCtr = DateTime.Now.ToString("yyyyMM");
            const string numCtr = "0000";
            var combine = yrCtr + numCtr;
            var defaultId = Int32.Parse(combine);



            //---------------------------------------------------------------------------------- 
            var createid = new SqlParameter();
            createid.ParameterName = "@CreateId";

            var createriv = new SqlParameter();
            createriv.ParameterName = "@CreateRiv";
            //createriv.Value = defaultId;

            var createuid = new SqlParameter();
            createuid.ParameterName = "@CreateUid";
            createuid.Value = UserId;

            var createfname = new SqlParameter();
            createfname.ParameterName = "@CreateFname";
            createfname.Value = FullName;

            var createaction = new SqlParameter();
            createaction.ParameterName = "@CreateAction";
            createaction.Value = "Create";

            var createnext = new SqlParameter();
            createnext.ParameterName = "@CreateNext";
            createnext.Value = "";

            var createdate = new SqlParameter();
            createdate.ParameterName = "@CreateDate";
            createdate.Value = DateTime.Now;

            const string savecreate = @"INSERT INTO dbo.DmsActionLogs (Id, DmsRivInfoId, UserId, UserFname,
                                Action, NextStop, DateResponse) VALUES (@CreateId, @CreateRiv, @CreateUid, 
                                @CreateFname, @CreateAction, @CreateNext, @CreateDate)";

            var savecreatecmd = new SqlCommand(savecreate, conn);
            savecreatecmd.Parameters.Add(createid);
            savecreatecmd.Parameters.Add(createriv);
            savecreatecmd.Parameters.Add(createuid);
            savecreatecmd.Parameters.Add(createfname);
            savecreatecmd.Parameters.Add(createaction);
            savecreatecmd.Parameters.Add(createnext);
            savecreatecmd.Parameters.Add(createdate);
            //---------------------------------------------------------------------------------- 
            //---------------------------------------------------------------------------------- 



            //---------------------------------------------------------------------------------- 
            const string lstaction = "SELECT TOP 1 Id FROM dbo.DmsActionLogs Order by Id DESC";
            var lstactioncmd = new SqlCommand(lstaction, conn);

            const string cntaction = "SELECT COUNT(*) FROM dbo.DmsActionLogs";
            var cntactioncmd = new SqlCommand(cntaction, conn);
            //---------------------------------------------------------------------------------- 
            //---------------------------------------------------------------------------------- 




            try
            {
                conn.Open();
                var cntdriv = (int)cntrivcmd.ExecuteScalar();
                
                if (cntdriv == 0)
                {
                    
                    rivid.Value = defaultId;
                    uid.Value = UserId;
                    dept.Value = DrpdwnDept.Text;
                    rem.Value = TxtRemarks.Text;
                    date.Value = DateTime.Now;
                    pos.Value = 0;
                    stat.Value = 0;


                    rivcmd.ExecuteNonQuery();

                    foreach (var article in GrdRiv.Rows)
                    {
                        var cntdart = (int) cntartcmd.ExecuteScalar();
                        if (cntdart == 0)
                        {
                            var grdlot = article.Cells[0].Value;
                            VarTxt1.Text = grdlot.ToString();
                            VarTxt2.Text = (string)article.Cells[1].Value;
                            artid.Value = defaultId;
                            forrivid.Value = defaultId;
                            lot.Value = VarTxt1.Text;
                            art.Value = VarTxt2.Text;

                            artcmd.ExecuteNonQuery();


                            foreach (var item in article.ChildRows)
                            {
                                var cntditem = (int) cntitemcmd.ExecuteScalar();
                                if (cntditem == 0)
                                {
                                    var quant = item.Cells[3].Value;
                                    VarTxt1.Text = quant.ToString();
                                    VarTxt2.Text = (string) item.Cells[1].Value;
                                    itemid.Value = defaultId;
                                    forartid.Value = defaultId;
                                    qty.Value = VarTxt1;
                                    itemname.Value = VarTxt2;

                                    itemcmd.ExecuteNonQuery();

                                }
                                else if (cntditem != 0)
                                {
                                    var lastitem = lstitemcmd.ExecuteReader();
                                    lastitem.Read();
                                    var itemnewid = (int) lastitem["Id"] + 1;
                                    var quant = item.Cells[3].Value;
                                    VarTxt1.Text = quant.ToString();
                                    VarTxt2.Text = (string)item.Cells[1].Value;
                                    itemid.Value = itemnewid;
                                    forartid.Value = defaultId;
                                    qty.Value = VarTxt1;
                                    itemname.Value = VarTxt2;
                                    lastitem.Dispose();

                                    itemcmd.ExecuteNonQuery();
                                   
                                }
                            }
                        }
                        else if (cntdart != 0)
                        {

                            var lastart = lstartcmd.ExecuteReader();
                            lastart.Read();
                            var artnewid = (int)lastart["Id"] + 1;
                            var grdlot = article.Cells[0].Value;
                            VarTxt1.Text = grdlot.ToString();
                            VarTxt2.Text = (string)article.Cells[1].Value;
                            artid.Value = artnewid;
                            forrivid.Value = defaultId;
                            lot.Value = VarTxt1.Text;
                            art.Value = VarTxt2.Text;
                            lastart.Dispose();

                            artcmd.ExecuteNonQuery();
                           
                            foreach (var item in article.ChildRows)
                            {
                                var cntditem = (int)cntitemcmd.ExecuteScalar();
                                if (cntditem == 0)
                                {
                                    var quant = item.Cells[3].Value;
                                    VarTxt1.Text = quant.ToString();
                                    VarTxt2.Text = (string)item.Cells[1].Value;
                                    itemid.Value = defaultId;
                                    forartid.Value = artnewid;
                                    qty.Value = VarTxt1;
                                    itemname.Value = VarTxt2;

                                    itemcmd.ExecuteNonQuery();
                                    
                                }
                                else if (cntditem != 0)
                                {
                                    var lastitem = lstitemcmd.ExecuteReader();
                                    lastitem.Read();
                                    var itemnewid = (int)lastitem["Id"] + 1;
                                    var quant = item.Cells[3].Value;
                                    VarTxt1.Text = quant.ToString();
                                    VarTxt2.Text = (string)item.Cells[1].Value;
                                    itemid.Value = itemnewid;
                                    forartid.Value = artnewid;
                                    qty.Value = VarTxt1;
                                    itemname.Value = VarTxt2;
                                    lastitem.Dispose();

                                    itemcmd.ExecuteNonQuery();
                                    
                                }
                            }
                        }
                        
                    }


                    var cntactionrdr = (int)cntactioncmd.ExecuteScalar();
                    if (cntactionrdr == 0)
                    {
                        createid.Value = defaultId;
                        createriv.Value = defaultId;
                        savecreatecmd.ExecuteNonQuery();
                        savecreatecmd.Dispose();
                    }
                    else
                    {
                        var lastactionrdr = lstactioncmd.ExecuteReader();
                        lastactionrdr.Read();

                        var actnewid = (int)lastactionrdr["Id"] + 1;
                        createid.Value = actnewid;
                        createriv.Value = defaultId;
                        lastactionrdr.Dispose();

                        savecreatecmd.ExecuteNonQuery();
                        savecreatecmd.Dispose();
                    }
                    

                }
                else if(cntdriv != 0)
                {
                    
                    var lastriv = lstrivcmd.ExecuteReader();
                    lastriv.Read();
                    var rivnewid = (int)lastriv["Id"] + 1;
                    rivid.Value = rivnewid;
                    uid.Value = UserId;
                    dept.Value = DrpdwnDept.Text;
                    rem.Value = TxtRemarks.Text;
                    date.Value = DateTime.Now;
                    pos.Value = 0;
                    stat.Value = 0;
                    lastriv.Dispose();

                    rivcmd.ExecuteNonQuery();

                    foreach (var article in GrdRiv.Rows)
                    {
                        var cntdart = (int)cntartcmd.ExecuteScalar();
                        if (cntdart == 0)
                        {
                            var grdlot = article.Cells[0].Value;
                            VarTxt1.Text = grdlot.ToString();
                            VarTxt2.Text = (string)article.Cells[1].Value;
                            artid.Value = defaultId;
                            forrivid.Value = rivnewid;
                            lot.Value = VarTxt1.Text;
                            art.Value = VarTxt2.Text;

                            artcmd.ExecuteNonQuery();
                            foreach (var item in article.ChildRows)
                            {
                                var cntditem = (int)cntitemcmd.ExecuteScalar();
                                if (cntditem == 0)
                                {
                                    var quant = item.Cells[3].Value;
                                    VarTxt1.Text = quant.ToString();
                                    VarTxt2.Text = (string)item.Cells[1].Value;
                                    itemid.Value = defaultId;
                                    forartid.Value = defaultId;
                                    qty.Value = VarTxt1.Text;
                                    itemname.Value = VarTxt2.Text;

                                    itemcmd.ExecuteNonQuery();
                                }
                                else if (cntditem != 0)
                                {
                                    var lastitem = lstitemcmd.ExecuteReader();
                                    lastitem.Read();
                                    var itemnewid = (int)lastitem["Id"] + 1;
                                    var quant = item.Cells[3].Value;
                                    VarTxt1.Text = quant.ToString();
                                    VarTxt2.Text = (string)item.Cells[1].Value;
                                    itemid.Value = itemnewid;
                                    forartid.Value = defaultId;
                                    qty.Value = VarTxt1.Text;
                                    itemname.Value = VarTxt2.Text;
                                    lastitem.Dispose();

                                    itemcmd.ExecuteNonQuery();
                                }
                            }
                        }
                        else if (cntdart != 0)
                        {

                            var lastart = lstartcmd.ExecuteReader();
                            lastart.Read();
                            var artnewid = (int)lastart["Id"] + 1;
                            var grdlot = article.Cells[0].Value;
                            VarTxt1.Text = grdlot.ToString();
                            VarTxt2.Text = (string)article.Cells[1].Value;
                            artid.Value = artnewid;
                            forrivid.Value = rivnewid;
                            lot.Value = VarTxt1.Text;
                            art.Value = VarTxt2.Text;
                            lastart.Dispose();

                            artcmd.ExecuteNonQuery();

                            foreach (var item in article.ChildRows)
                            {
                                var cntditem = (int)cntitemcmd.ExecuteScalar();
                                if (cntditem == 0)
                                {
                                    var quant = item.Cells[3].Value;
                                    VarTxt1.Text = quant.ToString();
                                    VarTxt2.Text = (string)item.Cells[1].Value;
                                    itemid.Value = defaultId;
                                    forartid.Value = artnewid;
                                    qty.Value = VarTxt1.Text;
                                    itemname.Value = VarTxt2.Text;

                                    itemcmd.ExecuteNonQuery();
                                }
                                else if (cntditem != 0)
                                {
                                    var lastitem = lstitemcmd.ExecuteReader();
                                    lastitem.Read();
                                    var itemnewid = (int)lastitem["Id"] + 1;
                                    var quant = item.Cells[3].Value;
                                    VarTxt1.Text = quant.ToString();
                                    VarTxt2.Text = (string)item.Cells[1].Value;
                                    itemid.Value = itemnewid;
                                    forartid.Value = artnewid;
                                    qty.Value = VarTxt1.Text;
                                    itemname.Value = VarTxt2.Text;
                                    lastitem.Dispose();

                                    itemcmd.ExecuteNonQuery();
                                }
                            }
                        }

                    }

                    var cntactionrdr = (int)cntactioncmd.ExecuteScalar();
                    if (cntactionrdr == 0)
                    {
                        createid.Value = rivnewid;
                        createriv.Value = rivnewid;
                        savecreatecmd.ExecuteNonQuery();
                        savecreatecmd.Dispose();
                    }
                    else
                    {
                        var lastactionrdr = lstactioncmd.ExecuteReader();
                        lastactionrdr.Read();

                        var actnewid = (int)lastactionrdr["Id"] + 1;
                        createid.Value = actnewid;
                        createriv.Value = rivnewid;
                        lastactionrdr.Dispose();

                        savecreatecmd.ExecuteNonQuery();
                        savecreatecmd.Dispose();
                    }
                }


            }
            finally
            {
                conn.Close();
            }
            GrdRiv.Rows.Clear();
            DrpdwnDept.Text = "";
            TxtRemarks.Text = "";
            //----------------------------------------------------------------------------------
            //----------------------------------------------------------------------------------




        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            GrdRiv.Rows.Clear();
            DrpdwnDept.Text = "";
            TxtRemarks.Text = "";
            PnlCreateRiv.Visible = false;
        }


        private void GrdRiv_CellEndEdit(object sender, GridViewCellEventArgs e)
        {
            if (this.GrdRiv.CurrentCell.Tag != null)
            {
                this.GrdRiv.CurrentCell.Value = this.GrdRiv.CurrentCell.Tag;
                this.GrdRiv.CurrentCell.Tag = null;
            }
        }

        private void GrdRiv_EditorRequired(object sender, EditorRequiredEventArgs e)
        {
            if (e.EditorType == typeof (RadDropDownListEditor))
            {
                e.Editor = new CustomDropDownEditor();
            }
        }

        private void GrdRiv_UserAddingRow(object sender, GridViewRowCancelEventArgs e)
        {
            if (e.Rows[0].Cells[1].Value == null)
            {
                e.Cancel = true;
                //BtnCancel.Enabled = false;
                //BntSubmit.Enabled = false;
                RadMessageBox.SetThemeName("TelerikMetro");
                RadMessageBox.Show("Cannot be empty");

            }
            //else if (e.Rows[0].Cells[1].Value != null)
            //{
            //    BtnCancel.Enabled = true;
            //    BntSubmit.Enabled = true;
            //}


        }

        private void GrdRiv_CellValidating(object sender, CellValidatingEventArgs e)
        {
            var column = e.Column as GridViewDataColumn;
            if (e.Row is GridViewDataRowInfo && column != null && column.Name != "Lot Number" &&
                column.Name != "Quantity")
            {
                if (string.IsNullOrEmpty((string)e.Value) || ((string)e.Value).Trim() == string.Empty)
                {
                    e.Cancel = true;
                    ((GridViewDataRowInfo)e.Row).ErrorText = "Validation Error!";
                    BtnCancel.Enabled = false;
                    BntSubmit.Enabled = false;
                }
                else
                {
                    ((GridViewDataRowInfo)e.Row).ErrorText = string.Empty;
                    BtnCancel.Enabled = true;
                    BntSubmit.Enabled = true;
                }
            }
            else if(column != null && (column.Name == "Lot Number" || column.Name == "Quantity"))
            {
                if (e.Value == null)
                {
                    //RadMessageBox.Show("epal ka");
                    ( e.Row).ErrorText = "Validation Error";
                    e.Cancel = true;
                    BtnCancel.Enabled = false;
                    BntSubmit.Enabled = false;
                }
                else if(e.Value != null)
                {
                    (e.Row).ErrorText = string.Empty;
                    BtnCancel.Enabled = true;
                    BntSubmit.Enabled = true;
                }

            }
        }

        private void BtnNewRiv_Click(object sender, EventArgs e)
        {
            PnlCreateRiv.Visible = true;
            PnlPendingReq.Visible = false;
            PnlApproving.Visible = false;
            PnlRivTools.Visible = false;
            PnlApprovalTools.Visible = false;
            PnlAccount.Visible = false;
            PnlActionDetails.Visible = false;
            PnlNotifs.Visible = false;
        }

        private void BtnViewPending_Click(object sender, EventArgs e)
        {
            PnlCreateRiv.Visible = false;
            PnlPendingReq.Visible = true;
            PnlApproving.Visible = false;
            PnlRivTools.Visible = false;
            PnlApprovalTools.Visible = true;
            PnlAccount.Visible = false;
            PnlActionDetails.Visible = false;
            PnlNotifs.Visible = false;
            
            GrdArtApproved.MasterTemplate.Templates.Clear();
            GrdArtApproved.Rows.Clear();
            timer1.Tick += new EventHandler(TimerTick); // Everytime timer ticks, timer_Tick will be called
            timer1.Interval = (1000) * (5);              // Timer will tick evert second
            timer1.Enabled = true;                       // Enable the timer
            timer1.Start();                              // Start the timer
            BtnRefresh.PerformClick();
        }
        void TimerTick(object sender, EventArgs e)
        {

            switch (PnlPendingReq.Visible)
            {
                case true:
                    if (Department == "Warehouse")
                    {
                        var str = new MdlConn().Str;
                        const string query = "SELECT * From dbo.DmsRivInfoes WHERE PosCtr=0 ORDER BY DateCreated DESC";
                        var conn = new SqlConnection(str);
                        var cmd = new SqlCommand(query, conn);
                        try
                        {
                            conn.Open();
                            var rdr = cmd.ExecuteReader();
                            //var rdr2 = cmd2.ExecuteReader();
                            GrdPending.MasterTemplate.LoadFrom(rdr);
                            GrdPending.MasterTemplate.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
                            //GrdPending.Columns[0].IsVisible = false;
                            GrdPending.Columns[1].IsVisible = false;
                            GrdPending.Columns[5].IsVisible = false;
                            GrdPending.Columns[6].IsVisible = false;
                        }
                        finally
                        {
                            conn.Close();
                        }
                        
                    }
                    else if (Department =="OGM")
                    {
                        var str = new MdlConn().Str;
                        const string query = "SELECT * From dbo.DmsRivInfoes WHERE PosCtr=1 ORDER BY DateCreated DESC";
                        var conn = new SqlConnection(str);
                        var cmd = new SqlCommand(query, conn);
                        try
                        {
                            conn.Open();
                            var rdr = cmd.ExecuteReader();
                            //var rdr2 = cmd2.ExecuteReader();
                            GrdPending.MasterTemplate.LoadFrom(rdr);
                            GrdPending.MasterTemplate.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
                            //GrdPending.Columns[0].IsVisible = false;
                            GrdPending.Columns[1].IsVisible = false;
                            GrdPending.Columns[5].IsVisible = false;
                            GrdPending.Columns[6].IsVisible = false;
                        }
                        finally
                        {
                            conn.Close();
                        }
                    }
                    else if (Department == "Accounting")
                    {
                        var str = new MdlConn().Str;
                        const string query = "SELECT * From dbo.DmsRivInfoes WHERE PosCtr=2 ORDER BY DateCreated DESC";
                        var conn = new SqlConnection(str);
                        var cmd = new SqlCommand(query, conn);
                        try
                        {
                            conn.Open();
                            var rdr = cmd.ExecuteReader();
                            //var rdr2 = cmd2.ExecuteReader();
                            GrdPending.MasterTemplate.LoadFrom(rdr);
                            GrdPending.MasterTemplate.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
                            //GrdPending.Columns[0].IsVisible = false;
                            GrdPending.Columns[1].IsVisible = false;
                            GrdPending.Columns[5].IsVisible = false;
                            GrdPending.Columns[6].IsVisible = false;
                        }
                        finally
                        {
                            conn.Close();
                        }
                    }
                    break;
            }

        }



        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            if (Department == "Warehouse")
            {
                var str = new MdlConn().Str;
                const string query = "SELECT * From dbo.DmsRivInfoes WHERE PosCtr=0 ORDER BY DateCreated DESC";
                var conn = new SqlConnection(str);
                var cmd = new SqlCommand(query, conn);
                try
                {
                    conn.Open();
                    var rdr = cmd.ExecuteReader();
                    //var rdr2 = cmd2.ExecuteReader();
                    GrdPending.MasterTemplate.LoadFrom(rdr);
                    GrdPending.MasterTemplate.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
                    //GrdPending.Columns[0].IsVisible = false;
                    GrdPending.Columns[1].IsVisible = false;
                    GrdPending.Columns[5].IsVisible = false;
                    GrdPending.Columns[6].IsVisible = false;
                }
                finally
                {
                    conn.Close();
                }
                timer1.Enabled = true;
                timer1.Start();
            }
            else if (Department == "Accounting")
            {
                var str = new MdlConn().Str;
                const string query = "SELECT * From dbo.DmsRivInfoes WHERE PosCtr=1 ORDER BY DateCreated DESC";
                var conn = new SqlConnection(str);
                var cmd = new SqlCommand(query, conn);
                try
                {
                    conn.Open();
                    var rdr = cmd.ExecuteReader();
                    //var rdr2 = cmd2.ExecuteReader();
                    GrdPending.MasterTemplate.LoadFrom(rdr);
                    GrdPending.MasterTemplate.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
                    //GrdPending.Columns[0].IsVisible = false;
                    GrdPending.Columns[1].IsVisible = false;
                    GrdPending.Columns[5].IsVisible = false;
                    GrdPending.Columns[6].IsVisible = false;
                }
                finally
                {
                    conn.Close();
                }
                timer1.Enabled = true;
                timer1.Start();
            }
            else if (Department == "OGM")
            {
                var str = new MdlConn().Str;
                const string query = "SELECT * From dbo.DmsRivInfoes WHERE PosCtr=2 ORDER BY DateCreated DESC";
                var conn = new SqlConnection(str);
                var cmd = new SqlCommand(query, conn);
                try
                {
                    conn.Open();
                    var rdr = cmd.ExecuteReader();
                    //var rdr2 = cmd2.ExecuteReader();
                    GrdPending.MasterTemplate.LoadFrom(rdr);
                    GrdPending.MasterTemplate.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
                    //GrdPending.Columns[0].IsVisible = false;
                    GrdPending.Columns[1].IsVisible = false;
                    GrdPending.Columns[5].IsVisible = false;
                    GrdPending.Columns[6].IsVisible = false;
                }
                finally
                {
                    conn.Close();
                }
                timer1.Enabled = true;
                timer1.Start();
            }

            
        }

        private void GrdPending_Click(object sender, EventArgs e)
        {

            //----------------------------------------------------------------------------------
            //Creating child template
            var items2 = new GridViewTemplate();

            //Adding to master template
            GrdArtApproved.MasterTemplate.Templates.Add(items2);
            items2.AllowAddNewRow = false;
            items2.AllowDeleteRow = false;
            items2.AllowRowReorder = false;
            items2.AllowRowResize = false;
            items2.AllowEditRow = false;
            items2.EnableSorting = false;
            items2.AllowColumnResize = false;
            items2.AllowColumnReorder = false;


            //Creating child template's columns
            var fk2 = new GridViewDecimalColumn("Lot");
            var itemname2 = new GridViewTextBoxColumn("Item Name");
            var unit2 = new GridViewComboBoxColumn("Unit");
            var quantity2 = new GridViewDecimalColumn("Quantity");

            //Adding columns to the child template
            items2.Columns.Add(fk2);
            items2.Columns["Lot"].IsVisible = false;
            items2.Columns.Add(itemname2);
            items2.Columns.Add(unit2);
            items2.Columns.Add(quantity2);
            items2.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
            //----------------------------------------------------------------------------------
            //----------------------------------------------------------------------------------

            //----------------------------------------------------------------------------------
            //Creating Relation
            var relation2 = new GridViewRelation(GrdArtApproved.MasterTemplate);
            relation2.ChildTemplate = items2;
            relation2.RelationName = "ArticleItems2";
            relation2.ParentColumnNames.Add("Lot Number");
            relation2.ChildColumnNames.Add("Lot");
            GrdArtApproved.Relations.Add(relation2);



            //----------------------------------------------------------------------------------
            //----------------------------------------------------------------------------------      

            if (GrdPending.CurrentRow.Cells[0].Value != null)
            {
                var selectedid = (int)GrdPending.CurrentRow.Cells[0].Value;

                var str = new MdlConn().Str;
                var conn = new SqlConnection(str);

                //----------------------------------------------------------------------------------   
                var rivid = new SqlParameter();
                rivid.ParameterName = "@RIVID";
                rivid.Value = selectedid;

                const string rivquery = "SELECT * From dbo.DmsRivInfoes WHERE Id=@RIVID";
                var rivcmd = new SqlCommand(rivquery, conn);
                rivcmd.Parameters.Add(rivid);
                //----------------------------------------------------------------------------------
                //---------------------------------------------------------------------------------- 



                //---------------------------------------------------------------------------------- 
                var artid = new SqlParameter();
                artid.ParameterName = "@ArtID";
                artid.Value = selectedid;

                const string artquery = "SELECT * From dbo.DmsArticleInfoes WHERE DmsRivInfoId=@ArtID";
                var artcmd = new SqlCommand(artquery, conn);
                artcmd.Parameters.Add(artid);
                //---------------------------------------------------------------------------------- 
                //---------------------------------------------------------------------------------- 



                //---------------------------------------------------------------------------------- 
                var itemid = new SqlParameter();
                itemid.ParameterName = "@ItemId";

                const string itemquery = "SELECT * From dbo.DmsItemInfoes WHERE DmsArticleInfoId=@ItemId";
                var itemcmd = new SqlCommand( itemquery, conn);
                itemcmd.Parameters.Add(itemid);
                //---------------------------------------------------------------------------------- 
                //---------------------------------------------------------------------------------- 


                const string joinquery = "SELECT * dbo.DmsArticleInfoes" +
                                        "JOIN dbo.DmsItemInfoes ON dbo.DmsArticleInfoes.Id=dbo.DmsItemInfoes.DmsArticleInfoId " +
                                        "WHERE dbo.DmsArticleInfoes.DmsRivInfoId=@RIVID";

                //---------------------------------------------------------------------------------- 
                var adapter = new SqlDataAdapter(artcmd);
                var dt = new DataTable();
                //---------------------------------------------------------------------------------- 
                //---------------------------------------------------------------------------------- 



                //---------------------------------------------------------------------------------- 
                var rivid2 = new SqlParameter();
                rivid2.ParameterName = "@rivid2";
                rivid2.Value = selectedid;

                var uid2 = new SqlParameter();
                uid2.ParameterName = "@uid2";
                uid2.Value = UserId;
                const string findseen = "SELECT * FROM dbo.DmsActionLogs WHERE DmsRivInfoId=@rivid2 and UserId=@uid2 " +
                                        "and Action='Seen'";
                var findseencmd = new SqlCommand(findseen, conn);
                findseencmd.Parameters.Add(rivid2);
                findseencmd.Parameters.Add(uid2);
                //---------------------------------------------------------------------------------- 
                //---------------------------------------------------------------------------------- 



                //---------------------------------------------------------------------------------- 
                var seenid = new SqlParameter();
                seenid.ParameterName = "@SeenId";

                var seenriv = new SqlParameter();
                seenriv.ParameterName = "@SeenRiv";
                seenriv.Value = GrdPending.CurrentRow.Cells[0].Value;

                var seenuid = new SqlParameter();
                seenuid.ParameterName = "@SeenUid";
                seenuid.Value = UserId;

                var seenfname = new SqlParameter();
                seenfname.ParameterName = "@SeenFname";
                seenfname.Value = FullName;

                var seenaction = new SqlParameter();
                seenaction.ParameterName = "@SeenAction";
                seenaction.Value = "Seen";

                var seenext = new SqlParameter();
                seenext.ParameterName = "@SeenNext";
                seenext.Value = "";

                var seendate = new SqlParameter();
                seendate.ParameterName = "@SeenDate";
                seendate.Value = DateTime.Now;

                const string saveseen = @"INSERT INTO dbo.DmsActionLogs (Id, DmsRivInfoId, UserId, UserFname,
                                Action, NextStop, DateResponse) VALUES (@SeenId, @SeenRiv, @SeenUid, 
                                @SeenFname, @SeenAction, @SeenNext, @SeenDate)";

                var saveseencmd = new SqlCommand(saveseen, conn);
                saveseencmd.Parameters.Add(seenid);
                saveseencmd.Parameters.Add(seenriv);
                saveseencmd.Parameters.Add(seenuid);
                saveseencmd.Parameters.Add(seenfname);
                saveseencmd.Parameters.Add(seenaction);
                saveseencmd.Parameters.Add(seenext);
                saveseencmd.Parameters.Add(seendate);
                //---------------------------------------------------------------------------------- 
                //---------------------------------------------------------------------------------- 



                //---------------------------------------------------------------------------------- 
                const string lstaction = "SELECT TOP 1 Id FROM dbo.DmsActionLogs Order by Id DESC";
                var lstactioncmd = new SqlCommand(lstaction, conn);

                const string cntaction = "SELECT COUNT(*) FROM dbo.DmsActionLogs";
                var cntactioncmd = new SqlCommand(cntaction, conn);
                //---------------------------------------------------------------------------------- 
                //---------------------------------------------------------------------------------- 



                //---------------------------------------------------------------------------------- 

                var actionrivid = new SqlParameter();
                actionrivid.ParameterName = "@ID";
                actionrivid.Value = selectedid;

                const string notifquery = "SELECT * FROM dbo.DmsActionLogs WHERE DmsRivInfoId=@ID ORDER BY DateResponse Desc";
                var notifquerycmd = new SqlCommand(notifquery, conn);
                notifquerycmd.Parameters.Add(actionrivid);

                const string notifcount = "SELECT  COUNT(*) FROM dbo.DmsActionLogs";
                var notifcountcmd = new SqlCommand(notifcount, conn);

                GrdSingAct.MasterTemplate.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
                GrdSingAct.AllowAddNewRow = false;
                GrdSingAct.AllowColumnReorder = false;
                GrdSingAct.AllowColumnResize = false;
                GrdSingAct.AllowDeleteRow = false;
                GrdSingAct.AllowEditRow = false;
                GrdSingAct.AllowRowReorder = false;
                GrdSingAct.AllowRowResize = false;
                GrdSingAct.EnableFiltering = false;
                GrdSingAct.EnableGrouping = false;
                GrdSingAct.EnableSorting = false;
                GrdSingAct.EnableAlternatingRowColor = true;
                //---------------------------------------------------------------------------------- 
                //---------------------------------------------------------------------------------- 

                var yrCtr = DateTime.Now.ToString("yyyyMM");
                const string numCtr = "0000";
                var combine = yrCtr + numCtr;
                var defaultId = Int32.Parse(combine);

                try
                {
                    conn.Open();
                    var rivrdr = rivcmd.ExecuteReader();
                    rivrdr.Read();
                    var id = (int) rivrdr["Id"];
                    var date = (DateTime) rivrdr["DateCreated"];
                    LblRivID.Text = id.ToString();
                    LblDate.Text = date.ToLongDateString();
                    LblDept.Text = (string)rivrdr["Department"];
                    LblRem.Text = (string)rivrdr["Remarks"];
                    rivrdr.Dispose();

                    adapter.Fill(dt);
                    for (int q = 0; q < dt.Rows.Count; q++)
                    {
                        
                        itemid.Value = dt.Rows[q]["Id"].ToString();
                        GrdArtApproved.MasterTemplate.Rows.Add((int)dt.Rows[q]["Lot"], (string)dt.Rows[q]["Article"]);
                        GridViewTemplate template = GrdArtApproved.MasterTemplate.Templates[0];
                        var adapter2 = new SqlDataAdapter(itemcmd);
                        var dt2 = new DataTable();
                        adapter2.Fill(dt2);
                        for (int x = 0; x < dt2.Rows.Count; x++)
                        {
                            template.Rows.Add((int)dt.Rows[q]["Lot"], (string)dt2.Rows[x]["Item"], "Unit", (int)dt2.Rows[x]["Qty"]);
                        }

                    }

                    var findseenrdr = findseencmd.ExecuteReader();
                    findseenrdr.Read();
                    if (!findseenrdr.HasRows)
                    {
                        findseenrdr.Dispose();
                        var cntactionrdr = (int)cntactioncmd.ExecuteScalar();
                        if (cntactionrdr == 0)
                        {
                            seenid.Value = defaultId;
                            saveseencmd.ExecuteNonQuery();
                            saveseencmd.Dispose();
                        }
                        else
                        {
                            var lastactionrdr = lstactioncmd.ExecuteReader();
                            lastactionrdr.Read();

                            var actnewid = (int)lastactionrdr["Id"] + 1;
                            seenid.Value = actnewid;
                            lastactionrdr.Dispose();

                            saveseencmd.ExecuteNonQuery();
                            saveseencmd.Dispose();
                        }

                    }
                    findseenrdr.Dispose();
                    var notifcount2 = (int) notifcountcmd.ExecuteScalar();
                    if (notifcount2 != 0)
                    {
                        var notifrdr = notifquerycmd.ExecuteReader();
                        GrdSingAct.MasterTemplate.LoadFrom(notifrdr);
                        GrdSingAct.Columns[0].IsVisible = false;
                        GrdSingAct.Columns[2].IsVisible = false;
                    }


                }
                finally
                {
                    conn.Close();
                }


                PnlCreateRiv.Visible = false;
                PnlPendingReq.Visible = false;
                PnlApproving.Visible = true;
                PnlRivTools.Visible = true;
                PnlApprovalTools.Visible = false;
                PnlAccount.Visible = false;
                PnlActionDetails.Visible = true;
                PnlNotifs.Visible = false;
            }
            

        }

        private void LoadUnboundData()
        {
            //const string rivquery = "SELECT * From dbo.DmsRivInfoes " +
            //                        "JOIN dbo.DmsArticleInfoes ON dbo.DmsRivInfoes.Id=dbo.DmsArticleInfoes.DmsRivInfoId " +
            //                        "JOIN dbo.DmsItemInfoes ON dbo.DmsArticleInfoes.Id=dbo.DmsItemInfoes.DmsArticleInfoId " +
            //                        "WHERE dbo.DmsRivInfoes.Id=@RIVID";

        }

        private void BtnSearchPending_Click(object sender, EventArgs e)
        {
            var str = new MdlConn().Str;
            var conn = new SqlConnection(str);
            if (Department == "Warehouse")
            {
                const string query = "SELECT * From dbo.DmsRivInfoes WHERE PosCtr=0 and Id=@RIVID";

                var rivid = new SqlParameter();
                rivid.ParameterName = "@RIVID";
                rivid.Value = TxtSearchPending.Text;
                var cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(rivid);

                try
                {
                    conn.Open();
                    var rdr = cmd.ExecuteReader();
                    //rdr.Read();
                    if (rdr.HasRows)
                    {
                        timer1.Stop();
                        timer1.Enabled = false;
                        //var rdr2 = cmd2.ExecuteReader();
                        GrdPending.MasterTemplate.LoadFrom(rdr);
                        GrdPending.MasterTemplate.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
                    }
                    else
                    {
                        rdr.Dispose();
                        BtnRefresh.PerformClick();
                        RadMessageBox.SetThemeName("TelerikMetro");
                        RadMessageBox.Show("Your query returns no result", "Not found", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                    }
                }
                finally
                {
                    conn.Close();
                }
            }
            else if (Department == "Accounting")
            {
                const string query = "SELECT * From dbo.DmsRivInfoes WHERE PosCtr=1 and Id=@RIVID";

                var rivid = new SqlParameter();
                rivid.ParameterName = "@RIVID";
                rivid.Value = TxtSearchPending.Text;
                var cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(rivid);

                try
                {
                    conn.Open();
                    var rdr = cmd.ExecuteReader();
                    //rdr.Read();
                    if (rdr.HasRows)
                    {
                        timer1.Stop();
                        timer1.Enabled = false;
                        //var rdr2 = cmd2.ExecuteReader();
                        GrdPending.MasterTemplate.LoadFrom(rdr);
                        GrdPending.MasterTemplate.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
                    }
                    else
                    {
                        rdr.Dispose();
                        BtnRefresh.PerformClick();
                        RadMessageBox.SetThemeName("TelerikMetro");
                        RadMessageBox.Show("Your query returns no result", "Not found", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                    }
                }
                finally
                {
                    conn.Close();
                }
            }
            else if (Department == "OGM")
            {
                const string query = "SELECT * From dbo.DmsRivInfoes WHERE PosCtr=2 and Id=@RIVID";

                var rivid = new SqlParameter();
                rivid.ParameterName = "@RIVID";
                rivid.Value = TxtSearchPending.Text;
                var cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(rivid);

                try
                {
                    conn.Open();
                    var rdr = cmd.ExecuteReader();
                    //rdr.Read();
                    if (rdr.HasRows)
                    {
                        timer1.Stop();
                        timer1.Enabled = false;
                        //var rdr2 = cmd2.ExecuteReader();
                        GrdPending.MasterTemplate.LoadFrom(rdr);
                        GrdPending.MasterTemplate.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
                    }
                    else
                    {
                        rdr.Dispose();
                        BtnRefresh.PerformClick();
                        RadMessageBox.SetThemeName("TelerikMetro");
                        RadMessageBox.Show("Your query returns no result", "Not found", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                    }
                }
                finally
                {
                    conn.Close();
                }
            }

        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            PnlCreateRiv.Visible = false;
            PnlPendingReq.Visible = true;
            PnlApproving.Visible = false;
            PnlRivTools.Visible = false;
            PnlApprovalTools.Visible = true;
            PnlAccount.Visible = false;
            PnlActionDetails.Visible = false;
            PnlNotifs.Visible = false;
        }

        private void BtnApproved_Click(object sender, EventArgs e)
        {
            var str = new MdlConn().Str;
            var conn = new SqlConnection(str);

            //---------------------------------------------------------------------------------- 
            var approvedid = new SqlParameter();
            approvedid.ParameterName = "@ApprovedId";

            var approvedriv = new SqlParameter();
            approvedriv.ParameterName = "@ApprovedRiv";
            approvedriv.Value = LblRivID.Text;

            var approveduid = new SqlParameter();
            approveduid.ParameterName = "@ApprovedUid";
            approveduid.Value = UserId;

            var approvedfname = new SqlParameter();
            approvedfname.ParameterName = "@ApprovedFname";
            approvedfname.Value = FullName;

            var approvedaction = new SqlParameter();
            approvedaction.ParameterName = "@ApprovedAction";
            approvedaction.Value = "Approved";

            var approvednext = new SqlParameter();
            approvednext.ParameterName = "@ApprovedNext";

            var approveddate = new SqlParameter();
            approveddate.ParameterName = "@ApprovedDate";
            approveddate.Value = DateTime.Now;

            const string saveapproved = @"INSERT INTO dbo.DmsActionLogs (Id, DmsRivInfoId, UserId, UserFname,
                                Action, NextStop, DateResponse) VALUES (@ApprovedId, @ApprovedRiv, @ApprovedUid, 
                                @ApprovedFname, @ApprovedAction, @ApprovedNext, @ApprovedDate)";


            //---------------------------------------------------------------------------------- 
            var saveapprovedcmd = new SqlCommand(saveapproved, conn);
            saveapprovedcmd.Parameters.Add(approvedid);
            saveapprovedcmd.Parameters.Add(approvedriv);
            saveapprovedcmd.Parameters.Add(approveduid);
            saveapprovedcmd.Parameters.Add(approvedfname);
            saveapprovedcmd.Parameters.Add(approvedaction);
            saveapprovedcmd.Parameters.Add(approvednext);
            saveapprovedcmd.Parameters.Add(approveddate);
            //---------------------------------------------------------------------------------- 
            //---------------------------------------------------------------------------------- 



            //---------------------------------------------------------------------------------- 
            const string lstaction = "SELECT TOP 1 Id FROM dbo.DmsActionLogs Order by Id DESC";
            var lstactioncmd = new SqlCommand(lstaction, conn);

            const string cntaction = "SELECT COUNT(*) FROM dbo.DmsActionLogs";
            var cntactioncmd = new SqlCommand(cntaction, conn);
            //---------------------------------------------------------------------------------- 
            //---------------------------------------------------------------------------------- 


            var yrCtr = DateTime.Now.ToString("yyyyMM");
            const string numCtr = "0000";
            var combine = yrCtr + numCtr;
            var defaultId = Int32.Parse(combine);

            //approvedid.Value
            //approvednext.Value = "";
            if (Department == "Warehouse")
            {
                
                const string query = "Update dbo.DmsRivInfoes SET PosCtr=1 WHERE Id=@RIVID";

                var rivid = new SqlParameter();
                rivid.ParameterName = "@RIVID";
                rivid.Value = LblRivID.Text;

                var cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(rivid);

                approvednext.Value = "Accounting";
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    var cntactionrdr = (int)cntactioncmd.ExecuteScalar();
                    if (cntactionrdr == 0)
                    {
                        approvedid.Value = defaultId;
                        saveapprovedcmd.ExecuteNonQuery();
                        saveapprovedcmd.Dispose();
                    }
                    else
                    {
                        var lastactionrdr = lstactioncmd.ExecuteReader();
                        lastactionrdr.Read();

                        var actnewid = (int)lastactionrdr["Id"] + 1;
                        approvedid.Value = actnewid;
                        lastactionrdr.Dispose();

                        saveapprovedcmd.ExecuteNonQuery();
                        saveapprovedcmd.Dispose();
                    }
                }
                finally
                {
                    conn.Close();
                }

                BtnRefresh.PerformClick();
                BtnBack.PerformClick();
            }
            else if (Department == "OGM")
            {
                approvednext.Value = "Purchasing";
                const string query = "Update dbo.DmsRivInfoes SET PosCtr=2 WHERE Id=@RIVID";

                var rivid = new SqlParameter();
                rivid.ParameterName = "@RIVID";
                rivid.Value = LblRivID.Text;

                var cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(rivid);


                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    var cntactionrdr = (int)cntactioncmd.ExecuteScalar();
                    if (cntactionrdr == 0)
                    {
                        approvedid.Value = defaultId;
                        saveapprovedcmd.ExecuteNonQuery();
                        saveapprovedcmd.Dispose();
                    }
                    else
                    {
                        var lastactionrdr = lstactioncmd.ExecuteReader();
                        lastactionrdr.Read();

                        var actnewid = (int)lastactionrdr["Id"] + 1;
                        approvedid.Value = actnewid;
                        lastactionrdr.Dispose();

                        saveapprovedcmd.ExecuteNonQuery();
                        saveapprovedcmd.Dispose();
                    }
                }
                finally
                {
                    conn.Close();
                }

                BtnRefresh.PerformClick();
                BtnBack.PerformClick();
            }
            else if (Department == "Accounting")
            {
                approvednext.Value = "OGM";
                const string query = "Update dbo.DmsRivInfoes SET PosCtr=3 WHERE Id=@RIVID";

                var rivid = new SqlParameter();
                rivid.ParameterName = "@RIVID";
                rivid.Value = LblRivID.Text;

                var cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(rivid);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    var cntactionrdr = (int)cntactioncmd.ExecuteScalar();
                    if (cntactionrdr == 0)
                    {
                        approvedid.Value = defaultId;
                        saveapprovedcmd.ExecuteNonQuery();
                        saveapprovedcmd.Dispose();
                    }
                    else
                    {
                        var lastactionrdr = lstactioncmd.ExecuteReader();
                        lastactionrdr.Read();

                        var actnewid = (int)lastactionrdr["Id"] + 1;
                        approvedid.Value = actnewid;

                        lastactionrdr.Dispose();

                        saveapprovedcmd.ExecuteNonQuery();
                        saveapprovedcmd.Dispose();
                    }
                }
                finally
                {
                    conn.Close();
                }

                BtnRefresh.PerformClick();
                BtnBack.PerformClick();
            }

        }

        private void BtnNotifs_Click(object sender, EventArgs e)
        {
            PnlCreateRiv.Visible = false;
            PnlPendingReq.Visible = false;
            PnlApproving.Visible = false;
            PnlRivTools.Visible = false;
            PnlApprovalTools.Visible = false;
            PnlAccount.Visible = false;
            PnlActionDetails.Visible = false;
            PnlNotifs.Visible = true;

            var str = new MdlConn().Str;
            var conn = new SqlConnection(str);

            const string notifquery = "SELECT * FROM dbo.DmsActionLogs ORDER BY DateResponse Desc";
            var notifquerycmd = new SqlCommand(notifquery, conn);
            GrdNotifs.MasterTemplate.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
            GrdNotifs.AllowAddNewRow = false;
            GrdNotifs.AllowColumnReorder = false;
            GrdNotifs.AllowColumnResize = false;
            GrdNotifs.AllowDeleteRow = false;
            GrdNotifs.AllowEditRow = false;
            GrdNotifs.AllowRowReorder = false;
            GrdNotifs.AllowRowResize = false;
            GrdNotifs.EnableFiltering = false;
            GrdNotifs.EnableGrouping = false;
            GrdNotifs.EnableSorting = false;
            GrdNotifs.EnableAlternatingRowColor = true;
            try
            {
                conn.Open();
                var notifrdr = notifquerycmd.ExecuteReader();
                GrdNotifs.MasterTemplate.LoadFrom(notifrdr);
                GrdNotifs.Columns[0].IsVisible = false;
                GrdNotifs.Columns[2].IsVisible = false;
            }
            finally
            {
                conn.Close();
            }
        }

    }
}
