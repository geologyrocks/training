using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleDelegates
{
    public partial class MainForm : Form
    {
        // Define a delegate type.
        delegate double TrigOp(double radians);

        public MainForm()
        {
            InitializeComponent();
        }

        private void btnSin_Click(object sender, EventArgs e)
        {
            TrigOp op = Math.Sin;    // Or if you prefer:  new TrigOp(Math.Sin);
            MyPerformOp(op);

            // You can also not mention the delegate object at all....
            // MyPerformOp(Math.Sin);
        }

        private void btnCos_Click(object sender, EventArgs e)
        {
            TrigOp op = Math.Cos;
            MyPerformOp(op);
        }

        private void btnTan_Click(object sender, EventArgs e)
        {
            TrigOp op = Math.Tan;
            MyPerformOp(op);
        }

        // Perform the operation indicated by "op"
        private void MyPerformOp(TrigOp op)
        {
            // Test if the text box is empty
            if (this.txtDegrees.Text.Length == 0)
            {
                // Display error message 
                MessageBox.Show(
                    "Please enter an angle.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Set input focus to the text field	
                this.txtDegrees.Focus();

                // Return immediately
                return;
            }

            // Get the angle entered in the text field
            double degrees = 0.0;
            try
            {
                degrees = double.Parse(this.txtDegrees.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show(
                    "Please enter a NUMBER!!!!!!!!!!.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Set input focus to the text field	
                this.txtDegrees.Focus();

                // Return immediately
                return;
            }

            // Convert the angle from degrees into radians
            double radians = (degrees / 360) * 2 * Math.PI;

            // Invoke function specified by the "op" delegate
            double result = op(radians);

            // This syntax also works:
            // double result = op.Invoke(radians);

            // Round result to 4 figures, and display it
            result = Math.Round(result, 4);
            MessageBox.Show(result.ToString(), "Result");

            // Clear text field, and return focus
            this.txtDegrees.Clear();
            this.txtDegrees.Focus();
        }
    }
}
