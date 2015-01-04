using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.WinControls.RichTextBox.Model;

namespace OrmecoDms
{
    public class DropSource
    {
        public string Unit { get; set; }

        public DropSource(string unit)
        {
            Unit = unit;
        }

        public override string ToString()
        {
            return Unit;
        }
    }
}
