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
    public partial class Echocardiogram : Form
    {
        public Echocardiogram()
        {
            InitializeComponent();
        }

        private void Echocardiogram_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox12.Text))
            {
                operations op = new operations();

                bool re = op.validate_echo(textBox2.Text,textBox3.Text,textBox4.Text);
                if (re == true)
                {
                    DateTime time = DateTime.Now;
                    string format = "yyyy-MM-dd";
                    String code = textBox12.Text.ToString();
                    DBOperation db = new DBOperation();
                    db.open_con();
                    string query = "insert into Echo(code,Ao_Diam,Lvot_Diam,LA_Diam,date) values('" + code + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + time.ToString(format) + "')";
                    SqlCommand cmd = new SqlCommand(query, db.con);
                    int res = cmd.ExecuteNonQuery();
                    if (res >= 1)
                    {
                        MessageBox.Show("Record has been inserted successfully...");
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";

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

        


        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Form1 r = new Form1();
            r.Show();
            this.Hide();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 r = new Form1();
            r.Show();
            this.Hide();
        }
        public static string sendText = "";
        private void viewAllPatientToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            dep_patient_view3 d = new dep_patient_view3();
            d.Show();
            this.Hide();
        }
    }
}
