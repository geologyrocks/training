using System;
using System.Drawing;
using System.Windows.Forms;

namespace MulticastDelegates
{
    public partial class MainForm : Form
    {
        // Define a Delegate type.
        delegate string MyDelegate(Color aColor);

        // Declare a MyDelegate field, to refer to the multicast delegate.
        private MyDelegate mTheDelegate;

        public MainForm()
        {
            InitializeComponent();
        }

        private void btnAddWindow_Click(object sender, EventArgs e)
        {
            // Are any text fields blank?
            if (txtLeft.Text.Length == 0 || txtTop.Text.Length == 0)
            {
                // Display an error message, and return immediately 
                MessageBox.Show("Please fill in all text boxes.", "Error adding window",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //  Create a new child form with the specified location and size.
            ChildForm aChildForm = new ChildForm();
            aChildForm.Owner = this;
            aChildForm.DesktopBounds = new Rectangle(
                                        int.Parse(txtLeft.Text),
                                        int.Parse(txtTop.Text),
                                        int.Parse(txtWidth.Text),
                                        int.Parse(txtHeight.Text));
            aChildForm.Show();

            // Create a new delegate for the child form's Repaint method.
            MyDelegate newDelegate = aChildForm.Repaint;

            // If multicast delegate is null, this is the first child form.
            if (mTheDelegate == null)
            {
                // Use new delegate as the basis for the multicast delegate.
                mTheDelegate = newDelegate;
                sbStatus.Text = "Created first child form.";
            }
            else
            {
                // Combine new delegate into the multicast delegate.
                // Equivalent to: mTheDelegate = Delegate.Combine(mTheDelegate, newDelegate);
                mTheDelegate += newDelegate;

                // Use multicast delegate to count the child forms. 
                sbStatus.Text = $"Created child form {mTheDelegate.GetInvocationList().Length}.";
            }
        }

        private void btnColors_Click(object sender, EventArgs e)
        {
            // If multicast delegate is null, there are no child forms.
            if (mTheDelegate == null)
            {
                MessageBox.Show("There are no child forms to change.",
                    "Error changing color",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // Ask user to choose a color.
                ColorDialog dlgColor = new ColorDialog();
                dlgColor.ShowDialog();

                // Invoke multicast delegate, to repaint all the child forms.
                mTheDelegate(dlgColor.Color);

                // Use multicast delegate to count the child forms. 
                sbStatus.Text = $"Updated {mTheDelegate.GetInvocationList().Length} child form(s).";
            }
        }

        /// Child forms call this method, to tell us they are closing.
        public void ChildFormClosing(ChildForm aChildForm)
        {
            // Create a delegate for the ChildForm that is closing.
            MyDelegate unneededDelegate = new MyDelegate(aChildForm.Repaint);

            // Remove the delegate from the multicast delegate.
            // Equivalent to: mTheDelegate = Delegate.Remove(mTheDelegate, unneededDelegate);
            mTheDelegate -= unneededDelegate;

            // If multicast delegate is null, there are no child forms left.
            if (mTheDelegate == null)
            {
                sbStatus.Text = "Final child form has been closed.";
            }
            else
            {
                // Use multicast delegate to count the child forms. 
                sbStatus.Text = $"Child form closed, {mTheDelegate.GetInvocationList().Length} form(s) remaining.";
            }
        }

    }
}
