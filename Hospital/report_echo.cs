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
    public partial class report_echo : Form
    {
        public report_echo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            printForm1.Print();
        }

        private void report_echo_Load(object sender, EventArgs e)
        {
            String res = "";
            operations ob = new operations();
            res += ob.report_echo();
            label1.Text = res;
        }
    }
}
