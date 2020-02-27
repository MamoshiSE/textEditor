using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace textEditor
{
   
    public partial class Form1 : Form
    {
        String openedFileName;
        bool fileChanged = false;
        
        public Form1()
        {
            InitializeComponent();
          
            
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            if (this.Text != "doc1.txt")
            {
                using (StreamReader sr = new StreamReader(openedFileName))
                {

                    if (mainTextArea.Text != sr.ReadToEnd())
                    {
                        fileChanged = true;
                    }

                    sr.Close();
                }
            }
            if (String.IsNullOrWhiteSpace(mainTextArea.Text) || (fileChanged == false && this.Text != "doc1.txt"))
            {
                mainTextArea.Clear();
            } else
            {
                dynamic result = MessageBox.Show("Do you want to save changes to your text?", "Text Editor",
        MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                    saveToolStripButton.PerformClick();
                }

                if (result == DialogResult.No)
                {
                    
                    mainTextArea.Clear();
                }
            }
            fileChanged = false;
            this.Text = "doc1.txt";
        }
        

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();
            openfile.Title = "Open file";
            if (openfile.ShowDialog() == DialogResult.OK)
            {
                fileChanged = false;
                mainTextArea.Clear();
                using (StreamReader sr = new StreamReader(openfile.FileName))
                {
                    this.Text = openfile.SafeFileName + ".txt";
                    openedFileName = openfile.FileName;
                    mainTextArea.Text = sr.ReadToEnd();
                    sr.Close();
                }
            }
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            fileChanged = false;
            if (this.Text == "doc1.txt")
            {
                saveAsToolStripMenuItem.PerformClick();
                
            } else
            {

               
                File.WriteAllText(openedFileName, mainTextArea.Text);

                }
            
            
            
           
        }
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.Title = "Save file as";
            if (savefile.ShowDialog() == DialogResult.OK)
            {
                fileChanged = false;
                StreamWriter txt = new StreamWriter(savefile.FileName);
                txt.Write(mainTextArea.Text);
                txt.Close();

            }
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainTextArea.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainTextArea.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainTextArea.Paste();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainTextArea.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainTextArea.Redo();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainTextArea.SelectAll();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newToolStripButton.PerformClick();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openToolStripButton.PerformClick();
        }


        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveToolStripButton.PerformClick();
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
