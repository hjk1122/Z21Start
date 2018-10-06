namespace Z21Start
{
    partial class FrmMain
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
            this.btnRecv = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSendMsg = new System.Windows.Forms.RichTextBox();
            this.txtRecvMsg = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtLocalPort = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLocalIP = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtRemotePort = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRemoteIP = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRecv
            // 
            this.btnRecv.Location = new System.Drawing.Point(23, 421);
            this.btnRecv.Margin = new System.Windows.Forms.Padding(2);
            this.btnRecv.Name = "btnRecv";
            this.btnRecv.Size = new System.Drawing.Size(70, 31);
            this.btnRecv.TabIndex = 10;
            this.btnRecv.Text = "接收/停止";
            this.btnRecv.UseVisualStyleBackColor = true;
            this.btnRecv.Click += new System.EventHandler(this.btnRecv_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 123);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "接收信息：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 111);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "发送信息：";
            // 
            // txtSendMsg
            // 
            this.txtSendMsg.Location = new System.Drawing.Point(19, 136);
            this.txtSendMsg.Name = "txtSendMsg";
            this.txtSendMsg.Size = new System.Drawing.Size(331, 262);
            this.txtSendMsg.TabIndex = 12;
            this.txtSendMsg.Text = "";
            // 
            // txtRecvMsg
            // 
            this.txtRecvMsg.Location = new System.Drawing.Point(43, 148);
            this.txtRecvMsg.Name = "txtRecvMsg";
            this.txtRecvMsg.Size = new System.Drawing.Size(331, 262);
            this.txtRecvMsg.TabIndex = 13;
            this.txtRecvMsg.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtLocalPort);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtLocalIP);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtRecvMsg);
            this.groupBox1.Controls.Add(this.btnRecv);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(417, 475);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "接收端";
            // 
            // txtLocalPort
            // 
            this.txtLocalPort.Location = new System.Drawing.Point(111, 84);
            this.txtLocalPort.Name = "txtLocalPort";
            this.txtLocalPort.Size = new System.Drawing.Size(256, 21);
            this.txtLocalPort.TabIndex = 16;
            this.txtLocalPort.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(59, 87);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 12);
            this.label4.TabIndex = 15;
            this.label4.Text = "端口号:";
            // 
            // txtLocalIP
            // 
            this.txtLocalIP.Location = new System.Drawing.Point(111, 33);
            this.txtLocalIP.Name = "txtLocalIP";
            this.txtLocalIP.Size = new System.Drawing.Size(256, 21);
            this.txtLocalIP.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 39);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 12);
            this.label3.TabIndex = 13;
            this.label3.Text = "上级系统IP地址:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtRemotePort);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtRemoteIP);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtSendMsg);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox2.Location = new System.Drawing.Point(435, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(379, 462);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "发送端";
            // 
            // txtRemotePort
            // 
            this.txtRemotePort.Location = new System.Drawing.Point(81, 75);
            this.txtRemotePort.Name = "txtRemotePort";
            this.txtRemotePort.Size = new System.Drawing.Size(256, 21);
            this.txtRemotePort.TabIndex = 20;
            this.txtRemotePort.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 78);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 12);
            this.label5.TabIndex = 19;
            this.label5.Text = "端口号:";
            // 
            // txtRemoteIP
            // 
            this.txtRemoteIP.Location = new System.Drawing.Point(81, 27);
            this.txtRemoteIP.Name = "txtRemoteIP";
            this.txtRemoteIP.Size = new System.Drawing.Size(256, 21);
            this.txtRemoteIP.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 30);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 12);
            this.label6.TabIndex = 17;
            this.label6.Text = "远端IP地址:";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 502);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmMain";
            this.Text = "管理系统";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnRecv;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox txtSendMsg;
        private System.Windows.Forms.RichTextBox txtRecvMsg;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtLocalPort;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtLocalIP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRemotePort;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtRemoteIP;
        private System.Windows.Forms.Label label6;
    }
}