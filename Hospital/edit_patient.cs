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
    public partial class edit_patient : Form
    {
        public edit_patient()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox12.Text))
            {
                String code=textBox12.Text.ToString();
                DBOperation db = new DBOperation();
                db.open_con();
                String qry = "select * from patient where code='"+code+"'";
                SqlCommand cmd = new SqlCommand(qry,db.con);
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    textBox1.Text = reader[2].ToString();
                    textBox3.Text = reader[3].ToString();
                    textBox4.Text = reader[4].ToString();
                    textBox5.Text = reader[5].ToString();
                    textBox6.Text = reader[6].ToString();
                    textBox7.Text = reader[7].ToString();
                    textBox8.Text = reader[8].ToString();
                    textBox9.Text = reader[9].ToString();
                    textBox10.Text = reader[10].ToString();
                    textBox11.Text = reader[11].ToString();
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox12.Text) && !string.IsNullOrWhiteSpace(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox3.Text) && !string.IsNullOrWhiteSpace(textBox4.Text) && !string.IsNullOrWhiteSpace(textBox5.Text) && !string.IsNullOrWhiteSpace(textBox6.Text) && !string.IsNullOrWhiteSpace(textBox7.Text) && !string.IsNullOrWhiteSpace(textBox8.Text) && !string.IsNullOrWhiteSpace(textBox9.Text) && !string.IsNullOrWhiteSpace(textBox10.Text) && !string.IsNullOrWhiteSpace(textBox11.Text))
            {
                String code=textBox12.Text.ToString();
                DBOperation db = new DBOperation();
                db.open_con();
                String qry = "update patient set first_name='"+textBox1.Text+"',last_name='"+textBox3.Text+"',contact='"+textBox4.Text+"',email='"+textBox5.Text+"',blood_group='"+textBox6.Text+"',age='"+textBox7.Text+"',address1='"+textBox8.Text+"',address2='"+textBox9.Text+"',city='"+textBox10.Text+"',pin='"+textBox11.Text+"' where code='"+code+"'";
                SqlCommand cmd = new SqlCommand(qry, db.con);
                int res = cmd.ExecuteNonQuery();
                if (res >= 1)
                {
                    MessageBox.Show("updated sucessfully");
                }
                else
                {
                    MessageBox.Show("Ooops !!! Not updated!!");
                }
                String qry1 = "select * from patient where code='" + code + "'";
                SqlCommand cmds = new SqlCommand(qry1, db.con);
                SqlDataReader reader;
                reader = cmds.ExecuteReader();
                while (reader.Read())
                {
                    textBox1.Text = reader[2].ToString();
                    textBox3.Text = reader[3].ToString();
                    textBox4.Text = reader[4].ToString();
                    textBox5.Text = reader[5].ToString();
                    textBox6.Text = reader[6].ToString();
                    textBox7.Text = reader[7].ToString();
                    textBox8.Text = reader[8].ToString();
                    textBox9.Text = reader[9].ToString();
                    textBox10.Text = reader[10].ToString();
                    textBox11.Text = reader[11].ToString();
                }
                db.close_con();
            }
            else
            {
                MessageBox.Show("Field should not be empty");
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            view_patient vp = new view_patient();
            vp.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox12.Text))
            {
                String code = textBox12.Text.ToString();
                DBOperation db = new DBOperation();
                db.open_con();
                string query = "DELETE FROM patient WHERE code='" + code + "'";

                SqlCommand cmd = new SqlCommand(query, db.con);
                int res = cmd.ExecuteNonQuery();
                if (res >= 1)
                {

                    MessageBox.Show("Customer information deleted sucessfuly !!!");
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
                    textBox12.Text = "";
                }
                else
                {
                    MessageBox.Show("Deletion failed");
                }
                db.close_con();
            }
        }

        private void button4_Click(object sender, EventArgs e)
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
                while (reader.Read())
                {
                    textBox1.Text = reader[2].ToString();
                    textBox3.Text = reader[3].ToString();
                    textBox4.Text = reader[4].ToString();
                    textBox5.Text = reader[5].ToString();
                    textBox6.Text = reader[6].ToString();
                    textBox7.Text = reader[7].ToString();
                    textBox8.Text = reader[8].ToString();
                    textBox9.Text = reader[9].ToString();
                    textBox10.Text = reader[10].ToString();
                    textBox11.Text = reader[11].ToString();
                }
            }
            else
            {
                MessageBox.Show("Please input the customer unique id to search !!!");
            }
        }

        private void edit_patient_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
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
            textBox12.Text = "";
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
            register r = new register();
            r.Show();
            this.Hide();
        

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
