using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrmecoDms
{
    public class MdlConn
    {
        public string Str { get; set; }

        public MdlConn()
        {
            Str =  "Data Source=JOEL-PC\\SQLEXPRESS;Initial Catalog=Ormeco;Integrated Security=SSPI";
        }

    }
}
