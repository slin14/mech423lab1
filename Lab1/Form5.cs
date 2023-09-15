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

        int state = 0;      // 0 = READY, 3 = +X +Y +Z, 2 = +X +Z, 1 = +X
		int counter = 0;

		// parameters for state machine
		int thresh = 60;            // threshold to trigger state machine 
                                    // for the max difference in accerelation over the last numDataPts datapoints
                                    // need to exceed gravity (~25) and random minor motion
        int numDataPts = 5;         // number of data points to analyze
                                    // must be greater than 0
        double percentExceed = 1.4; // try to prevent false positive detection for gestures 1 and 2
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

                     if ((axPeak >= thresh) && (ayPeak >= thresh) && (azPeak >= thresh))
                    {
                        // Gesture 3 Right-hook (+X +Y +Z)
                        state = 3;
                    }
                    else if ((axPeak >= thresh) && (azPeak >= thresh) && (axPeak > ayPeak*percentExceed) && (azPeak > ayPeak* percentExceed))
                    {
                        // Gesture 2 High punch (+X +Z)
                        state = 2;
                    }
                    else if ((axPeak >= thresh) && (axPeak > ayPeak*percentExceed) && (axPeak > azPeak*percentExceed))
                    {
                        // Gesture 1 Simple punch (+X)
                        state = 1;
                    }
                    else
                    {
                        // no gesture detected
                        state = 0;
                    }
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
                
                // display data history
				textBoxState.Text = state.ToString();
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
            }
            else
            {
                //close the file
                sr.Close();
            }
            
        }
    }
}
