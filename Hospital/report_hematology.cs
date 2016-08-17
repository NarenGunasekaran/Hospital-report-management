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
    public partial class report_hematology : Form
    {
        public report_hematology()
        {
            InitializeComponent();
        }

        
        private void report_hematology_Load(object sender, EventArgs e)
        {

            String res = "";
            operations ob = new operations();
            res += ob.report_hemo();
            label1.Text = res;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            printForm1.Print();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
           
        }

    }
}
