namespace DoenaSoft.BlogFormatter
{
    partial class MainForm
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
            if(disposing && (components != null))
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ProcessButton = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.InputTextBox = new System.Windows.Forms.TextBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.OutputTextBox = new System.Windows.Forms.TextBox();
            this.KeywordsTextBox = new System.Windows.Forms.TextBox();
            this.CopyOutputButton = new System.Windows.Forms.Button();
            this.CopyKeywordsButton = new System.Windows.Forms.Button();
            this.ClearInputButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ProcessButton
            // 
            this.ProcessButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ProcessButton.Location = new System.Drawing.Point(507, 393);
            this.ProcessButton.Name = "ProcessButton";
            this.ProcessButton.Size = new System.Drawing.Size(75, 23);
            this.ProcessButton.TabIndex = 0;
            this.ProcessButton.Text = "Process";
            this.ProcessButton.UseVisualStyleBackColor = true;
            this.ProcessButton.Click += new System.EventHandler(this.OnProcessButtonClick);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 12);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.InputTextBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(786, 375);
            this.splitContainer1.SplitterDistance = 382;
            this.splitContainer1.TabIndex = 1;
            // 
            // InputTextBox
            // 
            this.InputTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InputTextBox.Location = new System.Drawing.Point(3, 3);
            this.InputTextBox.Multiline = true;
            this.InputTextBox.Name = "InputTextBox";
            this.InputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.InputTextBox.Size = new System.Drawing.Size(376, 369);
            this.InputTextBox.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.OutputTextBox);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.KeywordsTextBox);
            this.splitContainer2.Size = new System.Drawing.Size(400, 375);
            this.splitContainer2.SplitterDistance = 286;
            this.splitContainer2.TabIndex = 0;
            // 
            // OutputTextBox
            // 
            this.OutputTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OutputTextBox.Location = new System.Drawing.Point(3, 3);
            this.OutputTextBox.Multiline = true;
            this.OutputTextBox.Name = "OutputTextBox";
            this.OutputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.OutputTextBox.Size = new System.Drawing.Size(394, 280);
            this.OutputTextBox.TabIndex = 2;
            // 
            // KeywordsTextBox
            // 
            this.KeywordsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.KeywordsTextBox.Location = new System.Drawing.Point(0, 3);
            this.KeywordsTextBox.Multiline = true;
            this.KeywordsTextBox.Name = "KeywordsTextBox";
            this.KeywordsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.KeywordsTextBox.Size = new System.Drawing.Size(394, 79);
            this.KeywordsTextBox.TabIndex = 3;
            // 
            // CopyOutputButton
            // 
            this.CopyOutputButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CopyOutputButton.Location = new System.Drawing.Point(588, 393);
            this.CopyOutputButton.Name = "CopyOutputButton";
            this.CopyOutputButton.Size = new System.Drawing.Size(101, 23);
            this.CopyOutputButton.TabIndex = 2;
            this.CopyOutputButton.Text = "Copy Upper Right";
            this.CopyOutputButton.UseVisualStyleBackColor = true;
            this.CopyOutputButton.Click += new System.EventHandler(this.OnCopyOutputButtonClick);
            // 
            // CopyKeywordsButton
            // 
            this.CopyKeywordsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CopyKeywordsButton.Location = new System.Drawing.Point(695, 393);
            this.CopyKeywordsButton.Name = "CopyKeywordsButton";
            this.CopyKeywordsButton.Size = new System.Drawing.Size(103, 23);
            this.CopyKeywordsButton.TabIndex = 3;
            this.CopyKeywordsButton.Text = "Copy Lower Right";
            this.CopyKeywordsButton.UseVisualStyleBackColor = true;
            this.CopyKeywordsButton.Click += new System.EventHandler(this.OnCopyKewordsButtonClick);
            // 
            // ClearInputButton
            // 
            this.ClearInputButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ClearInputButton.Location = new System.Drawing.Point(12, 393);
            this.ClearInputButton.Name = "ClearInputButton";
            this.ClearInputButton.Size = new System.Drawing.Size(75, 23);
            this.ClearInputButton.TabIndex = 4;
            this.ClearInputButton.Text = "Clear Left";
            this.ClearInputButton.UseVisualStyleBackColor = true;
            this.ClearInputButton.Click += new System.EventHandler(this.OnClearInputButtonClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 428);
            this.Controls.Add(this.ClearInputButton);
            this.Controls.Add(this.CopyKeywordsButton);
            this.Controls.Add(this.CopyOutputButton);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.ProcessButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "BlogFormatter";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ProcessButton;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox InputTextBox;
        private System.Windows.Forms.Button CopyOutputButton;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TextBox OutputTextBox;
        private System.Windows.Forms.TextBox KeywordsTextBox;
        private System.Windows.Forms.Button CopyKeywordsButton;
        private System.Windows.Forms.Button ClearInputButton;
    }
}