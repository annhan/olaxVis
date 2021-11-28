namespace OlaxU60
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.resetOlax = new System.Windows.Forms.Button();
            this.getIp = new System.Windows.Forms.Button();
            this.resultCheckIP = new System.Windows.Forms.TextBox();
            this.dataGet = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(30, 26);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1065, 534);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.dataGet);
            this.tabPage1.Controls.Add(this.resultCheckIP);
            this.tabPage1.Controls.Add(this.getIp);
            this.tabPage1.Controls.Add(this.resetOlax);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1057, 505);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "OLAX U80";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(192, 71);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // resetOlax
            // 
            this.resetOlax.Location = new System.Drawing.Point(86, 64);
            this.resetOlax.Name = "resetOlax";
            this.resetOlax.Size = new System.Drawing.Size(170, 80);
            this.resetOlax.TabIndex = 0;
            this.resetOlax.Text = "resetOlax";
            this.resetOlax.UseVisualStyleBackColor = true;
            this.resetOlax.Click += new System.EventHandler(this.resetOlax_Click);
            // 
            // getIp
            // 
            this.getIp.Location = new System.Drawing.Point(86, 167);
            this.getIp.Name = "getIp";
            this.getIp.Size = new System.Drawing.Size(170, 80);
            this.getIp.TabIndex = 1;
            this.getIp.Text = "getIp";
            this.getIp.UseVisualStyleBackColor = true;
            this.getIp.Click += new System.EventHandler(this.getIp_Click);
            // 
            // resultCheckIP
            // 
            this.resultCheckIP.Location = new System.Drawing.Point(86, 269);
            this.resultCheckIP.Name = "resultCheckIP";
            this.resultCheckIP.Size = new System.Drawing.Size(170, 22);
            this.resultCheckIP.TabIndex = 2;
            // 
            // dataGet
            // 
            this.dataGet.Location = new System.Drawing.Point(526, 63);
            this.dataGet.Multiline = true;
            this.dataGet.Name = "dataGet";
            this.dataGet.Size = new System.Drawing.Size(270, 325);
            this.dataGet.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(112, 364);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1137, 591);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button getIp;
        private System.Windows.Forms.Button resetOlax;
        private System.Windows.Forms.TextBox dataGet;
        private System.Windows.Forms.TextBox resultCheckIP;
        private System.Windows.Forms.Button button1;
    }
}

