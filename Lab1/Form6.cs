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

        // average of the Ax, Ay, Az queue
        double axAvg = 127;
        double ayAvg = 127;
        double azAvg = 127;

        double axAvgOld = 127;
        double ayAvgOld = 127;
        double azAvgOld = 127;

        // STATES: 0 = READY
        //         1 = DET +X
        //         2 = WAIT
        //         3 = GESTURE 1
        //         4 = DET +Y
        //         5 = WAIT
        //         6 = DET +Z
        //         7 = GESTURE 2
        //         8 = DET +Z
        //         9 = WAIT
        //        10 = DET +X
        //        11 = GESTURE 3
        int state = 0;
        int prevState = 0;

        // GESTURES: 1 = +X
        //           2 = +Z, +X
        //           3 = +X, +Y, +Z
        int gesture = 0;

		// counters
		int count  = 0;
		int detect = 0;
		int show   = 0;

		// counter expire thresholds
		int countThresh  = 50;
		int detectThresh = 5;
		int showThresh   = 20;

		// acceleration thresholds
        // for the max difference in accerelation over the last numDataPts datapoints
        // need to exceed gravity (~25) and random minor motion
        int axPeakThresh = 60;           
        int ayPeakThresh = 70;
        int azPeakThresh = 50;

        // number of data points to analyze (must be greater than 0)
        int numDataPts = 10;        

        double percentExceed1 = 1.4; // try to prevent false positive detection for gesture 1
        double percentExceed2 = 1.0; // try to prevent false positive detection for gesture 2
                                     // % the axis in question must exceed the other axis/axes by
                                     // in order for a gesture to be detected

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

                            // update the previous average
                            axAvgOld = axAvg;
                            ayAvgOld = ayAvg;
                            azAvgOld = azAvg; 

                            // calculate the peak difference in acceleration over the last numDataPts
                            axPeak = ax.Max() - ax.Min();
                            ayPeak = ay.Max() - ay.Min();
                            azPeak = az.Max() - az.Min();

                            // calcuate the average in acceleration over the last numDataPts
                            axAvg = ax.Average() / numDataPts;
                            ayAvg = ay.Average() / numDataPts;
                            azAvg = az.Average() / numDataPts;

                            // update state variable
                            state_machine_control();
                            textBoxState.Text = state.ToString();

                            // update other variable according to the current state
                            state_machine_update();
                            textBoxGesture.Text = gesture.ToString();
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

        private void state_machine_control()
        {
            // state machine
            prevState = state;

            if (state == 1)
            {
                if ((axPeak > axPeakThresh)) // +X
                {
                    if (detect < detectThresh)
                    {
                        state = 1;
                    }
                    else
                    {
                        state = 2;
                    }
                }
                else
                {
                    state = 0;
                }
            }
            else if (state == 2)
            {
                if (count < countThresh)
                {
                    state = 2;
                }
                else
                {
                    if ((ayPeak > ayPeakThresh)) // +Y
                    {
                        state = 4;
                    }
                    else
                    {
                        state = 3;
                    }
                }
            }
            else if (state == 3)
            {
                if (show < showThresh)
                {
                    state = 3;
                }
                else
                {
                    state = 4;
                }
            }
            else if (state == 4)
            {
                if ((ayPeak > ayPeakThresh)) // +Y
                {
                    if (detect < detectThresh)
                    {
                        state = 4;
                    }
                    else
                    {
                        state = 5;
                    }
                }
                else
                {
                    state = 0;
                }
            }
            else if (state == 5)
            {
                if (count > countThresh)
                {
                    state = 5;
                }
                else
                {
                    state = 6;
                }
            }
            else if (state == 6)
            {
                if ((azPeak > azPeakThresh)) // +Z
                {
                    if (detect < detectThresh)
                    {
                        state = 6;
                    }
                    else
                    {
                        state = 7;
                    }
                }
                else
                {
                    state = 0;
                }
            }
            else // includes (state == 0)
            {
                if ((axPeak > axPeakThresh)) // +X
                {
                    state = 1;
                }
                else if ((azPeak > azPeakThresh)) // +Z
                {
                    state = 8;
                }
                else
                {
                    state = 0;
                }
            }
        }

        private void state_machine_update()
        {
            if (state == 1)
            {
                detect++;
            }
            else if (state == 2)
            {
                count++;
                detect = 0;
            }
            else if (state == 3)
            {
                show++;
                gesture = 1;
            }
            else if (state == 4)
            {
                detect++;
                count = 0;
            }
            else if (state == 5)
            {
                count++;
                detect = 0;
            }
            else if (state == 6)
            {
                detect++;
                count = 0;
            }
            else if (state == 7)
            {
                show++;
                gesture = 3;
            }
            else { // includes (state == 0)
                count = 0;
                gesture = 0;
                show = 0;
                detect = 0;
            }
        }
        private void timer2_Tick(object sender, EventArgs e)
        {

        }
    }
}
