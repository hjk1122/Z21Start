using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//本段代码中需要新增加的命名空间
using System.Net.Sockets;
using System.Net;
using System.Runtime.Remoting.Channels;
using System.Threading;

namespace Z21Start
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        struct sendStr
        {
            public string str1;
            public string str2;
        }

        /// <summary>
        /// 用于UDP发送的网络服务类
        /// </summary>
        private UdpClient udpcSend;

        /// <summary>
        /// 用于UDP接收的网络服务类
        /// </summary>
        private UdpClient udpcRecv;

        /// <summary>
        /// 按钮：发送数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSend_Click(object sender, EventArgs e)
        {
            //if (string.IsNullOrWhiteSpace(txtSendMsg.Text))
            //{
            //    MessageBox.Show("请先输入待发送内容");
            //    return;
            //}

            // 匿名发送
            //udpcSend = new UdpClient(0);             // 自动分配本地IPv4地址
            // 实名发送
            try
            {
                IPEndPoint localIpep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 6267); // 本机IP，指定的端口号
                udpcSend = new UdpClient(localIpep);
                string str1 = "0900400053006b88b0";
                string str2 = "0900400053006b80b8";
                //ArrayList str=new ArrayList();
                sendStr sendStr = new sendStr();
                sendStr.str1 = str1;
                sendStr.str2 = str2;
                string[] str = new string[2] {str1, str2};
                Thread thrSend = new Thread(SendMessage1);
                //thrSend.Start(txtSendMsg.Text);
                thrSend.Start(sendStr);
                //Thread thread1=new Thread(SendMessage);
                //thrSend.Start(str2);
                MessageBox.Show("发送成功", "信息");
            }
            catch (Exception e1)
            {
                MessageBox.Show(this, e1.Message, "错误");
            }
        }

        /// <summary>
        /// 发送信息
        /// </summary>
        /// <param name="obj"></param>
        private void SendMessage(object obj)
        {
            string message = (string) obj;
            byte[] sendbytes = Encoding.Unicode.GetBytes(message);
            IPEndPoint remoteIpep = new IPEndPoint(IPAddress.Parse("192.168.0.111"), 21105); // 发送到的IP地址和端口号
            udpcSend.Send(sendbytes, sendbytes.Length, remoteIpep);
            udpcSend.Close();
            //ResetTextBox(txtSendMsg);
        }

        private void SendMessage1(object obj)
        {
            try
            {
                sendStr sendStr1 = (sendStr) obj;

                byte[] sendbytes = Encoding.Unicode.GetBytes(sendStr1.str1);
                IPEndPoint remoteIpep = new IPEndPoint(IPAddress.Parse("192.168.18.4"), 21105); // 发送到的IP地址和端口号
                udpcSend.Send(sendbytes, sendbytes.Length, remoteIpep);
                sendbytes = Encoding.Unicode.GetBytes(sendStr1.str2);
                remoteIpep = new IPEndPoint(IPAddress.Parse("192.168.18.4"), 21105); // 发送到的IP地址和端口号
                int result = udpcSend.Send(sendbytes, sendbytes.Length, remoteIpep);
                udpcSend.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 开关：在监听UDP报文阶段为true，否则为false
        /// </summary>
        bool IsUdpcRecvStart = false;

        /// <summary>
        /// 线程：不断监听UDP报文
        /// </summary>
        Thread thrRecv;

        /// <summary>
        /// 按钮：接收数据开关
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRecv_Click(object sender, EventArgs e)
        {
            if (!IsUdpcRecvStart) // 未监听的情况，开始监听
            {
                IPEndPoint localIpep = new IPEndPoint(IPAddress.Parse("192.168.18.4"), 21105); // 本机IP和监听端口号
                udpcRecv = new UdpClient(localIpep);
                thrRecv = new Thread(ReceiveMessage);
                thrRecv.Start();
                IsUdpcRecvStart = true;
                ShowMessage(txtRecvMsg, "UDP监听器已成功启动");
            }
            else // 正在监听的情况，终止监听
            {
                thrRecv.Abort(); // 必须先关闭这个线程，否则会异常
                udpcRecv.Close();
                IsUdpcRecvStart = false;
                ShowMessage(txtRecvMsg, "UDP监听器已成功关闭");
            }
        }

        /// <summary>
        /// 接收数据
        /// </summary>
        /// <param name="obj"></param>
        private void ReceiveMessage(object obj)
        {
            IPEndPoint remoteIpep = new IPEndPoint(IPAddress.Any, 0);
            while (true)
            {
                try
                {
                    byte[] bytRecv = udpcRecv.Receive(ref remoteIpep);
                    string message = Encoding.Unicode.GetString(bytRecv, 0, bytRecv.Length);
                    ShowMessage(txtRecvMsg, string.Format("{0}[{1}]", remoteIpep, message));
                }
                catch (Exception ex)
                {
                    ShowMessage(txtRecvMsg, ex.Message);
                    break;
                }
            }
        }

        // 向RichTextBox中添加文本
        delegate void ShowMessageDelegate(TextBox txtbox, string message);

        private void ShowMessage(TextBox txtbox, string message)
        {
            if (txtbox.InvokeRequired)
            {
                ShowMessageDelegate showMessageDelegate = ShowMessage;
                txtbox.Invoke(showMessageDelegate, new object[] {txtbox, message});
            }
            else
            {
                txtbox.Text += message + "\r\n";
            }
        }

        // 清空指定RichTextBox中的文本
        delegate void ResetTextBoxDelegate(TextBox txtbox);

        private void ResetTextBox(TextBox txtbox)
        {
            if (txtbox.InvokeRequired)
            {
                ResetTextBoxDelegate resetTextBoxDelegate = ResetTextBox;
                txtbox.Invoke(resetTextBoxDelegate, new object[] {txtbox});
            }
            else
            {
                txtbox.Text = "";
            }
        }

        /// <summary>
        /// 关闭程序，强制退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
        }
    }
}