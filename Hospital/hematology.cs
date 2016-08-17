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
    public partial class hematology : Form
    {
        public hematology()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Form1 r = new Form1();
            r.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox12.Text))
            {
                String code = textBox12.Text.ToString();
                DBOperation db = new DBOperation();
                db.open_con();
                String qry = "select * from patient where code='" + code + "'";
                SqlCommand cmd = new SqlCommand(qry, db.con);
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    textBox1.Text = reader[2].ToString();
                    textBox6.Text = reader[6].ToString();
                    textBox7.Text = reader[7].ToString();

                }
                else
                {
                    MessageBox.Show("The Id is not valid !!! It will not give you anything");
                }
            }
            else
            {
                MessageBox.Show("Please input the customer unique id to search !!!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox12.Text))
            {
                operations op = new operations();
                bool check = op.validate_hema(textBox2.Text,textBox3.Text,textBox4.Text,textBox5.Text);
                if (check == true)
                {
                    DateTime time = DateTime.Now;
                    string format = "yyyy-MM-dd";
                    String code = textBox12.Text.ToString();
                    DBOperation db = new DBOperation();
                    db.open_con();
                    string query = "insert into hematology(code,wbc,rbc,hgb,platelet,date) values('" + code + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + time.ToString(format) + "')";
                    SqlCommand cmd = new SqlCommand(query, db.con);
                    int res = cmd.ExecuteNonQuery();
                    if (res >= 1)
                    {
                        MessageBox.Show("Record has been inserted successfully...");
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        textBox5.Text = "";

                    }
                    else
                    {
                        MessageBox.Show("Ooops !!! Not inserted!!");
                    }
                    db.close_con();
                }
            }
            else
            {
                MessageBox.Show("Dude!!! You need to insert the Id !!!");
            }
        }

        private void hematology_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 r = new Form1();
            r.Show();
            this.Hide();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        public static string sendText = "";
        private void viewAllPatientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sendText = "h";
            dep_patient_view d = new dep_patient_view();
            d.Show();
            this.Hide();
        }

       
    }
}
