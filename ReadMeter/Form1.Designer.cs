namespace ReadMeter
{
    partial class Form1
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
            this.cmboxPorts = new System.Windows.Forms.ComboBox();
            this.btnOpenPort = new System.Windows.Forms.Button();
            this.btnReadMeter = new System.Windows.Forms.Button();
            this.txtSerial = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtReact = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtVolt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBegin = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtActive = new System.Windows.Forms.TextBox();
            this.txtFreq = new System.Windows.Forms.TextBox();
            this.txtInstantActive = new System.Windows.Forms.TextBox();
            this.txtEnd = new System.Windows.Forms.TextBox();
            this.txtAmpre = new System.Windows.Forms.TextBox();
            this.txtInstantReact = new System.Windows.Forms.TextBox();
            this.txtPF = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtAmpre1 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Serial Port";
            // 
            // cmboxPorts
            // 
            this.cmboxPorts.FormattingEnabled = true;
            this.cmboxPorts.Location = new System.Drawing.Point(138, 20);
            this.cmboxPorts.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmboxPorts.Name = "cmboxPorts";
            this.cmboxPorts.Size = new System.Drawing.Size(180, 28);
            this.cmboxPorts.TabIndex = 1;
            // 
            // btnOpenPort
            // 
            this.btnOpenPort.Location = new System.Drawing.Point(361, 16);
            this.btnOpenPort.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnOpenPort.Name = "btnOpenPort";
            this.btnOpenPort.Size = new System.Drawing.Size(112, 35);
            this.btnOpenPort.TabIndex = 2;
            this.btnOpenPort.Text = "Open Port";
            this.btnOpenPort.UseVisualStyleBackColor = true;
            this.btnOpenPort.Click += new System.EventHandler(this.btnOpenPort_Click);
            // 
            // btnReadMeter
            // 
            this.btnReadMeter.Location = new System.Drawing.Point(361, 85);
            this.btnReadMeter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnReadMeter.Name = "btnReadMeter";
            this.btnReadMeter.Size = new System.Drawing.Size(112, 35);
            this.btnReadMeter.TabIndex = 5;
            this.btnReadMeter.Text = "read Meter";
            this.btnReadMeter.UseVisualStyleBackColor = true;
            this.btnReadMeter.Click += new System.EventHandler(this.btnReadMeter_Click);
            // 
            // txtSerial
            // 
            this.txtSerial.Location = new System.Drawing.Point(146, 162);
            this.txtSerial.Name = "txtSerial";
            this.txtSerial.Size = new System.Drawing.Size(394, 26);
            this.txtSerial.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(154, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Serial Number";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 236);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Reactive Energy";
            // 
            // txtReact
            // 
            this.txtReact.Location = new System.Drawing.Point(146, 233);
            this.txtReact.Name = "txtReact";
            this.txtReact.Size = new System.Drawing.Size(100, 26);
            this.txtReact.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(73, 270);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "Voltage";
            // 
            // txtVolt
            // 
            this.txtVolt.Location = new System.Drawing.Point(146, 267);
            this.txtVolt.Name = "txtVolt";
            this.txtVolt.Size = new System.Drawing.Size(100, 26);
            this.txtVolt.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(87, 304);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 20);
            this.label6.TabIndex = 13;
            this.label6.Text = "Begin";
            // 
            // txtBegin
            // 
            this.txtBegin.Location = new System.Drawing.Point(146, 301);
            this.txtBegin.Name = "txtBegin";
            this.txtBegin.Size = new System.Drawing.Size(100, 26);
            this.txtBegin.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(31, 202);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 20);
            this.label7.TabIndex = 15;
            this.label7.Text = "Active Energy";
            // 
            // txtActive
            // 
            this.txtActive.Location = new System.Drawing.Point(146, 199);
            this.txtActive.Name = "txtActive";
            this.txtActive.Size = new System.Drawing.Size(100, 26);
            this.txtActive.TabIndex = 14;
            // 
            // txtFreq
            // 
            this.txtFreq.Location = new System.Drawing.Point(440, 338);
            this.txtFreq.Name = "txtFreq";
            this.txtFreq.Size = new System.Drawing.Size(100, 26);
            this.txtFreq.TabIndex = 16;
            // 
            // txtInstantActive
            // 
            this.txtInstantActive.Location = new System.Drawing.Point(440, 236);
            this.txtInstantActive.Name = "txtInstantActive";
            this.txtInstantActive.Size = new System.Drawing.Size(100, 26);
            this.txtInstantActive.TabIndex = 21;
            // 
            // txtEnd
            // 
            this.txtEnd.Location = new System.Drawing.Point(146, 333);
            this.txtEnd.Name = "txtEnd";
            this.txtEnd.Size = new System.Drawing.Size(100, 26);
            this.txtEnd.TabIndex = 20;
            // 
            // txtAmpre
            // 
            this.txtAmpre.Location = new System.Drawing.Point(440, 304);
            this.txtAmpre.Name = "txtAmpre";
            this.txtAmpre.Size = new System.Drawing.Size(100, 26);
            this.txtAmpre.TabIndex = 19;
            // 
            // txtInstantReact
            // 
            this.txtInstantReact.Location = new System.Drawing.Point(440, 270);
            this.txtInstantReact.Name = "txtInstantReact";
            this.txtInstantReact.Size = new System.Drawing.Size(100, 26);
            this.txtInstantReact.TabIndex = 18;
            // 
            // txtPF
            // 
            this.txtPF.Location = new System.Drawing.Point(440, 202);
            this.txtPF.Name = "txtPF";
            this.txtPF.Size = new System.Drawing.Size(100, 26);
            this.txtPF.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(278, 239);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(154, 20);
            this.label8.TabIndex = 26;
            this.label8.Text = "Instant Active Power";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(100, 336);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 20);
            this.label9.TabIndex = 25;
            this.label9.Text = "End";
            // 
            // txtAmpre1
            // 
            this.txtAmpre1.AutoSize = true;
            this.txtAmpre1.Location = new System.Drawing.Point(370, 307);
            this.txtAmpre1.Name = "txtAmpre1";
            this.txtAmpre1.Size = new System.Drawing.Size(62, 20);
            this.txtAmpre1.TabIndex = 24;
            this.txtAmpre1.Text = "Current";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(259, 273);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(173, 20);
            this.label11.TabIndex = 23;
            this.label11.Text = "Instant Reactive Power";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(329, 205);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(103, 20);
            this.label12.TabIndex = 22;
            this.label12.Text = "Power Factor";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(347, 340);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(84, 20);
            this.label13.TabIndex = 27;
            this.label13.Text = "Frequency";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 425);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtAmpre1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtInstantActive);
            this.Controls.Add(this.txtEnd);
            this.Controls.Add(this.txtAmpre);
            this.Controls.Add(this.txtInstantReact);
            this.Controls.Add(this.txtPF);
            this.Controls.Add(this.txtFreq);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtActive);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtBegin);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtVolt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtReact);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSerial);
            this.Controls.Add(this.btnReadMeter);
            this.Controls.Add(this.btnOpenPort);
            this.Controls.Add(this.cmboxPorts);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "PSRES Meter Reader";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmboxPorts;
        private System.Windows.Forms.Button btnOpenPort;
        private System.Windows.Forms.Button btnReadMeter;
        private System.Windows.Forms.TextBox txtSerial;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtReact;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtVolt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBegin;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtActive;
        private System.Windows.Forms.TextBox txtFreq;
        private System.Windows.Forms.TextBox txtInstantActive;
        private System.Windows.Forms.TextBox txtEnd;
        private System.Windows.Forms.TextBox txtAmpre;
        private System.Windows.Forms.TextBox txtInstantReact;
        private System.Windows.Forms.TextBox txtPF;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label txtAmpre1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.IO.Ports.SerialPort serialPort1;
    }
}

