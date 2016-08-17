using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;

namespace Hospital
{
    public partial class dep_patient_view : Form
    {
        
        public dep_patient_view()
        {
            InitializeComponent();
            
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Form1 r = new Form1();
            r.Show();
            this.Hide();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            register r = new register();
            r.Show();
            this.Hide();
        }

        private void dep_patient_view_Load(object sender, EventArgs e)
        {
            DBOperation db = new DBOperation();
            db.open_con();
            String query = "Select * from patient";
            SqlDataAdapter adp = new SqlDataAdapter(query, db.con);
            hospitalDataSet1.Clear();
            adp.Fill(hospitalDataSet1, "patient");
            dataGridView1.DataSource = hospitalDataSet1;
            dataGridView1.DataMember = "patient";
            db.close_con();
        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {

            hematology h = new hematology();
            h.Show();
            this.Hide();
        }
    }
}
