using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO; // to save to file
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Lab1
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            // acquire the available COM ports and deposit them in a ComboBox
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());
            if (comboBox1.Items.Count == 0)
                comboBox1.Text = "No COM ports!";
            else
                comboBox1.SelectedIndex = 0;
        }

        // to display Serial Bytes to Read
        int serialBytesToRead = 0;

        // to temporarily hold incoming serial data
        string serialDataString = "";

        // store each new data byte in a ConcurrentQueue instead of a string
        ConcurrentQueue<Int32> dataQueue = new ConcurrentQueue<Int32>();

        // store Ax, Ay, Az values in ConcurrentQueues
        ConcurrentQueue<Int32> ax = new ConcurrentQueue<Int32>();
        ConcurrentQueue<Int32> ay = new ConcurrentQueue<Int32>();
        ConcurrentQueue<Int32> az = new ConcurrentQueue<Int32>();

        // StreamWriter object for output file
        StreamWriter outputFile;

        int axVal = 127;
        int ayVal = 127;
        int azVal = 127;

        int axOld = 127;
        int ayOld = 127;
        int azOld = 127;

        // (Max - Min) in the Ax, Ay, Az queue
        int axPeak = 0;
        int ayPeak = 0;
        int azPeak = 0;

        // keep track of which guesture is detected
        bool ges1 = false;
        bool ges2 = false;
        bool ges3 = false;

        bool prevGes1 = false;
        bool prevGes2 = false; 
        bool prevGes3 = false;


        // STATES: 0 = READY
        //         3 = +X +Y +Z
        //         2 = +X +Z
        //         1 = +X
        int state = 0;    // internal state variable   
        int stateUI = 0;  // to display on UI
		int counter = 0;
        int prevState = 0;

        // parameters for state machine
        int threshX = 60;           // threshold to trigger state machine
        int threshY = 70;
        int threshZ = 50;
         
                                    // for the max difference in accerelation over the last numDataPts datapoints
                                    // need to exceed gravity (~25) and random minor motion
        int numDataPts = 10;        // number of data points to analyze
                                    // must be greater than 0
        double percentExceed1 = 1.4; // try to prevent false positive detection for gesture 1
        double percentExceed2 = 1.0; // try to prevent false positive detection for gesture 2
                                     // % the axis in question must exceed the other axis/axes by
                                     // in order for a gesture to be detected
        int numConsecutivePts = 7;  // number of consecutive datapoints that fit a certain gesture
                                    // eg. 5 data points must be detected as a certain gesture
                                    //     in order for that gesture to be displayed on the UI

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
            serialBytesToRead = serialPort1.BytesToRead;
            bytesToRead = serialBytesToRead;

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
            //if (serialPort1.IsOpen)
            //    textBoxBytesToRead.Text = serialPort1.BytesToRead.ToString();
            textBoxBytesToRead.Text = serialBytesToRead.ToString();
            textBoxTempStringLength.Text = serialDataString.Length.ToString();
            textBoxItemsInQueue.Text = dataQueue.Count.ToString();
            textBoxSerialDataStream.Clear();
            textBoxOrientation.Clear();


            // display the contents of dataQueue in textBoxSerialDataStream
            Int32 dequeuedItem = 0;

            // for parsing the accelerometer data stream into Ax, Ay, Az
            bool nextIsAx = false;
            bool nextIsAy = false;
            bool nextIsAz = false;

            // orientation of the MSP430EXP PCB
            string orientation = ""; // TODO could use a buffer of 10 to be less sensitive

            foreach (Int32 item in dataQueue)
            {
                if (dataQueue.TryDequeue(out dequeuedItem)) // in case of collision btn threads
                {
                    textBoxSerialDataStream.AppendText($"{dequeuedItem.ToString()}, ");

                    // parse the accelerometer data stream into Ax, Ay, Az
                    // display in textboxes and store in respective queues
                    if (dequeuedItem == 255)
                    {
                        nextIsAx = true;
                        orientation = "";
                    }
                    else if (nextIsAx)
                    {
                        axVal = dequeuedItem;
                        ax.Enqueue(dequeuedItem);
                        textBoxAx.Text = dequeuedItem.ToString();
                        nextIsAy = true;
                        nextIsAx = false;
                    }
                    else if (nextIsAy)
                    {
                        ayVal = dequeuedItem;
                        ay.Enqueue(dequeuedItem);
                        textBoxAy.Text = dequeuedItem.ToString();
                        nextIsAz = true;
                        nextIsAy = false;
                    }
                    else if (nextIsAz)
                    {
                        azVal = dequeuedItem;
                        az.Enqueue(dequeuedItem);
                        textBoxAz.Text = dequeuedItem.ToString();
                        nextIsAz = false;
                        if (checkBoxSavetofile.Checked)
                        {
                            outputFile.Write($"{axVal.ToString()}, {ayVal.ToString()}, {azVal.ToString()}, {DateTime.Now.ToLongTimeString()}\n");
                        }

                        // if there are enough data points to analyze, call state machine
                        if (ax.Count() >= numDataPts)
                        {

                            // analyze the last numDataPts Ax, Ay, Az values
                            // delete the oldest data point
                            ax.TryDequeue(out axOld);
                            ay.TryDequeue(out ayOld);
                            az.TryDequeue(out azOld);

                            // calculate the peak difference in acceleration over the last numDataPts
                            axPeak = ax.Max() - ax.Min();
                            ayPeak = ay.Max() - ay.Min();
                            azPeak = az.Max() - az.Min();

                            state_machine();
                        }
                    }
                }
            }
            serialDataString = "";


            // determine orientation of the MSP430EXP PCB and display orientation in textbox
            // x orientation
            if (axVal >= 127) 
            {
                orientation = orientation + "+x, ";
            }
            else
            {
                orientation = orientation + "-x, ";
            }

            // y orientation
            if (ayVal >= 127)
            {
                orientation = orientation + "+y, ";
            }
            else
            {
                orientation = orientation + "-y, ";
            }

            // z orientation
            if (azVal >= 127)
            {
                orientation = orientation + "+z";
            }
            else
            {
                orientation = orientation + "-z";
            }

            // display orientation in textbox
            textBoxOrientation.Text = orientation;            
        }

        // close serial port
        private void Form6_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Dispose();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void buttonFilename_Click(object sender, EventArgs e)
        {
            
			// file dialog		
            SaveFileDialog mydialogBox = new SaveFileDialog();
            mydialogBox.InitialDirectory = System.IO.Directory.GetCurrentDirectory(); 
            // @"exactly what's in here" // '\' is not a special char
            mydialogBox.ShowDialog();
            textBoxFileName.Text = mydialogBox.FileName.ToString() + ".csv";
        }

        private void checkBoxSavetofile_CheckedChanged(object sender, EventArgs e)
        {

            if (textBoxFileName.Text == "")
            {
                textBoxFileName.Text = "result.csv";
            }

            // save data to CSV file if asked
            if (checkBoxSavetofile.Checked)
            {
                outputFile = new StreamWriter(textBoxFileName.Text); // saves to bin\Debug\

                //while (ax.TryDequeue(out tempAx) && ay.TryDequeue(out tempAy) && az.TryDequeue(out tempAz))
                //{
                //    outputFile.WriteLine($"{tempAx.ToString()}, {tempAy.ToString()}, {tempAz.ToString()}, {now.ToLongTimeString()}");
                //}
            }
            else
            { 
                outputFile.Close();

                // // optional: show a message box indicating data is save to file
                // MessageBox.Show($"saved data to {textBoxFileName.Text}");
            }
        }

        private void state_machine()
        {
            // state machine
            prevState = state;

            if ((axPeak >= threshX) && (ayPeak >= threshY) && (azPeak >= threshZ))
            {
                // Gesture 3 Right-hook (+X +Y +Z)
                state = 3;
                if (prevState == 3)
                {
                    counter++;
                }
                else
                {
                    counter = 0;
                }
            }
            else if ((axPeak >= threshX) && (azPeak >= threshZ) && (axPeak > ayPeak * percentExceed2) && (azPeak > ayPeak * percentExceed2))
            {
                // Gesture 2 High punch (+X +Z)
                state = 2;
                if (prevState == 2)
                {
                    counter++;
                }
                else
                {
                    counter = 0;
                }
            }
            else if ((axPeak >= threshX) && (axPeak > ayPeak * percentExceed1) && (axPeak > azPeak * percentExceed1))
            {
                // Gesture 1 Simple punch (+X)
                state = 1;
                if (prevState == 1)
                {
                    counter++;
                }
                else
                {
                    counter = 0;
                }
            }
            else
            {
                // no gesture detected
                state = 0;
                counter = 0;
            }


            // refresh state if gesture detected/undetected
            if ((state == 0) || (counter >= numConsecutivePts))
            {
                stateUI = state;
            }

            textBoxState.Text = stateUI.ToString();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {

        }
    }
}
