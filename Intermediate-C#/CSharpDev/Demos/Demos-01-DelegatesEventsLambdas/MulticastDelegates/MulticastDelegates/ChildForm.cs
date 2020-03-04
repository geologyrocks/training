using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MulticastDelegates
{
    public partial class ChildForm : Form
    {
        public ChildForm()
        {
            InitializeComponent();
        }

        private void ChildForm_Load(object sender, EventArgs e)
        {
            // Display the date-and-time of creation, in the caption bar
            this.Text = $"Created {DateTime.Now.ToLongTimeString()}";
        }

        // This method will be called via multicast delegate in main form.
        public string Repaint(Color theColor)
        {
            // Set the color for this form, and update the caption bar
            this.BackColor = theColor;
            this.Text = $"Updated {DateTime.Now.ToLongTimeString()}";
            return this.Text;
        }

        /// Handle the Closing event for this form.
        private void ChildForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Tell the main form we are closing, so the main form can 
            // remove us from its multicast delegate.
            MainForm MyOwner = (MainForm)this.Owner;
            MyOwner.ChildFormClosing(this);
        }
    }
}
