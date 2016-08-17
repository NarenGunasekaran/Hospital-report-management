using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Hospital
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string a=textBox1.Text.ToString();
            string b = textBox2.Text.ToString();
            if (!string.IsNullOrWhiteSpace(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox2.Text))
            {
                if (a == "Dept1" && b == "dept1")
                {
                    register r = new register();
                    r.Show();
                    this.Hide();
                }
                else if (a == "Dept2" && b == "dept2")
                {
                    hematology r = new hematology();
                    r.Show();
                    this.Hide();
                }
                else if (a == "Dept3" && b == "dept3")
                {
                    urines r = new urines();
                    r.Show();
                    this.Hide();
                }
                else if (a == "Dept4" && b == "dept4")
                {
                    Echocardiogram r = new Echocardiogram();
                    r.Show();
                    this.Hide();
                }
                else if (a == "Doctor" && b == "doctor")
                {
                    doctor r = new doctor();
                    r.Show();
                    this.Hide();
                }
                else {
                    MessageBox.Show("Wrong Credentials !!!");
                     }
            }
            else
            {
                MessageBox.Show("Fields should now be empty !!!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

    }
}
