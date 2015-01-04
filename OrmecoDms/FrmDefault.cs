using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OrmecoDms
{
    public partial class FrmDefault : C1.Win.C1Ribbon.C1RibbonForm
    {
        public int Stat;

        public FrmDefault()
        {
            InitializeComponent();
        }

        private void FrmDefault_Load(object sender, EventArgs e)
        {
            switch (Stat)
            {
                case 0:
                    var frm1 = new Form1();
                    frm1.ShowDialog();
                    break;
            }
        }


    }
}
