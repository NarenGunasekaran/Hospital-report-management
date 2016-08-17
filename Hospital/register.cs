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
    public partial class register : Form
    {
        public register()
        {
            InitializeComponent();
        }

        private void register_Load(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Form1 r = new Form1();
            r.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox3.Text) && !string.IsNullOrWhiteSpace(textBox4.Text) && !string.IsNullOrWhiteSpace(textBox5.Text) && !string.IsNullOrWhiteSpace(textBox6.Text) && !string.IsNullOrWhiteSpace(textBox7.Text) && !string.IsNullOrWhiteSpace(textBox8.Text) && !string.IsNullOrWhiteSpace(textBox9.Text) && !string.IsNullOrWhiteSpace(textBox10.Text) && !string.IsNullOrWhiteSpace(textBox11.Text))
            {
                operations op = new operations();

                bool re = op.validate(textBox1.Text,textBox3.Text,textBox4.Text,textBox5.Text,textBox7.Text,textBox10.Text,textBox11.Text);
                if (re == true)
                {
                    DBOperation db = new DBOperation();
                    db.open_con();

                    string num = op.rand_num().ToString();
                    string query = "insert into patient(code,first_name,last_name,contact,email,blood_group,age,address1,address2,city,pin) values('" + num + "','" + textBox1.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + textBox10.Text + "','" + textBox11.Text + "')";
                    SqlCommand cmd = new SqlCommand(query, db.con);
                    int res = cmd.ExecuteNonQuery();
                    if (res >= 1)
                    {
                        MessageBox.Show("Record has been inserted successfully...");
                        MessageBox.Show("Your ID : " + num);
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
                MessageBox.Show("All fields are mandatory !!!");
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            view_patient vp = new view_patient();
            vp.Show();
            this.Hide();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            edit_patient vp = new edit_patient();
            vp.Show();
            this.Hide();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
