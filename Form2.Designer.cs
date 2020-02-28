namespace textEditor
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.cancelSave = new System.Windows.Forms.Button();
            this.dontSave = new System.Windows.Forms.Button();
            this.save = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.cancelSave);
            this.panel1.Controls.Add(this.dontSave);
            this.panel1.Controls.Add(this.save);
            this.panel1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.panel1.Location = new System.Drawing.Point(0, 77);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(317, 49);
            this.panel1.TabIndex = 0;
            // 
            // cancelSave
            // 
            this.cancelSave.BackColor = System.Drawing.Color.LightGray;
            this.cancelSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cancelSave.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cancelSave.Location = new System.Drawing.Point(232, 14);
            this.cancelSave.Name = "cancelSave";
            this.cancelSave.Size = new System.Drawing.Size(75, 23);
            this.cancelSave.TabIndex = 2;
            this.cancelSave.Text = "Cancel";
            this.cancelSave.UseVisualStyleBackColor = false;
            this.cancelSave.Click += new System.EventHandler(this.button3_Click);
            // 
            // dontSave
            // 
            this.dontSave.BackColor = System.Drawing.Color.LightGray;
            this.dontSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.dontSave.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dontSave.Location = new System.Drawing.Point(151, 14);
            this.dontSave.Name = "dontSave";
            this.dontSave.Size = new System.Drawing.Size(75, 23);
            this.dontSave.TabIndex = 1;
            this.dontSave.Text = "Dont save";
            this.dontSave.UseVisualStyleBackColor = false;
            this.dontSave.Click += new System.EventHandler(this.button2_Click);
            // 
            // save
            // 
            this.save.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.save.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.save.Location = new System.Drawing.Point(70, 14);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(75, 23);
            this.save.TabIndex = 0;
            this.save.Text = "Save";
            this.save.UseVisualStyleBackColor = false;
            this.save.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(314, 126);
            this.panel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(3, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(262, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Do you want to change the saves for doc1?";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 125);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form2";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Text Editor";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Button dontSave;
        private System.Windows.Forms.Button cancelSave;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
    }
}