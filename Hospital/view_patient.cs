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
    public partial class view_patient : Form
    {
        public view_patient()
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

        private void view_patient_Load(object sender, EventArgs e)
        {
            DBOperation db = new DBOperation();
            db.open_con();
            String query = "Select * from patient";
            SqlDataAdapter adp = new SqlDataAdapter(query,db.con);
            hospitalDataSet1.Clear();
            adp.Fill(hospitalDataSet1,"patient");
            dataGridView1.DataSource = hospitalDataSet1;
            dataGridView1.DataMember = "patient";
            db.close_con();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DBOperation db = new DBOperation();
            db.open_con();
            int row = dataGridView1.CurrentRow.Index;
            int cno = int.Parse(dataGridView1.Rows[row].Cells[0].Value.ToString());
            string query = "DELETE FROM patient WHERE id='" + cno + "'";

            SqlCommand cmd = new SqlCommand(query, db.con);
            int res = cmd.ExecuteNonQuery();
            if (res >= 1)
            {
                               
                MessageBox.Show("Customer information deleted sucessfuly !!!");
                String quer = "Select * from patient";
                SqlDataAdapter adp = new SqlDataAdapter(quer, db.con);
                hospitalDataSet1.Clear();
                adp.Fill(hospitalDataSet1, "patient");
                dataGridView1.DataSource = hospitalDataSet1;
                dataGridView1.DataMember = "patient";
            }
            else
            {
                MessageBox.Show("Deletion failed");
            }
            db.close_con();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
