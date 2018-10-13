namespace DBconnection
{
    partial class MainForm
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
            this.btnconnect = new System.Windows.Forms.Button();
            this.lblrecipes = new System.Windows.Forms.Label();
            this.listrecipes = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnconnect
            // 
            this.btnconnect.Location = new System.Drawing.Point(203, 176);
            this.btnconnect.Name = "btnconnect";
            this.btnconnect.Size = new System.Drawing.Size(75, 23);
            this.btnconnect.TabIndex = 0;
            this.btnconnect.Text = "Connect";
            this.btnconnect.UseVisualStyleBackColor = true;
            this.btnconnect.Click += new System.EventHandler(this.btnconnect_Click);
            // 
            // lblrecipes
            // 
            this.lblrecipes.AutoSize = true;
            this.lblrecipes.Location = new System.Drawing.Point(32, 13);
            this.lblrecipes.Name = "lblrecipes";
            this.lblrecipes.Size = new System.Drawing.Size(40, 13);
            this.lblrecipes.TabIndex = 1;
            this.lblrecipes.Text = "Recips";
            // 
            // listrecipes
            // 
            this.listrecipes.FormattingEnabled = true;
            this.listrecipes.Location = new System.Drawing.Point(35, 41);
            this.listrecipes.Name = "listrecipes";
            this.listrecipes.Size = new System.Drawing.Size(218, 108);
            this.listrecipes.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 363);
            this.Controls.Add(this.listrecipes);
            this.Controls.Add(this.lblrecipes);
            this.Controls.Add(this.btnconnect);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnconnect;
        private System.Windows.Forms.Label lblrecipes;
        private System.Windows.Forms.ListBox listrecipes;
    }
}

