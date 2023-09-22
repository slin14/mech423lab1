namespace Lab1
{
    partial class Form5
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
            this.textBoxAx = new System.Windows.Forms.TextBox();
            this.textBoxAy = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxAz = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonProcess = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxDataHistory = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.checkBoxReadFromFile = new System.Windows.Forms.CheckBox();
            this.textBoxFileName = new System.Windows.Forms.TextBox();
            this.buttonFilename = new System.Windows.Forms.Button();
            this.textBoxAzPeak = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxAyPeak = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxAxPeak = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxState = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxGesture = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ax";
            // 
            // textBoxAx
            // 
            this.textBoxAx.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxAx.Location = new System.Drawing.Point(38, 14);
            this.textBoxAx.Name = "textBoxAx";
            this.textBoxAx.Size = new System.Drawing.Size(79, 30);
            this.textBoxAx.TabIndex = 0;
            // 
            // textBoxAy
            // 
            this.textBoxAy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxAy.Location = new System.Drawing.Point(165, 14);
            this.textBoxAy.Name = "textBoxAy";
            this.textBoxAy.Size = new System.Drawing.Size(79, 30);
            this.textBoxAy.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(129, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ay";
            // 
            // textBoxAz
            // 
            this.textBoxAz.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxAz.Location = new System.Drawing.Point(288, 14);
            this.textBoxAz.Name = "textBoxAz";
            this.textBoxAz.Size = new System.Drawing.Size(79, 30);
            this.textBoxAz.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(252, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "Az";
            // 
            // buttonProcess
            // 
            this.buttonProcess.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonProcess.Location = new System.Drawing.Point(9, 56);
            this.buttonProcess.Name = "buttonProcess";
            this.buttonProcess.Size = new System.Drawing.Size(358, 32);
            this.buttonProcess.TabIndex = 3;
            this.buttonProcess.Text = "Process New Data Point";
            this.buttonProcess.UseVisualStyleBackColor = true;
            this.buttonProcess.Click += new System.EventHandler(this.buttonProcess_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(4, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 25);
            this.label5.TabIndex = 9;
            this.label5.Text = "Data History";
            // 
            // textBoxDataHistory
            // 
            this.textBoxDataHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDataHistory.Location = new System.Drawing.Point(8, 157);
            this.textBoxDataHistory.Multiline = true;
            this.textBoxDataHistory.Name = "textBoxDataHistory";
            this.textBoxDataHistory.Size = new System.Drawing.Size(358, 236);
            this.textBoxDataHistory.TabIndex = 10;
            this.textBoxDataHistory.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // checkBoxReadFromFile
            // 
            this.checkBoxReadFromFile.AutoSize = true;
            this.checkBoxReadFromFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxReadFromFile.Location = new System.Drawing.Point(9, 475);
            this.checkBoxReadFromFile.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxReadFromFile.Name = "checkBoxReadFromFile";
            this.checkBoxReadFromFile.Size = new System.Drawing.Size(141, 24);
            this.checkBoxReadFromFile.TabIndex = 11;
            this.checkBoxReadFromFile.Text = "Read from File";
            this.checkBoxReadFromFile.UseVisualStyleBackColor = true;
            this.checkBoxReadFromFile.CheckedChanged += new System.EventHandler(this.checkBoxReadFromFile_CheckedChanged);
            // 
            // textBoxFileName
            // 
            this.textBoxFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxFileName.Location = new System.Drawing.Point(176, 505);
            this.textBoxFileName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxFileName.Name = "textBoxFileName";
            this.textBoxFileName.Size = new System.Drawing.Size(190, 30);
            this.textBoxFileName.TabIndex = 12;
            // 
            // buttonFilename
            // 
            this.buttonFilename.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFilename.Location = new System.Drawing.Point(8, 504);
            this.buttonFilename.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonFilename.Name = "buttonFilename";
            this.buttonFilename.Size = new System.Drawing.Size(162, 33);
            this.buttonFilename.TabIndex = 13;
            this.buttonFilename.Text = "Select Filename";
            this.buttonFilename.UseVisualStyleBackColor = true;
            this.buttonFilename.Click += new System.EventHandler(this.buttonFilename_Click);
            // 
            // textBoxAzPeak
            // 
            this.textBoxAzPeak.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxAzPeak.Location = new System.Drawing.Point(288, 436);
            this.textBoxAzPeak.Name = "textBoxAzPeak";
            this.textBoxAzPeak.Size = new System.Drawing.Size(79, 30);
            this.textBoxAzPeak.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(252, 439);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 25);
            this.label6.TabIndex = 19;
            this.label6.Text = "Az";
            // 
            // textBoxAyPeak
            // 
            this.textBoxAyPeak.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxAyPeak.Location = new System.Drawing.Point(165, 436);
            this.textBoxAyPeak.Name = "textBoxAyPeak";
            this.textBoxAyPeak.Size = new System.Drawing.Size(79, 30);
            this.textBoxAyPeak.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(129, 439);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 25);
            this.label7.TabIndex = 18;
            this.label7.Text = "Ay";
            // 
            // textBoxAxPeak
            // 
            this.textBoxAxPeak.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxAxPeak.Location = new System.Drawing.Point(38, 436);
            this.textBoxAxPeak.Name = "textBoxAxPeak";
            this.textBoxAxPeak.Size = new System.Drawing.Size(79, 30);
            this.textBoxAxPeak.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(3, 439);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 25);
            this.label8.TabIndex = 15;
            this.label8.Text = "Ax";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(5, 409);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(170, 25);
            this.label9.TabIndex = 20;
            this.label9.Text = "Peak Acceleration";
            // 
            // textBoxState
            // 
            this.textBoxState.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxState.Location = new System.Drawing.Point(71, 94);
            this.textBoxState.Name = "textBoxState";
            this.textBoxState.Size = new System.Drawing.Size(104, 30);
            this.textBoxState.TabIndex = 24;
            this.textBoxState.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(178, 99);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 25);
            this.label10.TabIndex = 23;
            this.label10.Text = "Gesture";
            // 
            // textBoxGesture
            // 
            this.textBoxGesture.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxGesture.Location = new System.Drawing.Point(261, 94);
            this.textBoxGesture.Name = "textBoxGesture";
            this.textBoxGesture.Size = new System.Drawing.Size(104, 30);
            this.textBoxGesture.TabIndex = 22;
            this.textBoxGesture.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(7, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 25);
            this.label4.TabIndex = 21;
            this.label4.Text = "State";
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 556);
            this.Controls.Add(this.textBoxState);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBoxGesture);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBoxAzPeak);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxAyPeak);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxAxPeak);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.checkBoxReadFromFile);
            this.Controls.Add(this.textBoxFileName);
            this.Controls.Add(this.buttonFilename);
            this.Controls.Add(this.textBoxDataHistory);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonProcess);
            this.Controls.Add(this.textBoxAz);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxAy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxAx);
            this.Controls.Add(this.label1);
            this.Name = "Form5";
            this.Text = "Form5";
            this.Load += new System.EventHandler(this.Form5_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxAx;
        private System.Windows.Forms.TextBox textBoxAy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxAz;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonProcess;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxDataHistory;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox checkBoxReadFromFile;
        private System.Windows.Forms.TextBox textBoxFileName;
        private System.Windows.Forms.Button buttonFilename;
        private System.Windows.Forms.TextBox textBoxAzPeak;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxAyPeak;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxAxPeak;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxState;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxGesture;
        private System.Windows.Forms.Label label4;
    }
}