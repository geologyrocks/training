namespace AsyncDelegates
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
            this.lstResults = new System.Windows.Forms.ListBox();
            this.btnCountFactors = new System.Windows.Forms.Button();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lstResults
            // 
            this.lstResults.Location = new System.Drawing.Point(14, 81);
            this.lstResults.Name = "lstResults";
            this.lstResults.Size = new System.Drawing.Size(496, 160);
            this.lstResults.TabIndex = 15;
            // 
            // btnCountFactors
            // 
            this.btnCountFactors.Location = new System.Drawing.Point(242, 11);
            this.btnCountFactors.Name = "btnCountFactors";
            this.btnCountFactors.Size = new System.Drawing.Size(96, 24);
            this.btnCountFactors.TabIndex = 14;
            this.btnCountFactors.Text = "Count Factors";
            this.btnCountFactors.Click += new System.EventHandler(this.btnCountFactors_Click);
            // 
            // txtNumber
            // 
            this.txtNumber.Location = new System.Drawing.Point(132, 14);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(104, 20);
            this.txtNumber.TabIndex = 13;
            // 
            // Label1
            // 
            this.Label1.Location = new System.Drawing.Point(14, 17);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(123, 16);
            this.Label1.TabIndex = 12;
            this.Label1.Text = "Please enter a number";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 254);
            this.Controls.Add(this.lstResults);
            this.Controls.Add(this.btnCountFactors);
            this.Controls.Add(this.txtNumber);
            this.Controls.Add(this.Label1);
            this.Name = "MainForm";
            this.Text = "Asynchronous delegates (callback result)";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ListBox lstResults;
        internal System.Windows.Forms.Button btnCountFactors;
        internal System.Windows.Forms.TextBox txtNumber;
        internal System.Windows.Forms.Label Label1;
    }
}

