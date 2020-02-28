using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace textEditor
{
    public partial class Form2 : Form
    {
       // Form1 form1;
        public Form2(Form1 form1)
        {
            InitializeComponent();
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1.form1.savePerformClick();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1.form1.dontSaveClick();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();

        }

      
    }
}
