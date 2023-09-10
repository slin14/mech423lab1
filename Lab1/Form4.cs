﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Lab1
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            timer1.Start();
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

        // store each new data byte in a ConcurrentQueue instead of a string
        ConcurrentQueue<Int32> dataQueue = new ConcurrentQueue<Int32>();

        // acquire the COM port from the ComboBox and use it to configure the COM port on the Serialport object
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            serialPort1.PortName = comboBox1.SelectedItem.ToString();
        }

        // serial port (after it is properly configured)
        // Once the serial port is opened, the accelerometer data is automatically enabled as output
        private void button2_Click(object sender, EventArgs e)
        {
            // serialPort1.Open();

            string nameCOMPort = "";
            // check if connection is satisfied
            if (comboBox1.Text != "")
                nameCOMPort = comboBox1.Text;
            else
                MessageBox.Show("No COM Port Selected", "Error");
            // open and close port
            if (serialPort1.IsOpen)
            {
                serialPort1.Dispose();
                button2.Text = "Connect";
            }
            else if (!serialPort1.IsOpen)
            {
                serialPort1.PortName = nameCOMPort;
                serialPort1.Open();
                button2.Text = "Disconnect";
            }
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

                // Enqueue
                dataQueue.Enqueue(newByte);

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
            textBoxItemsInQueue.Text = dataQueue.Count.ToString();
            textBoxSerialDataStream.Clear();

            // display the contents of dataQueue in textBoxSerialDataStream
            Int32 dequeuedItem = 0;
            foreach (Int32 item in dataQueue)
            {
                if (dataQueue.TryDequeue(out dequeuedItem))
                {
                    textBoxSerialDataStream.AppendText($"{dequeuedItem.ToString()}, ");
                }
            }
            serialDataString = "";
        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Dispose();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
