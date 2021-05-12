using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientFileStorage
{
    class SQLClass
    {
        public string sqlConnectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =" + System.IO.Path.GetDirectoryName(Path.GetDirectoryName(Application.StartupPath)) + "\\Database1.mdf; Integrated Security = True";
    }
}
