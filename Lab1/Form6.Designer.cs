namespace Lab1
{
    partial class Form6
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxBytesToRead = new System.Windows.Forms.TextBox();
            this.textBoxTempStringLength = new System.Windows.Forms.TextBox();
            this.textBoxItemsInQueue = new System.Windows.Forms.TextBox();
            this.textBoxSerialDataStream = new System.Windows.Forms.TextBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxAx = new System.Windows.Forms.TextBox();
            this.textBoxAy = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxAz = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxOrientation = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.buttonFilename = new System.Windows.Forms.Button();
            this.textBoxFileName = new System.Windows.Forms.TextBox();
            this.checkBoxSavetofile = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 199);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Serial Data Stream";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(5, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(188, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Serial Bytes to Read";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(5, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(184, 25);
            this.label3.TabIndex = 3;
            this.label3.Text = "Temp String Length";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(5, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(144, 25);
            this.label4.TabIndex = 4;
            this.label4.Text = "Items in Queue";
            // 
            // textBoxBytesToRead
            // 
            this.textBoxBytesToRead.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxBytesToRead.Location = new System.Drawing.Point(215, 70);
            this.textBoxBytesToRead.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxBytesToRead.Name = "textBoxBytesToRead";
            this.textBoxBytesToRead.Size = new System.Drawing.Size(187, 30);
            this.textBoxBytesToRead.TabIndex = 2;
            this.textBoxBytesToRead.TabStop = false;
            // 
            // textBoxTempStringLength
            // 
            this.textBoxTempStringLength.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTempStringLength.Location = new System.Drawing.Point(215, 107);
            this.textBoxTempStringLength.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxTempStringLength.Name = "textBoxTempStringLength";
            this.textBoxTempStringLength.Size = new System.Drawing.Size(187, 30);
            this.textBoxTempStringLength.TabIndex = 3;
            this.textBoxTempStringLength.TabStop = false;
            // 
            // textBoxItemsInQueue
            // 
            this.textBoxItemsInQueue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxItemsInQueue.Location = new System.Drawing.Point(215, 143);
            this.textBoxItemsInQueue.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxItemsInQueue.Name = "textBoxItemsInQueue";
            this.textBoxItemsInQueue.Size = new System.Drawing.Size(187, 30);
            this.textBoxItemsInQueue.TabIndex = 4;
            this.textBoxItemsInQueue.TabStop = false;
            // 
            // textBoxSerialDataStream
            // 
            this.textBoxSerialDataStream.Location = new System.Drawing.Point(11, 228);
            this.textBoxSerialDataStream.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxSerialDataStream.Multiline = true;
            this.textBoxSerialDataStream.Name = "textBoxSerialDataStream";
            this.textBoxSerialDataStream.Size = new System.Drawing.Size(408, 190);
            this.textBoxSerialDataStream.TabIndex = 6;
            this.textBoxSerialDataStream.TabStop = false;
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 11);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(193, 33);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(215, 10);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(204, 33);
            this.button2.TabIndex = 1;
            this.button2.Text = "Connect Serial";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 400;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(7, 442);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 25);
            this.label5.TabIndex = 7;
            this.label5.Text = "Ax";
            // 
            // textBoxAx
            // 
            this.textBoxAx.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxAx.Location = new System.Drawing.Point(48, 438);
            this.textBoxAx.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxAx.Name = "textBoxAx";
            this.textBoxAx.Size = new System.Drawing.Size(69, 30);
            this.textBoxAx.TabIndex = 8;
            this.textBoxAx.TabStop = false;
            // 
            // textBoxAy
            // 
            this.textBoxAy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxAy.Location = new System.Drawing.Point(195, 438);
            this.textBoxAy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxAy.Name = "textBoxAy";
            this.textBoxAy.Size = new System.Drawing.Size(69, 30);
            this.textBoxAy.TabIndex = 10;
            this.textBoxAy.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(153, 442);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 25);
            this.label6.TabIndex = 9;
            this.label6.Text = "Ay";
            // 
            // textBoxAz
            // 
            this.textBoxAz.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxAz.Location = new System.Drawing.Point(332, 438);
            this.textBoxAz.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxAz.Name = "textBoxAz";
            this.textBoxAz.Size = new System.Drawing.Size(69, 30);
            this.textBoxAz.TabIndex = 12;
            this.textBoxAz.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(291, 442);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 25);
            this.label7.TabIndex = 11;
            this.label7.Text = "Az";
            // 
            // textBoxOrientation
            // 
            this.textBoxOrientation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxOrientation.Location = new System.Drawing.Point(215, 481);
            this.textBoxOrientation.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxOrientation.Name = "textBoxOrientation";
            this.textBoxOrientation.Size = new System.Drawing.Size(187, 30);
            this.textBoxOrientation.TabIndex = 13;
            this.textBoxOrientation.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(5, 484);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(107, 25);
            this.label8.TabIndex = 14;
            this.label8.Text = "Orientation";
            // 
            // buttonFilename
            // 
            this.buttonFilename.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFilename.Location = new System.Drawing.Point(11, 574);
            this.buttonFilename.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonFilename.Name = "buttonFilename";
            this.buttonFilename.Size = new System.Drawing.Size(200, 33);
            this.buttonFilename.TabIndex = 4;
            this.buttonFilename.Text = "Select Filename";
            this.buttonFilename.UseVisualStyleBackColor = true;
            this.buttonFilename.Click += new System.EventHandler(this.buttonFilename_Click);
            // 
            // textBoxFileName
            // 
            this.textBoxFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxFileName.Location = new System.Drawing.Point(215, 575);
            this.textBoxFileName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxFileName.Name = "textBoxFileName";
            this.textBoxFileName.Size = new System.Drawing.Size(187, 30);
            this.textBoxFileName.TabIndex = 3;
            // 
            // checkBoxSavetofile
            // 
            this.checkBoxSavetofile.AutoSize = true;
            this.checkBoxSavetofile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxSavetofile.Location = new System.Drawing.Point(12, 545);
            this.checkBoxSavetofile.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxSavetofile.Name = "checkBoxSavetofile";
            this.checkBoxSavetofile.Size = new System.Drawing.Size(119, 24);
            this.checkBoxSavetofile.TabIndex = 2;
            this.checkBoxSavetofile.Text = "Save to File";
            this.checkBoxSavetofile.UseVisualStyleBackColor = true;
            this.checkBoxSavetofile.CheckedChanged += new System.EventHandler(this.checkBoxSavetofile_CheckedChanged);
            // 
            // Form6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 620);
            this.Controls.Add(this.checkBoxSavetofile);
            this.Controls.Add(this.textBoxFileName);
            this.Controls.Add(this.buttonFilename);
            this.Controls.Add(this.textBoxOrientation);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBoxAz);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxAy);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxAx);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBoxSerialDataStream);
            this.Controls.Add(this.textBoxItemsInQueue);
            this.Controls.Add(this.textBoxTempStringLength);
            this.Controls.Add(this.textBoxBytesToRead);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form6";
            this.Text = "Serial Demo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form6_FormClosing);
            this.Load += new System.EventHandler(this.Form6_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxBytesToRead;
        private System.Windows.Forms.TextBox textBoxTempStringLength;
        private System.Windows.Forms.TextBox textBoxItemsInQueue;
        private System.Windows.Forms.TextBox textBoxSerialDataStream;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxAx;
        private System.Windows.Forms.TextBox textBoxAy;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxAz;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxOrientation;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button buttonFilename;
        private System.Windows.Forms.TextBox textBoxFileName;
        private System.Windows.Forms.CheckBox checkBoxSavetofile;
    }
}
