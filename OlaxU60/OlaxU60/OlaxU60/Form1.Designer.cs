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
            this.Other = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGet = new System.Windows.Forms.TextBox();
            this.resultCheckIP = new System.Windows.Forms.TextBox();
            this.getIp = new System.Windows.Forms.Button();
            this.resetOlax = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.namecard = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Other.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Other
            // 
            this.Other.Controls.Add(this.tabPage1);
            this.Other.Controls.Add(this.tabPage2);
            this.Other.Location = new System.Drawing.Point(30, 12);
            this.Other.Name = "Other";
            this.Other.SelectedIndex = 0;
            this.Other.Size = new System.Drawing.Size(508, 422);
            this.Other.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.resetOlax);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(500, 393);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "OLAX U80";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // dataGet
            // 
            this.dataGet.Location = new System.Drawing.Point(544, 109);
            this.dataGet.Multiline = true;
            this.dataGet.Name = "dataGet";
            this.dataGet.Size = new System.Drawing.Size(270, 325);
            this.dataGet.TabIndex = 3;
            // 
            // resultCheckIP
            // 
            this.resultCheckIP.BackColor = System.Drawing.Color.PeachPuff;
            this.resultCheckIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resultCheckIP.Location = new System.Drawing.Point(734, 12);
            this.resultCheckIP.Multiline = true;
            this.resultCheckIP.Name = "resultCheckIP";
            this.resultCheckIP.Size = new System.Drawing.Size(80, 80);
            this.resultCheckIP.TabIndex = 2;
            this.resultCheckIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.resultCheckIP.TextChanged += new System.EventHandler(this.resultCheckIP_TextChanged);
            // 
            // getIp
            // 
            this.getIp.Location = new System.Drawing.Point(544, 12);
            this.getIp.Name = "getIp";
            this.getIp.Size = new System.Drawing.Size(170, 80);
            this.getIp.TabIndex = 1;
            this.getIp.Text = "GET IP";
            this.getIp.UseVisualStyleBackColor = true;
            this.getIp.Click += new System.EventHandler(this.getIp_Click);
            // 
            // resetOlax
            // 
            this.resetOlax.Location = new System.Drawing.Point(22, 25);
            this.resetOlax.Name = "resetOlax";
            this.resetOlax.Size = new System.Drawing.Size(170, 80);
            this.resetOlax.TabIndex = 0;
            this.resetOlax.Text = "resetOlax";
            this.resetOlax.UseVisualStyleBackColor = true;
            this.resetOlax.Click += new System.EventHandler(this.resetOlax_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.namecard);
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(500, 393);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Other";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(167, 53);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(134, 60);
            this.button2.TabIndex = 0;
            this.button2.Text = "Restart network";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // namecard
            // 
            this.namecard.Location = new System.Drawing.Point(167, 14);
            this.namecard.Name = "namecard";
            this.namecard.Size = new System.Drawing.Size(227, 22);
            this.namecard.TabIndex = 1;
            this.namecard.Text = "Ethernet 3";
            this.namecard.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tên Card mạng";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 449);
            this.Controls.Add(this.Other);
            this.Controls.Add(this.resultCheckIP);
            this.Controls.Add(this.dataGet);
            this.Controls.Add(this.getIp);
            this.Name = "Form1";
            this.Text = "Change IP";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Other.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl Other;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button getIp;
        private System.Windows.Forms.Button resetOlax;
        private System.Windows.Forms.TextBox dataGet;
        private System.Windows.Forms.TextBox resultCheckIP;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox namecard;
        private System.Windows.Forms.Label label1;
    }
}

