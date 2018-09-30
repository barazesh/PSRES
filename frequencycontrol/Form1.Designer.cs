namespace frequencycontrol
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
            this.PortOpenBtn = new System.Windows.Forms.Button();
            this.SendBtn = new System.Windows.Forms.Button();
            this.freqtxt = new System.Windows.Forms.TextBox();
            this.dutycycletxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.portscmbox = new System.Windows.Forms.ComboBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.actualFreqlbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Port";
            // 
            // PortOpenBtn
            // 
            this.PortOpenBtn.Location = new System.Drawing.Point(217, 23);
            this.PortOpenBtn.Name = "PortOpenBtn";
            this.PortOpenBtn.Size = new System.Drawing.Size(75, 23);
            this.PortOpenBtn.TabIndex = 1;
            this.PortOpenBtn.Text = "Open Port";
            this.PortOpenBtn.UseVisualStyleBackColor = true;
            this.PortOpenBtn.Click += new System.EventHandler(this.PortOpenBtn_Click);
            // 
            // SendBtn
            // 
            this.SendBtn.Location = new System.Drawing.Point(217, 161);
            this.SendBtn.Name = "SendBtn";
            this.SendBtn.Size = new System.Drawing.Size(75, 23);
            this.SendBtn.TabIndex = 2;
            this.SendBtn.Text = "Set";
            this.SendBtn.UseVisualStyleBackColor = true;
            this.SendBtn.Click += new System.EventHandler(this.SendBtn_Click);
            // 
            // freqtxt
            // 
            this.freqtxt.Location = new System.Drawing.Point(92, 161);
            this.freqtxt.Name = "freqtxt";
            this.freqtxt.Size = new System.Drawing.Size(100, 20);
            this.freqtxt.TabIndex = 3;
            // 
            // dutycycletxt
            // 
            this.dutycycletxt.Location = new System.Drawing.Point(92, 97);
            this.dutycycletxt.Name = "dutycycletxt";
            this.dutycycletxt.Size = new System.Drawing.Size(100, 20);
            this.dutycycletxt.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Duty Cycle";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Frequency";
            // 
            // portscmbox
            // 
            this.portscmbox.FormattingEnabled = true;
            this.portscmbox.Location = new System.Drawing.Point(71, 25);
            this.portscmbox.Name = "portscmbox";
            this.portscmbox.Size = new System.Drawing.Size(121, 21);
            this.portscmbox.TabIndex = 7;
            // 
            // actualFreqlbl
            // 
            this.actualFreqlbl.AutoSize = true;
            this.actualFreqlbl.Location = new System.Drawing.Point(92, 188);
            this.actualFreqlbl.Name = "actualFreqlbl";
            this.actualFreqlbl.Size = new System.Drawing.Size(13, 13);
            this.actualFreqlbl.TabIndex = 8;
            this.actualFreqlbl.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 226);
            this.Controls.Add(this.actualFreqlbl);
            this.Controls.Add(this.portscmbox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dutycycletxt);
            this.Controls.Add(this.freqtxt);
            this.Controls.Add(this.SendBtn);
            this.Controls.Add(this.PortOpenBtn);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button PortOpenBtn;
        private System.Windows.Forms.Button SendBtn;
        private System.Windows.Forms.TextBox freqtxt;
        private System.Windows.Forms.TextBox dutycycletxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox portscmbox;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Label actualFreqlbl;
    }
}

