using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Hospital
{
    class DBOperation
    {
        public SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=\"C:\\Users\\Naren\\Documents\\Visual Studio 2010\\Projects\\Hospital\\Hospital\\Hospital.mdf\";Integrated Security=True;User Instance=True");

        public void open_con()
        {
            con.Open();
        }

        public void close_con()
        {
            con.Close();
        }

       
    }
}
