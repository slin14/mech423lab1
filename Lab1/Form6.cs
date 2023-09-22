using System;
using System.Collections.Concurrent;
using System.IO; // to save to file
using System.Linq;
using System.Windows.Forms;

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

        // current and previous Ax, Ay, Az values
        int axVal = 127;
        int ayVal = 127;
        int azVal = 127;

        int axOld = 127;
        int ayOld = 127;
        int azOld = 127;

        // STATES: 0 = READY
        //         1 = +X
        //         2 = GESTURE 1 (+X)
        //         3 = +X +Y
        //         4 = GESTURE 3 (+X +Y +Z)
        //         5 = +Z
        //         7 = GESTURE 2 (+Z +X)
        int state = 0;
        int prevState = 0;

        // GESTURES: 1 = +X
        //           2 = +Z, +X
        //           3 = +X, +Y, +Z
        int gesture = 0;

		// counters
		int count  = 0;
		int pause  = 0;
		int show   = 0;

		// counter expire thresholds
		int countThresh  = 50; // gesture detection expire
		int pauseThresh  = 10; // pause before detecting next sequence
		int showThresh   = 50; // gesture display expire

		// acceleration thresholds
        int accelThresh = 40;

        // nominal acceleration values
        int nomAx = 127;
        int nomAy = 127;
        int nomAz = 153; 

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

            // store previous Ax, Ay, Az values
            axOld = axVal;
            ayOld = ayVal;
            azOld = azVal;

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
                        textBoxAx.Text = dequeuedItem.ToString();
                        nextIsAy = true;
                        nextIsAx = false;
                    }
                    else if (nextIsAy)
                    {
                        ayVal = dequeuedItem;
                        textBoxAy.Text = dequeuedItem.ToString();
                        nextIsAz = true;
                        nextIsAy = false;
                    }
                    else if (nextIsAz)
                    {
                        azVal = dequeuedItem;
                        textBoxAz.Text = dequeuedItem.ToString();
                        nextIsAz = false;
                        if (checkBoxSavetofile.Checked)
                        {
                            outputFile.Write($"{axVal.ToString()}, {ayVal.ToString()}, {azVal.ToString()}, {DateTime.Now.ToLongTimeString()}\n");
                        }

                            // update state variable
                            state_machine_control();
                            textBoxState.Text = state.ToString();

                            // update other variable according to the current state
                            state_machine_update();
                            textBoxGesture.Text = gesture.ToString();

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

            // acceleration checks
            bool posX = (axVal < nomAx - accelThresh) && (axVal < axOld);
            bool negX = (axVal > nomAx + accelThresh) && (axVal > axOld);
            bool posY = (ayVal < nomAy - accelThresh) && (ayVal < ayOld);
            bool negY = (ayVal > nomAy + accelThresh) && (ayVal > ayOld);
            bool posZ = (azVal < nomAz - accelThresh) && (azVal < ayOld);
            bool negZ = (azVal > nomAz + accelThresh) && (azVal > ayOld);

            if (state == 1)
            {
                if ((pause >= pauseThresh) && posY)
                {
                    state = 3;
                    count = 0;
                    pause = 0;
                }
                else if (count >= countThresh)
                {
                    state = 2;
                }
            }
            else if (state == 2)
            {
                if (show >= showThresh)
                {
                    state = 0;
                }
            }
            else if (state == 3)
            {
                if ((pause >= pauseThresh) && posZ)
                {
                    state = 4;
                }
                else if (count >= countThresh)
                {
                    state = 0;
                }
            }
            else if (state == 4)
            {
                if (show >= showThresh) 
                {
                    state = 0;
                }
            }
            else if (state == 5)
            {
                if ((pause >= pauseThresh) && posX)
                {
                    state = 6;
                }
            }
            else if (state == 6)
            {
                if (show >= showThresh)
                {
                    state = 0;
                }
            }
            else // includes (state == 0)
            {
                if (posX)
                {
                    state = 1;
                }
                else if (posZ)
                {
                    state = 5;
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
                pause++;
                count++;
            }
            else if (state == 2)
            {
                show++;
                gesture = 1;
            }
            else if (state == 3)
            {
                pause++;
                count++;
            }
            else if (state == 4)
            {
                show++;
                gesture = 3;
            }
            else if (state == 5)
            {
                pause++;
                count++;
            }
            else if (state == 6)
            {
                show++;
                gesture = 2;
            }
            else { // includes (state == 0)
                count = 0;
                gesture = 0;
                show = 0;
                pause = 0;
            }
        }
        private void timer2_Tick(object sender, EventArgs e)
        {

        }
    }
}
