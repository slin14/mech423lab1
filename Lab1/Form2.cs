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
    public partial class Form2 : Form
    {
        Queue<Int32> dataQueue = new Queue<Int32>();

        public Form2()
        {
            InitializeComponent();
            timer1.Start();
        }

        // enqueue values from the Textbox into dataQueue
        private void button1_Click(object sender, EventArgs e)
        {
            dataQueue.Enqueue(Convert.ToInt32(textBox1.Text)); // Convert.ToInt32 converts strings to Int
        }

        // dequeue and average first N data points
        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        // display the contents of dataQueue in the large multi-line Textbox
        private void UpdateQueue()
        {
            textBox6.Clear();
            foreach (Int32 item in dataQueue)
            {
                textBox6.AppendText($"{item.ToString()}, ");
            }
        }

        // dequeue values from dataQueue
        // if dataQueue is empty, show a MessageBox to provide user with an error message
        private void button2_Click(object sender, EventArgs e)
        {
            if (dataQueue.Count > 0)
            {
                dataQueue.Dequeue();
            }
            else
            {
                MessageBox.Show("Error: queue is empty");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateQueue();
        }
    }
}
