using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            // acquire the available COM ports and deposit them in a ComboBox
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());
            if (comboBox1.Items.Count == 0)
                comboBox1.Text = "No COM ports!";
            else
                comboBox1.SelectedIndex = 0;
        }

        // to temporarily hold incoming serial data
        string serialDataString = "";

        // acquire the COM port from the ComboBox and use it to configure the COM port on the Serialport object
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            serialPort1.PortName = comboBox1.SelectedItem.ToString();
        }

        // serial port (after it is properly configured)
        // Once the serial port is opened, the accelerometer data is automatically enabled as output
        private void button2_Click(object sender, EventArgs e)
        {
            serialPort1.Open();
        }

        // DataReceived event handler for serialPort
        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            int newByte = 0;
            int bytesToRead;

            // determine the number of BytesToRead in the serial buffer
            bytesToRead = serialPort1.BytesToRead;

            // read the bytes, one at a time, from the serial buffer
            while (bytesToRead != 0)
            {
                newByte = serialPort1.ReadByte();
                // Convert each byte to a string and append it to the serialDataString with “,“ and “ “ characters
                serialDataString = serialDataString + newByte.ToString() + ", ";
                bytesToRead = serialPort1.BytesToRead;
            }
        }

        // show the number of bytes in the serial buffer
        // transfer data from serialDataString to the Serial Data Stream Textbox
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
                textBoxBytesToRead.Text = serialPort1.BytesToRead.ToString();
            textBoxTempStringLength.Text = serialDataString.Length.ToString();
            textBoxItemsInQueue.AppendText(serialDataString);
            serialDataString = "";
        }
    }
}
