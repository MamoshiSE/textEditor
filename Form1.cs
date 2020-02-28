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
using System.Text.RegularExpressions;

namespace textEditor
{
   
    public partial class Form1 : Form
    {
        String openedFilePath;
        String openedFileName;
        bool fileChanged = false;
        String cWithSpace = "0";
        String cNoSpace = "0";


        public Form1()
        {
            InitializeComponent();
          
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            checkFileChanged();

            // If there is no changes or the document is empty, start new blank page.
            if (fileChanged == false && this.Text != "doc1.txt*")
            {
                mainTextArea.Clear();
                this.Text = "doc1.txt";
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
                    fileChanged = false;
                    this.Text = "doc1.txt";
                }
            }
            
        }
        

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();
            openfile.Title = "Open file";
            if (openfile.ShowDialog() == DialogResult.OK)
            {
                
                mainTextArea.Clear();
                using (StreamReader sr = new StreamReader(openfile.FileName))
                {
                    this.Text = openfile.SafeFileName + ".txt";
                    openedFileName = this.Text;
                    openedFilePath = openfile.FileName;
                    mainTextArea.Text = sr.ReadToEnd();
                    fileChanged = false;
                    sr.Close();
                }
            }
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            
            if (this.Text == "doc1.txt*")
            {
                saveAsToolStripMenuItem.PerformClick();
                
            } else
            {

               
                File.WriteAllText(openedFilePath, mainTextArea.Text);

                }
            
            
            
           
        }
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.Title = "Save file as";
            if (savefile.ShowDialog() == DialogResult.OK)
            {
                
                StreamWriter txt = new StreamWriter(savefile.FileName);
                txt.Write(mainTextArea.Text);
                fileChanged = false;
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

        private void checkFileChanged()
        {
            // Checking if a file is open, if so - checking for changes in the file.
            if (this.Text != "doc1.txt" && this.Text !="doc1.txt*")
            {
                using (StreamReader sr = new StreamReader(openedFilePath))
                {

                    if (mainTextArea.Text != sr.ReadToEnd())
                    {
                        fileChanged = true;
                    } else
                    {
                        fileChanged = false;
                    }

                    sr.Close();
                }
            }
            
        }
        private void mainTextArea_TextChanged(object sender, EventArgs e)
        {
            checkFileChanged();
            if (fileChanged == true)
            {
                this.Text = openedFileName + "*";
            }
            else if (fileChanged == false && (this.Text != "doc1.txt" && this.Text != "doc1.txt*"))
            {
                this.Text = openedFileName;
            }
            else if (!String.IsNullOrWhiteSpace(mainTextArea.Text) && this.Text == "doc1.txt")
            {
                this.Text = "doc1.txt*";
            }
            if (String.IsNullOrWhiteSpace(mainTextArea.Text))
            {
                this.Text = "doc1.txt";
            }
           
            charWithSpace.Text = "Char with space: " + mainTextArea.Text.Length.ToString();
            charNoSpace.Text = "Char no space: " + mainTextArea.Text.Count(c => !Char.IsWhiteSpace(c)).ToString(); 
            amountOfWords.Text = "Words: " + mainTextArea.Text.Split(' ').Count();
            amountOfRows.Text = "Rows: " + mainTextArea.Lines.Count().ToString();
        }

        private void toolStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void charWithSpace_Click(object sender, EventArgs e)
        {
           
        }
    }
}
