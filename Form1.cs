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
        String openedFilePath;
        public static String openedFileName = "doc1.txt";
        public bool fileChanged = false;
        public static Form1 form1;



        public Form1()
        {
            InitializeComponent();
            
            mainTextArea.AllowDrop = true;   
            mainTextArea.DragDrop += new DragEventHandler(mainTextArea_DragDrop);
            form1 = this;
            
       
        }

            void mainTextArea_DragDrop(object sender, DragEventArgs e)


        {
            {
                if (e.Data.GetDataPresent(DataFormats.FileDrop)) {  // check so file is dropped
                    string[] files = e.Data.GetData(DataFormats.FileDrop) as string[];
                    
                if (files.Length == 1) { // check so max 1 file
                        if (Control.ModifierKeys == Keys.Control) // if control held down - add content to end of file
                        {

                            mainTextArea.Text += File.ReadAllText(files[0]);
                            //openedFileName = Path.GetFileName(files[0]);
                            //openedFilePath = files[0];
                            //this.Text = openedFileName;



                        } else if (Control.ModifierKeys == Keys.Shift) // if shift held down - add to position of cursor
                        {

                            mainTextArea.SelectedText += File.ReadAllText(files[0]);
                            
                        } else // if nothing is pressed replace page with new file (check for save first)
                        {
                            checkFileChanged();
                              // Checking if file needs saving
                            if (fileChanged == true || this.Text == "doc1.txt*")
                            {
                                Form2 f2 = new Form2(form1);
                                f2.ShowDialog();
                                if (fileChanged == false && Form2.closeCancel == false)
                                {
                                    this.Text = "doc1.txt";
                                    mainTextArea.Text = File.ReadAllText(files[0]);
                                }
                                // checks if user clicked on cancel drag + drop action
                                if (Form2.closeCancel == true)
                                {
                                    Form2.closeCancel = false;
                                    return;
                                }
                                
                            }
                            else
                            {
                                this.Text = "doc1.txt";
                                mainTextArea.Text = File.ReadAllText(files[0]);
                            }
                        }

                        }
                    else
                    {
                        MessageBox.Show("Please input 1 file at a time");
                    }
                }
              
                }

            }

        
                   
            private void newToolStripButton_Click(object sender, EventArgs e)
        {
            checkFileChanged();

            // If there is no changes or the document is empty, start new blank page.
            if (fileChanged == false && this.Text != "doc1.txt*")
            {
                fileChanged = false;
                mainTextArea.Clear();
                this.Text = "doc1.txt";
                openedFileName = "doc1.txt";
                openedFilePath = "";
            }
            else if (this.Text != "doc1.txt")
            {
                Form2 f2 = new Form2(form1);
                f2.ShowDialog(); // Shows Form2

                /*dynamic result = MessageBox.Show("Do you want to save changes to your text?", "Text Editor",
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
            } */

            }
        }
      

            private void openToolStripButton_Click(object sender, EventArgs e)
        {
            checkFileChanged();

            if ((fileChanged == true || this.Text == "doc1.txt*") && this.Text != "doc1.txt")
            {
                Form2 f2 = new Form2(form1);
                f2.ShowDialog();
               
                if (fileChanged == false && Form2.closeCancel == false)
                {
                    openToolStripButton.PerformClick();
                    
                } else if (Form2.closeCancel == true)
                {
                    Form2.closeCancel = false;
                }
                {

                }
            }
            else 
            {
                OpenFileDialog openfile = new OpenFileDialog();
                openfile.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openfile.Title = "Open file";
                if (openfile.ShowDialog() == DialogResult.OK)
                {

                    mainTextArea.Clear();
                    using (StreamReader sr = new StreamReader(openfile.FileName))
                    {
                        this.Text = openfile.SafeFileName;
                        openedFileName = this.Text;
                        openedFilePath = openfile.FileName;
                        mainTextArea.Text = sr.ReadToEnd();
                        fileChanged = false;
                        sr.Close();
                    }
                }
            }
            
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            
            if (this.Text == "doc1.txt*" || this.Text == "doc1.txt")
            {
                saveAsToolStripMenuItem.PerformClick();
                
            } else
            {

               
                File.WriteAllText(openedFilePath, mainTextArea.Text);
                this.Text = openedFileName;

                }
            
            
            
           
        }
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            savefile.Title = "Save file as";
            if (savefile.ShowDialog() == DialogResult.OK)
            {
                
                StreamWriter txt = new StreamWriter(savefile.FileName);
                FileInfo t = new FileInfo(savefile.FileName); // in order to get name without full path
                txt.Write(mainTextArea.Text);
                fileChanged = false;
                this.Text = t.Name;
                openedFileName = this.Text;
                openedFilePath = savefile.FileName;
                
                txt.Close();

            }
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

            charWithSpace.Text = "Char with space: " + mainTextArea.Text.Count();
            charNoSpace.Text = "Char no space: " + mainTextArea.Text.Count(c => !Char.IsWhiteSpace(c)).ToString();
            amountOfWords.Text = "Words: " + (mainTextArea.Text.Split(new char[] { ' ', '\n' }, StringSplitOptions.RemoveEmptyEntries).Length).ToString();
            int rowAmount = mainTextArea.GetLineFromCharIndex(mainTextArea.TextLength) + 1; // to avoid setting wrapping to false;
            amountOfRows.Text = "Rows: " + rowAmount;
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {



            checkFileChanged();

            if ((fileChanged == true || this.Text == "doc1.txt*") && this.Text != "doc1.txt")
            {
                Form2 f2 = new Form2(form1);
                f2.ShowDialog();
                if (Form2.closeCancel == true)
                {
                    e.Cancel = true;
                    Form2.closeCancel = false;
                    return;
                    
                }
            }
        }

     

        private void fileToolStripMenuItem_DropDownClosed(object sender, EventArgs e)
        {
            fileToolStripMenuItem.ForeColor = Color.White;
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fileToolStripMenuItem.ForeColor = Color.Black;
        }

        private void fileToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            fileToolStripMenuItem.ForeColor = Color.Black;
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editToolStripMenuItem.ForeColor = Color.Black;
        }

        private void editToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            editToolStripMenuItem.ForeColor = Color.Black;
        }

        private void editToolStripMenuItem_DropDownClosed(object sender, EventArgs e)
        {
            editToolStripMenuItem.ForeColor = Color.White;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mainTextArea.AllowDrop = true;
            
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newToolStripButton.PerformClick();
        }


        // used to make method accesable in other form
        public void savePerformClick()
        {
            saveToolStripMenuItem.PerformClick();
        }

        // used to make method accesable in other form
        public void dontSaveClick()
        {
            mainTextArea.Clear();
            fileChanged = false;
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



    }
}
