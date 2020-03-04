using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Threading;

namespace StopWatch
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        protected DateTime mStarted;
        protected Thread mThread = null;
        protected TimeSpan mTotalElapsed = new TimeSpan(0);

        private void btnStart_Click(object sender, EventArgs e)
        {
            this.btnStart.Enabled = false;
            this.btnStop.Enabled = true;
            this.btnReset.Enabled = false;

            mStarted = DateTime.Now;

            ThreadStart ts = new ThreadStart(this.MyTicker);
            mThread = new Thread(ts);
            mThread.Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            mTotalElapsed += DateTime.Now - mStarted;
            if (mThread.IsAlive)
            {
                mThread.Abort();
            }

            btnStart.Enabled = true;
            btnStop.Enabled = false;
            btnReset.Enabled = true;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            btnReset.Enabled = false;

            mTotalElapsed = new TimeSpan(0);
            DisplayTimespan(mTotalElapsed);
        }

        void MyTicker()
        {
            while (true)
            {
                Thread.Sleep(1000);
                DisplayTimespan(mTotalElapsed + (DateTime.Now - mStarted));
            }
        }

        private void DisplayTimespan(TimeSpan ts)
        {
            this.lblTime.Text = $"{ts.Hours:D2}:{ts.Minutes:D2}:{ts.Seconds:D2}";
        }
    }
}