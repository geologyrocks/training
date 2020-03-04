namespace SimpleDelegates
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
            this.btnTan = new System.Windows.Forms.Button();
            this.btnCos = new System.Windows.Forms.Button();
            this.btnSin = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.txtDegrees = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnTan
            // 
            this.btnTan.Location = new System.Drawing.Point(180, 81);
            this.btnTan.Name = "btnTan";
            this.btnTan.Size = new System.Drawing.Size(72, 24);
            this.btnTan.TabIndex = 19;
            this.btnTan.Text = "Tan";
            this.btnTan.Click += new System.EventHandler(this.btnTan_Click);
            // 
            // btnCos
            // 
            this.btnCos.Location = new System.Drawing.Point(180, 49);
            this.btnCos.Name = "btnCos";
            this.btnCos.Size = new System.Drawing.Size(72, 24);
            this.btnCos.TabIndex = 18;
            this.btnCos.Text = "Cos";
            this.btnCos.Click += new System.EventHandler(this.btnCos_Click);
            // 
            // btnSin
            // 
            this.btnSin.Location = new System.Drawing.Point(180, 17);
            this.btnSin.Name = "btnSin";
            this.btnSin.Size = new System.Drawing.Size(72, 24);
            this.btnSin.TabIndex = 17;
            this.btnSin.Text = "Sin";
            this.btnSin.Click += new System.EventHandler(this.btnSin_Click);
            // 
            // Label1
            // 
            this.Label1.Location = new System.Drawing.Point(12, 19);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(88, 16);
            this.Label1.TabIndex = 16;
            this.Label1.Text = "Angle (degrees)";
            // 
            // txtDegrees
            // 
            this.txtDegrees.Location = new System.Drawing.Point(100, 17);
            this.txtDegrees.Name = "txtDegrees";
            this.txtDegrees.Size = new System.Drawing.Size(64, 20);
            this.txtDegrees.TabIndex = 15;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 122);
            this.Controls.Add(this.btnTan);
            this.Controls.Add(this.btnCos);
            this.Controls.Add(this.btnSin);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.txtDegrees);
            this.Name = "MainForm";
            this.Text = "Trigonometry Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTan;
        private System.Windows.Forms.Button btnCos;
        private System.Windows.Forms.Button btnSin;
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.TextBox txtDegrees;
    }
}

