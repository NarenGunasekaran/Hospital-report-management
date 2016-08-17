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
    public partial class doctor : Form
    {
        public doctor()
        {
            InitializeComponent();
           
            String hem = doc_hematology.sendTextAll;
            if(hem != null)
            {
                textBox1.Text = hem.ToString();
                DBOperation db = new DBOperation();
                db.open_con();
                String qry = "select * from patient where code='" + hem + "'";
                SqlCommand cmd = new SqlCommand(qry, db.con);
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    textBox2.Text = reader[2].ToString();
                    textBox3.Text = reader[7].ToString();
                    textBox4.Text = reader[6].ToString();

                }
            }

        }

        
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 r = new Form1();
            r.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                String code = textBox1.Text.ToString();
                DBOperation db = new DBOperation();
                db.open_con();
                String qry = "select * from patient where code='" + code + "'";
                SqlCommand cmd = new SqlCommand(qry, db.con);
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    textBox2.Text = reader[2].ToString();
                    textBox3.Text = reader[7].ToString();
                    textBox4.Text = reader[6].ToString();

                }
                else
                {
                    MessageBox.Show("OOPS !!! This Id does not exist !!!");
                }
              
            }
            else
            {
                MessageBox.Show("Please input the customer id to search !!!");
            }
        }

        public static string sendText = "";
        
        private void button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                DBOperation db = new DBOperation();
                db.open_con();

                String qry = "select * from hematology where code='"+textBox1.Text+"'";
                
                SqlCommand cmd = new SqlCommand(qry,db.con);
                int i = cmd.ExecuteNonQuery();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                   
                    sendText = textBox1.Text;
                    doc_hematology r = new doc_hematology();
                    r.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("No hematology report found for this patient");
                }
            }
            else
            {
                MessageBox.Show("Please Input the patient ID !!!");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
           
             if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                
                 DBOperation db = new DBOperation();
                db.open_con();
                String qry = "select * from urin where code='"+textBox1.Text+"'";
                
                SqlCommand cmd = new SqlCommand(qry,db.con);
                int i = cmd.ExecuteNonQuery();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    
                    sendText = textBox1.Text;
                    doc_urin r = new doc_urin();
                    r.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("No urin report found for this patient");
                }
            }
             else
             {
                 MessageBox.Show("Please Input the patient ID !!!");
             }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {

                DBOperation db = new DBOperation();
                db.open_con();
                String qry = "select * from Echo where code='" + textBox1.Text + "'";

                SqlCommand cmd = new SqlCommand(qry, db.con);
                int i = cmd.ExecuteNonQuery();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {

                    sendText = textBox1.Text;
                    doc_echocardiogram r = new doc_echocardiogram();
                    r.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("No Echocardiogram report found for this patient");
                }
            }
            else
            {
                MessageBox.Show("Please Input the patient ID !!!");
            }
        }

        private void doctor_Load(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form1 r = new Form1();
            r.Show();
            this.Hide();
        }
    }
}
