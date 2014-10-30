namespace AssemblerStudioDevelop
{
    partial class ChildForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChildForm));
            AssemblerStudioDevelop.SyntaxSettings syntaxSettings1 = new AssemblerStudioDevelop.SyntaxSettings();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.syntaxRichTextBox1 = new AssemblerStudioDevelop.SyntaxRichTextBox();
            this.SuspendLayout();
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Document = this.printDocument1;
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.ShowIcon = false;
            this.printPreviewDialog1.Visible = false;
            // 
            // printDocument1
            // 
            this.printDocument1.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.OnBeginPrint);
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.OnPrintPage);
            // 
            // printDialog1
            // 
            this.printDialog1.Document = this.printDocument1;
            // 
            // pageSetupDialog1
            // 
            this.pageSetupDialog1.Document = this.printDocument1;
            // 
            // syntaxRichTextBox1
            // 
            this.syntaxRichTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.syntaxRichTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.syntaxRichTextBox1.EnableAutoDragDrop = true;
            this.syntaxRichTextBox1.Font = new System.Drawing.Font("Consolas", 11.25F);
            this.syntaxRichTextBox1.Location = new System.Drawing.Point(0, 0);
            this.syntaxRichTextBox1.Name = "syntaxRichTextBox1";
            syntaxSettings1.Comment = "";
            syntaxSettings1.CommentColor = System.Drawing.Color.Green;
            syntaxSettings1.EnableComments = true;
            syntaxSettings1.EnableIntegers = true;
            syntaxSettings1.EnableRegisters = true;
            syntaxSettings1.EnableSpecialInstructions = true;
            syntaxSettings1.EnableStrings = true;
            syntaxSettings1.IntegerColor = System.Drawing.Color.Red;
            syntaxSettings1.KeywordColor = System.Drawing.Color.Empty;
            syntaxSettings1.Keywords = ((System.Collections.Generic.List<string>)(resources.GetObject("syntaxSettings1.Keywords")));
            syntaxSettings1.RegistersColor = System.Drawing.Color.SlateBlue;
            syntaxSettings1.SpecialInstructionsColor = System.Drawing.Color.Gray;
            syntaxSettings1.StringColor = System.Drawing.Color.Gray;
            this.syntaxRichTextBox1.Settings = syntaxSettings1;
            this.syntaxRichTextBox1.ShortcutsEnabled = false;
            this.syntaxRichTextBox1.Size = new System.Drawing.Size(284, 262);
            this.syntaxRichTextBox1.TabIndex = 0;
            this.syntaxRichTextBox1.Text = "";
            this.syntaxRichTextBox1.SelectionChanged += new System.EventHandler(this.syntaxRichTextBox1_SelectionChanged);
            // 
            // ChildForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.syntaxRichTextBox1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ChildForm";
            this.Text = "ChildForm";
            this.Activated += new System.EventHandler(this.ChildForm_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChildForm_FormClosing);
            this.Load += new System.EventHandler(this.ChildForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public SyntaxRichTextBox syntaxRichTextBox1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;


    }
}