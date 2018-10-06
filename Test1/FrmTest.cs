using System;
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
using System.Threading;
using Test1.sysInfo;
using Test1.tools;

namespace Test1
{
    public partial class FrmTest : Form
    {
        private string localIP = "";
        private int localPort = 0;
        private string remoteIP = "";
        private int remotePort = 0;
        private  string strHex1 = "";
        public  string StrHex
        {
            get { return strHex1; }
            set { strHex1 = value; }
        }
        public FrmTest()
        {
            InitializeComponent();
            this.txtLocalIP.Text = GetInfo.GetAppConfig("localIP");
            this.txtLocalPort.Text = GetInfo.GetAppConfig("localPort");
            this.txtRemoteIP.Text = GetInfo.GetAppConfig("remoteIP");
            this.txtRemotePort.Text = GetInfo.GetAppConfig("remotePort");
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
            try
            {
                localIP = this.txtLocalIP.Text.Trim();
                localPort = int.Parse(this.txtLocalPort.Text);

                if (string.IsNullOrWhiteSpace(txtSendMsg.Text))
                {
                    MessageBox.Show("请先输入待发送内容");
                    return;
                }

                // 匿名发送
                //udpcSend = new UdpClient(0);             // 自动分配本地IPv4地址
                // 实名发送
                //IPEndPoint localIpep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 12345); // 本机IP，指定的端口号
                IPEndPoint localIpep = new IPEndPoint(IPAddress.Parse(localIP), localPort); // 本机IP，指定的端口号
                udpcSend = new UdpClient(localIpep);
                Thread thrSend = new Thread(SendMessage);
                thrSend.Start(txtSendMsg.Text);
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, "错误");
            }
        }

        /// <summary>
        /// 发送信息
        /// </summary>
        /// <param name="obj"></param>
        private void SendMessage(object obj)
        {
            try
            {
                remoteIP = this.txtRemoteIP.Text.Trim();
                remotePort = int.Parse(this.txtRemotePort.Text);
                //转换为16进制
                string message = (string) obj;
                //byte[] sendbytes = Encoding.UTF8.GetBytes(message);
                //16进制字符串转换为8位字节数组
                byte[] sendbytes = Tool.strToHexByte(message);
                //IPEndPoint remoteIpep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8848); // 发送到的IP地址和端口号
                IPEndPoint remoteIpep = new IPEndPoint(IPAddress.Parse(remoteIP), remotePort); // 发送到的IP地址和端口号
                udpcSend.Send(sendbytes, sendbytes.Length, remoteIpep);
                udpcSend.Close();
                ResetTextBox(txtSendMsg);
            }
            catch (Exception e1)
            {
                throw e1;
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


        // 向RichTextBox中添加文本
        delegate void ShowMessageDelegate(RichTextBox txtbox, string message);

        private void ShowMessage(RichTextBox txtbox, string message)
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
        delegate void ResetTextBoxDelegate(RichTextBox txtbox);

        private void ResetTextBox(RichTextBox txtbox)
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
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

    }
}