﻿namespace OlaxU60
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
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.myLocalIP = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.ChangeNetwork = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.resetOlax = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.statusreset = new System.Windows.Forms.TextBox();
            this.namenetwork = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lblmyaddress = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGet = new System.Windows.Forms.TextBox();
            this.resultCheckIP = new System.Windows.Forms.TextBox();
            this.getIp = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Other.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // Other
            // 
            this.Other.Controls.Add(this.tabPage3);
            this.Other.Controls.Add(this.tabPage1);
            this.Other.Controls.Add(this.tabPage2);
            this.Other.Controls.Add(this.tabPage4);
            this.Other.Location = new System.Drawing.Point(30, 12);
            this.Other.Name = "Other";
            this.Other.SelectedIndex = 0;
            this.Other.Size = new System.Drawing.Size(543, 422);
            this.Other.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.myLocalIP);
            this.tabPage3.Controls.Add(this.comboBox1);
            this.tabPage3.Controls.Add(this.textBox1);
            this.tabPage3.Controls.Add(this.ChangeNetwork);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(535, 393);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Airtel E3372";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // myLocalIP
            // 
            this.myLocalIP.Location = new System.Drawing.Point(15, 147);
            this.myLocalIP.Multiline = true;
            this.myLocalIP.Name = "myLocalIP";
            this.myLocalIP.Size = new System.Drawing.Size(170, 182);
            this.myLocalIP.TabIndex = 9;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Mobifone",
            "Viettel",
            "Vinafone"});
            this.comboBox1.Location = new System.Drawing.Point(353, 43);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(136, 24);
            this.comboBox1.TabIndex = 8;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.PeachPuff;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(201, 43);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(144, 80);
            this.textBox1.TabIndex = 7;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ChangeNetwork
            // 
            this.ChangeNetwork.Location = new System.Drawing.Point(15, 43);
            this.ChangeNetwork.Name = "ChangeNetwork";
            this.ChangeNetwork.Size = new System.Drawing.Size(170, 80);
            this.ChangeNetwork.TabIndex = 1;
            this.ChangeNetwork.Text = "ChangeNetwork";
            this.ChangeNetwork.UseVisualStyleBackColor = true;
            this.ChangeNetwork.Click += new System.EventHandler(this.ChangeNetwork_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.resetOlax);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(535, 393);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "OLAX U80";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // resetOlax
            // 
            this.resetOlax.Location = new System.Drawing.Point(14, 25);
            this.resetOlax.Name = "resetOlax";
            this.resetOlax.Size = new System.Drawing.Size(170, 80);
            this.resetOlax.TabIndex = 0;
            this.resetOlax.Text = "resetOlax";
            this.resetOlax.UseVisualStyleBackColor = true;
            this.resetOlax.Click += new System.EventHandler(this.resetOlax_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(535, 393);
            this.tabPage2.TabIndex = 4;
            this.tabPage2.Text = "Reset network";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.statusreset);
            this.groupBox1.Controls.Add(this.namenetwork);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(48, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(320, 272);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // statusreset
            // 
            this.statusreset.BackColor = System.Drawing.Color.PeachPuff;
            this.statusreset.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusreset.Location = new System.Drawing.Point(6, 143);
            this.statusreset.Multiline = true;
            this.statusreset.Name = "statusreset";
            this.statusreset.Size = new System.Drawing.Size(308, 34);
            this.statusreset.TabIndex = 12;
            this.statusreset.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // namenetwork
            // 
            this.namenetwork.FormattingEnabled = true;
            this.namenetwork.Location = new System.Drawing.Point(85, 34);
            this.namenetwork.Name = "namenetwork";
            this.namenetwork.Size = new System.Drawing.Size(136, 24);
            this.namenetwork.TabIndex = 11;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(227, 31);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(87, 29);
            this.button3.TabIndex = 3;
            this.button3.Text = "get List";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 77);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(308, 60);
            this.button2.TabIndex = 0;
            this.button2.Text = "Restart network";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-27, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tên Card mạng";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.button1);
            this.tabPage4.Controls.Add(this.label4);
            this.tabPage4.Controls.Add(this.lblmyaddress);
            this.tabPage4.Controls.Add(this.label2);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(535, 393);
            this.tabPage4.TabIndex = 5;
            this.tabPage4.Text = "About";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(24, 177);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(326, 45);
            this.button1.TabIndex = 4;
            this.button1.Text = "Copy My Address";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Donate";
            // 
            // lblmyaddress
            // 
            this.lblmyaddress.AutoSize = true;
            this.lblmyaddress.Location = new System.Drawing.Point(21, 148);
            this.lblmyaddress.Name = "lblmyaddress";
            this.lblmyaddress.Size = new System.Drawing.Size(349, 17);
            this.lblmyaddress.TabIndex = 1;
            this.lblmyaddress.Text = "0x85E4c76cCF1C88BdFc4093b67A95A6EFD4824a8B";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Facebook @annhandt09";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // dataGet
            // 
            this.dataGet.Location = new System.Drawing.Point(579, 109);
            this.dataGet.Multiline = true;
            this.dataGet.Name = "dataGet";
            this.dataGet.Size = new System.Drawing.Size(270, 325);
            this.dataGet.TabIndex = 3;
            // 
            // resultCheckIP
            // 
            this.resultCheckIP.BackColor = System.Drawing.Color.PeachPuff;
            this.resultCheckIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resultCheckIP.Location = new System.Drawing.Point(769, 12);
            this.resultCheckIP.Multiline = true;
            this.resultCheckIP.Name = "resultCheckIP";
            this.resultCheckIP.Size = new System.Drawing.Size(80, 80);
            this.resultCheckIP.TabIndex = 2;
            this.resultCheckIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // getIp
            // 
            this.getIp.Location = new System.Drawing.Point(579, 12);
            this.getIp.Name = "getIp";
            this.getIp.Size = new System.Drawing.Size(170, 80);
            this.getIp.TabIndex = 1;
            this.getIp.Text = "GET IP";
            this.getIp.UseVisualStyleBackColor = true;
            this.getIp.Click += new System.EventHandler(this.getIp_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(201, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(242, 17);
            this.label3.TabIndex = 13;
            this.label3.Text = "Đối Với E3372 Airtel các bác nên mở ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(201, 177);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(236, 17);
            this.label5.TabIndex = 14;
            this.label5.Text = "1 tab để truy cập vào web của dcom";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(201, 206);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(209, 17);
            this.label6.TabIndex = 15;
            this.label6.Text = "nếu change ip không hoạt động";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 462);
            this.Controls.Add(this.Other);
            this.Controls.Add(this.resultCheckIP);
            this.Controls.Add(this.dataGet);
            this.Controls.Add(this.getIp);
            this.Name = "Form1";
            this.Text = "Change IP";
            this.Other.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl Other;
        private System.Windows.Forms.Button getIp;
        private System.Windows.Forms.Button resetOlax;
        private System.Windows.Forms.TextBox dataGet;
        private System.Windows.Forms.TextBox resultCheckIP;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button ChangeNetwork;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox myLocalIP;
        private System.Windows.Forms.Label lblmyaddress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ComboBox namenetwork;
        private System.Windows.Forms.TextBox statusreset;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
    }
}

