using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C1.Win.C1FlexGrid.Classic;
using Telerik.WinControls.UI;

namespace OrmecoDms
{
    public class CustomDropDownEditor : RadDropDownListEditor
    {
        public override bool EndEdit()
        {
            var cellElement = this.OwnerElement as GridComboBoxCellElement;

            RadGridView grid = cellElement.GridControl;
            var f = (FrmMain)grid.FindForm();
            
            for (int q = 0; q < f.DropSources.Count(); q++)
            {
                if (f.DropSources[q].Unit.ToString() == (((RadDropDownListEditorElement)this.EditorElement).Text))
                {
                    return base.EndEdit();
                }
            }

            var wew = ((RadDropDownListEditorElement)this.EditorElement).Text;
            if (wew != "")
            {
                f.DropSources.Add(new DropSource(wew));
                cellElement.Tag = wew;
                return base.EndEdit();
                
            }

            return base.EndEdit();
        }
    }
}
