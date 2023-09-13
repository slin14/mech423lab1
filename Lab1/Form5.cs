using System;
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

        int ax = 127;
        int ay = 127;
        int az = 127;

        int axPrev = 127;
        int ayPrev = 127;
        int azPrev = 127;

        int state = 0;      // 0 = READY, 3 = +X +Y +Z, 2 = +X +Z, 1 = +X
		int counter = 0;

		// parameters for state machine
		int counterResetThresh = 2;
		int jerkThresh = 2;

        // feed current values of Ax, Ay, Az into state machine
        private void buttonProcess_Click(object sender, EventArgs e)
        {
			axPrev = ax;
			ayPrev = ay;
			azPrev = az;

            if (Int32.TryParse(textBoxAx.Text, out ax) && Int32.TryParse(textBoxAy.Text, out ay) && Int32.TryParse(textBoxAz.Text, out az))
            {
				if ((ax - axPrev >= jerkThresh) && (ay - ayPrev >= jerkThresh) && (az - azPrev >= jerkThresh)) {
					state = 3;
					counter = 0;
				}
				else if ((ax - axPrev >= jerkThresh) && (az - azPrev >= jerkThresh)) {
					state = 2;
					counter = 0;
				}
				else if ((ax - axPrev >= jerkThresh)) {
					state = 1;
					counter = 0;
				}
				else if (counter > counterResetThresh) {
					state = 0;
					counter = 0;
				}
				else {
					counter++;
				}
				textBoxState.Text = state.ToString();
            }
            else
            {
                MessageBox.Show("Invalid Data Point format (must be int)");
            }
        }
    }
}
