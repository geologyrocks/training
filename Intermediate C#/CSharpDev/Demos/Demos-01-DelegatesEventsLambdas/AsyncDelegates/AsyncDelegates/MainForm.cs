using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncDelegates
{
    public partial class MainForm : Form
    {
        // Define a delegate type, to specify signature of method to call.
        delegate int MyDelegate(ref int Number, out int LargestFactor);

        public MainForm()
        {
            InitializeComponent();
        }

        private void btnCountFactors_Click(object sender, EventArgs e)
        {
            // Get the number entered by the user in the text box 
            int number = int.Parse(txtNumber.Text);

            // Create delegate, for a "find factor" method
            FactorFinder aFactorFinder = new FactorFinder();
            MyDelegate theDel = aFactorFinder.MyCountFactors;

            // Create an AsyncCallback delegate, for our "callback" method
            AsyncCallback callbackDel = this.MyProcessAsyncResults;

            // Invoke the "factor finder" method asynchronously
            int temp;
            theDel.BeginInvoke(ref number,      // 1st param to MyCountFactors()
                               out temp,        // 2nd param to MyCountFactors()
                               callbackDel,     // Callback delegate 
                               DateTime.Now);   // State, accessible by callback
        }

        private void MyProcessAsyncResults(IAsyncResult ar)
        {
            // Downcast IAsyncResult interface into AsyncResult class type
            AsyncResult result = (AsyncResult)ar;

            // Get our delegate from the AsyncResult object 
            MyDelegate theDelegate = (MyDelegate)result.AsyncDelegate;

            // Get the results of the asynchronous method
            int factorCount = 0, number = 0, largestFactor = 0;
            factorCount = theDelegate.EndInvoke(ref number, out largestFactor, ar);

            // Get the "state" out of the result
            DateTime timeStarted = (DateTime)ar.AsyncState;

            // Display the results in the list box
            if (factorCount == 0)
            {
                lstResults.Items.Add($"[Calculation started {timeStarted.ToLongTimeString()}]  {number} is a prime number");
            }
            else
            {
                lstResults.Items.Add($"[Calculation started {timeStarted.ToLongTimeString()}]  {number} has {factorCount} factors, largest factor is {largestFactor}");
            }
        }
    }
}
