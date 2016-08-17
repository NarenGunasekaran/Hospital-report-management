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
    public partial class urines : Form
    {
        public urines()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox12.Text))
            {
                operations op = new operations();
                bool check = op.validate_urin(textBox2.Text,textBox3.Text,textBox4.Text,textBox5.Text,textBox8.Text,textBox9.Text,textBox10.Text);
                if (check == true)
                {
                    DateTime time = DateTime.Now;
                    string format = "yyyy-MM-dd";
                    String code = textBox12.Text.ToString();
                    DBOperation db = new DBOperation();
                    db.open_con();
                    string query = "insert into urin(code,color,appearence,ph,specific_gravity,urobilinogen,rbc,wbc,date) values('" + code + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + textBox10.Text + "','" + time.ToString(format) + "')";
                    SqlCommand cmd = new SqlCommand(query, db.con);
                    int res = cmd.ExecuteNonQuery();
                    if (res >= 1)
                    {
                        MessageBox.Show("Record has been inserted successfully...");
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        textBox5.Text = "";
                        textBox8.Text = "";
                        textBox9.Text = "";
                        textBox10.Text = "";
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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void urines_Load(object sender, EventArgs e)
        {

        }
        public static string sendText = "";
        private void viewAllPatientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sendText = "u";
            dep_patient_view2 d = new dep_patient_view2();
            d.Show();
            this.Hide();
        }

    }
}
