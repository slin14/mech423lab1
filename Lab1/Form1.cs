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
    public partial class Form1 : Form
    {
        int mouseX = 0;
        int mouseY = 0;

        string recordedClicks = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        // when MouseMove is called, use e to aquire the mouse pointer position in PictureBox
        // show them in the appropriate textboxes
        private void pictureBoxMouseMove(object sender, MouseEventArgs e)
        {
            textBox1.Text = e.X.ToString();
            textBox2.Text = e.Y.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        // when MouseClick is called, aquire the mouse position
        // construct a string of the mouse position and end-of-line character
        // add this string to the Textbox
        private void PictureBoxMouseClick(object sender, MouseEventArgs e)
        {
            textBox3.AppendText($"({e.X},{e.Y})\r\n");
        }
    }
}
