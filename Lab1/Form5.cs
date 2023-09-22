using System;
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
using System.Text.RegularExpressions; // regex
using static System.Net.Mime.MediaTypeNames;
using System.Linq.Expressions;

namespace Lab1
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        StreamReader sr;
        string fileLine;
        Regex regex = new Regex(@"(?<ax>.*),\s*(?<ay>.*),\s*(?<az>.*),.*");

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
        int count = 0;
        int detect = 0;
        int show = 0;

        // counter expire thresholds
        int countThresh = 50;
        int detectThresh = 5;
        int showThresh = 20;

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

        // store the last numDataPts Ax, Ay, Az values
        ConcurrentQueue<Int32> ax = new ConcurrentQueue<Int32>();
        ConcurrentQueue<Int32> ay = new ConcurrentQueue<Int32>();
        ConcurrentQueue<Int32> az = new ConcurrentQueue<Int32>();

        // feed current values of Ax, Ay, Az into state machine
        private void buttonProcess_Click(object sender, EventArgs e)
        {
            if (Int32.TryParse(textBoxAx.Text, out axVal) && Int32.TryParse(textBoxAy.Text, out ayVal) && Int32.TryParse(textBoxAz.Text, out azVal))
            {
                // analyze the last numDataPts Ax, Ay, Az values
                
                // have enough data points to analyze?
                if (ax.Count() >= numDataPts) // yes, have enough data points to analyze
                {
                    // delete the oldest data point
                    ax.TryDequeue(out axOld);
                    ay.TryDequeue(out ayOld);
                    az.TryDequeue(out azOld);

                    // store the new data point
                    ax.Enqueue(axVal);
                    ay.Enqueue(ayVal);
                    az.Enqueue(azVal);

                    // calculate the peak difference in acceleration over the last numDataPts
                    axPeak = ax.Max() - ax.Min();
                    ayPeak = ay.Max() - ay.Min();
                    azPeak = az.Max() - az.Min();

                    // update state variable
                    state_machine_control();
                    textBoxState.Text = state.ToString();

                    // update other variable according to the current state
                    state_machine_update();
                    textBoxGesture.Text = gesture.ToString();

                }
                else // no, don't have enough data points to analyze
                {
                    // store the new data point
                    ax.Enqueue(axVal);
                    ay.Enqueue(ayVal);
                    az.Enqueue(azVal);

                    // can't perform analysis yet
                    state = 0;
                }

                textBoxState.Text = state.ToString();
                // display data history
                textBoxDataHistory.AppendText($"({axVal}, {ayVal}, {azVal}, {state}), ");

                if (checkBoxReadFromFile.Checked)
                {
                    // display the next data point from file
                    fileLine = sr.ReadLine();
                    if ((fileLine != null))
                    {
                        //Parse line using regex
                        Match match = regex.Match(fileLine);
                        if (match.Success)
                        {
                            textBoxAx.Text = match.Groups["ax"].Value;
                            textBoxAy.Text = match.Groups["ay"].Value;
                            textBoxAz.Text = match.Groups["az"].Value;
                        }
                    }
                    else
                    {
                        MessageBox.Show("reached end of file!");
                    }
                }
            }
            else // invalid data
            {
                MessageBox.Show("Invalid Data Point format (must be int)");
            }

            // display for debug
            textBoxAxPeak.Text = axPeak.ToString();
            textBoxAyPeak.Text = ayPeak.ToString();
            textBoxAzPeak.Text = azPeak.ToString();
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

            // initialize file name to read from
            textBoxFileName.Text = "result.csv";
        }

        private void buttonFilename_Click(object sender, EventArgs e)
        {
            // file dialog		
            OpenFileDialog mydialogBox = new OpenFileDialog();
            mydialogBox.InitialDirectory = System.IO.Directory.GetCurrentDirectory();
            // @"exactly what's in here" // '\' is not a special char
            mydialogBox.ShowDialog();
            textBoxFileName.Text = mydialogBox.FileName.ToString();
        }

        private void checkBoxReadFromFile_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxReadFromFile.Checked)
            {
                try
                {
                    //Pass the file path and file name to the StreamReader constructor
                    sr = new StreamReader(textBoxFileName.Text);
                    //Read the first line of text
                    fileLine = sr.ReadLine();
                    //Parse line using regex
                    Match match = regex.Match(fileLine);
                    if (match.Success)
                    {
                        textBoxAx.Text = match.Groups["ax"].Value;
                        textBoxAy.Text = match.Groups["ay"].Value;
                        textBoxAz.Text = match.Groups["az"].Value;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error opening file {textBoxFileName.Text}, or no file provided.\n" + ex.Message);
                }

                // empty data
                textBoxDataHistory.Clear();
                foreach (Int32 item in ax)
                {
                    ax.TryDequeue(out axOld);
                    ay.TryDequeue(out ayOld);
                    az.TryDequeue(out azOld);
                }
            }
            else
            {
                //close the file
                sr.Close();
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
                    state = 0;
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
                    state = 0;
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
            else
            { // includes (state == 0)
                count = 0;
                gesture = 0;
                show = 0;
                detect = 0;
            }
        }
    }
}
