namespace LampControl
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtdutycycle = new System.Windows.Forms.TextBox();
            this.btndutycycle = new System.Windows.Forms.Button();
            this.chkalllamps = new System.Windows.Forms.CheckBox();
            this.btnfrequency = new System.Windows.Forms.Button();
            this.txtfrequency = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmboxParent = new System.Windows.Forms.ComboBox();
            this.label25 = new System.Windows.Forms.Label();
            this.chkallParents = new System.Windows.Forms.CheckBox();
            this.cmboxLamps = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtPresence1 = new System.Windows.Forms.TextBox();
            this.txtDistbin1 = new System.Windows.Forms.TextBox();
            this.txtDist1 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtLightbin1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtLight1 = new System.Windows.Forms.TextBox();
            this.txtTempbin1 = new System.Windows.Forms.TextBox();
            this.txtTemp1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtPresence2 = new System.Windows.Forms.TextBox();
            this.txtDistbin2 = new System.Windows.Forms.TextBox();
            this.txtDist2 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtLightbin2 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtLight2 = new System.Windows.Forms.TextBox();
            this.txtTempbin2 = new System.Windows.Forms.TextBox();
            this.txtTemp2 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtPresence3 = new System.Windows.Forms.TextBox();
            this.txtDistbin3 = new System.Windows.Forms.TextBox();
            this.txtDist3 = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.txtLightbin3 = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txtLight3 = new System.Windows.Forms.TextBox();
            this.txtTempbin3 = new System.Windows.Forms.TextBox();
            this.txtTemp3 = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.btnReadSensor = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnRefreshPortNames = new System.Windows.Forms.Button();
            this.btnPort = new System.Windows.Forms.Button();
            this.cmboxPorts = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(173, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Lamp Selector";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(321, 30);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Duty Cycle";
            // 
            // txtdutycycle
            // 
            this.txtdutycycle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdutycycle.Location = new System.Drawing.Point(407, 25);
            this.txtdutycycle.Margin = new System.Windows.Forms.Padding(5);
            this.txtdutycycle.Name = "txtdutycycle";
            this.txtdutycycle.Size = new System.Drawing.Size(72, 29);
            this.txtdutycycle.TabIndex = 3;
            // 
            // btndutycycle
            // 
            this.btndutycycle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndutycycle.Location = new System.Drawing.Point(325, 58);
            this.btndutycycle.Margin = new System.Windows.Forms.Padding(5);
            this.btndutycycle.Name = "btndutycycle";
            this.btndutycycle.Size = new System.Drawing.Size(154, 30);
            this.btndutycycle.TabIndex = 4;
            this.btndutycycle.Text = "SET Duty Cycle";
            this.btndutycycle.UseVisualStyleBackColor = true;
            this.btndutycycle.Click += new System.EventHandler(this.btndutycycle_Click);
            // 
            // chkalllamps
            // 
            this.chkalllamps.AutoSize = true;
            this.chkalllamps.Location = new System.Drawing.Point(177, 58);
            this.chkalllamps.Margin = new System.Windows.Forms.Padding(2);
            this.chkalllamps.Name = "chkalllamps";
            this.chkalllamps.Size = new System.Drawing.Size(45, 24);
            this.chkalllamps.TabIndex = 6;
            this.chkalllamps.Text = "All";
            this.chkalllamps.UseVisualStyleBackColor = true;
            this.chkalllamps.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // btnfrequency
            // 
            this.btnfrequency.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnfrequency.Location = new System.Drawing.Point(498, 58);
            this.btnfrequency.Margin = new System.Windows.Forms.Padding(5);
            this.btnfrequency.Name = "btnfrequency";
            this.btnfrequency.Size = new System.Drawing.Size(154, 31);
            this.btnfrequency.TabIndex = 9;
            this.btnfrequency.Text = "SET Frequency";
            this.btnfrequency.UseVisualStyleBackColor = true;
            this.btnfrequency.Click += new System.EventHandler(this.btnfrequency_Click);
            // 
            // txtfrequency
            // 
            this.txtfrequency.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtfrequency.Location = new System.Drawing.Point(591, 24);
            this.txtfrequency.Margin = new System.Windows.Forms.Padding(5);
            this.txtfrequency.Name = "txtfrequency";
            this.txtfrequency.Size = new System.Drawing.Size(61, 29);
            this.txtfrequency.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(497, 30);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Frequency";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmboxParent);
            this.groupBox1.Controls.Add(this.label25);
            this.groupBox1.Controls.Add(this.chkallParents);
            this.groupBox1.Controls.Add(this.cmboxLamps);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnfrequency);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtfrequency);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtdutycycle);
            this.groupBox1.Controls.Add(this.chkalllamps);
            this.groupBox1.Controls.Add(this.btndutycycle);
            this.groupBox1.Location = new System.Drawing.Point(20, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(670, 103);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lamp Control";
            // 
            // cmboxParent
            // 
            this.cmboxParent.FormattingEnabled = true;
            this.cmboxParent.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6"});
            this.cmboxParent.Location = new System.Drawing.Point(81, 58);
            this.cmboxParent.Name = "cmboxParent";
            this.cmboxParent.Size = new System.Drawing.Size(58, 28);
            this.cmboxParent.TabIndex = 11;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(27, 30);
            this.label25.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(119, 20);
            this.label25.TabIndex = 10;
            this.label25.Text = "Parent Selector";
            // 
            // chkallParents
            // 
            this.chkallParents.AutoSize = true;
            this.chkallParents.Location = new System.Drawing.Point(31, 61);
            this.chkallParents.Margin = new System.Windows.Forms.Padding(2);
            this.chkallParents.Name = "chkallParents";
            this.chkallParents.Size = new System.Drawing.Size(45, 24);
            this.chkallParents.TabIndex = 12;
            this.chkallParents.Text = "All";
            this.chkallParents.UseVisualStyleBackColor = true;
            // 
            // cmboxLamps
            // 
            this.cmboxLamps.FormattingEnabled = true;
            this.cmboxLamps.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6"});
            this.cmboxLamps.Location = new System.Drawing.Point(220, 56);
            this.cmboxLamps.Name = "cmboxLamps";
            this.cmboxLamps.Size = new System.Drawing.Size(72, 28);
            this.cmboxLamps.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtPresence1);
            this.groupBox2.Controls.Add(this.txtDistbin1);
            this.groupBox2.Controls.Add(this.txtDist1);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.txtLightbin1);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtLight1);
            this.groupBox2.Controls.Add(this.txtTempbin1);
            this.groupBox2.Controls.Add(this.txtTemp1);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(20, 188);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(352, 308);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sensor Pack 1";
            // 
            // txtPresence1
            // 
            this.txtPresence1.Location = new System.Drawing.Point(118, 263);
            this.txtPresence1.Margin = new System.Windows.Forms.Padding(2);
            this.txtPresence1.Name = "txtPresence1";
            this.txtPresence1.Size = new System.Drawing.Size(200, 26);
            this.txtPresence1.TabIndex = 13;
            // 
            // txtDistbin1
            // 
            this.txtDistbin1.Location = new System.Drawing.Point(118, 225);
            this.txtDistbin1.Margin = new System.Windows.Forms.Padding(2);
            this.txtDistbin1.Name = "txtDistbin1";
            this.txtDistbin1.Size = new System.Drawing.Size(200, 26);
            this.txtDistbin1.TabIndex = 12;
            // 
            // txtDist1
            // 
            this.txtDist1.Location = new System.Drawing.Point(118, 187);
            this.txtDist1.Margin = new System.Windows.Forms.Padding(2);
            this.txtDist1.Name = "txtDist1";
            this.txtDist1.Size = new System.Drawing.Size(200, 26);
            this.txtDist1.TabIndex = 11;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(35, 266);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 20);
            this.label9.TabIndex = 10;
            this.label9.Text = "Presence";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(4, 228);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(107, 20);
            this.label10.TabIndex = 9;
            this.label10.Text = "Distance (bin)";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(39, 190);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 20);
            this.label11.TabIndex = 8;
            this.label11.Text = "Distance";
            // 
            // txtLightbin1
            // 
            this.txtLightbin1.Location = new System.Drawing.Point(118, 149);
            this.txtLightbin1.Margin = new System.Windows.Forms.Padding(2);
            this.txtLightbin1.Name = "txtLightbin1";
            this.txtLightbin1.Size = new System.Drawing.Size(200, 26);
            this.txtLightbin1.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(32, 152);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 20);
            this.label7.TabIndex = 6;
            this.label7.Text = "Light (bin)";
            // 
            // txtLight1
            // 
            this.txtLight1.Location = new System.Drawing.Point(118, 111);
            this.txtLight1.Margin = new System.Windows.Forms.Padding(2);
            this.txtLight1.Name = "txtLight1";
            this.txtLight1.Size = new System.Drawing.Size(200, 26);
            this.txtLight1.TabIndex = 5;
            // 
            // txtTempbin1
            // 
            this.txtTempbin1.Location = new System.Drawing.Point(118, 73);
            this.txtTempbin1.Margin = new System.Windows.Forms.Padding(2);
            this.txtTempbin1.Name = "txtTempbin1";
            this.txtTempbin1.Size = new System.Drawing.Size(200, 26);
            this.txtTempbin1.TabIndex = 4;
            // 
            // txtTemp1
            // 
            this.txtTemp1.Location = new System.Drawing.Point(118, 35);
            this.txtTemp1.Margin = new System.Windows.Forms.Padding(2);
            this.txtTemp1.Name = "txtTemp1";
            this.txtTemp1.Size = new System.Drawing.Size(200, 26);
            this.txtTemp1.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(67, 114);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 20);
            this.label6.TabIndex = 2;
            this.label6.Text = "Light";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 76);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 20);
            this.label5.TabIndex = 1;
            this.label5.Text = "Temp (bin)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(62, 38);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Temp";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtPresence2);
            this.groupBox3.Controls.Add(this.txtDistbin2);
            this.groupBox3.Controls.Add(this.txtDist2);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.txtLightbin2);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.txtLight2);
            this.groupBox3.Controls.Add(this.txtTempbin2);
            this.groupBox3.Controls.Add(this.txtTemp2);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Location = new System.Drawing.Point(386, 188);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(359, 308);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Sensor Pack 2";
            // 
            // txtPresence2
            // 
            this.txtPresence2.Location = new System.Drawing.Point(118, 263);
            this.txtPresence2.Margin = new System.Windows.Forms.Padding(2);
            this.txtPresence2.Name = "txtPresence2";
            this.txtPresence2.Size = new System.Drawing.Size(200, 26);
            this.txtPresence2.TabIndex = 13;
            // 
            // txtDistbin2
            // 
            this.txtDistbin2.Location = new System.Drawing.Point(118, 225);
            this.txtDistbin2.Margin = new System.Windows.Forms.Padding(2);
            this.txtDistbin2.Name = "txtDistbin2";
            this.txtDistbin2.Size = new System.Drawing.Size(200, 26);
            this.txtDistbin2.TabIndex = 12;
            // 
            // txtDist2
            // 
            this.txtDist2.Location = new System.Drawing.Point(118, 187);
            this.txtDist2.Margin = new System.Windows.Forms.Padding(2);
            this.txtDist2.Name = "txtDist2";
            this.txtDist2.Size = new System.Drawing.Size(200, 26);
            this.txtDist2.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(35, 266);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 20);
            this.label8.TabIndex = 10;
            this.label8.Text = "Presence";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(4, 228);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(107, 20);
            this.label12.TabIndex = 9;
            this.label12.Text = "Distance (bin)";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(39, 190);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(72, 20);
            this.label13.TabIndex = 8;
            this.label13.Text = "Distance";
            // 
            // txtLightbin2
            // 
            this.txtLightbin2.Location = new System.Drawing.Point(118, 149);
            this.txtLightbin2.Margin = new System.Windows.Forms.Padding(2);
            this.txtLightbin2.Name = "txtLightbin2";
            this.txtLightbin2.Size = new System.Drawing.Size(200, 26);
            this.txtLightbin2.TabIndex = 7;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(32, 152);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(79, 20);
            this.label14.TabIndex = 6;
            this.label14.Text = "Light (bin)";
            // 
            // txtLight2
            // 
            this.txtLight2.Location = new System.Drawing.Point(118, 111);
            this.txtLight2.Margin = new System.Windows.Forms.Padding(2);
            this.txtLight2.Name = "txtLight2";
            this.txtLight2.Size = new System.Drawing.Size(200, 26);
            this.txtLight2.TabIndex = 5;
            // 
            // txtTempbin2
            // 
            this.txtTempbin2.Location = new System.Drawing.Point(118, 73);
            this.txtTempbin2.Margin = new System.Windows.Forms.Padding(2);
            this.txtTempbin2.Name = "txtTempbin2";
            this.txtTempbin2.Size = new System.Drawing.Size(200, 26);
            this.txtTempbin2.TabIndex = 4;
            // 
            // txtTemp2
            // 
            this.txtTemp2.Location = new System.Drawing.Point(118, 35);
            this.txtTemp2.Margin = new System.Windows.Forms.Padding(2);
            this.txtTemp2.Name = "txtTemp2";
            this.txtTemp2.Size = new System.Drawing.Size(200, 26);
            this.txtTemp2.TabIndex = 3;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(67, 114);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(44, 20);
            this.label15.TabIndex = 2;
            this.label15.Text = "Light";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(27, 76);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(84, 20);
            this.label16.TabIndex = 1;
            this.label16.Text = "Temp (bin)";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(62, 38);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(49, 20);
            this.label17.TabIndex = 0;
            this.label17.Text = "Temp";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtPresence3);
            this.groupBox4.Controls.Add(this.txtDistbin3);
            this.groupBox4.Controls.Add(this.txtDist3);
            this.groupBox4.Controls.Add(this.label18);
            this.groupBox4.Controls.Add(this.label19);
            this.groupBox4.Controls.Add(this.label20);
            this.groupBox4.Controls.Add(this.txtLightbin3);
            this.groupBox4.Controls.Add(this.label21);
            this.groupBox4.Controls.Add(this.txtLight3);
            this.groupBox4.Controls.Add(this.txtTempbin3);
            this.groupBox4.Controls.Add(this.txtTemp3);
            this.groupBox4.Controls.Add(this.label22);
            this.groupBox4.Controls.Add(this.label23);
            this.groupBox4.Controls.Add(this.label24);
            this.groupBox4.Location = new System.Drawing.Point(760, 188);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox4.Size = new System.Drawing.Size(340, 308);
            this.groupBox4.TabIndex = 15;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Sensor Pack 3";
            // 
            // txtPresence3
            // 
            this.txtPresence3.Location = new System.Drawing.Point(118, 263);
            this.txtPresence3.Margin = new System.Windows.Forms.Padding(2);
            this.txtPresence3.Name = "txtPresence3";
            this.txtPresence3.Size = new System.Drawing.Size(200, 26);
            this.txtPresence3.TabIndex = 13;
            // 
            // txtDistbin3
            // 
            this.txtDistbin3.Location = new System.Drawing.Point(118, 225);
            this.txtDistbin3.Margin = new System.Windows.Forms.Padding(2);
            this.txtDistbin3.Name = "txtDistbin3";
            this.txtDistbin3.Size = new System.Drawing.Size(200, 26);
            this.txtDistbin3.TabIndex = 12;
            // 
            // txtDist3
            // 
            this.txtDist3.Location = new System.Drawing.Point(118, 187);
            this.txtDist3.Margin = new System.Windows.Forms.Padding(2);
            this.txtDist3.Name = "txtDist3";
            this.txtDist3.Size = new System.Drawing.Size(200, 26);
            this.txtDist3.TabIndex = 11;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(35, 266);
            this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(76, 20);
            this.label18.TabIndex = 10;
            this.label18.Text = "Presence";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(4, 228);
            this.label19.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(107, 20);
            this.label19.TabIndex = 9;
            this.label19.Text = "Distance (bin)";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(39, 190);
            this.label20.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(72, 20);
            this.label20.TabIndex = 8;
            this.label20.Text = "Distance";
            // 
            // txtLightbin3
            // 
            this.txtLightbin3.Location = new System.Drawing.Point(118, 149);
            this.txtLightbin3.Margin = new System.Windows.Forms.Padding(2);
            this.txtLightbin3.Name = "txtLightbin3";
            this.txtLightbin3.Size = new System.Drawing.Size(200, 26);
            this.txtLightbin3.TabIndex = 7;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(32, 152);
            this.label21.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(79, 20);
            this.label21.TabIndex = 6;
            this.label21.Text = "Light (bin)";
            // 
            // txtLight3
            // 
            this.txtLight3.Location = new System.Drawing.Point(118, 111);
            this.txtLight3.Margin = new System.Windows.Forms.Padding(2);
            this.txtLight3.Name = "txtLight3";
            this.txtLight3.Size = new System.Drawing.Size(200, 26);
            this.txtLight3.TabIndex = 5;
            // 
            // txtTempbin3
            // 
            this.txtTempbin3.Location = new System.Drawing.Point(118, 73);
            this.txtTempbin3.Margin = new System.Windows.Forms.Padding(2);
            this.txtTempbin3.Name = "txtTempbin3";
            this.txtTempbin3.Size = new System.Drawing.Size(200, 26);
            this.txtTempbin3.TabIndex = 4;
            // 
            // txtTemp3
            // 
            this.txtTemp3.Location = new System.Drawing.Point(118, 35);
            this.txtTemp3.Margin = new System.Windows.Forms.Padding(2);
            this.txtTemp3.Name = "txtTemp3";
            this.txtTemp3.Size = new System.Drawing.Size(200, 26);
            this.txtTemp3.TabIndex = 3;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(67, 114);
            this.label22.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(44, 20);
            this.label22.TabIndex = 2;
            this.label22.Text = "Light";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(27, 76);
            this.label23.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(84, 20);
            this.label23.TabIndex = 1;
            this.label23.Text = "Temp (bin)";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(62, 38);
            this.label24.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(49, 20);
            this.label24.TabIndex = 0;
            this.label24.Text = "Temp";
            // 
            // serialPort1
            // 
            this.serialPort1.BaudRate = 115200;
            // 
            // btnReadSensor
            // 
            this.btnReadSensor.Location = new System.Drawing.Point(20, 501);
            this.btnReadSensor.Name = "btnReadSensor";
            this.btnReadSensor.Size = new System.Drawing.Size(946, 34);
            this.btnReadSensor.TabIndex = 16;
            this.btnReadSensor.Text = "Read Sensors";
            this.btnReadSensor.UseVisualStyleBackColor = true;
            this.btnReadSensor.Click += new System.EventHandler(this.btnReadSensor_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnRefreshPortNames);
            this.groupBox5.Controls.Add(this.btnPort);
            this.groupBox5.Controls.Add(this.cmboxPorts);
            this.groupBox5.Location = new System.Drawing.Point(697, 10);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(198, 114);
            this.groupBox5.TabIndex = 17;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Port";
            // 
            // btnRefreshPortNames
            // 
            this.btnRefreshPortNames.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnRefreshPortNames.Location = new System.Drawing.Point(101, 24);
            this.btnRefreshPortNames.Name = "btnRefreshPortNames";
            this.btnRefreshPortNames.Size = new System.Drawing.Size(85, 37);
            this.btnRefreshPortNames.TabIndex = 2;
            this.btnRefreshPortNames.Text = "Refresh";
            this.btnRefreshPortNames.UseVisualStyleBackColor = false;
            this.btnRefreshPortNames.Click += new System.EventHandler(this.btnRefreshPortNames_Click);
            // 
            // btnPort
            // 
            this.btnPort.Location = new System.Drawing.Point(14, 24);
            this.btnPort.Name = "btnPort";
            this.btnPort.Size = new System.Drawing.Size(81, 37);
            this.btnPort.TabIndex = 1;
            this.btnPort.Text = "Set Port";
            this.btnPort.UseVisualStyleBackColor = true;
            this.btnPort.Click += new System.EventHandler(this.btnPort_Click);
            // 
            // cmboxPorts
            // 
            this.cmboxPorts.FormattingEnabled = true;
            this.cmboxPorts.Location = new System.Drawing.Point(14, 67);
            this.cmboxPorts.Name = "cmboxPorts";
            this.cmboxPorts.Size = new System.Drawing.Size(172, 28);
            this.cmboxPorts.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1112, 552);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.btnReadSensor);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtdutycycle;
        private System.Windows.Forms.Button btndutycycle;
        private System.Windows.Forms.CheckBox chkalllamps;
        private System.Windows.Forms.Button btnfrequency;
        private System.Windows.Forms.TextBox txtfrequency;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtPresence1;
        private System.Windows.Forms.TextBox txtDistbin1;
        private System.Windows.Forms.TextBox txtDist1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtLightbin1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtLight1;
        private System.Windows.Forms.TextBox txtTempbin1;
        private System.Windows.Forms.TextBox txtTemp1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtPresence2;
        private System.Windows.Forms.TextBox txtDistbin2;
        private System.Windows.Forms.TextBox txtDist2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtLightbin2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtLight2;
        private System.Windows.Forms.TextBox txtTempbin2;
        private System.Windows.Forms.TextBox txtTemp2;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtPresence3;
        private System.Windows.Forms.TextBox txtDistbin3;
        private System.Windows.Forms.TextBox txtDist3;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtLightbin3;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtLight3;
        private System.Windows.Forms.TextBox txtTempbin3;
        private System.Windows.Forms.TextBox txtTemp3;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button btnReadSensor;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnPort;
        private System.Windows.Forms.ComboBox cmboxPorts;
        private System.Windows.Forms.ComboBox cmboxLamps;
        private System.Windows.Forms.Button btnRefreshPortNames;
        private System.Windows.Forms.ComboBox cmboxParent;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.CheckBox chkallParents;
    }
}

