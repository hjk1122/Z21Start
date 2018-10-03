namespace Z21Start
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.txtSendMsg = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRecvMsg = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRecv = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtSendMsg
            // 
            this.txtSendMsg.Location = new System.Drawing.Point(127, 36);
            this.txtSendMsg.Name = "txtSendMsg";
            this.txtSendMsg.Size = new System.Drawing.Size(158, 25);
            this.txtSendMsg.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "发送信息：";
            // 
            // txtRecvMsg
            // 
            this.txtRecvMsg.Location = new System.Drawing.Point(127, 164);
            this.txtRecvMsg.Name = "txtRecvMsg";
            this.txtRecvMsg.Size = new System.Drawing.Size(157, 25);
            this.txtRecvMsg.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 167);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "接收信息：";
            // 
            // btnRecv
            // 
            this.btnRecv.Location = new System.Drawing.Point(347, 164);
            this.btnRecv.Name = "btnRecv";
            this.btnRecv.Size = new System.Drawing.Size(75, 23);
            this.btnRecv.TabIndex = 4;
            this.btnRecv.Text = "接收";
            this.btnRecv.UseVisualStyleBackColor = true;
            this.btnRecv.Click += new System.EventHandler(this.btnRecv_Click);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(347, 39);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 5;
            this.btnSend.Text = "发送";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 255);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.btnRecv);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtRecvMsg);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSendMsg);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSendMsg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRecvMsg;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRecv;
        private System.Windows.Forms.Button btnSend;
    }
}

