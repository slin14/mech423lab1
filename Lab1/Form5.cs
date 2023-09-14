using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        int axVal = 127;
        int ayVal = 127;
        int azVal = 127;

        int axPrev = 127;
        int ayPrev = 127;
        int azPrev = 127;

        int state = 0;      // 0 = READY, 3 = +X +Y +Z, 2 = +X +Z, 1 = +X
		int counter = 0;

		// parameters for state machine
		int counterResetThresh = 2;
		int jerkThresh = 30; // set to 30 so it exceeds gravity (~25)

        // // store Ax, Ay, Az values in ConcurrentQueues
        // ConcurrentQueue<Int32> ax = new ConcurrentQueue<Int32>();
        // ConcurrentQueue<Int32> ay = new ConcurrentQueue<Int32>();
        // ConcurrentQueue<Int32> az = new ConcurrentQueue<Int32>();

        // feed current values of Ax, Ay, Az into state machine
        private void buttonProcess_Click(object sender, EventArgs e)
        {
			axPrev = axVal;
			ayPrev = ayVal;
			azPrev = azVal;

            if (Int32.TryParse(textBoxAx.Text, out axVal) && Int32.TryParse(textBoxAy.Text, out ayVal) && Int32.TryParse(textBoxAz.Text, out azVal))
            {
                // ax.Enqueue(axVal);
                // ay.Enqueue(ayVal);
                // az.Enqueue(azVal);

                if ((axVal - axPrev >= jerkThresh) && (ayVal - ayPrev >= jerkThresh) && (azVal - azPrev >= jerkThresh)) {
					state = 3;
					counter = 0;
				}
				else if ((axVal - axPrev >= jerkThresh) && (azVal - azPrev >= jerkThresh)) {
					state = 2;
					counter = 0;
				}
				else if ((axVal - axPrev >= jerkThresh)) {
					state = 1;
					counter = 0;
				}
				else if (counter >= counterResetThresh) {
					state = 0;
					counter = 0;
				}
				else {
					counter++;
				}
				textBoxState.Text = state.ToString();
                textBoxDataHistory.AppendText($"({axVal}, {ayVal}, {azVal}, {state}), ");
            }
            else
            {
                MessageBox.Show("Invalid Data Point format (must be int)");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            // initialize Ax Ay Az textboxes to make it more convinent
            textBoxAx.Text = "127";
            textBoxAy.Text = "127";
            textBoxAz.Text = "127";
        }
    }
}
