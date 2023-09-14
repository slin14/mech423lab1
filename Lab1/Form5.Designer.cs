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
            this.textBoxState = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxDataHistory = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.checkBoxReadFromFile = new System.Windows.Forms.CheckBox();
            this.textBoxFileName = new System.Windows.Forms.TextBox();
            this.buttonFilename = new System.Windows.Forms.Button();
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
            this.buttonProcess.Location = new System.Drawing.Point(9, 59);
            this.buttonProcess.Name = "buttonProcess";
            this.buttonProcess.Size = new System.Drawing.Size(358, 32);
            this.buttonProcess.TabIndex = 3;
            this.buttonProcess.Text = "Process New Data Point";
            this.buttonProcess.UseVisualStyleBackColor = true;
            this.buttonProcess.Click += new System.EventHandler(this.buttonProcess_Click);
            // 
            // textBoxState
            // 
            this.textBoxState.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxState.Location = new System.Drawing.Point(257, 103);
            this.textBoxState.Name = "textBoxState";
            this.textBoxState.Size = new System.Drawing.Size(109, 30);
            this.textBoxState.TabIndex = 8;
            this.textBoxState.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(116, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 25);
            this.label4.TabIndex = 7;
            this.label4.Text = "Current State";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(4, 142);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 25);
            this.label5.TabIndex = 9;
            this.label5.Text = "Data History";
            // 
            // textBoxDataHistory
            // 
            this.textBoxDataHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDataHistory.Location = new System.Drawing.Point(8, 170);
            this.textBoxDataHistory.Multiline = true;
            this.textBoxDataHistory.Name = "textBoxDataHistory";
            this.textBoxDataHistory.Size = new System.Drawing.Size(358, 273);
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
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 556);
            this.Controls.Add(this.checkBoxReadFromFile);
            this.Controls.Add(this.textBoxFileName);
            this.Controls.Add(this.buttonFilename);
            this.Controls.Add(this.textBoxDataHistory);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxState);
            this.Controls.Add(this.label4);
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
        private System.Windows.Forms.TextBox textBoxState;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxDataHistory;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox checkBoxReadFromFile;
        private System.Windows.Forms.TextBox textBoxFileName;
        private System.Windows.Forms.Button buttonFilename;
    }
}