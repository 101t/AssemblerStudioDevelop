namespace AssemblerStudioDevelop
{
    partial class ExecutionViewer
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
            AssemblerStudioDevelop.SyntaxSettings syntaxSettings1 = new AssemblerStudioDevelop.SyntaxSettings();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExecutionViewer));
            this.syntaxRichTextBox1 = new AssemblerStudioDevelop.SyntaxRichTextBox();
            this.SuspendLayout();
            // 
            // syntaxRichTextBox1
            // 
            this.syntaxRichTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.syntaxRichTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.syntaxRichTextBox1.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            syntaxSettings1.StringColor = System.Drawing.Color.Blue;
            this.syntaxRichTextBox1.Settings = syntaxSettings1;
            this.syntaxRichTextBox1.Size = new System.Drawing.Size(284, 262);
            this.syntaxRichTextBox1.TabIndex = 0;
            this.syntaxRichTextBox1.Text = "";
            this.syntaxRichTextBox1.SelectionChanged += new System.EventHandler(this.syntaxRichTextBox1_SelectionChanged);
            // 
            // ExecutionViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.syntaxRichTextBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ExecutionViewer";
            this.Text = "Execution Viewer";
            this.Activated += new System.EventHandler(this.ExecutionViewer_Activated);
            this.Load += new System.EventHandler(this.ExecutionViewer_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private SyntaxRichTextBox syntaxRichTextBox1;
    }
}