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
    public partial class report_urin : Form
    {
        public report_urin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            printForm1.Print();
        }

        private void report_urin_Load(object sender, EventArgs e)
        {
            String res = "";
            operations ob = new operations();
            res += ob.report_urin();
            label1.Text = res;
        }
    }
}
