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
        public static Form2 form2;
        public static bool closeCancel = false;
        public Form2(Form1 form1)
        {
            InitializeComponent();
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1.form1.savePerformClick();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
          
              
            Form1.form1.dontSaveClick();
            this.Hide();
            
        }

        public void button3_Click(object sender, EventArgs e)
        {
            
            closeCancel = true;
            this.Hide();

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label1.Text = "Do you want to save the changes for " + Form1.openedFileName;
        }
    }
}
