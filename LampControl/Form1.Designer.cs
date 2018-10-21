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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtdutycycle = new System.Windows.Forms.TextBox();
            this.btndutycycle = new System.Windows.Forms.Button();
            this.txtlampselector = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btnfrequency = new System.Windows.Forms.Button();
            this.txtfrequency = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Lamp Selector";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 118);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Duty Cycle";
            // 
            // txtdutycycle
            // 
            this.txtdutycycle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdutycycle.Location = new System.Drawing.Point(43, 170);
            this.txtdutycycle.Margin = new System.Windows.Forms.Padding(6);
            this.txtdutycycle.Name = "txtdutycycle";
            this.txtdutycycle.Size = new System.Drawing.Size(219, 29);
            this.txtdutycycle.TabIndex = 3;
            // 
            // btndutycycle
            // 
            this.btndutycycle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndutycycle.Location = new System.Drawing.Point(283, 170);
            this.btndutycycle.Margin = new System.Windows.Forms.Padding(6);
            this.btndutycycle.Name = "btndutycycle";
            this.btndutycycle.Size = new System.Drawing.Size(125, 29);
            this.btndutycycle.TabIndex = 4;
            this.btndutycycle.Text = "SET Duty Cycle";
            this.btndutycycle.UseVisualStyleBackColor = true;
            this.btndutycycle.Click += new System.EventHandler(this.btndutycycle_Click);
            // 
            // txtlampselector
            // 
            this.txtlampselector.Location = new System.Drawing.Point(43, 63);
            this.txtlampselector.Margin = new System.Windows.Forms.Padding(6);
            this.txtlampselector.Name = "txtlampselector";
            this.txtlampselector.Size = new System.Drawing.Size(219, 29);
            this.txtlampselector.TabIndex = 5;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(300, 63);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(111, 28);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.Text = "All Lamps";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // btnfrequency
            // 
            this.btnfrequency.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnfrequency.Location = new System.Drawing.Point(283, 273);
            this.btnfrequency.Margin = new System.Windows.Forms.Padding(6);
            this.btnfrequency.Name = "btnfrequency";
            this.btnfrequency.Size = new System.Drawing.Size(125, 29);
            this.btnfrequency.TabIndex = 9;
            this.btnfrequency.Text = "SET Frequency";
            this.btnfrequency.UseVisualStyleBackColor = true;
            this.btnfrequency.Click += new System.EventHandler(this.btnfrequency_Click);
            // 
            // txtfrequency
            // 
            this.txtfrequency.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtfrequency.Location = new System.Drawing.Point(43, 273);
            this.txtfrequency.Margin = new System.Windows.Forms.Padding(6);
            this.txtfrequency.Name = "txtfrequency";
            this.txtfrequency.Size = new System.Drawing.Size(219, 29);
            this.txtfrequency.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 221);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 24);
            this.label3.TabIndex = 7;
            this.label3.Text = "Frequency";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 391);
            this.Controls.Add(this.btnfrequency);
            this.Controls.Add(this.txtfrequency);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.txtlampselector);
            this.Controls.Add(this.btndutycycle);
            this.Controls.Add(this.txtdutycycle);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtdutycycle;
        private System.Windows.Forms.Button btndutycycle;
        private System.Windows.Forms.TextBox txtlampselector;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button btnfrequency;
        private System.Windows.Forms.TextBox txtfrequency;
        private System.Windows.Forms.Label label3;
    }
}

