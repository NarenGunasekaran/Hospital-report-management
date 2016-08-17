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
    public partial class doc_echocardiogram : Form
    {
        public doc_echocardiogram()
        {
            InitializeComponent();

            label3.Text = doctor.sendText;

            if (!string.IsNullOrWhiteSpace(label3.Text))
            {
                DateTime time = DateTime.Now;
                string format = "yyyy-MM-dd";
                String code = label3.Text.ToString();
                DBOperation db = new DBOperation();
                db.open_con();
                String qry = "select date,Ao_Diam,Lvot_Diam,LA_Diam from Echo where code='" + code + "' and date ='" + time.ToString(format) + "'";
                SqlDataAdapter adp = new SqlDataAdapter(qry, db.con);

                hospitalDataSet1.Clear();
                adp.Fill(hospitalDataSet1, "Echo");
                dataGridView1.DataSource = hospitalDataSet1;
                dataGridView1.DataMember = "Echo";
                db.close_con();

            }          
        }

        private void doc_echocardiogram_Load(object sender, EventArgs e)
        {

        }
        public static string sendTextAll = "";
        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                DateTime time = DateTime.Now;
                string format = textBox1.Text.ToString();

                String code = label3.Text.ToString();
                DBOperation db = new DBOperation();
                db.open_con();
                String qry = "select date,Ao_Diam,Lvot_Diam,LA_Diam from Echo where code='" + code + "' and date ='" + time.ToString(format) + "'";
                SqlDataAdapter adp = new SqlDataAdapter(qry, db.con);
                hospitalDataSet1.Clear();
                adp.Fill(hospitalDataSet1, "Echo");
                dataGridView1.DataSource = hospitalDataSet1;
                dataGridView1.DataMember = "Echo";
                db.close_con();
            }
            else
            {
                MessageBox.Show("Please Enter date to search !!!");
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sendTextAll = label3.Text;
            doctor r = new doctor();
            r.Show();
            this.Hide();


        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            operations.pid = Int32.Parse(label3.Text.ToString());
            report_echo ob = new report_echo();
            ob.Show();
        }

        private void backToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            sendTextAll = label3.Text;
            
            doctor r = new doctor();
            r.Show();
            this.Hide();
        }
    }
}
