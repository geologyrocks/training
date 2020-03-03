namespace MulticastDelegates
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
            this.sbStatus = new System.Windows.Forms.StatusBar();
            this.btnColors = new System.Windows.Forms.Button();
            this.btnAddWindow = new System.Windows.Forms.Button();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.txtTop = new System.Windows.Forms.TextBox();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.txtLeft = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // sbStatus
            // 
            this.sbStatus.Location = new System.Drawing.Point(0, 82);
            this.sbStatus.Name = "sbStatus";
            this.sbStatus.Size = new System.Drawing.Size(402, 22);
            this.sbStatus.SizingGrip = false;
            this.sbStatus.TabIndex = 44;
            // 
            // btnColors
            // 
            this.btnColors.Location = new System.Drawing.Point(216, 36);
            this.btnColors.Name = "btnColors";
            this.btnColors.Size = new System.Drawing.Size(96, 24);
            this.btnColors.TabIndex = 43;
            this.btnColors.Text = "Change Colors";
            this.btnColors.Click += new System.EventHandler(this.btnColors_Click);
            // 
            // btnAddWindow
            // 
            this.btnAddWindow.Location = new System.Drawing.Point(216, 4);
            this.btnAddWindow.Name = "btnAddWindow";
            this.btnAddWindow.Size = new System.Drawing.Size(96, 24);
            this.btnAddWindow.TabIndex = 42;
            this.btnAddWindow.Text = "Add Window";
            this.btnAddWindow.Click += new System.EventHandler(this.btnAddWindow_Click);
            // 
            // txtHeight
            // 
            this.txtHeight.Location = new System.Drawing.Point(145, 36);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(43, 20);
            this.txtHeight.TabIndex = 41;
            // 
            // txtTop
            // 
            this.txtTop.Location = new System.Drawing.Point(145, 4);
            this.txtTop.Name = "txtTop";
            this.txtTop.Size = new System.Drawing.Size(43, 20);
            this.txtTop.TabIndex = 37;
            // 
            // txtWidth
            // 
            this.txtWidth.Location = new System.Drawing.Point(48, 36);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(43, 20);
            this.txtWidth.TabIndex = 39;
            // 
            // txtLeft
            // 
            this.txtLeft.Location = new System.Drawing.Point(48, 4);
            this.txtLeft.Name = "txtLeft";
            this.txtLeft.Size = new System.Drawing.Size(43, 20);
            this.txtLeft.TabIndex = 35;
            // 
            // Label4
            // 
            this.Label4.Location = new System.Drawing.Point(104, 39);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(38, 16);
            this.Label4.TabIndex = 40;
            this.Label4.Text = "Height";
            // 
            // Label3
            // 
            this.Label3.Location = new System.Drawing.Point(104, 7);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(29, 16);
            this.Label3.TabIndex = 36;
            this.Label3.Text = "Top";
            // 
            // Label2
            // 
            this.Label2.Location = new System.Drawing.Point(8, 39);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(37, 16);
            this.Label2.TabIndex = 38;
            this.Label2.Text = "Width";
            // 
            // Label1
            // 
            this.Label1.Location = new System.Drawing.Point(8, 7);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(40, 16);
            this.Label1.TabIndex = 34;
            this.Label1.Text = "Left";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 104);
            this.Controls.Add(this.sbStatus);
            this.Controls.Add(this.btnColors);
            this.Controls.Add(this.btnAddWindow);
            this.Controls.Add(this.txtHeight);
            this.Controls.Add(this.txtTop);
            this.Controls.Add(this.txtWidth);
            this.Controls.Add(this.txtLeft);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Name = "MainForm";
            this.Text = "Multicast delegates example";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.StatusBar sbStatus;
        internal System.Windows.Forms.Button btnColors;
        internal System.Windows.Forms.Button btnAddWindow;
        internal System.Windows.Forms.TextBox txtHeight;
        internal System.Windows.Forms.TextBox txtTop;
        internal System.Windows.Forms.TextBox txtWidth;
        internal System.Windows.Forms.TextBox txtLeft;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
    }
}

